using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.Edocs
{
    public class AutuacaoModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset DataHora { get; set; }
        public PapelModel Papel { get; set; }
        public PapelModel Responsavel { get; set; }
        public Guid IdTermo { get; set; }
        public string RegistroTermo { get; set; }
        public LocalizacaoModel Localizacao { get; set; }
        public long Tipo { get; set; }
    }
}
