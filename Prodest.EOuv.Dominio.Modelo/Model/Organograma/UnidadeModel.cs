using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{
    public class UnidadeModel
    {
        public string guid { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public string nomeCurto { get; set; }
        public TipoUnidadeModel tipoUnidade { get; set; }
        public OrganizacaoModel organizacao { get; set; }
        public UnidadePaiModel unidadePai { get; set; }
        public EnderecoModel endereco { get; set; }
        public ContatoModel[] contatos { get; set; }
        public EmailModel[] emails { get; set; }
        public SiteModel[] sites { get; set; }
    }
}
