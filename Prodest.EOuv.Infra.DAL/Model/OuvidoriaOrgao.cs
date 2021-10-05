#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class OuvidoriaOrgao
    {
        public int IdOuvidoria { get; set; }
        public int IdOrgao { get; set; }

        public virtual Orgao Orgao { get; set; }
        public virtual Ouvidoria Ouvidoria { get; set; }
    }
}