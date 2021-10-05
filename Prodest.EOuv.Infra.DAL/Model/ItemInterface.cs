using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ItemInterface
    {
        public ItemInterface()
        {
            InverseIdItemInterfaceIcone = new HashSet<ItemInterface>();
            InverseIdItemInterfacePai = new HashSet<ItemInterface>();
            ItemInterfacePerfil = new HashSet<ItemInterfacePerfil>();
        }

        public int IdItemInterface { get; set; }
        public string DescItemInterface { get; set; }
        public int IdTipoItemInterface { get; set; }
        public string DescAcao { get; set; }
        public int? IdItemInterfacePai { get; set; }
        public short? NumOrdem { get; set; }
        public string TxtDescritivo { get; set; }
        public int? IdItemInterfaceIcone { get; set; }

        public virtual ItemInterface ItemInterfaceIcone { get; set; }
        public virtual ItemInterface ItemInterfacePai { get; set; }
        public virtual TipoItemInterface TipoItemInterface { get; set; }
        public virtual ICollection<ItemInterface> InverseIdItemInterfaceIcone { get; set; }
        public virtual ICollection<ItemInterface> InverseIdItemInterfacePai { get; set; }
        public virtual ICollection<ItemInterfacePerfil> ItemInterfacePerfil { get; set; }
    }
}