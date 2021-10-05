using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Uf
    {
        public Uf()
        {
            Municipio = new HashSet<Municipio>();
        }

        public string SigUf { get; set; }
        public string DescUf { get; set; }
        public int IdPais { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}