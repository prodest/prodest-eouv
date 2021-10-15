using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class PapelModel
    {
        public string DescricaoTipoDestino { get; set; }
        public long TipoAgente { get; set; }
        public string TipoPapel { get; set; }

        // comuns
        public Guid Id { get; set; }

        public string Nome { get; set; }

        // v2
        public string Tipo { get; set; }

        public string SiglaOrganizacao { get; set; }
        public string SiglaUnidade { get; set; }
        public string NomeOrganizacaoUnidade { get; set; }
        public string SiglaOrganizacaoUnidade { get; set; }
        public string TipoLocalizacaoGrupo { get; set; }
        public string NomeUnidadeGrupo { get; set; }
        public string SiglaUnidadeGrupo { get; set; }
        public string NomeOrganizacaoGrupo { get; set; }
        public string SiglaOrganizacaoGrupo { get; set; }
        public string NomeServidorPapel { get; set; }
        public string TipoLocalizacaoPapel { get; set; }
        public string NomeUnidadePapel { get; set; }
        public string SiglaUnidadePapel { get; set; }
        public string NomeOrganizacaoPapel { get; set; }
        public string SiglaOrganizacaoPapel { get; set; }
    }
}