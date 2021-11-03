using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class PerfilModel
    {
        public PerfilModel()
        {
            ItemInterfacePerfil = new HashSet<ItemInterfacePerfilModel>();
            Usuario = new HashSet<UsuarioModel>();
        }

        public int IdPerfil { get; set; }
        public string DescPerfil { get; set; }

        public virtual ICollection<ItemInterfacePerfilModel> ItemInterfacePerfil { get; set; }
        public virtual ICollection<UsuarioModel> Usuario { get; set; }        
    }
}