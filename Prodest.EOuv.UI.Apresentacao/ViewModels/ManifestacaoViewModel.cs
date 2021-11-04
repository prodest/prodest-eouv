using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
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
        public int IdManifestacao { get; set; }

        public string NumProtocolo { get; set; }
        public int IdOrgaoResponsavel { get; set; }
        public int? IdUsuarioAnalise { get; set; }
        public int IdTipoManifestacao { get; set; }
        public int IdTipoIdentificacao { get; set; }
        public int? IdTipoManifestante { get; set; }
        public int IdAssunto { get; set; }
        public int IdOrgaoInteresse { get; set; }
        public int? IdCanalEntrada { get; set; }
        public int? IdModoResposta { get; set; }
        public int IdSituacaoManifestacao { get; set; }

        public virtual TipoManifestacaoViewModel TipoManifestacao { get; set; }
        public virtual SituacaoManifestacaoViewModel SituacaoManifestacao { get; set; }
        public virtual OrgaoViewModel OrgaoResponsavel { get; set; }
        public virtual OrgaoViewModel OrgaoInteresse { get; set; }
        public virtual AssuntoViewModel Assunto { get; set; }
        public DateTime DataRegistro { get; set; }

        public string DataRegistroFormat
        {
            get { return DataRegistro.ToString("dd/MM/yyyy"); }
        }

        public DateTime PrazoResposta { get; set; }

        public string PrazoRespostaFormat
        {
            get { return PrazoResposta.ToString("dd/MM/yyyy"); }
        }

        public virtual UsuarioViewModel UsuarioCadastrador { get; set; }

        public string RegistradoPorFormat
        {
            get { return UsuarioCadastrador != null ? UsuarioCadastrador.Pessoa.Nome : "Cidadão"; }
        }

        public virtual CanalEntradaViewModel CanalEntrada { get; set; }
        public virtual ModoRespostaViewModel ModoResposta { get; set; }

        //Teor da Manifestação-----------------------------------------------------------
        public string TextoManifestacao { get; set; }

        public virtual MunicipioViewModel Municipio { get; set; }

        public string MunicipioLocalFatoFormat
        {
            get { return Municipio != null ? Municipio.DescMunicipio : "Todo o Estado"; }
        }

        public List<AnexoManifestacaoViewModel> AnexoManifestacao { get; set; }
        public List<ComplementoManifestacaoViewModel> ComplementoManifestacao { get; set; }

        //Dados do Manifestante-----------------------------------------------------------
        public virtual TipoIdentificacaoViewModel TipoIdentificacao { get; set; }

        public virtual TipoManifestanteViewModel TipoManifestante { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual PessoaJuridicaViewModel PessoaJuridica { get; set; }

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
        public List<ReclamacaoOmissaoViewModel> ReclamacaoOmissaoManifestacaoPai { get; set; }
        public List<RecursoNegativaViewModel> RecursoNegativa { get; set; }
        public List<DesdobramentoManifestacaoViewModel> DesdobramentoManifestacaoManifestacaoPai { get; set; }
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

        public string DtComplementoFormat
        {
            get { return DtComplemento.ToString("dd/MM/yyyy"); }
        }

        public UsuarioViewModel UsuarioLeitura { get; set; }
        public DateTime DtLeitura { get; set; }

        public string DtLeituraFormat
        {
            get { return DtLeitura.ToString("dd/MM/yyyy"); }
        }

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

        public string SexoFormat
        {
            get { return Sexo == "M" ? "Masculino" : "Feminino"; }
        }

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

        public string PrazoOriginalFormat
        {
            get { return PrazoOriginal.ToString("dd/MM/yyyy"); }
        }

        public DateTime NovoPrazo { get; set; }

        public string NovoPrazoFormat
        {
            get { return NovoPrazo.ToString("dd/MM/yyyy"); }
        }

        public OrgaoViewModel Orgao { get; set; }
        public string TxtJustificativaProrrogacao { get; set; }
        public DateTime DataProrrogacao { get; set; }

        public string DataProrrogacaoFormat
        {
            get { return DataProrrogacao.ToString("dd/MM/yyyy"); }
        }
    }

    public partial class DiligenciaManifestacaoViewModel
    {
        public string TxtDiligencia { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public DateTime DataDiligencia { get; set; }

        public string DataDiligenciaFormat
        {
            get { return DataDiligencia.ToString("dd/MM/yyyy"); }
        }

        public string TxtRespostaDiligencia { get; set; }
        public DateTime DataRespostaDiligencia { get; set; }

        public string DataRespostaDiligenciaFormat
        {
            get { return DataRespostaDiligencia.ToString("dd/MM/yyyy"); }
        }

        //public List<AnexoManifestacaoViewModel> AnexoRespostaDiligencia { get; set; }
    }

    public partial class EncaminhamentoManifestacaoViewModel
    {
        public OrgaoViewModel OrgaoOrigem { get; set; }
        public OrgaoViewModel OrgaoDestino { get; set; }
        public string TxtEncaminhamento { get; set; }
        public DateTime DataEncaminhamento { get; set; }

        public string DataEncaminhamentoFormat
        {
            get { return DataEncaminhamento.ToString("dd/MM/yyyy"); }
        }
    }

    public partial class RespostaManifestacaoViewModel
    {
        public string TxtResposta { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public DateTime DataResposta { get; set; }

        public string DataRespostaFormat
        {
            get { return DataResposta.ToString("dd/MM/yyyy"); }
        }

        //public List<AnexoManifestacaoViewModel> AnexoResposta { get; set; }
    }

    public partial class ApuracaoManifestacaoViewModel
    {
        public string TxtSolicitacaoApuracao { get; set; }
        public DateTime DataSolicitacaoApuracao { get; set; }

        public string DataSolicitacaoApuracaoFormat
        {
            get { return DataSolicitacaoApuracao.ToString("dd/MM/yyyy"); }
        }

        public string TxtRespostaApuracao { get; set; }
        public DateTime DataRespostaApuracao { get; set; }

        public string DataRespostaApuracaoFormat
        {
            get { return DataRespostaApuracao.ToString("dd/MM/yyyy"); }
        }

        //public List<AnexoManifestacaoViewModel> AnexoApuracao { get; set; }
    }

    public partial class DespachoManifestacaoViewModel
    {
        public int IdDespachoManifestacao { get; set; }
        public int IdManifestacao { get; set; }
        public int IdOrgao { get; set; }
        public string TextoSolicitacaoDespacho { get; set; }
        public int IdUsuarioSolicitacaoDespacho { get; set; }
        public DateTime DataSolicitacaoDespacho { get; set; }

        public string DataSolicitacaoDespachoFormat
        {
            get { return DataSolicitacaoDespacho.ToString("dd/MM/yyyy"); }
        }

        public DateTime PrazoResposta { get; set; }

        public string PrazoRespostaFormat
        {
            get { return PrazoResposta.ToString("dd/MM/yyyy"); }
        }

        public string ProtocoloEdocs { get; set; }
        public Guid? IdEncaminhamento { get; set; }
        public int IdAgenteDestinatario { get; set; }
        public int IdAgenteResposta { get; set; }
        public DateTime? DataRespostaDespacho { get; set; }

        public string DataRespostaDespachoFormat
        {
            get
            {
                return DataRespostaDespacho != null ? DataRespostaDespacho.Value.ToString("dd/MM/yyyy") : "";
            }
        }

        public string IdSituacaoDespacho { get; set; }
        public virtual OrgaoViewModel Orgao { get; set; }
        public virtual UsuarioViewModel UsuarioSolicitacaoDespacho { get; set; }
        public virtual AgenteManifestacaoViewModel AgenteDestinatario { get; set; }
        public virtual AgenteManifestacaoViewModel AgenteResposta { get; set; }
        public virtual SituacaoDespachoViewModel SituacaoDespacho { get; set; }

        public string AgenteDestinatarioFormat
        {
            get
            {
                if (AgenteDestinatario != null)
                {
                    if (AgenteDestinatario.TipoAgente == (int)Enums.TipoAgente.Papel)
                    {
                        return AgenteDestinatario.NomeUsuario;
                    }
                    else if (AgenteDestinatario.TipoAgente == (int)Enums.TipoAgente.Grupo)
                    {
                        return AgenteDestinatario.NomeGrupo;
                    }
                    else if (AgenteDestinatario.TipoAgente == (int)Enums.TipoAgente.Unidade)
                    {
                        return AgenteDestinatario.NomeSetor;
                    }
                }
                return "";
            }
        }
    }

    public partial class NotificacaoManifestacaoViewModel
    {
        public string TxtNotificacao { get; set; }
        public DateTime DataNotificacao { get; set; }

        public string DataNotificacaoFormat
        {
            get { return DataNotificacao.ToString("dd/MM/yyyy"); }
        }

        //public List<AnexoManifestacaoViewModel> AnexoNotificacao { get; set; }
    }

    public partial class AnotacaoManifestacaoViewModel
    {
        public string TxtAnotacao { get; set; }
        public DateTime DataAnotacao { get; set; }

        public string DataAnotacaoFormat
        {
            get { return DataAnotacao.ToString("dd/MM/yyyy"); }
        }
    }

    public partial class InterpelacaoManifestacaoViewModel
    {
        public string TxtInterpelacao { get; set; }
        public DateTime DataInterpelacao { get; set; }

        public string DataInterpelacaoFormat
        {
            get { return DataInterpelacao.ToString("dd/MM/yyyy"); }
        }

        public string TxtRespostaInterpelacao { get; set; }
        public OrgaoViewModel OrgaoResposta { get; set; }
        public DateTime DataRespostaInterpelacao { get; set; }

        public string DataRespostaInterpelacaoFormat
        {
            get { return DataRespostaInterpelacao.ToString("dd/MM/yyyy"); }
        }

        public SituacaoInterpelacaoViewModel SituacaoInterpelacao { get; set; }

        //public List<AnexoManifestacaoViewModel> AnexoInterpelacao { get; set; }
    }

    public partial class ReclamacaoOmissaoViewModel
    {
        public DateTime DataReclamacaoOmissao { get; set; }

        public string DataReclamacaoOmissaoFormat
        {
            get { return DataReclamacaoOmissao.ToString("dd/MM/yyyy"); }
        }

        public ManifestacaoSimplificadaViewModel ManifestacaoFilha { get; set; }
        public ManifestacaoSimplificadaViewModel ManifestacaoPai { get; set; }
    }

    public partial class RecursoNegativaViewModel
    {
        public string NumeroRecurso { get; set; }
        public string TxtRecursoNegativa { get; set; }

        //public List<AnexoManifestacaoViewModel> AnexoRecurso { get; set; }
        public DateTime DataRecursoNegativa { get; set; }

        public string DataRecursoNegativaFormat
        {
            get { return DataRecursoNegativa.ToString("dd/MM/yyyy"); }
        }

        public string TxtRespostaRecursoNegativa { get; set; }

        //public List<AnexoManifestacaoViewModel> AnexoRespostaRecurso { get; set; }
        public DateTime DataRespostaRecursoNegativa { get; set; }

        public string DataRespostaRecursoNegativaFormat
        {
            get { return DataRespostaRecursoNegativa.ToString("dd/MM/yyyy"); }
        }
    }

    public partial class DesdobramentoManifestacaoViewModel
    {
        public virtual ManifestacaoSimplificadaViewModel ManifestacaoFilha { get; set; }
        public OrgaoViewModel Orgao { get; set; }
        public DateTime DataDesdobramento { get; set; }

        public string DataDesdobramentoFormat
        {
            get { return DataDesdobramento.ToString("dd/MM/yyyy"); }
        }
    }

    public partial class HistoricoManifestacaoViewModel
    {
        public DateTime DataHistorico { get; set; }

        public string DataHistoricoFormat
        {
            get { return DataHistorico.ToString("dd/MM/yyyy"); }
        }

        public OrgaoViewModel Orgao { get; set; }
        public SituacaoManifestacaoViewModel SituacaoManifestacao { get; set; }
    }

    public partial class OrgaoViewModel
    {
        public Guid GuidOrgao { get; set; }
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

    public partial class ResultadoRespostaViewModel
    {
        public int IdResultadoResposta { get; set; }
        public string DescResultadoResposta { get; set; }
        public string ClassificacaoResultadoResposta { get; set; }
    }

    public partial class AgenteManifestacaoViewModel
    {
        public int IdAgenteManifestacao { get; set; }
        public int TipoAgente { get; set; }
        public string GuidUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public Guid? GuidPapel { get; set; }
        public string NomePapel { get; set; }
        public Guid? GuidGrupo { get; set; }
        public string NomeGrupo { get; set; }
        public Guid? GuidSetor { get; set; }
        public string NomeSetor { get; set; }
        public string SiglaSetor { get; set; }
        public Guid? GuidOrgao { get; set; }
        public string NomeOrgao { get; set; }
        public string SiglaOrgao { get; set; }
        public Guid? GuidPatriarca { get; set; }
        public string NomePatriarca { get; set; }
        public string SiglaPatriarca { get; set; }
    }

    public partial class SituacaoDespachoViewModel
    {
        public int IdSituacaoDespacho { get; set; }
        public string DescSituacaoDespacho { get; set; }
    }

    public partial class SituacaoInterpelacaoViewModel
    {
        public int IdSituacaoInterpelacao { get; set; }
        public string DescSituacaoInterpelacao { get; set; }
    }
}