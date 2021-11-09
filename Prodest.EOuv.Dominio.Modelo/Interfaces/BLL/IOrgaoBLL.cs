using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IOrgaoBLL
    {
        Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato();

        Task<bool> VerificarPermissaoOrgaoManifestacao(ManifestacaoModel manifestacao, int idOrgao);

    }
}