using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Shared.Util;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IOrgaoBLL _orgaoBLL;
        private readonly IManifestacaoBLL _manifestacaoBLL;

        public UsuarioBLL(IOrgaoBLL orgaoBLL, IManifestacaoBLL manifestacaoBLL)
        {
            _orgaoBLL = orgaoBLL;
            _manifestacaoBLL = manifestacaoBLL;
        }

        public async Task<bool> UsuarioPossuiAcessoManifestacao(int idManifestacao, UsuarioModel usuario)
        {
            bool podeVisualizar = false;

            ManifestacaoModel manifestacao = await _manifestacaoBLL.ObterManifestacaoPorId(idManifestacao);

            if (usuario.IdPerfil == (int)Enums.PerfilUsuario.RepresentanteOuvidoria)
            {
                podeVisualizar = await _orgaoBLL.VerificarPermissaoOrgaoManifestacao(manifestacao, (int)usuario.IdOrgao);
            }
            else if (usuario.IdPerfil == (int)Enums.PerfilUsuario.ServidorOrgao)
            {
                podeVisualizar = (usuario.IdOrgao == manifestacao.IdOrgaoResponsavel);
            }

            return podeVisualizar;
        }
    }
}