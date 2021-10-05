using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class TipoItemInterfaceModel
    {
        public TipoItemInterfaceModel()
        {
            ItemInterface = new HashSet<ItemInterfaceModel>();
        }

        public int IdTipoItemInterface { get; set; }
        public string DescTipoItemInterface { get; set; }

        public virtual ICollection<ItemInterfaceModel> ItemInterface { get; set; }
    }
}