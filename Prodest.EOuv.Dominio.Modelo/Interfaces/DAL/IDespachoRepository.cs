using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IDespachoRepository
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int id);
        Task<List<int>> ObterDespachosEmAberto();

        Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao);
        Task ResponderDespacho(int idDespacho, AgenteManifestacaoModel atorResposta);
        Task<SetorModel> BuscaSetor(string idSetor);
        Task AdicionarAgenteResposta(AgenteManifestacaoModel agenteResposta);
        Task<AgenteManifestacaoModel> montaAgente(string idAgente, int tipoAgente);
        Task<int> AdicionaAtor(AgenteManifestacaoModel atorResposta);
        Task<DespachoManifestacaoModel> ObterDespacho(int IdDespachoManifestacao);
        Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int idDespachoManifestacao);
        Task AtualizaDespacho(DespachoManifestacaoModel despachoManifestacao);
    }
}