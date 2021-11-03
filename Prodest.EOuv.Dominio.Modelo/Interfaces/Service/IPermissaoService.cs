using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.Service
{
    public interface IPermissaoService
    {
        Task<ICollection<KeyValuePair<string, string>>> SearchByUsuarioAsync();
        Task<ICollection<KeyValuePair<string, string>>> SearchByUsuarioAsync(Guid idUsuario, bool cache = true);
    }
}