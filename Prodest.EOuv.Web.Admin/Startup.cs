using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prodest.EOuv.Shared.Configuracao;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Prodest.EOuv.Infra.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Audit.EntityFramework.Providers;
using Audit.Core;
using System.Linq;
using Elastic.Apm.NetCoreAll;

namespace Prodest.EOuv.Web.Admin
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region[=== DataProtectionKeys ===]
            services.AddDbContext<DataProtectionKeysContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataProtectionKeysConnection")));
            services.AddDataProtection().SetApplicationName("EOuv")
                                        .PersistKeysToDbContext<DataProtectionKeysContext>();
            #endregion

            #region[=== Auditoria (Audit.NET) ===]
            services.AddDbContext<AuditLogContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var provider = services.BuildServiceProvider();
            var _httpContextAccessor = provider.GetService<IHttpContextAccessor>();

            Audit.Core.Configuration.DataProvider = new EntityFrameworkDataProvider();
            Audit.Core.Configuration.Setup().UseEntityFramework(ef => ef
                .UseDbContext(ev => provider.GetService<AuditLogContext>())
                .AuditTypeMapper(t => typeof(AuditLog))
                .AuditEntityAction<AuditLog>((auditEvent, entry, entity) =>
                {
                    if (entry.Action == "Update")
                    {
                        if (entry.Changes == null)
                        {
                            return false;
                        }
                        else
                        {
                            entry.Changes.Where(x => Equals(x.NewValue, x.OriginalValue)).ToList().ForEach(item => entry.Changes.Remove(item));

                            if (entry.Changes.Count == 0)
                            {
                                return false;
                            }
                        }
                    }

                    entity.AuditDate = DateTime.Now;
                    entity.AuditUserName = _httpContextAccessor.HttpContext.User.FindFirst("nome")?.Value;
                    entity.AuditUserCpf = _httpContextAccessor.HttpContext.User.FindFirst("cpf")?.Value;
                    entity.Origin = _httpContextAccessor.HttpContext.Request.GetTypedHeaders().Referer.AbsoluteUri.Split("//").Last();
                    //var urlAcessada = _httpContextAccessor.HttpContext.Request.GetTypedHeaders().Referer;
                    //if (urlAcessada is null)
                    //{
                    //    entity.Origin = _httpContextAccessor.HttpContext.Request.Path.Value;
                    //}
                    //else
                    //{
                    //    entity.Origin = _httpContextAccessor.HttpContext.Request.GetTypedHeaders().Referer.AbsoluteUri.Split("//").Last();
                    //}
                    entity.EntityType = entry.EntityType.Name;
                    entity.Action = entry.Action;
                    entity.TablePk = entry.PrimaryKey.First().Value.ToString();
                    entity.AuditData = entry.ToJson();

                    return true;
                })
                .IgnoreMatchedProperties(true)
            );
            #endregion

            #region[=== Log de Erros (ELMAH) ===]
            services.AddElmah<SqlErrorLog>(options =>
            {
                //options.ApplicationName = "E-Flow";
                options.ConnectionString = Configuration.GetConnectionString("ElmahConnection");
                //options.OnPermissionCheck = context => false;
            });
            #endregion

            services.AddControllersWithViews();
            services.AddSingleton(Configuration);
            services.AddDbContext<EouvContext>();
            services.InjetarDependencias();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddHealthChecks();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            //Configuração do ASP.NET Core para trabalhar com servidores proxy e balanceadores de carga
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.RequireHeaderSymmetry = false;
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            #region[=== Acesso Cidadão ===]
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie(options =>
                {
                    options.Cookie.Name = "prodest-eouv-admin";
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(06);
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = Configuration.GetValue<string>("AcessoCidadao:Authority");
                    options.ClientSecret = Configuration.GetValue<string>("AcessoCidadao:Hybrid:ClientSecret");
                    options.ClientId = Configuration.GetValue<string>("AcessoCidadao:Hybrid:ClientId");
                    options.SignedOutRedirectUri = Configuration.GetValue<string>("AcessoCidadao:Hybrid:SignedOutRedirectUri");
                    options.ResponseType = Configuration.GetValue<string>("AcessoCidadao:Hybrid:ResponseType");
                    //options.CallbackPath = "/";
                    options.Scope.Clear();

                    foreach (var scope in Configuration.GetValue<string>("AcessoCidadao:Hybrid:Scopes").Split(' '))
                    {
                        options.Scope.Add(scope);
                    }

                    options.ClaimActions.MapAll();
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,
                    };
                });
            #endregion

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            app.UseAllElasticApm(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseElmah();

            app.UseHealthChecks("/health/live");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}