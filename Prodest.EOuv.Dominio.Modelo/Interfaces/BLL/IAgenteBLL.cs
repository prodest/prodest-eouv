using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IAgenteBLL
    {
        Task<AgenteManifestacaoModel> MontaAgente(string idAgente, int tipoAgente);

        Task<int> AdicionarAgente(AgenteManifestacaoModel agenteResposta);
    }
}