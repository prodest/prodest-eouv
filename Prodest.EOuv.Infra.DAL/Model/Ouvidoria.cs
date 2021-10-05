using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Ouvidoria
    {
        public int IdOuvidoria { get; set; }
        public string NomeOuvidoria { get; set; }
        public string EmailOuvidoria { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdOrgaoResponsavel { get; set; }

        public virtual Orgao OrgaoResponsavel { get; set; }
    }
}