using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface IAgenteRepository
    {
        Task<int> AdicionarAgente(AgenteManifestacaoModel agenteResposta);
    }
}