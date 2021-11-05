using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IDespachoWorkService
    {
        Task<List<DespachoManifestacaoViewModel>> ObterDespachosPorManifestacao(int idManifestacao);

        Task<JsonReturnViewModel> Despachar(DespachoManifestacaoEntry despachoEntry);

        Task EncerrarDespachoManualmente(int idDespacho);

        Task<List<DocumentoControladoModel>> ObterDocumentosEncaminhamentoEDocs(int idManifestacao);
    }

    public class DespachoWorkService : IDespachoWorkService
    {
        private readonly IDespachoBLL _despachoBLL;
        private readonly IMapper _mapper;

        public DespachoWorkService(IDespachoBLL despachoBLL, IMapper mapper)
        {
            _despachoBLL = despachoBLL;
            _mapper = mapper;
        }

        public async Task<List<DespachoManifestacaoViewModel>> ObterDespachosPorManifestacao(int idManifestacao)
        {
            var despachoModel = await _despachoBLL.ObterDespachosPorManifestacao(idManifestacao);
            var despachoViewModel = _mapper.Map<List<DespachoManifestacaoViewModel>>(despachoModel);
            return despachoViewModel;
        }

        public async Task<List<DocumentoControladoModel>> ObterDocumentosEncaminhamentoEDocs(int idManifestacao)
        {
            var listaDocumentos = await _despachoBLL.ObterDocumentosDespachoPorManifestacao(idManifestacao);
            return listaDocumentos;
        }

        public async Task<JsonReturnViewModel> Despachar(DespachoManifestacaoEntry despachoEntry)
        {
            var jsonRetorno = new JsonReturnViewModel();

            (bool ok, string mensagens) validacoesTela = ValidarCamposDespachar(despachoEntry);

            if (validacoesTela.ok)
            {
                //Converter Entry para Model
                DespachoManifestacaoModel despachoModel = new DespachoManifestacaoModel();

                despachoModel.IdManifestacao = despachoEntry.IdManifestacao;
                despachoModel.DataSolicitacaoDespacho = Convert.ToDateTime(DateTime.Now);
                despachoModel.PrazoResposta = Convert.ToDateTime(despachoEntry.PrazoResposta);
                despachoModel.TextoSolicitacaoDespacho = despachoEntry.TextoDespacho;

                var filtroDadosSelecionados = _mapper.Map<FiltroDadosManifestacaoModel>(despachoEntry.FiltroDadosManifestacaoSelecionados);

                string papelResponsavel = despachoEntry.GuidPapelResponsavel;
                string papelDestinatario = despachoEntry.GuidPapelDestinatario;
                int tipoDestinatario = despachoEntry.TipoDestinatario;

                (bool okNegocio, string mensagemNegocio) = await _despachoBLL.Despachar(despachoModel, papelDestinatario, tipoDestinatario, papelResponsavel, filtroDadosSelecionados);

                jsonRetorno.Ok = okNegocio;
                jsonRetorno.Mensagem = mensagemNegocio;
            }
            else
            {
                StringBuilder validationSummary = new StringBuilder();
                validationSummary.AppendLine("Foram encontrados os seguintes problemas:");
                validationSummary.AppendLine();
                validationSummary.AppendLine(validacoesTela.mensagens);

                jsonRetorno.Mensagem = validationSummary.ToString();
            }

            return jsonRetorno;
        }

        private (bool ok, string mensagens) ValidarCamposDespachar(DespachoManifestacaoEntry despachoEntry)
        {
            bool ok = true;
            StringBuilder validationSummary = new StringBuilder();

            if (string.IsNullOrWhiteSpace(despachoEntry.GuidPapelResponsavel))
            {
                validationSummary.AppendLine("O Papel do Responsável deve ser informado!");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(despachoEntry.GuidPapelDestinatario))
            {
                validationSummary.AppendLine("O Destinatário deve ser informado!");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(despachoEntry.PrazoResposta))
            {
                validationSummary.AppendLine("O Prazo de Resposta deve ser informado!");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(despachoEntry.TextoDespacho))
            {
                validationSummary.AppendLine("O Texto de Despacho deve ser informado!");
                ok = false;
            }

            return (ok, validationSummary.ToString());
        }

        public async Task EncerrarDespachoManualmente(int idDespacho)
        {
            await _despachoBLL.EncerrarDespachoManualmente(idDespacho);
        }
    }
}