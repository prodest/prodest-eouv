﻿using Newtonsoft.Json.Linq;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class DespachoBLL : IDespachoBLL
    {
        private readonly IDespachoRepository _despachoRepository;
        private readonly IPdfApiBLL _pdfApiBLL;
        private readonly IHtmlApiBLL _htmlApiBLL;
        private readonly IEDocsBLL _edocsBLL;
        private readonly IManifestacaoBLL _manifestacaoBLL;

        public DespachoBLL(IDespachoRepository despachoRepository, IPdfApiBLL pdfApiBLL, IHtmlApiBLL htmlApiBLL, IEDocsBLL edocsBLL, IManifestacaoBLL manifestacaoBLL)
        {
            _despachoRepository = despachoRepository;
            _pdfApiBLL = pdfApiBLL;
            _htmlApiBLL = htmlApiBLL;
            _edocsBLL = edocsBLL;
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

        public async Task<DespachoManifestacaoModel> ObterDespacho(int IdDespachoManifestacao)
        {
            return await _despachoRepository.ObterDespacho(IdDespachoManifestacao);
        }

        public async Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao)
        {
            return await _despachoRepository.ObterDespachoEDestinatario(IdDespachoManifestacao);
        }

        public async Task<AgenteManifestacaoModel> montaAgente(string idAgente, int tipoAgente)
        {
            return await _despachoRepository.montaAgente(idAgente, tipoAgente);
        }
        


        public async Task AdicionarDespacho(DespachoManifestacaoModel despacho)
        {
            despacho.IdManifestacao = 366;
            despacho.IdOrgao = 843;
            despacho.IdUsuarioSolicitacaoDespacho = 29;
            despacho.DataSolicitacaoDespacho = DateTime.Now;

            await _despachoRepository.AdicionarDespacho(despacho);
        }

        public async Task Despachar(DespachoManifestacaoModel despachoModel, string destinatario, string papelResponsavel, FiltroDadosManifestacaoModel filtroDadosManifestacao)
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
            string html = await MontarHtmlDetalhesManifestacao(manifestacao);
            //Gerar PDF a partir do HTML
            byte[] arquivoPdfCapturar = await _pdfApiBLL.GerarPdfByHtml(html);
            //Capturar arquivo PDF no E-Docs
            string idDocumento = await CapturarDocumentoEdocs(arquivoPdfCapturar, papelResponsavel, nomeArquivo);
            //Encaminhar via E-Docs
            string idEncaminhamento = await EncaminharDocumentoEdocs(idDocumento, "Demanda de Ouvidoria", despachoModel.TextoSolicitacaoDespacho, papelResponsavel, destinatario);
            //Salvar Despacho no Eouv com IdEvento (sem IdEncaminhamento por enquanto)
            despachoModel.ProtocoloEdocs = await _edocsBLL.GetProtocoloEncaminhamento(idEncaminhamento);
            despachoModel.IdEncaminhamento = new Guid(idEncaminhamento);
            despachoModel.IdOrgao = manifestacao.IdOrgaoResponsavel;
            despachoModel.IdUsuarioSolicitacaoDespacho = (int)manifestacao.IdUsuarioAnalise;
            await _despachoRepository.AdicionarDespacho(despachoModel);
        }

        private async Task<string> MontarHtmlDetalhesManifestacao(ManifestacaoModel manifestacao)
        {            
            string html = await _htmlApiBLL.GerarHtml(manifestacao);            
            JObject json = JObject.FromObject(manifestacao);//Geração de objeto json de teste a partir da manifestacao
            return html;
        }

        private async Task<string> CapturarDocumentoEdocs(byte[] arquivoPdfCapturar, string papelResponsavel, string nomeArquivo)
        {
            var IdDocumento = await _edocsBLL.CapturarDocumento(arquivoPdfCapturar, papelResponsavel, nomeArquivo);
            return IdDocumento;
        }

        private async Task<string> EncaminharDocumentoEdocs(string idDocumento, string assunto, string mensagem, string papelResponsavel, string idDestinatario)
        {
            var IdEncaminhamento = await _edocsBLL.EncaminharDocumento(idDocumento, assunto, mensagem, papelResponsavel, idDestinatario);
            return IdEncaminhamento;
        }

        public async Task ResponderDespacho(int idDespacho, AgenteManifestacaoModel agenteResposta)
        {
            //salva ator
            var idAtorResposta = await _despachoRepository.AdicionarAgente(agenteResposta);

            var despachoManifestacao = await _despachoRepository.ObterDespacho(idDespacho);
            despachoManifestacao.Situacao = nameof(Enums.SituacaoDespacho.Respondido);
            //despachoManifestacao.AgenteResposta = agenteResposta;
            //salva ator resposta            
            despachoManifestacao.IdAgenteResposta = idAtorResposta;
            await _despachoRepository.AtualizarDespacho(despachoManifestacao);
        }

        public async Task ResponderDespacho(int idDespacho)
        {
            try { 
                //busca Despacho
                DespachoManifestacaoModel despacho = await ObterDespachoEDestinatario(idDespacho);

                //busca se o encaminhamento foi respondido pelo destinatario, retorna quem respondeu
                EncaminhamentoRastreioDestinoModel responsavel = await _edocsBLL.ResponsavelPorResponderAoDestinatario(despacho.IdEncaminhamento.ToString(), new[] { despacho.AgenteDestinatario.GuidUsuario });
                if (responsavel != null)//encontrado
                {
                    if (despacho.Situacao == nameof(Enums.SituacaoDespacho.Aberto))
                    {
                        AgenteManifestacaoModel agenteResposta = await montaAgente(responsavel.Id, responsavel.TipoAgente);

                        var idAtorResposta = await _despachoRepository.AdicionarAgente(agenteResposta);
                        despacho.Situacao = nameof(Enums.SituacaoDespacho.Respondido);
                        despacho.IdAgenteResposta = idAtorResposta;
                        await _despachoRepository.AtualizarDespacho(despacho);
                    }
                }
            }
            catch (Exception e)
            {
                throw (new Exception(e.StackTrace));
            }
        }

        public async Task<SetorModel> BuscarSetor(string idSetor)
        {
            var setor = await _despachoRepository.BuscarSetor(idSetor);
            return setor;
        }
        public async Task AdicionarAgenteResposta(AgenteManifestacaoModel agenteResposta)
        {
            await _despachoRepository.AdicionarAgenteResposta(agenteResposta);            
        }
        
    }
}