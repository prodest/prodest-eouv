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

        public enum NivelAcesso
        {
            Publico = 1,
            Organizacional = 2,
            Restrito = 3,
            Sigiloso = 4,
            Reservado = 5,
            Secreto = 6,
            Ultrassecreto = 7,
            SigilosoSemFundamentoLegal = 8
        }

        public enum SituacaoDespacho
        {
            Aberto = 1,
            Respondido = 2,
            EncerradoManualmente = 3
        }

        public enum TipoAgente
        {
            Cidadao = 1,
            Papel = 2,
            Grupo = 3,
            Unidade = 4,
            Organizacao = 5,
            Sistema = 6,
            NaoIdentificado = 99
        }

        public enum PerfilUsuario
        {
            Gestor = 1,
            OuvidoriaGeral = 2,
            AtendenteOuvidoria = 3,
            Cidadao = 4,
            RepresentanteOuvidoria = 5,
            ServidorOrgao = 6,
            RegistradorOrgao = 7
        }

        public enum SituacaoManifestacao
        {
            [Description("Triagem")]
            TRIAGEM = 1,

            [Description("Aberta")]
            ABERTA = 2,

            [Description("Em Andamento")]
            EM_ANDAMENTO = 3,

            [Description("Em Diligência")]
            EM_DILIGENCIA = 4,

            [Description("Resposta de Diligência")]
            RESPOSTA_DE_DILIGENCIA = 5,

            [Description("Em Apuração")]
            EM_APURACAO = 6,

            [Description("Apurada")]
            APURADA = 7,

            [Description("Despachada")]
            DESPACHADA = 8,

            [Description("Encerrada")]
            ENCERRADA = 9,

            [Description("Arquivada")]
            ARQUIVADA = 10,

            [Description("Devolvida")]
            DEVOLVIDA = 11,

            [Description("Interpelada")]
            INTERPELADA = 12,

            [Description("Encerrada Automaticamente")]
            ENCERRADA_AUTOMATICAMENTE = 13,

            [Description("Reaberta por Interpelação")]
            REABERTA_POR_INTERPELACAO = 14,

            [Description("Reaberta por Recurso")]
            REABERTA_POR_RECURSO_NEGATIVA = 15,

            [Description("Reclamação de Omissão")]
            ABERTA_POR_RECLAMACAO_OMISSAO = 16,

            //Situações que não fazem parte do banco ----------------------------------------------------
            [Description("Complementadas")]
            COMPLEMENTADA = 99,

            [Description("Em Apuração Sem Rensponsável")]
            EM_APURACAO_SEM_RESPONSAVEL = 98
        }



    }
}