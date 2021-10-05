#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class ItemInterfacePerfilModel
    {
        public int IdItemInterface { get; set; }
        public int IdPerfil { get; set; }

        public virtual ItemInterfaceModel ItemInterface { get; set; }
        public virtual PerfilModel Perfil { get; set; }
    }
}