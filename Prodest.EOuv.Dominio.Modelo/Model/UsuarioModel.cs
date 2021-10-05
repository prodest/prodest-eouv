using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public int IdPessoa { get; set; }
        public int? IdOrgao { get; set; }
        public string Login { get; set; }
        public DateTime DatCadastro { get; set; }
        public bool IndUsuarioServidor { get; set; }
        public bool IndUsuarioSistema { get; set; }

        public virtual OrgaoModel Orgao { get; set; }
        public virtual PerfilModel Perfil { get; set; }
        public virtual PessoaModel Pessoa { get; set; }
    }
}