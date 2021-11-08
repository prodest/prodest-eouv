using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> BuscarUsuarioPorId(int idUsuario);

        Task<UsuarioModel> BuscarUsuarioPorLogin(string login);
    }
}