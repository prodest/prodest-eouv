using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public class PerfilLogadoModel
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public OrgaoModel[] Orgaos { get; set; }
        public RecursoModel[] Recursos { get; set; }
        public Guid IdExterno { get; set; }
    }
}
