using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Municipio
    {
        public Municipio()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int IdMunicipio { get; set; }
        public string DescMunicipio { get; set; }
        public string SigUf { get; set; }
        public int? IdRegional { get; set; }

        public virtual Uf Uf { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}