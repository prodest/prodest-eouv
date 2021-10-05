using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class AssinaturaDigitalValidaModel
    {
        public string IdentificadorTemporarioArquivoNaNuvem { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
