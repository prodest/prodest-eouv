using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class SetorModel
    {
        public SetorModel()
        {
            HistoricoManifestacao = new HashSet<HistoricoManifestacaoModel>();
        }

        public int IdSetor { get; set; }
        public Guid GuidSetor { get; set; }
        public string SiglaSetor { get; set; }
        public string NomeSetor { get; set; }
        public Guid GuidOrgao { get; set; }
        public int? IdOrgao { get; set; }
        public DateTime DatAtualizacao { get; set; }
        public bool IndAtivo { get; set; }

        public virtual OrgaoModel Orgao { get; set; }
        public virtual ICollection<HistoricoManifestacaoModel> HistoricoManifestacao { get; set; }
    }
}