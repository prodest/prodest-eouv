using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prodest.EOuv.UI.Apresentacao
{
    public partial class DespachoManifestacaoEntry
    {
        public int IdManifestacao { get; set; }
        public string PrazoResposta { get; set; }
        public string TextoDespacho { get; set; }
        public string[] Anexos { get; set; }
        public string GuidPapelResponsavel { get; set; }
        public string GuidPapelDestinatario { get; set; }
        public int TipoDestinatario { get; set; }
        public FiltroDadosManifestacaoSelecionadosEntry FiltroDadosManifestacaoSelecionados { get; set; }
    }
}