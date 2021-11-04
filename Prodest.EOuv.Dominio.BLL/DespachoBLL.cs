using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
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

        public async Task AdicionarDespacho(DespachoManifestacaoModel despacho)
        {
            despacho.IdManifestacao = 366;
            despacho.IdOrgao = 843;
            despacho.IdUsuarioSolicitacaoDespacho = 29;
            despacho.DataSolicitacaoDespacho = DateTime.Now;

            await _despachoRepository.AdicionarDespacho(despacho);
        }

        public async Task Despachar(DespachoManifestacaoModel despachoModel, string guidDestinatario, int tipoDestinatario, string papelResponsavel, FiltroDadosManifestacaoModel filtroDadosManifestacao)
        {
            //Validar regras de negócio
            //Validar se o prazo está OK
            //Validar se o texto está OK
            //Validar se os anexos está OK
            //Validar se o destinatario está ok
            //Validar se o papel está ok

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

        public async Task EncerrarDespachoManualmente(int idDespacho)
        {
            DespachoManifestacaoModel despacho = await ObterDespachoPorId(idDespacho);
            despacho.IdSituacaoDespacho = (int)Enums.SituacaoDespacho.EncerradoManualmente;
            despacho.DataRespostaDespacho = DateTime.Now;
            await _despachoRepository.AtualizarDespacho(despacho);
        }
    }
}