using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class ProcessoModel
    {
        public Guid Id { get; set; }
        public string Ano { get; set; }
        public AutuacaoModel Autuacao { get; set; }
        public ClasseModel Classe { get; set; }
        public string Protocolo { get; set; }
        public string Resumo { get; set; }
        public long Situacao { get; set; }
    }
}