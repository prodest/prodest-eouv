using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class Setor
    {
        public Setor()
        {
            HistoricoManifestacao = new HashSet<HistoricoManifestacao>();
        }

        public int IdSetor { get; set; }
        public Guid GuidSetor { get; set; }
        public string SiglaSetor { get; set; }
        public string NomeSetor { get; set; }
        public Guid GuidOrgao { get; set; }
        public int? IdOrgao { get; set; }
        public DateTime DatAtualizacao { get; set; }
        public bool IndAtivo { get; set; }

        public virtual Orgao Orgao { get; set; }
        public virtual ICollection<HistoricoManifestacao> HistoricoManifestacao { get; set; }
    }
}