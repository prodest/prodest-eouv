using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.UI.Apresentacao
{
    public interface IManifestacaoWorkService
    {
        Task<ManifestacaoViewModel> ObterDadosCompletosManifestacao(int idManifestacao);
    }

    public class ManifestacaoWorkService : IManifestacaoWorkService
    {
        private readonly IManifestacaoBLL _manifestacaoBLL;
        private readonly IMapper _mapper;

        public ManifestacaoWorkService(IManifestacaoBLL manifestacaoBLL, IMapper mapper)
        {
            _manifestacaoBLL = manifestacaoBLL;
            _mapper = mapper;
        }

        public async Task<ManifestacaoViewModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            var manifestacaoModel = await _manifestacaoBLL.ObterDadosCompletosManifestacao(idManifestacao);

            var manifestacaoViewModel = new ManifestacaoViewModel();

            //Dados Básicos da Manifestação
            manifestacaoViewModel.NumProtocolo = manifestacaoModel.NumProtocolo;
            manifestacaoViewModel.TipoManifestacao = manifestacaoModel.TipoManifestacao?.DescTipoManifestacao;
            manifestacaoViewModel.Situacao = manifestacaoModel.SituacaoManifestacao?.DescSituacaoManifestacao;
            manifestacaoViewModel.OrgaoAtual = _mapper.Map<OrgaoViewModel>(manifestacaoModel.OrgaoResponsavel);
            manifestacaoViewModel.OrgaoDestinatario = _mapper.Map<OrgaoViewModel>(manifestacaoModel.OrgaoInteresse);
            manifestacaoViewModel.Assunto = manifestacaoModel.Assunto?.DescAssunto;
            manifestacaoViewModel.DataRegistro = manifestacaoModel.DataRegistro.ToString();
            manifestacaoViewModel.PrazoResposta = manifestacaoModel.PrazoResposta?.ToString();
            manifestacaoViewModel.UsuarioCadastrador = manifestacaoModel.UsuarioCadastrador?.Pessoa?.Nome;
            manifestacaoViewModel.CanalEntrada = manifestacaoModel.CanalEntrada?.DescCanalEntrada;
            manifestacaoViewModel.ModoResposta = manifestacaoModel.ModoResposta?.DescModoResposta;
            manifestacaoViewModel.TipoIdentificacao = manifestacaoModel.TipoIdentificacao?.DescTipoIdentificacao;

            //Teor da Manifestação
            manifestacaoViewModel.TextoManifestacao = manifestacaoModel.TextoManifestacao;
            manifestacaoViewModel.LocalFato = manifestacaoModel.IdMunicipio.ToString();
            var anexoManifestacao = manifestacaoModel.AnexoManifestacao.Where(a => a.IdTipoAnexoManifestacao == (int)Enums.TipoAnexoManifestacaoOptions.Anexo_Resposta).ToList();
            manifestacaoViewModel.AnexoManifestacao = _mapper.Map<List<AnexoManifestacaoViewModel>>(anexoManifestacao);
            manifestacaoViewModel.ComplementoManifestacao = _mapper.Map<List<ComplementoManifestacaoViewModel>>(manifestacaoModel.ComplementoManifestacao);

            //Dados do Manifestante
            ManifestanteViewModel dadosManifestante = new ManifestanteViewModel();
            dadosManifestante.Nome = manifestacaoModel.Pessoa?.Nome;
            dadosManifestante.Cpf = manifestacaoModel.Pessoa?.Cpf;
            dadosManifestante.Genero = manifestacaoModel.Pessoa?.Sexo;
            dadosManifestante.Telefone = manifestacaoModel.Pessoa?.Telefone;
            dadosManifestante.Email = manifestacaoModel.Pessoa?.Email;
            dadosManifestante.TipoManifestante = manifestacaoModel.TipoManifestante?.DescTipoManifestante;
            dadosManifestante.CNPJ = manifestacaoModel.PessoaJuridica?.NumCnpj;
            dadosManifestante.OrgaoEmpresa = manifestacaoModel.PessoaJuridica?.OrgaoEmpresa;
            dadosManifestante.Cep = manifestacaoModel.Pessoa?.Cep;
            dadosManifestante.Municipio = manifestacaoModel.Pessoa?.Municipio?.DescMunicipio;
            dadosManifestante.UF = manifestacaoModel.Pessoa?.Municipio?.Uf?.SigUf;
            dadosManifestante.Logradouro = manifestacaoModel.Pessoa?.Nome;
            dadosManifestante.Numero = manifestacaoModel.Pessoa?.Numero;
            dadosManifestante.Complemento = manifestacaoModel.Pessoa?.Complemento;
            dadosManifestante.Bairro = manifestacaoModel.Pessoa?.Bairro;

            manifestacaoViewModel.DadosManifestante = _mapper.Map<ManifestanteViewModel>(dadosManifestante);

            //Dados de Análise
            manifestacaoViewModel.ProrrogacaoManifestacao = _mapper.Map<List<ProrrogacaoManifestacaoViewModel>>(manifestacaoModel.ProrrogacaoManifestacao);
            manifestacaoViewModel.DiligenciaManifestacao = _mapper.Map<List<DiligenciaManifestacaoViewModel>>(manifestacaoModel.DiligenciaManifestacao);
            manifestacaoViewModel.EncaminhamentoManifestacao = _mapper.Map<List<EncaminhamentoManifestacaoViewModel>>(manifestacaoModel.EncaminhamentoManifestacao);
            manifestacaoViewModel.RespostaManifestacao = _mapper.Map<List<RespostaManifestacaoViewModel>>(manifestacaoModel.RespostaManifestacao);
            manifestacaoViewModel.ApuracaoManifestacao = _mapper.Map<List<ApuracaoManifestacaoViewModel>>(manifestacaoModel.ApuracaoManifestacao);
            manifestacaoViewModel.DespachoManifestacao = _mapper.Map<List<DespachoManifestacaoViewModel>>(manifestacaoModel.DespachoManifestacao);
            manifestacaoViewModel.NotificacaoManifestacao = _mapper.Map<List<NotificacaoManifestacaoViewModel>>(manifestacaoModel.NotificacaoManifestacao);
            manifestacaoViewModel.AnotacaoManifestacao = _mapper.Map<List<AnotacaoManifestacaoViewModel>>(manifestacaoModel.AnotacaoManifestacao);
            manifestacaoViewModel.InterpelacaoManifestacao = _mapper.Map<List<InterpelacaoManifestacaoViewModel>>(manifestacaoModel.InterpelacaoManifestacao);
            manifestacaoViewModel.ReclamacaoOmissao = _mapper.Map<List<ReclamacaoOmissaoViewModel>>(manifestacaoModel.ReclamacaoOmissaoManifestacaoPai);
            manifestacaoViewModel.RecursoNegativa = _mapper.Map<List<RecursoNegativaViewModel>>(manifestacaoModel.RecursoNegativa);
            manifestacaoViewModel.DesdobramentoManifestacao = _mapper.Map<List<DesdobramentoManifestacaoViewModel>>(manifestacaoModel.DesdobramentoManifestacaoManifestacaoPai);
            manifestacaoViewModel.HistoricoManifestacao = _mapper.Map<List<HistoricoManifestacaoViewModel>>(manifestacaoModel.HistoricoManifestacao);

            return manifestacaoViewModel;
        }
    }
}