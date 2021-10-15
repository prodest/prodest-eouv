using Prodest.EOuv.Dominio.Modelo.Model;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IOrganogramaService
    {
        Task<UnidadeModel> GetUnidade(string lotacaoId);

        Task<OrganizacaoModel> GetOrganizacao(string id);

        Task<OrganizacaoModel[]> GetOrganizacoesFilhas(string id);

        Task<UnidadeModel[]> GetUnidadesOrganizacao(string id);
    }
}