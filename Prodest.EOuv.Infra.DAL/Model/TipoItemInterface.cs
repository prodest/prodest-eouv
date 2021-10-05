using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class TipoItemInterface
    {
        public TipoItemInterface()
        {
            ItemInterface = new HashSet<ItemInterface>();
        }

        public int IdTipoItemInterface { get; set; }
        public string DescTipoItemInterface { get; set; }

        public virtual ICollection<ItemInterface> ItemInterface { get; set; }
    }
}