using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IRespostaWorkService
    {
        Task<JsonReturnViewModel> ObterResultadosRespostaPorTipologia(int idTipoManifestacao);

        Task<JsonReturnViewModel> ObterOrgaosCompetenciaFato();

        Task<JsonReturnViewModel> ResponderManifestacao(RespostaManifestacaoEntry respostaEntry);
    }

    public class RespostaWorkService : IRespostaWorkService
    {
        private readonly IRespostaBLL _respostaBLL;
        private readonly IMapper _mapper;

        public RespostaWorkService(IRespostaBLL respostaBLL, IMapper mapper)
        {
            _respostaBLL = respostaBLL;
            _mapper = mapper;
        }

        public async Task<JsonReturnViewModel> ObterResultadosRespostaPorTipologia(int idTipoManifestacao)
        {
            var jsonRetorno = new JsonReturnViewModel();

            List<ResultadoRespostaModel> listaResultadosRespostaModel = await _respostaBLL.ObterResultadosRespostaPorTipologia(idTipoManifestacao);
            jsonRetorno.Retorno = _mapper.Map<List<ResultadoRespostaViewModel>>(listaResultadosRespostaModel);
            jsonRetorno.Ok = true;

            return jsonRetorno;
        }

        public async Task<JsonReturnViewModel> ObterOrgaosCompetenciaFato()
        {
            var jsonRetorno = new JsonReturnViewModel();

            List<OrgaoModel> listaOrgaosCompetenciaFatoModel = await _respostaBLL.ObterOrgaosCompetenciaFato();
            jsonRetorno.Retorno = _mapper.Map<List<OrgaoViewModel>>(listaOrgaosCompetenciaFatoModel);
            jsonRetorno.Ok = true;

            return jsonRetorno;
        }

        public async Task<JsonReturnViewModel> ResponderManifestacao(RespostaManifestacaoEntry respostaEntry)
        {
            var jsonRetorno = new JsonReturnViewModel();

            (bool ok, string mensagens) validacoesTela = ValidarCamposResponder(respostaEntry);

            if (validacoesTela.ok)
            {
                RespostaManifestacaoEntryModel respostaEntryModel = _mapper.Map<RespostaManifestacaoEntryModel>(respostaEntry);

                (bool okNegocio, string mensagemNegocio) = await _respostaBLL.ResponderManifestacao(respostaEntryModel);

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

        private (bool ok, string mensagens) ValidarCamposResponder(RespostaManifestacaoEntry respostaEntry)
        {
            bool ok = true;
            StringBuilder validationSummary = new StringBuilder();

            if (respostaEntry.IdResultadoResposta == 0)
            {
                validationSummary.AppendLine("O Resultado da Resposta deve ser informado!");
                ok = false;
            }
            if (respostaEntry.IdOrgaoCompetenciaFato == 0)
            {
                validationSummary.AppendLine("O Órgão de Competência do Fato deve ser informado!");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(respostaEntry.TextoResposta))
            {
                validationSummary.AppendLine("O Texto da Resposta deve ser informado!");
                ok = false;
            }

            return (ok, validationSummary.ToString());
        }
    }
}