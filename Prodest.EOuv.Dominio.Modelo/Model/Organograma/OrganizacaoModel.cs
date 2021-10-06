using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{
    public class OrganizacaoModel
    {
        public string guid { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string sigla { get; set; }
        public OrganizacaoModel organizacaoPai { get; set; }
    }
}
