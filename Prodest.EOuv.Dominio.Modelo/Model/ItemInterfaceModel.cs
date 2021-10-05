using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ItemInterfaceModel
    {
        public ItemInterfaceModel()
        {
            InverseIdItemInterfaceIcone = new HashSet<ItemInterfaceModel>();
            InverseIdItemInterfacePai = new HashSet<ItemInterfaceModel>();
            ItemInterfacePerfil = new HashSet<ItemInterfacePerfilModel>();
        }

        public int IdItemInterface { get; set; }
        public string DescItemInterface { get; set; }
        public int IdTipoItemInterface { get; set; }
        public string DescAcao { get; set; }
        public int? IdItemInterfacePai { get; set; }
        public short? NumOrdem { get; set; }
        public string TxtDescritivo { get; set; }
        public int? IdItemInterfaceIcone { get; set; }

        public virtual ItemInterfaceModel ItemInterfaceIcone { get; set; }
        public virtual ItemInterfaceModel ItemInterfacePai { get; set; }
        public virtual TipoItemInterfaceModel TipoItemInterface { get; set; }
        public virtual ICollection<ItemInterfaceModel> InverseIdItemInterfaceIcone { get; set; }
        public virtual ICollection<ItemInterfaceModel> InverseIdItemInterfacePai { get; set; }
        public virtual ICollection<ItemInterfacePerfilModel> ItemInterfacePerfil { get; set; }
    }
}