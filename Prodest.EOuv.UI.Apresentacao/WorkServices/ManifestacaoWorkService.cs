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
        Task<ManifestacaoViewModel> ObterDadosCompletosManifestacao(int idManifestacao);
        Task<ManifestacaoViewModel> ObterManifestacaoPorId(int idManifestacao);
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

        public async Task<ManifestacaoViewModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            ManifestacaoModel manifestacaoModel = await _manifestacaoBLL.ObterDadosCompletosManifestacao(idManifestacao);
            ManifestacaoViewModel manifestacaoViewModel = _mapper.Map<ManifestacaoViewModel>(manifestacaoModel);
            return manifestacaoViewModel;
        }

        public async Task<ManifestacaoViewModel> ObterManifestacaoPorId(int idManifestacao)
        {
            ManifestacaoModel manifestacaoModel = await _manifestacaoBLL.ObterManifestacaoPorId(idManifestacao);
            ManifestacaoViewModel manifestacaoViewModel = _mapper.Map<ManifestacaoViewModel>(manifestacaoModel);
            return manifestacaoViewModel;
        }
    }
}