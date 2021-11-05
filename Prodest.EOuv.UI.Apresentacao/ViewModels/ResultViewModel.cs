using System.Collections.Generic;

namespace Prodest.EOuv.UI.Apresentacao
{
    public class ResultViewModel<RESULT>
    {
        public RESULT Retorno { get; set; }
        public bool Ok { get; set; }

        public string Mensagem;
    }
}