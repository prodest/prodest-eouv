#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class OuvidoriaOrgaoModel
    {
        public int IdOuvidoria { get; set; }
        public int IdOrgao { get; set; }

        public virtual OrgaoModel Orgao { get; set; }
        public virtual OuvidoriaModel Ouvidoria { get; set; }
    }
}