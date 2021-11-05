using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IAgenteBLL
    {
        Task<AgenteManifestacaoModel> MontaAgenteUsuario(string idAgente);

        Task<AgenteManifestacaoModel> MontaAgenteGrupoComissao(string idAgente);

        Task<AgenteManifestacaoModel> MontaAgenteSetor(string idAgente);

        Task<int> AdicionarAgente(AgenteManifestacaoModel agenteResposta);
    }
}