using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public class Recurso
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<AcaoModel> Acoes { get; set; }
    }
}