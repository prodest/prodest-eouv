using System;
using System.ComponentModel;

namespace Prodest.EOuv.Shared.Util
{
    public class Enums
    {
        public enum TipoAnexoManifestacaoOptions
        {
            Anexo_Manifestacao = 1,
            Anexo_Resposta = 2,
            Anexo_Complemento = 3,
            Anexo_RespostaRecurso = 4,
            Anexo_RespostaApuracao = 5,
            Anexo_RespostaDiligencia = 6,
            Anexo_RecursoNegativa = 7,
            Anexo_Interpelacao = 8,
            Anexo_Notificacao = 9
        }
        public enum AuthenticationType
        {
            [Description("Nenhuma")]
            None = 0,

            [Description("Usuário")]
            User = 1,

            [Description("Aplicação")]
            Application = 2
        }

        public enum EventoSituacao
        {
            Criado = 1,
            Enfileirado = 2,
            Processando = 3,
            Executado = 4,
            Concluido = 5,
            Cancelado = 9
        }

        public enum DocumentoValorLegal
        {
            Original = 1,
            CopiaAutenticadaCartorio = 2,
            CopiaAutenticadaAdministrativamente = 3,
            CopiaSimples = 4
        }

        public enum nivelAcesso
        {
            Sigiloso = 4
        }
    }
}