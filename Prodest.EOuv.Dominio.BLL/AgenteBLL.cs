using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class AgenteBLL : IAgenteBLL
    {
        private readonly IAgenteRepository _agenteRepository;
        private readonly ISetorRepository _setorRepository;
        private readonly IAcessoCidadaoService _acessoCidadaoService;

        public AgenteBLL(IAgenteRepository agenteRepository, ISetorRepository setorRepository, IAcessoCidadaoService acessoCidadaoService)
        {
            _agenteRepository = agenteRepository;
            _setorRepository = setorRepository;
            _acessoCidadaoService = acessoCidadaoService;
        }

        public async Task<int> AdicionarAgente(AgenteManifestacaoModel agente)
        {
            return await _agenteRepository.AdicionarAgente(agente);
        }

    }
}