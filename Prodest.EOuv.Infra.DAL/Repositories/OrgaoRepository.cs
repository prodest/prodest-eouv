﻿using AutoMapper;
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
    public class OrgaoRepository : IOrgaoRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public OrgaoRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<OrgaoModel> ObterOrgaoPorId(int idOrgao)
        {
            Orgao orgao = await _eouvContext.Orgao.Where(o => o.IdOrgao == idOrgao).AsNoTracking().FirstOrDefaultAsync();

            var retorno = _mapper.Map<OrgaoModel>(orgao);
            return retorno;
        }

        public async Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato()
        {
            List<Orgao> listaOrgaosCompetenciaFato = await _eouvContext.Orgao.Where(m => m.IndAtivo == true || m.IndOutrasCompetencias == true)
                                                                             .OrderBy(o => o.SiglaOrgao).OrderBy(o => o.IndOutrasCompetencias)
                                                                             .AsNoTracking().ToListAsync();

            return _mapper.Map<List<OrgaoModel>>(listaOrgaosCompetenciaFato);
        }

        //public async Task<List<int>> ObterIdOrgaosVinculadosByOrgaoResponsavel(int idOrgao)
        //{
        //    Ouvidoria ouvidoria = _eouvContext.Ouvidoria.Include(o => o.Ouvi).Where(o => o.Id.IdOrgao == idOrgao).FirstOrDefault();

        //    if (ouvidoria == null)
        //    {
        //        return null;
        //    }
        //    else if (ouvidoria.OrgaoResponsavel.Count < 1)
        //    {
        //        return null;
        //    }

        //    return ouvidoria.Orgaos.Select(o => o.IdOrgao).ToList();
        //}


    }
}