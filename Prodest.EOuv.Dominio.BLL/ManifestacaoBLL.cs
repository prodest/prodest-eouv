using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class ManifestacaoBLL : IManifestacaoBLL
    {
        private readonly IManifestacaoRepository _manifestacaoRepository;

        public ManifestacaoBLL(IManifestacaoRepository manifestacaoRepository)
        {
            _manifestacaoRepository = manifestacaoRepository;
        }

        public async Task<bool> ExisteManifestacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ExisteManifestacao(idManifestacao);
        }

        public async Task<ManifestacaoModel> ObterManifestacaoPorId(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterManifestacaoPorId(idManifestacao);
        }

        public async Task<ManifestacaoModel> ObterDadosBasicosManifestacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosBasicosManifestacao(idManifestacao);
        }

        public async Task<List<AnexoManifestacaoModel>> ObterAnexosManifestacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterAnexosManifestacao(idManifestacao);
        }

        public async Task<List<ComplementoManifestacaoModel>> ObterDadosComplemento(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosComplemento(idManifestacao);
        }

        public async Task<PessoaModel> ObterDadosPessoa(int idPessoa)
        {
            return await _manifestacaoRepository.ObterDadosPessoa(idPessoa);
        }

        public async Task<PessoaJuridicaModel> ObterDadosPessoaJuridica(int idPessoaJuridica)
        {
            return await _manifestacaoRepository.ObterDadosPessoaJuridica(idPessoaJuridica);
        }

        public async Task<MunicipioModel> ObterDadosMunicipio(int idMunicipio)
        {
            return await _manifestacaoRepository.ObterDadosMunicipio(idMunicipio);
        }

        public async Task<List<RespostaManifestacaoModel>> ObterDadosResposta(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosResposta(idManifestacao);
        }

        public async Task<List<ProrrogacaoManifestacaoModel>> ObterDadosProrrogacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosProrrogacao(idManifestacao);
        }

        public async Task<List<ApuracaoManifestacaoModel>> ObterDadosApuracao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosApuracao(idManifestacao);
        }

        public async Task<List<EncaminhamentoManifestacaoModel>> ObterDadosEncaminhamento(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosEncaminhamento(idManifestacao);
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDadosDespacho(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosDespacho(idManifestacao);
        }

        public async Task<List<DesdobramentoManifestacaoModel>> ObterDadosDesdobramento(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosDesdobramento(idManifestacao);
        }

        public async Task<List<DiligenciaManifestacaoModel>> ObterDadosDiligencia(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosDiligencia(idManifestacao);
        }

        public async Task<List<InterpelacaoManifestacaoModel>> ObterDadosInterpelacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosInterpelacao(idManifestacao);
        }

        public async Task<List<NotificacaoManifestacaoModel>> ObterDadosNotificacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosNotificacao(idManifestacao);
        }

        public async Task<List<AnotacaoManifestacaoModel>> ObterDadosAnotacao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosAnotacao(idManifestacao);
        }

        public async Task<List<ReclamacaoOmissaoModel>> ObterDadosReclamacaoOmissao(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosReclamacaoOmissao(idManifestacao);
        }

        public async Task<List<RecursoNegativaModel>> ObterDadosRecursoNegativa(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosRecursoNegativa(idManifestacao);
        }

        public async Task<List<HistoricoManifestacaoModel>> ObterDadosHistorico(int idManifestacao)
        {
            return await _manifestacaoRepository.ObterDadosHistorico(idManifestacao);
        }

        public async Task<int> AdicionarManifestacao(ManifestacaoModel manifestacao)
        {
            return await _manifestacaoRepository.AdicionarManifestacao(manifestacao);
        }

        public async Task<int> AtualizarManifestacao(ManifestacaoModel manifestacao)
        {
            return await _manifestacaoRepository.AtualizarManifestacao(manifestacao);
        }

    }
}