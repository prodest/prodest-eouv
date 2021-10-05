using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class PessoaJuridicaModel
    {
        public int IdPessoaJuridica { get; set; }
        public string NumCnpj { get; set; }
        public string OrgaoEmpresa { get; set; }
    }
}