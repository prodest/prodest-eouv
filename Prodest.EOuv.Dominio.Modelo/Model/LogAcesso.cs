using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class LogAcesso
    {
        public int IdLogAcesso { get; set; }
        public int IdUsuario { get; set; }
        public int? IdOrgao { get; set; }
        public DateTime DataAcesso { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}