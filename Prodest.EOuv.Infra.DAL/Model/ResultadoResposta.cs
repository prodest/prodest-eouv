using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class ResultadoResposta
    {
        public ResultadoResposta()
        {
            Manifestacao = new HashSet<Manifestacao>();
            ResultadoRespostaTipologia = new HashSet<ResultadoRespostaTipologia>();
        }

        public int IdResultadoResposta { get; set; }
        public string DescResultadoResposta { get; set; }
        public string ClassificacaoResultadoResposta { get; set; }

        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
        public virtual ICollection<ResultadoRespostaTipologia> ResultadoRespostaTipologia { get; set; }
    }
}