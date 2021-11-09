using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.DAL
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public UsuarioRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<UsuarioModel> ObterUsuarioPorId(int idUsuario)
        {
            var usuario = await _eouvContext.Usuario.Where(d => d.IdUsuario == idUsuario)
                                                                  .AsNoTracking().FirstOrDefaultAsync();
            var retorno = _mapper.Map<UsuarioModel>(usuario);
            return retorno;
        }

        public async Task<UsuarioModel> ObterUsuarioPorLogin(string login)
        {
            var usuario = await _eouvContext.Usuario.Where(d => d.Login == login)
                                                                  .AsNoTracking().FirstOrDefaultAsync();
            var retorno = _mapper.Map<UsuarioModel>(usuario);
            return retorno;
        }
    }
}