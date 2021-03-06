using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> ObterUsuarioPorId(int idUsuario);

        Task<UsuarioModel> ObterUsuarioPorLogin(string login);
    }
}