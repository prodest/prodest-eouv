using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class PessoaModel
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public int? IdMunicipio { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }

        public virtual MunicipioModel Municipio { get; set; }
    }
}