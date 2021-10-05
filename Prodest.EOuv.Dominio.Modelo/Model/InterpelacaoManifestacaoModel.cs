using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class InterpelacaoManifestacaoModel
    {
        public int IdInterpelacaoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtInterpelacao { get; set; }
        public DateTime DataInterpelacao { get; set; }
        public int? IdUsuarioResposta { get; set; }
        public int? IdOrgaoResposta { get; set; }
        public string TxtRespostaInterpelacao { get; set; }
        public DateTime? DataRespostaInterpelacao { get; set; }
        public int? IdSituacaoInterpelacao { get; set; }
        public DateTime? PrazoRespostaInterpelacao { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel OrgaoResposta { get; set; }

        public virtual SituacaoInterpelacaoModel SituacaoInterpelacao { get; set; }
        public virtual UsuarioModel UsuarioResposta { get; set; }
    }
}