
using Prodest.EOuv.Dominio.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IAcessoCidadaoBLL
    {
        Task<AgentePublicoPapelModel> GetPapel(Guid id);
        Task<ConjuntoGrupoModel[]> GetConjuntoGrupos(Guid id, string tipoFiltro);
        Task<AgentePublicoModel[]> GetConjuntoAgentesPublicos(Guid id);
        Task<UnidadeModel[]> GetUnidadesPerfilAdministrador(Guid id);
    }
}
