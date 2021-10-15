using Prodest.EOuv.Dominio.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class HtmlApiBLL : IHtmlApiBLL
    {
        private readonly IHtmlApiService _htmlApiService;

        public HtmlApiBLL(IHtmlApiService htmlApiService)
        {
            _htmlApiService = htmlApiService;
        }

        public async Task<string> GerarHtml(object obj)
        {
            return await _htmlApiService.GerarHtml(obj);
        }
    }
}