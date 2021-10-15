using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IPdfApiService
    {
        Task<byte[]> ConcatenarPdfs(List<byte[]> listaDocumentos);

        Task<byte[]> GerarPdfByHtml(string html);
    }
}