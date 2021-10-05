#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ItemInterfacePerfil
    {
        public int IdItemInterface { get; set; }
        public int IdPerfil { get; set; }

        public virtual ItemInterface ItemInterface { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}