using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public class PerfilPapelPermissao 
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<OrgaoPerfilPapelPermissao> Orgaos { get; set; }
        public ICollection<RecursoModel> Recursos { get; set; }
    }
}