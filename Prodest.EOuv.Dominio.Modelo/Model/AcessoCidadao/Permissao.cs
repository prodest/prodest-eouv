using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public class Permissao 
    {
        public ICollection<PapelPermissao> Papeis { get; set; }
    }
}