using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils.Exceptions;

namespace Prodest.EOuv.Infra.Service
{
    public class PdfApiService : IPdfApiService
    {
        private readonly string _baseUrl;
        private readonly int _cacheExpirationHours;
        private readonly IMemoryCache _memoryCache;
        private readonly IApiContext _apiContext;

        public PdfApiService(
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IApiContext apiContext
        )
        {
            _baseUrl = configuration.GetValue<string>("ApiUrls:Pdf");
            _cacheExpirationHours = configuration.GetValue<int>("CacheExpirationHours:ApiEDocs");
            _memoryCache = memoryCache;
            _apiContext = apiContext;
        }

        // =========================
        // public methods
        // =========================

        public async Task<byte[]> ConcatenarPdfs(List<byte[]> listaDocumentos)
        {
            return await PostRequest<byte[]>($"{_baseUrl}/v2/processos/autuar", listaDocumentos);
        }

        public async Task<byte[]> GerarPdfByHtml(string html)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(html), "html" },
            };

            var result = await _apiContext.PostAndDownloadAsync<byte[]>($"{_baseUrl}/api/TransformaPdf/HtmlPdf", content);

            return result.Data;
        }

        // =========================
        // private methods
        // =========================

        private async Task<T> GetRequest<T>(string url) where T : class
        {
            var (isSuccess, data, errorMessage) = await _apiContext.GetRequest<T>(url, Enums.AuthenticationType.User);

            if (!isSuccess)
            {
                var ex = new EDocsApiException(errorMessage);
                throw ex;
            }

            return data;
        }

        private async Task<T> PostRequest<T>(
            string url,
            object body = null,
            HttpContent httpContent = null,
            bool? ignoreResponseData = false,
            Enums.AuthenticationType? authenticationType = null
        ) where T : class
        {
            var (isSuccess, data, errorMessage) = await _apiContext.PostRequest<T>(
                url,
                authenticationType ?? Enums.AuthenticationType.None,
                body,
                httpContent,
                ignoreResponseData
            );

            if (!isSuccess)
            {
                var ex = new EDocsApiException(errorMessage);
                throw ex;
            }

            return data;
        }
    }
}