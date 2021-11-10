using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IAgenteBLL
    {
        Task<int> AdicionarAgente(AgenteManifestacaoModel agenteResposta);
    }
}