using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.UI.Apresentacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prodest.EOuv.UI.Apresentacao
{
    public partial class ManifestacaoViewModel
    {
        //Dados Básicos da Manifestação-----------------------------------------------------------
        public string NumProtocolo { get; set; }

        public virtual TipoManifestacaoViewModel TipoManifestacao { get; set; }
        public virtual SituacaoManifestacaoViewModel SituacaoManifestacao { get; set; }
        public virtual OrgaoViewModel OrgaoResponsavel { get; set; }
        public virtual OrgaoViewModel OrgaoInteresse { get; set; }
        public virtual AssuntoViewModel Assunto { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? PrazoResposta { get; set; }
        public virtual UsuarioViewModel UsuarioCadastrador { get; set; }
        public virtual CanalEntradaViewModel CanalEntrada { get; set; }
        public virtual ModoRespostaViewModel ModoResposta { get; set; }

        //Teor da Manifestação-----------------------------------------------------------
        public string TextoManifestacao { get; set; }

        public virtual MunicipioViewModel Municipio { get; set; }
        public List<AnexoManifestacaoViewModel> AnexoManifestacao { get; set; }
        public List<ComplementoManifestacaoViewModel> ComplementoManifestacao { get; set; }

        //Dados do Manifestante-----------------------------------------------------------
        public virtual TipoIdentificacaoViewModel TipoIdentificacao { get; set; }

        public virtual TipoManifestanteViewModel TipoManifestante { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        //Dados de Análise-----------------------------------------------------------
        public List<ProrrogacaoManifestacaoViewModel> ProrrogacaoManifestacao { get; set; }

        public List<DiligenciaManifestacaoViewModel> DiligenciaManifestacao { get; set; }
        public List<EncaminhamentoManifestacaoViewModel> EncaminhamentoManifestacao { get; set; }
        public List<RespostaManifestacaoViewModel> RespostaManifestacao { get; set; }
        public List<ApuracaoManifestacaoViewModel> ApuracaoManifestacao { get; set; }
        public List<DespachoManifestacaoViewModel> DespachoManifestacao { get; set; }
        public List<NotificacaoManifestacaoViewModel> NotificacaoManifestacao { get; set; }
        public List<AnotacaoManifestacaoViewModel> AnotacaoManifestacao { get; set; }
        public List<InterpelacaoManifestacaoViewModel> InterpelacaoManifestacao { get; set; }
        public List<ReclamacaoOmissaoViewModel> ReclamacaoOmissao { get; set; }
        public List<RecursoNegativaViewModel> RecursoNegativa { get; set; }
        public List<DesdobramentoManifestacaoViewModel> DesdobramentoManifestacao { get; set; }
        public List<HistoricoManifestacaoViewModel> HistoricoManifestacao { get; set; }
    }

    public partial class AnexoManifestacaoViewModel
    {
        public string NomeArquivo { get; set; }
        public int IdTipoAnexoManifestacao { get; set; }
        public List<ArquivoFisicoAnexoManifestacaoViewModel> ArquivoFisicoAnexoManifestacao { get; set; }
    }

    public partial class ArquivoFisicoAnexoManifestacaoViewModel
    {
        public byte[] Conteudo { get; set; }
    }

    public partial class ComplementoManifestacaoViewModel
    {
        public string TxtComplemento { get; set; }
        public DateTime DtComplemento { get; set; }
        //public List<AnexoManifestacaoViewModel> AnexoComplemento { get; set; }
    }

    public partial class PessoaViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public int? IdMunicipio { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public virtual MunicipioViewModel Municipio { get; set; }
    }

    public partial class PessoaJuridicaViewModel
    {
        public string NumCnpj { get; set; }
        public string OrgaoEmpresa { get; set; }
    }

    public partial class ProrrogacaoManifestacaoViewModel
    {
        public DateTime PrazoOriginal { get; set; }
        public string NovoPrazo { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public string TxtJustificativaProrrogacao { get; set; }
        public string DataProrrogacao { get; set; }
    }

    public partial class DiligenciaManifestacaoViewModel
    {
        public string TxtDiligencia { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public string DataDiligencia { get; set; }
        public string TxtRespostaDiligencia { get; set; }
        public string DataRespostaDiligencia { get; set; }
        //public List<AnexoManifestacaoViewModel> AnexoRespostaDiligencia { get; set; }
    }

    public partial class EncaminhamentoManifestacaoViewModel
    {
        public OrgaoViewModel OrgaoOrigem { get; set; }
        public OrgaoViewModel OrgaoDestino { get; set; }
        public string TxtEncaminhamento { get; set; }
        public string DataEncaminhamento { get; set; }
    }

    public partial class RespostaManifestacaoViewModel
    {
        public string TxtResposta { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public string DataResposta { get; set; }
        //public List<AnexoManifestacaoViewModel> AnexoResposta { get; set; }
    }

    public partial class ApuracaoManifestacaoViewModel
    {
        public string TxtSolicitacaoApuracao { get; set; }
        public string DataSolicitacaoApuracao { get; set; }
        public string TxtRespostaApuracao { get; set; }
        public string DataRespostaApuracao { get; set; }
        //public List<AnexoManifestacaoViewModel> AnexoApuracao { get; set; }
    }

    public partial class NotificacaoManifestacaoViewModel
    {
        public string TxtNotificacao { get; set; }
        public string DataNotificacao { get; set; }
        //public List<AnexoManifestacaoViewModel> AnexoNotificacao { get; set; }
    }

    public partial class AnotacaoManifestacaoViewModel
    {
        public string TxtAnotacao { get; set; }
        public string DataAnotacao { get; set; }
    }

    public partial class InterpelacaoManifestacaoViewModel
    {
        public string TxtInterpelacao { get; set; }
        public string DataInterpelacao { get; set; }
        public string TxtRespostaInterpelacao { get; set; }
        public OrgaoViewModel OrgaoResposta { get; set; }
        public string DataRespostaInterpelacao { get; set; }
        //public List<AnexoManifestacaoViewModel> AnexoInterpelacao { get; set; }
    }

    public partial class ReclamacaoOmissaoViewModel
    {
        public string DataReclamacaoOmissao { get; set; }
        public ManifestacaoSimplificadaViewModel ManifestacaoFilha { get; set; }
        public ManifestacaoSimplificadaViewModel ManifestacaoPai { get; set; }
    }

    public partial class RecursoNegativaViewModel
    {
        public string NumeroRecurso { get; set; }
        public string TxtRecursoNegativa { get; set; }

        //public List<AnexoManifestacaoViewModel> AnexoRecurso { get; set; }
        public string DataRecursoNegativa { get; set; }

        public string TxtRespostaRecursoNegativa { get; set; }

        //public List<AnexoManifestacaoViewModel> AnexoRespostaRecurso { get; set; }
        public string DataRespostaRecursoNegativa { get; set; }
    }

    public partial class DesdobramentoManifestacaoViewModel
    {
        public virtual ManifestacaoSimplificadaViewModel ManifestacaoFilha { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public string DataDesdobramento { get; set; }
    }

    public partial class HistoricoManifestacaoViewModel
    {
        public string DataHistorico { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public SituacaoManifestacaoViewModel SituacaoManifestacao { get; set; }
    }

    public partial class OrgaoViewModel
    {
        public string SiglaOrgao { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
    }

    public partial class SituacaoManifestacaoViewModel
    {
        public string DescSituacaoManifestacao { get; set; }
    }

    public partial class ManifestacaoSimplificadaViewModel
    {
        public string NumProtocolo { get; set; }
    }

    public partial class AssuntoViewModel
    {
        public string DescAssunto { get; set; }
    }

    public partial class CanalEntradaViewModel
    {
        public string DescCanalEntrada { get; set; }
    }

    public partial class ModoRespostaViewModel
    {
        public string DescModoResposta { get; set; }
    }

    public partial class TipoIdentificacaoViewModel
    {
        public string DescTipoIdentificacao { get; set; }
    }

    public partial class TipoManifestacaoViewModel
    {
        public string DescTipoManifestacao { get; set; }
    }

    public partial class TipoManifestanteViewModel
    {
        public string DescTipoManifestante { get; set; }
    }

    public partial class UsuarioViewModel
    {
        public virtual OrgaoViewModel Orgao { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
    }

    public partial class MunicipioViewModel
    {
        public string DescMunicipio { get; set; }
        public string SigUf { get; set; }
        public virtual UfViewModel Uf { get; set; }
    }

    public partial class UfViewModel
    {
        public string DescUf { get; set; }
    }
}