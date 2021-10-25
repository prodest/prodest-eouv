using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IDespachoRepository
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int id);

        Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao);
        Task EncerrarDespacho(int idDespacho);
    }
}