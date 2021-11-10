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
        private readonly ISharedBLL _sharedBLL;
        private readonly IMapper _mapper;

        public ManifestacaoWorkService(IManifestacaoBLL manifestacaoBLL, ISharedBLL sharedBLL, IMapper mapper)
        {
            _manifestacaoBLL = manifestacaoBLL;
            _sharedBLL = sharedBLL;
            _mapper = mapper;
        }

        public async Task<JsonReturnViewModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            var jsonRetorno = new JsonReturnViewModel();

            ManifestacaoModel manifestacaoModel = await _sharedBLL.ObterDadosCompletosManifestacao(idManifestacao);

            if (manifestacaoModel != null)
            {
                jsonRetorno.Ok = true;
                jsonRetorno.Retorno = _mapper.Map<ManifestacaoViewModel>(manifestacaoModel);
            }
            else
            {
                jsonRetorno.Ok = false;
                jsonRetorno.Mensagem = "Manifestação não encontrada ou Usuário não possui acesso!";
            }

            return jsonRetorno;
        }

        public async Task<JsonReturnViewModel> ObterManifestacaoPorId(int idManifestacao)
        {
            var jsonRetorno = new JsonReturnViewModel();

            ManifestacaoModel manifestacaoModel = await _manifestacaoBLL.ObterManifestacaoPorId(idManifestacao);

            if (manifestacaoModel != null)
            {
                jsonRetorno.Ok = true;
                jsonRetorno.Retorno = _mapper.Map<ManifestacaoViewModel>(manifestacaoModel);
            }
            else
            {
                jsonRetorno.Ok = false;
                jsonRetorno.Mensagem = "Manifestação não encontrada ou Usuário não possui acesso!";
            }

            return jsonRetorno;
        }
    }
}