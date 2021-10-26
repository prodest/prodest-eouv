using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Prodest.EOuv.Shared.Util.Enums;

namespace Prodest.EOuv.Infra.DAL
{
    public class DespachoRepository : IDespachoRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public DespachoRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int idManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();
            return _mapper.Map<List<DespachoManifestacaoModel>>(despachoManifestacao);
        }

        public async Task<DespachoManifestacaoModel> ObterDespacho(int IdDespachoManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
        }

        public async Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao)
                                                                              .Include(d => d.AgenteDestinatario)
                                                                              .AsNoTracking()
                                                                              .FirstOrDefaultAsync();
            return _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
        }

        public async Task<List<int>> ObterDespachosEmAberto()
        {
            var idManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdSituacaoDespacho == (int)Enums.SituacaoDespacho.Aberto)
                                                                              .Select(d => d.IdDespachoManifestacao)
                                                                              .ToListAsync();
            var retorno = _mapper.Map<List<int>>(idManifestacao);
            return retorno;
        }

        public async Task<int> AdicionarAgente(AgenteManifestacaoModel agente)
        {
            var agenteManifestacao = _mapper.Map<AgenteManifestacao>(agente);
            _eouvContext.AgenteManifestacao.Add(agenteManifestacao);
            await _eouvContext.SaveChangesAsync();
            return agenteManifestacao.IdAgenteManifestacao;
        }

        public async Task AtualizarDespacho(DespachoManifestacaoModel despachoManifestacao)
        {
            _eouvContext.Update(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();
        }

        public async Task<SetorModel> BuscarSetor(string idSetor)
        {
            var setor = await _eouvContext.Setor
                                    .Include(m => m.Orgao)
                                    //.Include(m => m.Orgao.Patriaca)
                                    .Where(d => d.GuidSetor == new Guid(idSetor)).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<SetorModel>(setor);
        }

        public async Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao)
        {
            _eouvContext.Add(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();
        }
    }
}