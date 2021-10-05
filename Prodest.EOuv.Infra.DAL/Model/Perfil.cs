using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Perfil
    {
        public Perfil()
        {
            ItemInterfacePerfil = new HashSet<ItemInterfacePerfil>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPerfil { get; set; }
        public string DescPerfil { get; set; }

        public virtual ICollection<ItemInterfacePerfil> ItemInterfacePerfil { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}