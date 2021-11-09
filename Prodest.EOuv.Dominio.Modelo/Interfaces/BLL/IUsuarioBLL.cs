using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IUsuarioBLL
    {
        Task<bool> UsuarioPossuiAcessoManifestacao(int idManifestacao, UsuarioModel usuario);

    }
}