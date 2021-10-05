using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Pais
    {
        public Pais()
        {
            Uf = new HashSet<Uf>();
        }

        public int IdPais { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Uf> Uf { get; set; }
    }
}