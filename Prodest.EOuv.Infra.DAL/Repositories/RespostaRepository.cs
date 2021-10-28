using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.DAL
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public RespostaRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<List<ResultadoRespostaModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao)
        {
            List<ResultadoResposta> listaResultadosResposta = await _eouvContext.ResultadoResposta
                                                                                .Join(_eouvContext.ResultadoRespostaTipologia.Where(m => m.IdTipoManifestacao == idTipoManifestacao), res => res.IdResultadoResposta, tip => tip.IdResultadoResposta, (res, tip) => res)
                                                                                .AsNoTracking().ToListAsync();

            return _mapper.Map<List<ResultadoRespostaModel>>(listaResultadosResposta);
        }

        public async Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato()
        {
            List<Orgao> listaOrgaosCompetenciaFato = await _eouvContext.Orgao
                                                                       .Where(m => m.IndAtivo == true || m.IndOutrasCompetencias == true)
                                                                       .OrderBy(o => o.SiglaOrgao).OrderBy(o => o.IndOutrasCompetencias)
                                                                       .AsNoTracking().ToListAsync();

            return _mapper.Map<List<OrgaoModel>>(listaOrgaosCompetenciaFato);
        }

        public async Task<int> AdicionarResposta(RespostaManifestacaoModel respostaModel)
        {
            var resposta = _mapper.Map<RespostaManifestacao>(respostaModel);
            _eouvContext.RespostaManifestacao.Add(resposta);
            await _eouvContext.SaveChangesAsync();
            return resposta.IdRespostaManifestacao;
        }
    }
}