using Audit.Core;
using Audit.EntityFramework.Providers;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prodest.EOuv.Infra.DAL;
using Prodest.EOuv.Shared.Configuracao;
using System;
using System.Linq;

namespace Prodest.EOuv.Background.Jobs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                    entity.AuditUserName = _httpContextAccessor.HttpContext?.User?.FindFirst("nome")?.Value ?? "Background.Jobs";
                    entity.AuditUserCpf = _httpContextAccessor.HttpContext?.User?.FindFirst("cpf")?.Value ?? "Background.Jobs";
                    entity.Origin = "Background.Jobs";
                    entity.EntityType = entry.EntityType.Name;
                    entity.Action = entry.Action;
                    entity.TablePk = entry.PrimaryKey.First().Value.ToString();
                    entity.AuditData = entry.ToJson();

                    return true;
                })
                .IgnoreMatchedProperties(true)
            );
            #endregion

            services.AddControllersWithViews();
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<EouvContext>();
            services.InjetarDependencias();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddScoped<IHangfireService, HangfireService>();

            // Add Hangfire services
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer(options =>
            {
                options.Queues = new[] { "Edocs", "default" };
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs, IWebHostEnvironment env)
        {
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

            JobsHangfire();
        }

        private static void JobsHangfire()
        {
            RecurringJob.AddOrUpdate<IHangfireService>("BuscaRespostaDespachosAbertos", bj => bj.BuscaRespostaDespachosAbertos(), "* 1 * * *");
        }
    }
}