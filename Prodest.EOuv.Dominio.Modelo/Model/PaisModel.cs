using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class PaisModel
    {
        public PaisModel()
        {
            Uf = new HashSet<UfModel>();
        }

        public int IdPais { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<UfModel> Uf { get; set; }
    }
}