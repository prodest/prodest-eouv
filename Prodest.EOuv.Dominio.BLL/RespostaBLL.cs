using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class RespostaBLL : IRespostaBLL
    {
        private readonly IRespostaRepository _respostaRepository;

        public RespostaBLL(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public async Task<List<ResultadoRespostaModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao)
        {
            return await _respostaRepository.ObterResultadosRespostaPorTipologia(idTipoManifestacao);
        }

        public async Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato()
        {
            return await _respostaRepository.ObterOrgaosCompetenciaFato();
        }
    }
}