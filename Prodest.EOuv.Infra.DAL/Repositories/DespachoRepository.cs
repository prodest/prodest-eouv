using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
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
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao).ToListAsync();
            return _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDespachosEmAberto()
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.Situacao == nameof(Enums.SituacaoDespacho.Aberto)).AsNoTracking().ToListAsync();
            return _mapper.Map<List<DespachoManifestacaoModel>>(despachoManifestacao);        
        }

        public async Task ResponderDespacho(int idDespacho, object atorResposta)
        {
            var despachoManifestacao = await ObterDespacho(idDespacho);

            despachoManifestacao.Situacao = nameof(Enums.SituacaoDespacho.Respondido);
            //salva ator resposta
            _eouvContext.Update(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();            
        }
        public async Task<SetorModel> BuscaSetor(string idSetor)
        {
            var setor = await _eouvContext.Setor.Where(d => d.GuidSetor == new Guid(idSetor)).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<SetorModel>(setor);            
        }

        public async Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao)
        {
            _eouvContext.Add(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();
        }
    }
}