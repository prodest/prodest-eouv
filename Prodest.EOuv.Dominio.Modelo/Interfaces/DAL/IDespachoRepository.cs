using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IDespachoRepository
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int id);

        Task<List<int>> ObterDespachosEmAberto();

        Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao);

        Task<SetorModel> BuscarSetor(string idSetor);

        Task<int> AdicionarAgente(AgenteManifestacaoModel agenteResposta);

        Task<DespachoManifestacaoModel> ObterDespacho(int IdDespachoManifestacao);

        Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int idDespachoManifestacao);

        Task AtualizarDespacho(DespachoManifestacaoModel despachoManifestacao);
    }
}