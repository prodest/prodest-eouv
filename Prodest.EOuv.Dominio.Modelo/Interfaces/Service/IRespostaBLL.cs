using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IRespostaBLL
    {
        Task<List<ResultadoRespostaModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao);

        Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato();
    }
}