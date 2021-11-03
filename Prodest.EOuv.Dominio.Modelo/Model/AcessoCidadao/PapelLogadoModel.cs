using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public class PapelLogadoModel 
    {
        public string TipoPapel { get; set; }
        public bool Prioritario { get; set; }
        public string AgentePublicoNome { get; set; }
        public string Nome { get; set; }
        public string LotacaoGuid { get; set; }
        public UsuarioLogadoModel Servidor { get; set; }
        public ICollection<PerfilLogadoModel> Perfis { get; set; }
        public Guid? IdExterno { get; set; }
    }
}