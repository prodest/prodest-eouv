using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IManifestacaoWorkService
    {
        Task<JsonReturnViewModel> ObterDadosCompletosManifestacao(int idManifestacao);

        Task<JsonReturnViewModel> ObterManifestacaoPorId(int idManifestacao);
    }

    public class ManifestacaoWorkService : IManifestacaoWorkService
    {
        private readonly IManifestacaoBLL _manifestacaoBLL;
        private readonly IMapper _mapper;

        public ManifestacaoWorkService(IManifestacaoBLL manifestacaoBLL, IMapper mapper)
        {
            _manifestacaoBLL = manifestacaoBLL;
            _mapper = mapper;
        }

        public async Task<JsonReturnViewModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            var jsonRetorno = new JsonReturnViewModel();

            if (idManifestacao > 0)
            {
                ManifestacaoModel manifestacaoModel = await _manifestacaoBLL.ObterDadosCompletosManifestacao(idManifestacao);
                jsonRetorno.Retorno = _mapper.Map<ManifestacaoViewModel>(manifestacaoModel);
                jsonRetorno.Ok = true;
            }
            else
            {
                jsonRetorno.Ok = false;
                jsonRetorno.Mensagem = "Manifestação não encontrada!";
            }

            return jsonRetorno;
        }

        public async Task<JsonReturnViewModel> ObterManifestacaoPorId(int idManifestacao)
        {
            var jsonRetorno = new JsonReturnViewModel();

            if (idManifestacao > 0)
            {
                ManifestacaoModel manifestacaoModel = await _manifestacaoBLL.ObterManifestacaoPorId(idManifestacao);
                jsonRetorno.Retorno = _mapper.Map<ManifestacaoViewModel>(manifestacaoModel);
                jsonRetorno.Ok = true;
            }
            else
            {
                jsonRetorno.Ok = false;
                jsonRetorno.Mensagem = "Manifestação não encontrada!";
            }

            return jsonRetorno;
        }
    }
}