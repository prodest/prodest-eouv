using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IDespachoWorkService
    {
        Task<List<DespachoManifestacaoViewModel>> ObterDespachosPorManifestacao(int idManifestacao);

        Task AdicionarDespacho(DespachoManifestacaoViewModel despachoViewModel);
    }

    public class DespachoWorkService : IDespachoWorkService
    {
        private readonly IDespachoBLL _despachoBLL;
        private readonly IMapper _mapper;

        public DespachoWorkService(IDespachoBLL despachoBLL, IMapper mapper)
        {
            _despachoBLL = despachoBLL;
            _mapper = mapper;
        }

        public async Task<List<DespachoManifestacaoViewModel>> ObterDespachosPorManifestacao(int idManifestacao)
        {
            var despachoModel = await _despachoBLL.ObterDespachosPorManifestacao(idManifestacao);
            var despachoViewModel = _mapper.Map<List<DespachoManifestacaoViewModel>>(despachoModel);
            return despachoViewModel;
        }

        public async Task AdicionarDespacho(DespachoManifestacaoViewModel despachoViewModel)
        {
            var despachoModel = _mapper.Map<DespachoManifestacaoModel>(despachoViewModel);
            await _despachoBLL.AdicionarDespacho(despachoModel);
        }
    }
}