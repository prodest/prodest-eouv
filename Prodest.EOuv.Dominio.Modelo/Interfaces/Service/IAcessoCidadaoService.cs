using Prodest.EOuv.Dominio.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IAcessoCidadaoService
    {
        Task<AgentePublicoPapelModel[]> GetAgentePublicoPapeis(string id);

        Task<AgentePublicoPapelModel> GetPapel(string id);

        Task<AgentePublicoModel> GetConjuntoGestor(string id);

        Task<ConjuntoGrupoModel[]> GetConjuntoGrupos(string id, string tipoFiltro);

        Task<AgentePublicoModel[]> GetConjuntoAgentesPublicos(string id);

        Task<PermissaoUsuarioModel> GetPermissaoUsuario(string id);
        Task<AgentePublicoPapelModel[]> GetAgentePublico(string id, string busca);
    }
}