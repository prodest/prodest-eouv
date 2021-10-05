using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class OuvidoriaModel
    {
        public int IdOuvidoria { get; set; }
        public string NomeOuvidoria { get; set; }
        public string EmailOuvidoria { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdOrgaoResponsavel { get; set; }

        public virtual OrgaoModel OrgaoResponsavel { get; set; }
    }
}