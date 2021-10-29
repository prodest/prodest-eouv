using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.Service
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IUsuarioLogadoModel Usuario;

        private readonly IUsuarioProvider _usuarioProvider;

        public PermissaoService(IUsuarioProvider usuarioProvider)
        {
            Usuario = usuarioProvider.GetCurrent();
            _usuarioProvider = usuarioProvider;
        }

        public async Task<ICollection<KeyValuePair<string, string>>> SearchByUsuarioAsync()
        {
            return await SearchByUsuarioAsync(Usuario.IdExterno.Value, true);
        }


        public async Task<ICollection<KeyValuePair<string, string>>> SearchByUsuarioAsync(Guid idUsuario, bool cache = true)
        {
            UsuarioLogadoModel cidadao = (UsuarioLogadoModel)await _usuarioProvider.ObterCidadaoPorId(idUsuario);

            ICollection<KeyValuePair<string, string>> permissoes = null;

            if (cidadao != null)
                permissoes = cidadao.Permissoes;

            return permissoes;
        }

    }
}