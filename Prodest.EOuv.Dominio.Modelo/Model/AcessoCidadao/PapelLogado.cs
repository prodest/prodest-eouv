namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public class PapelLogado 
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string LotacaoGuid { get; set; }
        public string AgentePublicoSub { get; set; }
        public string AgentePublicoNome { get; set; }
        public bool Prioritario { get; set; }
    }
}