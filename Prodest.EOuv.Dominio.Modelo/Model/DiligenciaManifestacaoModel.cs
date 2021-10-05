using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class DiligenciaManifestacaoModel
    {
        public int IdDiligenciaManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public string TxtDiligencia { get; set; }
        public int IdUsuario { get; set; }
        public int IdOrgao { get; set; }
        public DateTime DataDiligencia { get; set; }
        public string TxtRespostaDiligencia { get; set; }
        public DateTime? DataRespostaDiligencia { get; set; }

        //public virtual ManifestacaoModel Manifestacao { get; set; }
        public virtual OrgaoModel Orgao { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}