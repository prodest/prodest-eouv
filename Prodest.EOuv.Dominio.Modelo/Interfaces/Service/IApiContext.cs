using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.Service
{
    public interface IApiContext
    {
        Task<(bool isSuccess, T data, string errorMessage)> GetRequest<T>(string url, Enums.AuthenticationType authenticationType) where T : class;
        Task<(bool isSuccess, T data, string errorMessage)> PostRequest<T>(
            string url,
            Enums.AuthenticationType authenticationType,
            object body = null,
            HttpContent httpContent = null,
            bool? ignoreResponseData = false
        ) where T : class;
        Task<(bool isSuccess, Stream data, string errorMessage)> PdfPostRequest(string url, object body);
    }
}
