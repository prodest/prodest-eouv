using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface IRespostaRepository
    {
        Task<List<ResultadoRespostaModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao);

        Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato();

        Task<int> AdicionarResposta(RespostaManifestacaoModel respostaModel);
    }
}