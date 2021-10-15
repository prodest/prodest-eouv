using Prodest.EOuv.Dominio.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class PdfApiBLL : IPdfApiBLL
    {
        private readonly IPdfApiService _pdfApiService;

        public PdfApiBLL(IPdfApiService pdfApiService)
        {
            _pdfApiService = pdfApiService;
        }

        public async Task<byte[]> ConcatenarPdfs(List<byte[]> listaDocumentos)
        {
            return await _pdfApiService.ConcatenarPdfs(listaDocumentos);
        }

        public async Task<byte[]> GerarPdfByHtml(string html)
        {
            return await _pdfApiService.GerarPdfByHtml(html);
        }
    }
}