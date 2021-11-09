using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface IOrgaoRepository
    {
        Task<OrgaoModel> ObterOrgaoPorId(int idOrgao);
        Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato();
        //Task<List<int>> ObterIdOrgaosVinculadosByOrgaoResponsavel(int idOrgao);
    }
}