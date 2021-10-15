using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prodest.EOuv.UI.Apresentacao
{
    public partial class ListaDadosManifestacaoSelecionadosEntry
    {
        public bool DadosBasicos { get; set; }
        public bool DadosManifestante { get; set; }
        public bool DadosComplemento { get; set; }
        public bool DadosProrrogacao { get; set; }
        public bool DadosDiligencia { get; set; }
        public bool DadosEncaminhamento { get; set; }
        public bool DadosResposta { get; set; }
        public bool DadosApuracao { get; set; }
        public bool DadosDespacho { get; set; }
        public bool DadosNotificacao { get; set; }
        public bool DadosAnotacao { get; set; }
        public bool DadosInterpelacao { get; set; }
        public bool DadosReclamacaoOmissao { get; set; }
        public bool DadosRecursoNegativa { get; set; }
        public bool DadosDesdobramento { get; set; }
        public bool DadosHistorico { get; set; }
    }
}