using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Dominio.Modelo
{
    public class EncaminhamentoRequestModel
    {
        // v1
        public string? Titulo { get; set; }

        public string? Conteudo { get; set; }
        public string? ResponsavelId { get; set; }
        public string? EncaminhamentoAnteriorId { get; set; }
        public string[]? DestinosIds { get; set; }
        public string[]? DocumentosIds { get; set; }
        public bool? Organizacional { get; set; } = true;

        // v2
        public string? Assunto { get; set; }

        public string? Mensagem { get; set; }
        public string? IdResponsavel { get; set; }
        public string? IdEncaminhamentoAnterior { get; set; }
        public string[]? IdsDestinos { get; set; }
        public string[]? IdsDocumentos { get; set; }
        public RestricaoAcessoModel RestricaoAcesso { get; set; } = new RestricaoAcessoModel();

        // comum
        public bool? EnviarEmailNotificacoes { get; set; } = true;
    }
}