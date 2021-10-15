using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IHtmlApiService
    {
        Task<string> GerarHtml(object obj);
    }
}