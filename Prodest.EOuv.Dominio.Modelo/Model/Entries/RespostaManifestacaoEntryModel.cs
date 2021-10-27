using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Model.Entries
{
    public class RespostaManifestacaoEntryModel
    {
        public int IdManifestacao { get; set; }
        public string TextoResposta { get; set; }
        public int IdResultadoResposta { get; set; }
        public int IdOrgaoCompetenciaFato { get; set; }
        public string[] Anexos { get; set; }
    }
}