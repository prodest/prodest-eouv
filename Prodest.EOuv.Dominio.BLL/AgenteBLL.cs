using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using System;
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

        public Task<int> AdicionarAgente(AgenteManifestacaoModel agente)
        {
            return _agenteRepository.AdicionarAgente(agente);
        }

        public async Task<AgenteManifestacaoModel> MontaAgente(string idAgente, int tipoAgente)
        {
            AgentePublicoPapelModel papel = await _acessoCidadaoService.GetPapel(idAgente);
            SetorModel setor = null;
            if (papel != null && !String.IsNullOrEmpty(papel.LotacaoGuid))
            {
                setor = await _setorRepository.BuscarSetor(papel.LotacaoGuid);
            }
            AgenteManifestacaoModel AgenteResposta = new AgenteManifestacaoModel
            {
                GuidPapel = new Guid(idAgente),
                NomePapel = papel.Nome,
                GuidUsuario = papel.AgentePublicoSub,
                NomeUsuario = papel.AgentePublicoNome,
                GuidSetor = new Guid(papel.LotacaoGuid),
                Tipo = (byte)tipoAgente
            };
            if (setor is not null)
            {
                AgenteResposta.NomeSetor = setor.NomeSetor;
                AgenteResposta.SiglaSetor = setor.SiglaSetor;
                AgenteResposta.GuidOrgao = setor.Orgao.GuidOrgao;
                AgenteResposta.NomeOrgao = setor.Orgao.RazaoSocial;
                AgenteResposta.SiglaOrgao = setor.Orgao.SiglaOrgao;
                /*
                //TODO: Adicionar Dados do Patriarca na API de Carga do Organograma no eOuv antigo
                AgenteResposta.GuidPatriarca = setor.Orgao.Patriaca.Guid;
                AgenteResposta.NomePatriarca = setor.Orgao.Patriaca.RazaoSocial;
                AgenteResposta.SiglaPatriarca = setor.Orgao.Patriaca.Sigla;
                */
                AgenteResposta.GuidPatriarca = new Guid("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");
                AgenteResposta.NomePatriarca = "ESTADO DO ESPIRITO SANTO";
                AgenteResposta.SiglaPatriarca = "GOVES";
            }
            return AgenteResposta;
        }
    }
}