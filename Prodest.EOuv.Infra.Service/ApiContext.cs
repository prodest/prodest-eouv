using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra
{
    public class ApiContext : IApiContext
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _clientCredentialsToken;

        public ApiContext(
            ILogger<ApiContext> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        // =========================
        // public methods
        // =========================

        public async Task<(bool isSuccess, T data, string errorMessage)> GetRequest<T>(string url, Enums.AuthenticationType authenticationType) where T : class
        {
            var httpClient = await GetHttpClientAsync(authenticationType);

            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            T output = null;
            string errorMessage = null;
            if (response.IsSuccessStatusCode)
            {
                output = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
            }
            else
            {
                var suffix = $"{response.StatusCode}";
                suffix += response.StatusCode.ToString() != response.ReasonPhrase
                    ? $" :: {response.ReasonPhrase}"
                    : "";
                suffix += !string.IsNullOrWhiteSpace(response.Headers.WwwAuthenticate.ToString()) && response.Headers.WwwAuthenticate.ToString().Contains("error")
                    ? $" :: {response.Headers.WwwAuthenticate}"
                    : "";

                errorMessage = !string.IsNullOrWhiteSpace(json) ? $"{json} ({suffix})" : suffix;
            }

            return (response.IsSuccessStatusCode, output, errorMessage);
        }

        public async Task<(bool isSuccess, T data, string errorMessage)> PostRequest<T>(
            string url,
            Enums.AuthenticationType authenticationType,
            object body = null,
            HttpContent httpContent = null,
            bool? ignoreResponseData = false
        ) where T : class
        {
            var httpClient = await GetHttpClientAsync(authenticationType);

            if (body != null && httpContent == null)
            {
                httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            }

            var response = await httpClient.PostAsync(url, httpContent);
            var json = await response.Content.ReadAsStringAsync();

            T output = null;
            string errorMessage = null;
            if (response.IsSuccessStatusCode)
            {
                if (!ignoreResponseData.Value)
                {
                    output = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
                }
            }
            else
            {
                var suffix = $"{response.StatusCode}";
                suffix += response.StatusCode.ToString() != response.ReasonPhrase
                    ? $" :: {response.ReasonPhrase}"
                    : "";
                suffix += !string.IsNullOrWhiteSpace(response.Headers.WwwAuthenticate.ToString()) && response.Headers.WwwAuthenticate.ToString().Contains("error")
                    ? $" :: {response.Headers.WwwAuthenticate}"
                    : "";

                errorMessage = !string.IsNullOrWhiteSpace(json) ? $"{json} ({suffix})" : suffix;
            }

            return (response.IsSuccessStatusCode, output, errorMessage);
        }

        public async Task<(bool isSuccess, Stream data, string errorMessage)> PdfPostRequest(string url, object body)
        {
            var proxy = new WebProxy { BypassProxyOnLocal = true };
            var clientHandler = new HttpClientHandler { Proxy = proxy };
            clientHandler.ServerCertificateCustomValidationCallback = (r, c, ch, e) => true;
            var httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, httpContent);

            Stream output = null;
            string errorMessage = null;
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsStreamAsync();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();

                var suffix = $"{response.StatusCode}";
                suffix += response.StatusCode.ToString() != response.ReasonPhrase
                    ? $" :: {response.ReasonPhrase}"
                    : "";
                suffix += !string.IsNullOrWhiteSpace(response.Headers.WwwAuthenticate.ToString()) && response.Headers.WwwAuthenticate.ToString().Contains("error")
                    ? $" :: {response.Headers.WwwAuthenticate}"
                    : "";

                errorMessage = !string.IsNullOrWhiteSpace(error) ? $"{error} ({suffix})" : suffix;
            }

            return (response.IsSuccessStatusCode, output, errorMessage);
        }

        public async Task<ApiResponse<T>> PostAndDownloadAsync<T>(string url, HttpContent content)
        {
            var httpClient = _httpClientFactory.CreateClient("multipart/form-data");
            httpClient.Timeout = TimeSpan.FromSeconds(1200);

            var result = await httpClient.PostAsync(url, content);
            ApiResponse<T> apiResponse;

            string responseContent = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(responseContent))
                apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
            else
            {
                var apiResponseDeserialize = JsonConvert.DeserializeObject<ApiResponse<object>>(responseContent);
                if (apiResponseDeserialize != null)
                    apiResponse = new ApiResponse<T>(apiResponseDeserialize);
                else
                    throw new Exception($"{result.StatusCode}-{responseContent}");
            }

            return apiResponse;
        }

        // =========================
        // private methods
        // =========================

        private async Task<HttpClient> GetHttpClientAsync(Enums.AuthenticationType authenticationType)
        {
            var httpClient = _httpClientFactory.CreateClient();

            if (authenticationType == Enums.AuthenticationType.User)
            {
                if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    #region[para testes]
                    //                    if (_configuration.GetValue<string>("Ambiente_DES_HOM_PRD_TRE").ToUpper() == "DES") _logger.LogInformation(accessToken);
                    #endregion
                }
                else
                {
                    throw new ApiUnauthorizedException();
                }
            }
            else if (authenticationType == Enums.AuthenticationType.Application)
            {
                if (_clientCredentialsToken == null || _clientCredentialsToken == "")
                {
                    await GenerateClientCredentialsToken();
                }
                else
                {
                    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(_clientCredentialsToken);
                    if (jwt.ValidTo <= DateTime.Now)
                    {
                        await GenerateClientCredentialsToken();
                    }
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _clientCredentialsToken);
            }

            return httpClient;
        }

        private async Task<string> GenerateClientCredentialsToken()
        {
            var requestBody = new Dictionary<string, string>
            {
                { "client_id", _configuration.GetSection("AcessoCidadao:ClientCredentials:ClientId").Value },
                { "client_secret", _configuration.GetSection("AcessoCidadao:ClientCredentials:ClientSecret").Value },
                { "grant_type", "client_credentials" },
                { "scope", _configuration.GetSection("AcessoCidadao:ClientCredentials:Scopes").Value }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_configuration.GetSection("AcessoCidadao:Authority").Value}/connect/token")
            {
                Content = new FormUrlEncodedContent(requestBody)
            };

            using (var client = _httpClientFactory.CreateClient("default"))
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                    _clientCredentialsToken = responseBody["access_token"].ToString();
                }
                else
                {
                    throw new ApiUnauthorizedException();
                }
            }

            return _clientCredentialsToken;
        }
    }
}