using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class AcessoCidadaoBLL : IAcessoCidadaoBLL
    {
        private readonly IAcessoCidadaoService _acessoCidadaoService;
        private readonly IOrganogramaService _organogramaService;

        public AcessoCidadaoBLL(
            IAcessoCidadaoService acessoCidadaoService,
            IOrganogramaService organogramaService
        )
        {
            _acessoCidadaoService = acessoCidadaoService;
            _organogramaService = organogramaService;
        }

        // ======================
        // public methods
        // ======================

        public async Task<AgentePublicoPapelModel> GetPapel(Guid id)
        {
            var papel = await _acessoCidadaoService.GetPapel(id.ToString());
            papel.Lotacao = await _organogramaService.GetUnidade(papel.LotacaoGuid);

            return papel;
        }

        public async Task<ConjuntoGrupoModel[]> GetConjuntoGrupos(Guid id, string tipoFiltro)
        {
            return await _acessoCidadaoService.GetConjuntoGrupos(id.ToString(), tipoFiltro);
        }

        public async Task<AgentePublicoModel[]> GetConjuntoAgentesPublicos(Guid id)
        {
            return await _acessoCidadaoService.GetConjuntoAgentesPublicos(id.ToString());
        }

        public async Task<UnidadeModel[]> GetUnidadesPerfilAdministrador(Guid id)
        {
            var response = await _acessoCidadaoService.GetPermissaoUsuario(id.ToString());
            var ret = new List<UnidadeModel>();

            foreach (var papel in response.Papeis)
            {
                var perfilAdministrador = papel.Perfis.First(x => x.Nome.ToUpper() == "ADMINISTRADOR");

                foreach (var orgao in perfilAdministrador.Orgaos)
                {
                    ret.Add(await _organogramaService.GetUnidade(orgao.Guid));
                }
            }

            return ret.ToArray();
        }

        // ======================
        // private methods
        // ======================
    }
}