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

        public async Task AdicionarDespacho(DespachoManifestacaoModel despacho)
        {
            despacho.IdManifestacao = 366;
            despacho.IdOrgao = 843;
            despacho.IdUsuarioSolicitacaoDespacho = 29;
            despacho.DataSolicitacaoDespacho = DateTime.Now;

            await _despachoRepository.AdicionarDespacho(despacho);
        }

        public async Task Despachar(DespachoManifestacaoModel despachoModel, string destinatarios, string papelResponsavel, ListaFiltroDadosManifestacaoModel listaDadosSelecionados)
        {
            //Validar regras de negócio
            //Validar se o prazo está OK
            //Validar se o texto está OK
            //Validar se os anexos está OK
            //Validar se o destinatario está ok
            //Validar se o papel está ok

            //Buscar Dados da Manifestação
            ManifestacaoModel manifestacao = await _manifestacaoBLL.ObterDadosCompletosManifestacao(despachoModel.IdManifestacao);

            string nomeArquivo = "Manifestação " + manifestacao.NumProtocolo;

            string html = await MontarHtmlDetalhesManifestacao(manifestacao, listaDadosSelecionados);
            byte[] arquivoPdfCapturar = await _pdfApiBLL.GerarPdfByHtml(html);
            string idDocumento = await CapturarDocumentoEdocs(arquivoPdfCapturar, papelResponsavel, nomeArquivo);

            //obter dados necessarios
            //- Verificar lista de dados selecionados, montar HTML e gerar PDF

            //- Capturar arquivo PDF
            //- Encaminhar via E-Docs
            //- Salvar Despacho no Eouv com IdEvento (sem IdEncaminhamento por enquanto)
        }

        private async Task<string> MontarHtmlDetalhesManifestacao(ManifestacaoModel manifestacao, ListaFiltroDadosManifestacaoModel listaDadosSelecionados)
        {
            string html = await _htmlApiBLL.GerarHtml(manifestacao);
            return html;
        }

        private async Task<string> CapturarDocumentoEdocs(byte[] arquivoPdfCapturar, string papelResponsavel, string nomeArquivo)
        {
            var IdEncaminhamento = await _edocsBLL.CapturarDocumento(arquivoPdfCapturar, papelResponsavel, nomeArquivo);
            return IdEncaminhamento;
        }
    }
}