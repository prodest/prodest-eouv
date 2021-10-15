using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ProcessoAutuarRequestModel
    {
        public string IdPapelResponsavel { get; set; }
        public string IdLocal { get; set; }
        public string IdClasse { get; set; }
        public string Resumo { get; set; }
        public List<string> IdsAgentesInteressados { get; set; }
        public List<string> IdsDocumentosEntranhados { get; set; }
        public List<PessoaJuridicaInteressadaModel> PessoasJuridicasInteressadas { get; set; }
        public List<InteressadoSemIdentificacaoModel> InteressadosSemIdentificacao { get; set; }
    }
}