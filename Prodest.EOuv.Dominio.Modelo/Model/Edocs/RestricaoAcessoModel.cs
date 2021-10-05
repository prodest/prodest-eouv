using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class RestricaoAcessoModel
    {
        public bool TransparenciaAtiva { get; set; }
        public bool SigilosoSemFundamentoLegalApi { get; set; }
        public Guid[] IdsFundamentosLegais { get; set; }
        public ClassificacaoInformacaoModel ClassificacaoInformacao { get; set; }
    }
}
