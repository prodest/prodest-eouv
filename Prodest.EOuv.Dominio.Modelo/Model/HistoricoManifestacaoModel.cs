using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class HistoricoManifestacaoModel
    {
        public int IdHistoricoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public int? IdOrgao { get; set; }
        public int? IdSetor { get; set; }
        public int IdSituacao { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DataHistorico { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel Orgao { get; set; }

        public virtual SetorModel Setor { get; set; }
        public virtual SituacaoManifestacaoModel SituacaoManifestacao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}