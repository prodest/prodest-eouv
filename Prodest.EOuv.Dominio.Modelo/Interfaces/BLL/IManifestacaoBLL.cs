using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IManifestacaoBLL
    {
        Task<ManifestacaoModel> ObterDadosCompletosManifestacao(int idManifestacao);

        Task<ManifestacaoModel> ObterDadosFiltradosManifestacao(int idManifestacao, FiltroDadosManifestacaoModel filtroDadosManifestacao);

        Task<ManifestacaoModel> ObterDadosBasicosManifestacao(int idManifestacao);

        Task<List<AnexoManifestacaoModel>> ObterAnexosManifestacao(int idManifestacao);

        Task<List<ComplementoManifestacaoModel>> ObterDadosComplemento(int idManifestacao);

        Task<PessoaModel> ObterDadosPessoa(int idPessoa);

        Task<PessoaJuridicaModel> ObterDadosPessoaJuridica(int idPessoaJuridica);

        Task<MunicipioModel> ObterDadosMunicipio(int idMunicipio);

        Task<List<RespostaManifestacaoModel>> ObterDadosResposta(int idManifestacao);

        Task<List<ProrrogacaoManifestacaoModel>> ObterDadosProrrogacao(int idManifestacao);

        Task<List<ApuracaoManifestacaoModel>> ObterDadosApuracao(int idManifestacao);

        Task<List<EncaminhamentoManifestacaoModel>> ObterDadosEncaminhamento(int idManifestacao);

        Task<List<DespachoManifestacaoModel>> ObterDadosDespacho(int idManifestacao);

        Task<List<DesdobramentoManifestacaoModel>> ObterDadosDesdobramento(int idManifestacao);

        Task<List<DiligenciaManifestacaoModel>> ObterDadosDiligencia(int idManifestacao);

        Task<List<InterpelacaoManifestacaoModel>> ObterDadosInterpelacao(int idManifestacao);

        Task<List<NotificacaoManifestacaoModel>> ObterDadosNotificacao(int idManifestacao);

        Task<List<AnotacaoManifestacaoModel>> ObterDadosAnotacao(int idManifestacao);

        Task<List<ReclamacaoOmissaoModel>> ObterDadosReclamacaoOmissao(int idManifestacao);

        Task<List<RecursoNegativaModel>> ObterDadosRecursoNegativa(int idManifestacao);

        Task<List<HistoricoManifestacaoModel>> ObterDadosHistorico(int idManifestacao);
    }
}