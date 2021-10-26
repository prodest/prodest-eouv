using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.DAL
{
    public class AgenteRepository : IAgenteRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public AgenteRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<int> AdicionarAgente(AgenteManifestacaoModel agente)
        {
            var agenteManifestacao = _mapper.Map<AgenteManifestacao>(agente);
            _eouvContext.AgenteManifestacao.Add(agenteManifestacao);
            await _eouvContext.SaveChangesAsync();
            return agenteManifestacao.IdAgenteManifestacao;
        }
    }
}