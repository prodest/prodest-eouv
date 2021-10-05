using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class OrgaoModel
    {
        public int IdOrgao { get; set; }
        public Guid GuidOrgao { get; set; }
        public string SiglaOrgao { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DatAtualizacao { get; set; }
        public bool IndAtivo { get; set; }
        public bool IndOutrasCompetencias { get; set; }
        public bool IndInsercaoManual { get; set; }
    }
}