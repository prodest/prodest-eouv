using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ProcessoEncerrarRequestModel
    {
        public string IdProcesso { get; set; }
        public string IdPapelResponsavel { get; set; }
        public string Desfecho { get; set; }
        public RestricaoAcessoModel RestricaoAcesso { get; set; }
    }
}