using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils.Exceptions;

namespace Prodest.EOuv.Infra.Service
{
    public class HtmlApiService : IHtmlApiService
    {
        private readonly string _baseUrl = "https://localhost:44351";
        private readonly IApiContext _apiContext;

        public HtmlApiService(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<string> GerarHtml(object obj)
        {
            try
            {
                Teste obj2 = new Teste { Codigo = 4, Descricao = "Teste 4" };
                //var Json = JsonSerializer.Serialize(obj);
                var Json = JsonConvert.SerializeObject(obj);

                var content = new StringContent(Json, Encoding.UTF8, "application/json");

                var result = await _apiContext.PostAsync($"{_baseUrl}/Render/ResumoManifestacao", content);

                if (result.IsSuccessStatusCode)
                {
                    string retorno = await result.Content.ReadAsStringAsync();
                    return retorno;
                }
                else
                {
                    return default(string);
                }
            }
            catch (Exception ex)
            {
                var teste = ex;
            }

            return "";
        }

        public class Teste
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; }
        }
    }
}