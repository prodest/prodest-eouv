﻿using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class DespachoBLL : IDespachoBLL
    {
        private readonly IDespachoRepository _despachoRepository;
        private readonly IAgenteBLL _agenteBLL;
        private readonly IPdfApiService _pdfApiService;
        private readonly IHtmlApiService _htmlApiService;
        private readonly IEDocsService _edocsService;
        private readonly IManifestacaoBLL _manifestacaoBLL;

        public DespachoBLL(IDespachoRepository despachoRepository, IAgenteBLL agenteBLL, IPdfApiService pdfApiService,
                            IHtmlApiService htmlApiService, IEDocsService edocsService, IManifestacaoBLL manifestacaoBLL)
        {
            _despachoRepository = despachoRepository;
            _agenteBLL = agenteBLL;
            _pdfApiService = pdfApiService;
            _htmlApiService = htmlApiService;
            _edocsService = edocsService;
            _manifestacaoBLL = manifestacaoBLL;
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDespachosPorManifestacao(int idManifestacao)
        {
            return await _despachoRepository.ObterDespachoPorManifestacao(idManifestacao);
        }

        public async Task<List<int>> ObterDespachosEmAberto()
        {
            return await _despachoRepository.ObterDespachosEmAberto();
        }

        public async Task<DespachoManifestacaoModel> ObterDespachoPorId(int IdDespachoManifestacao)
        {
            return await _despachoRepository.ObterDespachoPorId(IdDespachoManifestacao);
        }

        public async Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao)
        {
            return await _despachoRepository.ObterDespachoEDestinatario(IdDespachoManifestacao);
        }

        public async Task<List<DocumentoControladoModel>> ObterDocumentosDespachoPorManifestacao(int idManifestacao)
        {
            var listaEncaminhamentosDespachos = await _despachoRepository.ObterIdEncaminhamentoDespachoPorManifestacao(idManifestacao);
            List<DocumentoControladoModel> documentos = new List<DocumentoControladoModel>();

            foreach (var idEncaminhamento in listaEncaminhamentosDespachos)
            {
                var listaDocumentos = await _edocsService.GetDocumentoEncaminhamento(idEncaminhamento.ToString());
                foreach (var item in listaDocumentos)
                {
                    documentos.Add(item);
                }
            }

            return documentos;
        }

        public async Task<(bool, string)> Despachar(DespachoManifestacaoModel despachoModel, string guidDestinatario, int tipoDestinatario, string papelResponsavel, FiltroDadosManifestacaoModel filtroDadosManifestacao)
        {
            //Validar regras de negócio
            (bool ok, string mensagens) validacoesNegocio = ValidarNegocioDespachar(despachoModel);

            if (validacoesNegocio.ok)
            {
                //Buscar Dados filtrados da Manifestação
                ManifestacaoModel manifestacao = await _manifestacaoBLL.ObterDadosFiltradosManifestacao(despachoModel.IdManifestacao, filtroDadosManifestacao);

                string nomeArquivo = "Manifestação " + manifestacao.NumProtocolo;

                //Gerar página HTML
                string html = await _htmlApiService.GerarHtml(manifestacao);

                //Gerar PDF a partir do HTML
                byte[] arquivoPdfCapturar = await _pdfApiService.GerarPdfByHtml(html);

                //Capturar arquivo PDF no E-Docs
                string idDocumento = await _edocsService.CapturarDocumento(arquivoPdfCapturar, papelResponsavel, nomeArquivo);

                //Encaminhar via E-Docs
                string idEncaminhamento = await _edocsService.EncaminharDocumento(idDocumento, "Demanda de Ouvidoria", despachoModel.TextoSolicitacaoDespacho, papelResponsavel, guidDestinatario);

                //Salvar Despacho no Eouv com IdEvento (sem IdEncaminhamento por enquanto)
                despachoModel.ProtocoloEdocs = await _edocsService.GetProtocoloEncaminhamento(idEncaminhamento);
                despachoModel.IdEncaminhamento = new Guid(idEncaminhamento);
                despachoModel.IdOrgao = manifestacao.IdOrgaoResponsavel;
                despachoModel.IdUsuarioSolicitacaoDespacho = (int)manifestacao.IdUsuarioAnalise;
                despachoModel.IdSituacaoDespacho = (int)Enums.SituacaoDespacho.Aberto;

                AgenteManifestacaoModel agenteDestinatario = new AgenteManifestacaoModel();
                //Se Agente = Papel
                if (tipoDestinatario == (int)Enums.TipoAgente.Papel)
                {
                    agenteDestinatario = await _agenteBLL.MontaAgenteUsuario(guidDestinatario);
                }
                //Se Agente = Grupo
                else if (tipoDestinatario == (int)Enums.TipoAgente.Grupo)
                {
                    agenteDestinatario = await _agenteBLL.MontaAgenteGrupoComissao(guidDestinatario);
                }
                //Se Agente = Setor
                else
                {
                    agenteDestinatario = await _agenteBLL.MontaAgenteSetor(guidDestinatario);
                }

                var idAgenteDestinatario = await _agenteBLL.AdicionarAgente(agenteDestinatario);
                despachoModel.IdAgenteDestinatario = idAgenteDestinatario;
                await _despachoRepository.AdicionarDespacho(despachoModel);

                return (true, "Despacho encaminhado com sucesso!");
            }
            else
            {
                StringBuilder validationSummary = new StringBuilder();
                validationSummary.AppendLine(validacoesNegocio.mensagens);

                return (false, validationSummary.ToString());
            }
        }

        public async Task ResponderDespacho(int idDespacho)
        {
            //busca Despacho
            DespachoManifestacaoModel despachoModel = await ObterDespachoEDestinatario(idDespacho);

            //busca se o encaminhamento foi respondido pelo destinatario, retorna quem respondeu
            EncaminhamentoRastreioDestinoModel responsavel = await _edocsService.ResponsavelPorResponderAoDestinatario(despachoModel.IdEncaminhamento.ToString(), new[] { despachoModel.AgenteDestinatario.GuidUsuario });
            if (responsavel != null)//encontrado
            {
                if (despachoModel.IdSituacaoDespacho == (int)Enums.SituacaoDespacho.Aberto)
                {
                    AgenteManifestacaoModel agenteResposta = await _agenteBLL.MontaAgenteUsuario(responsavel.Id);

                    var idAgenteResposta = await _agenteBLL.AdicionarAgente(agenteResposta);
                    despachoModel.IdSituacaoDespacho = (int)Enums.SituacaoDespacho.Respondido;
                    despachoModel.IdAgenteResposta = idAgenteResposta;
                    await _despachoRepository.AtualizarDespacho(despachoModel);
                }
            }
        }

        public async Task<(bool, string)> EncerrarDespachoManualmente(int idDespacho)
        {
            //Validar regras de negócio
            (bool ok, string mensagens) validacoesNegocio = ValidarNegocioEncerrarDespachoManualmente(idDespacho);

            if (validacoesNegocio.ok)
            {
                DespachoManifestacaoModel despacho = await ObterDespachoPorId(idDespacho);
                despacho.IdSituacaoDespacho = (int)Enums.SituacaoDespacho.EncerradoManualmente;
                despacho.DataRespostaDespacho = DateTime.Now;
                await _despachoRepository.AtualizarDespacho(despacho);

                return (true, "Despacho encerrado com sucesso!");
            }
            else
            {
                StringBuilder validationSummary = new StringBuilder();
                validationSummary.AppendLine(validacoesNegocio.mensagens);

                return (false, validationSummary.ToString());
            }
        }

        private (bool ok, string mensagens) ValidarNegocioDespachar(DespachoManifestacaoModel despachoModel)
        {
            bool ok = true;
            StringBuilder validationSummary = new StringBuilder();

            //Validar se o prazo está dentro do prazo máximo da manifestação
            //Validar se o usuário responsável possui acesso a manifestação
            //Validar se o destinatário é do mesmo órgão da manifestação

            //if (despachoModel.)
            //{
            //    validationSummary.AppendLine("O Papel do Responsável deve ser informado!");
            //    ok = false;
            //}
            //if (string.IsNullOrWhiteSpace(despachoEntry.GuidPapelDestinatario))
            //{
            //    validationSummary.AppendLine("O Destinatário deve ser informado!");
            //    ok = false;
            //}
            //if (string.IsNullOrWhiteSpace(despachoEntry.PrazoResposta))
            //{
            //    validationSummary.AppendLine("O Prazo de Resposta deve ser informado!");
            //    ok = false;
            //}
            //if (string.IsNullOrWhiteSpace(despachoEntry.TextoDespacho))
            //{
            //    validationSummary.AppendLine("O Texto de Despacho deve ser informado!");
            //    ok = false;
            //}

            return (ok, validationSummary.ToString());
        }

        private (bool ok, string mensagens) ValidarNegocioEncerrarDespachoManualmente(int idDespacho)
        {
            bool ok = true;
            StringBuilder validationSummary = new StringBuilder();

            //Validar se o despacho pode ser encerrado manualmente

            return (ok, validationSummary.ToString());
        }
    }
}