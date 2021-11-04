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

        public async Task<AgenteManifestacaoModel> MontaAgenteSetor(string idAgente)
        {
            SetorModel setor = await _setorRepository.BuscarSetor(idAgente);

            AgenteManifestacaoModel agente = new AgenteManifestacaoModel();

            if (setor != null)
            {
                agente.GuidSetor = new Guid(idAgente);
                agente.NomeSetor = setor.NomeSetor;
                agente.SiglaSetor = setor.SiglaSetor;
                agente.GuidOrgao = setor.Orgao.GuidOrgao;
                agente.NomeOrgao = setor.Orgao.RazaoSocial;
                agente.SiglaOrgao = setor.Orgao.SiglaOrgao;
                agente.TipoAgente = (int)Enums.TipoAgente.Unidade;
            }

            return agente;
        }

        public async Task<AgenteManifestacaoModel> MontaAgenteGrupoComissao(string idAgente)
        {
            AgentePublicoPapelModel grupo = await _acessoCidadaoService.GetGrupo(idAgente);

            AgenteManifestacaoModel agente = new AgenteManifestacaoModel();

            if (grupo != null)
            {
                agente.GuidGrupo = new Guid(idAgente);
                agente.NomeGrupo = grupo.Nome;
                agente.TipoAgente = (int)Enums.TipoAgente.Grupo;
            }

            //TODO: Buscar informações de Setor e Orgao do Grupo

            return agente;
        }

        public async Task<AgenteManifestacaoModel> MontaAgenteUsuario(string idAgente)
        {
            AgentePublicoPapelModel papel = await _acessoCidadaoService.GetPapel(idAgente);
            SetorModel setor = null;
            if (papel != null && !String.IsNullOrEmpty(papel.LotacaoGuid))
            {
                setor = await _setorRepository.BuscarSetor(papel.LotacaoGuid);
            }
            AgenteManifestacaoModel agente = new AgenteManifestacaoModel
            {
                GuidPapel = new Guid(idAgente),
                NomePapel = papel.Nome,
                GuidUsuario = papel.AgentePublicoSub,
                NomeUsuario = papel.AgentePublicoNome,
                GuidSetor = new Guid(papel.LotacaoGuid),
                TipoAgente = (int)Enums.TipoAgente.Papel
            };
            if (setor is not null)
            {
                agente.NomeSetor = setor.NomeSetor;
                agente.SiglaSetor = setor.SiglaSetor;
                agente.GuidOrgao = setor.Orgao.GuidOrgao;
                agente.NomeOrgao = setor.Orgao.RazaoSocial;
                agente.SiglaOrgao = setor.Orgao.SiglaOrgao;
                /*
                //TODO: Adicionar Dados do Patriarca na API de Carga do Organograma no eOuv antigo
                AgenteResposta.GuidPatriarca = setor.Orgao.Patriaca.Guid;
                AgenteResposta.NomePatriarca = setor.Orgao.Patriaca.RazaoSocial;
                AgenteResposta.SiglaPatriarca = setor.Orgao.Patriaca.Sigla;
                */
                agente.GuidPatriarca = new Guid("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");
                agente.NomePatriarca = "ESTADO DO ESPIRITO SANTO";
                agente.SiglaPatriarca = "GOVES";
            }
            return agente;
        }
    }
}