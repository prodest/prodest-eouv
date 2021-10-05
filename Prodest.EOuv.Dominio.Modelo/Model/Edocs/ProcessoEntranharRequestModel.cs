using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public partial class ProcessoEntranharRequestModel
    {
        public string IdProcesso { get; set; }
        public string IdPapelResponsavel { get; set; }
        public string Justificativa { get; set; }
        public string[] IdsDocumentosEntranhados { get; set; }
        public string IdEncaminhamento { get; set; }
        public RestricaoAcessoModel RestricaoAcesso { get; set; }
    }
}
