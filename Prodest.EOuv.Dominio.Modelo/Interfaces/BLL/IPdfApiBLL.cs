using Prodest.EOuv.Dominio.Modelo.Model.Edocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IPdfApiBLL
    {
        Task<byte[]> ConcatenarPdfs(List<byte[]> listaDocumentos);

        Task<byte[]> GerarPdfByHtml(string html);
    }
}