using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model
{
    public class PerfilModel
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public OrgaoModel[] Orgaos { get; set; }
        public RecursoModel[] Recursos { get; set; }
    }
}
