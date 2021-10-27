using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IRespostaWorkService
    {
        Task<List<ResultadoRespostaViewModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao);

        Task<List<OrgaoViewModel>> ObterOrgaosCompetenciaFato();

        Task ResponderManifestacao(RespostaManifestacaoEntry respostaEntry);
    }

    public class RespostaWorkService : IRespostaWorkService
    {
        private readonly IRespostaBLL _respostaBLL;
        private readonly IMapper _mapper;

        public RespostaWorkService(IRespostaBLL respostaBLL, IMapper mapper)
        {
            _respostaBLL = respostaBLL;
            _mapper = mapper;
        }

        public async Task<List<ResultadoRespostaViewModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao)
        {
            List<ResultadoRespostaModel> listaResultadosRespostaModel = await _respostaBLL.ObterResultadosRespostaPorTipologia(idTipoManifestacao);
            List<ResultadoRespostaViewModel> listaResultadosRespostaViewModel = _mapper.Map<List<ResultadoRespostaViewModel>>(listaResultadosRespostaModel);
            return listaResultadosRespostaViewModel;
        }

        public async Task<List<OrgaoViewModel>> ObterOrgaosCompetenciaFato()
        {
            List<OrgaoModel> listaOrgaosCompetenciaFatoModel = await _respostaBLL.ObterOrgaosCompetenciaFato();
            List<OrgaoViewModel> listaOrgaosCompetenciaFatoViewModel = _mapper.Map<List<OrgaoViewModel>>(listaOrgaosCompetenciaFatoModel);
            return listaOrgaosCompetenciaFatoViewModel;
        }

        public async Task ResponderManifestacao(RespostaManifestacaoEntry respostaEntry)
        {
            //TODO: validações de tela
            //Validar campo prazo preenchido
            //Validar campo texto preenchido
            //Validar anexos
            //Validar destinatario preenchido
            //Validar papel responsavel preenchido

            RespostaManifestacaoEntryModel respostaEntryModel = _mapper.Map<RespostaManifestacaoEntryModel>(respostaEntry);

            await _respostaBLL.ResponderManifestacao(respostaEntryModel);
        }
    }
}