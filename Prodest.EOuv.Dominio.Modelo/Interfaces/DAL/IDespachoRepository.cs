using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface IDespachoRepository
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int id);

        Task<List<int>> ObterDespachosEmAberto();

        Task<DespachoManifestacaoModel> ObterDespachoPorId(int IdDespachoManifestacao);

        Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int idDespachoManifestacao);

        Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao);

        Task AtualizarDespacho(DespachoManifestacaoModel despachoManifestacao);
    }
}