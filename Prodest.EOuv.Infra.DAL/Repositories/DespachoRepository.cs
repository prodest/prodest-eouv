using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
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

        public async Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int idManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();
            return _mapper.Map<List<DespachoManifestacaoModel>>(despachoManifestacao);
        }

        public async Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao)
        {
            _eouvContext.Add(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();
        }
    }
}