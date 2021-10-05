using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class InterpelacaoManifestacao
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

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Orgao OrgaoResposta { get; set; }
        public virtual SituacaoInterpelacao SituacaoInterpelacao { get; set; }
        public virtual Usuario UsuarioResposta { get; set; }
    }
}