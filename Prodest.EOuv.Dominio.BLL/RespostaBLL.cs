using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class RespostaBLL : IRespostaBLL
    {
        private readonly IRespostaRepository _respostaRepository;
        private readonly IManifestacaoBLL _manifestacaoBLL;

        public RespostaBLL(IRespostaRepository respostaRepository, IManifestacaoBLL manifestacaoBLL)
        {
            _respostaRepository = respostaRepository;
            _manifestacaoBLL = manifestacaoBLL;
        }

        public async Task<List<ResultadoRespostaModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao)
        {
            return await _respostaRepository.ObterResultadosRespostaPorTipologia(idTipoManifestacao);
        }

        public async Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato()
        {
            return await _respostaRepository.ObterOrgaosCompetenciaFato();
        }

        public async Task ResponderManifestacao(RespostaManifestacaoEntryModel respostaEntryModel)
        {
            var manifestacao = await _manifestacaoBLL.ObterManifestacaoPorId(respostaEntryModel.IdManifestacao);

            RespostaManifestacaoModel respostaModel = new RespostaManifestacaoModel();
            respostaModel.IdManifestacao = respostaEntryModel.IdManifestacao;
            respostaModel.TxtResposta = respostaEntryModel.TextoResposta;
            respostaModel.IdUsuario = 29; //TODO: Buscar usuário autenticado
            respostaModel.IdOrgao = 877; //TODO: Buscar orgão do usuário autenticado
            respostaModel.DataResposta = DateTime.Now;
            respostaModel.PrazoResposta = manifestacao.PrazoResposta;

            await _respostaRepository.AdicionarResposta(respostaModel);

            manifestacao.IdResultadoResposta = respostaEntryModel.IdResultadoResposta;
            manifestacao.IdOrgaoInteresse = respostaEntryModel.IdOrgaoCompetenciaFato;

            await _manifestacaoBLL.AtualizarManifestacao(manifestacao);
        }
    }
}