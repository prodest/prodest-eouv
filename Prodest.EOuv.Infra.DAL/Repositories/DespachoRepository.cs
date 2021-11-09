using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<DespachoManifestacaoModel> ObterDespachoPorId(int IdDespachoManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao)
                                                                                .AsNoTracking().FirstOrDefaultAsync();
            var retorno = _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
            return retorno;
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int idManifestacao)
        {
            List<DespachoManifestacao> despachoManifestacao = await _eouvContext.DespachoManifestacao.Include(d => d.SituacaoDespacho)
                                                                                .Include(d => d.AgenteDestinatario)
                                                                                .Where(d => d.IdManifestacao == idManifestacao)
                                                                                .AsNoTracking().ToListAsync();
            var retorno = _mapper.Map<List<DespachoManifestacaoModel>>(despachoManifestacao);
            return retorno;
        }

        public async Task<List<Guid?>> ObterIdEncaminhamentoDespachoPorManifestacao(int idManifestacao)
        {
            List<Guid?> listaIdEncaminhamentoDespachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdManifestacao == idManifestacao)
                                                                                    .Select(d => d.IdEncaminhamento)
                                                                                    .ToListAsync();
            var retorno = listaIdEncaminhamentoDespachoManifestacao;
            return retorno;
        }

        public async Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao)
                                                                              .Include(d => d.AgenteDestinatario)
                                                                              .AsNoTracking()
                                                                              .FirstOrDefaultAsync();
            var retorno = _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
            _eouvContext.Entry(despachoManifestacao).State = EntityState.Detached;
            return retorno;
        }

        public async Task<List<int>> ObterDespachosEmAberto()
        {
            var idManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdSituacaoDespacho == (int)Enums.SituacaoDespacho.Aberto)
                                                                              .Select(d => d.IdDespachoManifestacao)
                                                                              .ToListAsync();
            var retorno = _mapper.Map<List<int>>(idManifestacao);
            return retorno;
        }

        public async Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacaoModel)
        {
            _eouvContext.DespachoManifestacao.Add(_mapper.Map<DespachoManifestacao>(despachoManifestacaoModel));
            await _eouvContext.SaveChangesAsync();
        }

        public async Task AtualizarDespacho(DespachoManifestacaoModel despachoManifestacaoModel)
        {
            DespachoManifestacao despachoManifestacao = _mapper.Map<DespachoManifestacao>(despachoManifestacaoModel);
            _eouvContext.Update(despachoManifestacao);
            await _eouvContext.SaveChangesAsync();
        }
    }
}