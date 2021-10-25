using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IDespachoWorkService
    {
        Task<List<DespachoManifestacaoViewModel>> ObterDespachosPorManifestacao(int idManifestacao);

        Task AdicionarDespacho(DespachoManifestacaoViewModel despachoViewModel);

        Task Despachar(DespachoManifestacaoEntry despachoEntry);
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

        public async Task Despachar(DespachoManifestacaoEntry despachoEntry)
        {
            //validações de tela
            //Validar campo prazo preenchido
            //Validar campo texto preenchido
            //Validar anexos
            //Validar destinatario preenchido
            //Validar papel responsavel preenchido

            //Converter Entry para Model
            DespachoManifestacaoModel despachoModel = new DespachoManifestacaoModel();
            despachoModel.IdManifestacao = despachoEntry.IdManifestacao;
            despachoModel.DataSolicitacaoDespacho = Convert.ToDateTime(DateTime.Now);
            despachoModel.PrazoResposta = Convert.ToDateTime(despachoEntry.PrazoResposta);
            despachoModel.TextoSolicitacaoDespacho = despachoEntry.TextoDespacho;

            var filtroDadosSelecionados = _mapper.Map<FiltroDadosManifestacaoModel>(despachoEntry.FiltroDadosManifestacaoSelecionados);

            string papelResponsavel = despachoEntry.GuidPapelResponsavel;
            string papelDestinatario = despachoEntry.GuidPapelDestinatario;

            await _despachoBLL.Despachar(despachoModel, papelDestinatario, papelResponsavel, filtroDadosSelecionados);
        }
    }
}