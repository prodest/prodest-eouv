using Prodest.EOuv.Dominio.Modelo;
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

        public async Task<List<DespachoManifestacaoModel>> ObterDespachosEmAberto()
        {
            return await _despachoRepository.ObterDespachosEmAberto();
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
            string idEncaminhamento = await EncaminharDocumentoEdocs(idDocumento, "Demanda de Ouvidoria", despachoModel.TextoSolicitacaoDespacho, despachoModel.IdUsuarioSolicitacaoDespacho.ToString(), destinatario, papelResponsavel);
            //Salvar Despacho no Eouv com IdEvento (sem IdEncaminhamento por enquanto)
        }

        private async Task<string> MontarHtmlDetalhesManifestacao(ManifestacaoModel manifestacao)
        {
            string html = await _htmlApiBLL.GerarHtml(manifestacao);
            return html;
        }

        private async Task<string> CapturarDocumentoEdocs(byte[] arquivoPdfCapturar, string papelResponsavel, string nomeArquivo)
        {
            var IdDocumento = await _edocsBLL.CapturarDocumento(arquivoPdfCapturar, papelResponsavel, nomeArquivo);
            return IdDocumento;
        }

        private async Task<string> EncaminharDocumentoEdocs(string idDocumento, string assunto, string mensagem, string idResponsavel, string idDestinatario, string papelResponsavel)
        {
            var IdEncaminhamento = await _edocsBLL.EncaminharDocumento(idDocumento, assunto, mensagem, idResponsavel, idDestinatario, papelResponsavel);
            return IdEncaminhamento;
        }

        public async Task ResponderDespacho(int idDespacho, object atorResposta)
        {   
           await _despachoRepository.ResponderDespacho(idDespacho, atorResposta);            
        }
        
        public async Task BuscaSetor(string idSetor)
        {
            await _despachoRepository.BuscaSetor(idSetor);
        }
    }
}