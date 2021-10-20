using System.Collections.Generic;
using System.Threading.Tasks;
using Prodest.EOuv.Infra.DAL.Setor;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IDespachoRepository
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int id);
        Task<List<DespachoManifestacaoModel>> ObterDespachosEmAberto();

        Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao);
        Task ResponderDespacho(int idDespacho, object atorResposta);
        Task<SetorModel> BuscaSetor(string idSetor);
    }
}