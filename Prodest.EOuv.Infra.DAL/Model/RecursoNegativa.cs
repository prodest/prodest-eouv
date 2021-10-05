using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class RecursoNegativa
    {
        public int IdRecursoNegativa { get; set; }
        public int IdManifestacao { get; set; }
        public int NumeroRecurso { get; set; }
        public string TxtRecursoNegativa { get; set; }
        public DateTime DataRecursoNegativa { get; set; }
        public int? IdUsuarioResposta { get; set; }
        public string TxtRespostaRecursoNegativa { get; set; }
        public DateTime? DataRespostaRecursoNegativa { get; set; }
        public DateTime? PrazoRespostaRecursoNegativa { get; set; }

        public virtual Manifestacao Manifestacao { get; set; }
        public virtual Usuario UsuarioResposta { get; set; }
    }
}