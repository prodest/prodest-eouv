using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.Service
{
    public interface IUsuarioProvider
    {
        IEnumerable<Claim> Claims { get; }

        IUsuarioLogadoModel GetCurrent();
        Task SetCurrent(ClaimsPrincipal user);

        Task<IUsuarioLogadoModel> ObterCidadaoPorId(Guid idCidadao);
        //Task<CidadaoModel> ObterCidadaoPorCpfOuAdicionar(string cpf);
        //Task<ICollection<CidadaoModel>> ObterCidadaosPorPerfil(Guid idPerfil);
        //Task<ICollection<GrupoModel>> ObterGruposByServidorAsync(Guid idCidadao);
        //Task<ICollection<OrganizacaoModel>> ObterPatriarcasHabilitadosAsync();
        
        //Task<ICollection<T>> RemoverAgentesPatriarcasDesabilitados<T>(ICollection<T> agentes) where T : AgenteModel;
    }
}