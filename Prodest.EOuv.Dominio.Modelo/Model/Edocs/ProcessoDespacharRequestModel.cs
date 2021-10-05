using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class ProcessoDespacharRequestModel
    {
        public string IdProcesso { get; set; }
        public string IdPapelResponsavel { get; set; }
        public string Mensagem { get; set; }
        public string[] IdsDocumentosEntranhados { get; set; }
        public RestricaoAcessoModel RestricaoAcesso { get; set; }
    }
}
