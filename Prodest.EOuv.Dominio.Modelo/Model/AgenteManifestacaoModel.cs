using System;
using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class AgenteManifestacaoModel
    {
        public int IdAgenteManifestacao { get; set; }
        public byte Tipo { get; set; }
        public string GuidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public Guid? GuidPapel { get; set; }
        public string NomePapel { get; set; }
        public Guid? GuidSetor { get; set; }
        public string NomeSetor { get; set; }
        public string SiglaSetor { get; set; }
        public Guid? GuidOrgao { get; set; }
        public string NomeOrgao { get; set; }
        public string SiglaOrgao { get; set; }
        public Guid? GuidPatriarca { get; set; }
        public string NomePatriarca { get; set; }
        public string SiglaPatriarca { get; set; }
    }
}