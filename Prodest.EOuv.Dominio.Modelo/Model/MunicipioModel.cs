using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class MunicipioModel
    {
        public int IdMunicipio { get; set; }
        public string DescMunicipio { get; set; }
        public string SigUf { get; set; }
        public int? IdRegional { get; set; }

        public virtual UfModel Uf { get; set; }
    }
}