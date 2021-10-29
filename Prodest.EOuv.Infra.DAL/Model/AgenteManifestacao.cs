using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class AgenteManifestacao
    {
        public AgenteManifestacao()
        {
            DespachoManifestacaoAgenteDestinatario = new HashSet<DespachoManifestacao>();
            DespachoManifestacaoAgenteResposta = new HashSet<DespachoManifestacao>();
        }

        public int IdAgenteManifestacao { get; set; }
        public int TipoAgente { get; set; }
        public string GuidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public Guid? GuidPapel { get; set; }
        public string NomePapel { get; set; }
        public Guid? GuidGrupo { get; set; }
        public string NomeGrupo { get; set; }
        public Guid? GuidSetor { get; set; }
        public string NomeSetor { get; set; }
        public string SiglaSetor { get; set; }
        public Guid? GuidOrgao { get; set; }
        public string NomeOrgao { get; set; }
        public string SiglaOrgao { get; set; }
        public Guid? GuidPatriarca { get; set; }
        public string NomePatriarca { get; set; }
        public string SiglaPatriarca { get; set; }

        public virtual ICollection<DespachoManifestacao> DespachoManifestacaoAgenteDestinatario { get; set; }
        public virtual ICollection<DespachoManifestacao> DespachoManifestacaoAgenteResposta { get; set; }
    }
}