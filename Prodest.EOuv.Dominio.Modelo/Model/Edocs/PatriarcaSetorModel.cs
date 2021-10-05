using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class PatriarcaSetorModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public LocalizacaoSetor localizacao { get; set; }
    }

    public class LocalizacaoSetor
    {
        public string Sigla { get; set; }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
