using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface ISharedBLL
    {
        Task<AgenteManifestacaoModel> MontaAgenteGrupoComissao(string idAgente);
        Task<AgenteManifestacaoModel> MontaAgenteSetor(string idAgente);
        Task<AgenteManifestacaoModel> MontaAgenteUsuario(string idAgente);
        Task<ManifestacaoModel> ObterDadosCompletosManifestacao(int idManifestacao);
        Task<ManifestacaoModel> ObterDadosFiltradosManifestacao(int idManifestacao, FiltroDadosManifestacaoModel filtroDadosManifestacao);
        Task<bool> UsuarioPossuiAcessoManifestacao(int idManifestacao);
        Task<bool> VerificarPermissaoOrgaoManifestacao(ManifestacaoModel manifestacao, int idOrgao);
    }
}