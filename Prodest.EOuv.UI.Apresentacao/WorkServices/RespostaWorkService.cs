using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IRespostaWorkService
    {
        Task<List<ResultadoRespostaViewModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao);

        Task<List<OrgaoViewModel>> ObterOrgaosCompetenciaFato();
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

        public async Task<List<ResultadoRespostaViewModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao)
        {
            List<ResultadoRespostaModel> listaResultadosRespostaModel = await _respostaBLL.ObterResultadosRespostaPorTipologia(idTipoManifestacao);
            List<ResultadoRespostaViewModel> listaResultadosRespostaViewModel = _mapper.Map<List<ResultadoRespostaViewModel>>(listaResultadosRespostaModel);
            return listaResultadosRespostaViewModel;
        }

        public async Task<List<OrgaoViewModel>> ObterOrgaosCompetenciaFato()
        {
            List<OrgaoModel> listaOrgaosCompetenciaFatoModel = await _respostaBLL.ObterOrgaosCompetenciaFato();
            List<OrgaoViewModel> listaOrgaosCompetenciaFatoViewModel = _mapper.Map<List<OrgaoViewModel>>(listaOrgaosCompetenciaFatoModel);
            return listaOrgaosCompetenciaFatoViewModel;
        }
    }
}