using System.Collections.Generic;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class PessoaJuridica
    {
        public PessoaJuridica()
        {
            Manifestacao = new HashSet<Manifestacao>();
        }

        public int IdPessoaJuridica { get; set; }
        public string NumCnpj { get; set; }
        public string OrgaoEmpresa { get; set; }

        public virtual ICollection<Manifestacao> Manifestacao { get; set; }
    }
}