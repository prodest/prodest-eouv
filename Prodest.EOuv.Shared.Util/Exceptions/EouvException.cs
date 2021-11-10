using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Prodest.EOuv.Shared.Utils
{
    public class EouvException : Exception
    {
        public EouvException(string mensagem) : base(mensagem) { }

        public EouvException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }

    public class EouvPaginaNaoEncontradaException : EouvException
    {
        public EouvPaginaNaoEncontradaException(string mensagem) : base(mensagem) { }

        public EouvPaginaNaoEncontradaException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }

    public class EouvUsuarioSemAcessoException : EouvException
    {
        public EouvUsuarioSemAcessoException(string mensagem) : base(mensagem) { }

        public EouvUsuarioSemAcessoException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
