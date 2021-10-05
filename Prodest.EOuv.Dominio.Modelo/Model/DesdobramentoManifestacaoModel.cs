using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class DesdobramentoManifestacaoModel
    {
        public int IdDesdobramentoManifestacao { get; set; }
        public int IdManifestacaoPai { get; set; }
        public int IdManifestacaoFilha { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataDesdobramento { get; set; }

        public virtual ManifestacaoModel ManifestacaoFilha { get; set; }
        public virtual ManifestacaoModel ManifestacaoPai { get; set; }
        public virtual OrgaoModel Orgao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}