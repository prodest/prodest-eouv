using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prodest.EOuv.UI.Apresentacao
{
    public partial class RespostaManifestacaoEntry
    {
        public int IdManifestacao { get; set; }
        public string TextoResposta { get; set; }
        public int IdResultadoResposta { get; set; }
        public int IdOrgaoCompetenciaFato { get; set; }
        public string[] Anexos { get; set; }
    }
}