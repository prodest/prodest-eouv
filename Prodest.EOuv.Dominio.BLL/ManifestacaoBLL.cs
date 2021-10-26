using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
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

        public async Task<ManifestacaoModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            ManifestacaoModel manifestacaoModel = await ObterDadosBasicosManifestacao(idManifestacao);

            if (manifestacaoModel.IdPessoa != null)
            {
                manifestacaoModel.Pessoa = await ObterDadosPessoa((int)manifestacaoModel.IdPessoa);
            }
            if (manifestacaoModel.IdPessoaJuridica != null)
            {
                manifestacaoModel.PessoaJuridica = await ObterDadosPessoaJuridica((int)manifestacaoModel.IdPessoaJuridica);
            }
            if (manifestacaoModel.IdMunicipio != 0)
            {
                manifestacaoModel.Municipio = await ObterDadosMunicipio((int)manifestacaoModel.IdMunicipio);
            }

            manifestacaoModel.AnexoManifestacao = await ObterAnexosManifestacao(idManifestacao);
            manifestacaoModel.ComplementoManifestacao = await ObterDadosComplemento(idManifestacao);
            manifestacaoModel.ProrrogacaoManifestacao = await ObterDadosProrrogacao(idManifestacao);
            manifestacaoModel.DiligenciaManifestacao = await ObterDadosDiligencia(idManifestacao);
            manifestacaoModel.EncaminhamentoManifestacao = await ObterDadosEncaminhamento(idManifestacao);
            manifestacaoModel.RespostaManifestacao = await ObterDadosResposta(idManifestacao);
            manifestacaoModel.ApuracaoManifestacao = await ObterDadosApuracao(idManifestacao);
            manifestacaoModel.NotificacaoManifestacao = await ObterDadosNotificacao(idManifestacao);
            manifestacaoModel.AnotacaoManifestacao = await ObterDadosAnotacao(idManifestacao);
            manifestacaoModel.InterpelacaoManifestacao = await ObterDadosInterpelacao(idManifestacao);
            manifestacaoModel.ReclamacaoOmissaoManifestacaoPai = await ObterDadosReclamacaoOmissao(idManifestacao);
            manifestacaoModel.RecursoNegativa = await ObterDadosRecursoNegativa(idManifestacao);
            manifestacaoModel.DespachoManifestacao = await ObterDadosDespacho(idManifestacao);
            manifestacaoModel.DesdobramentoManifestacaoManifestacaoPai = await ObterDadosDesdobramento(idManifestacao);
            manifestacaoModel.HistoricoManifestacao = await ObterDadosHistorico(idManifestacao);

            return manifestacaoModel;
        }

        public async Task<ManifestacaoModel> ObterDadosFiltradosManifestacao(int idManifestacao, FiltroDadosManifestacaoModel filtroDadosManifestacao)
        {
            ManifestacaoModel manifestacaoModel = await ObterDadosBasicosManifestacao(idManifestacao);

            if (filtroDadosManifestacao.DadosAnexo)
            {
                manifestacaoModel.AnexoManifestacao = await ObterAnexosManifestacao(idManifestacao);
            }
            if (manifestacaoModel.IdMunicipio != 0)
            {
                manifestacaoModel.Municipio = await ObterDadosMunicipio((int)manifestacaoModel.IdMunicipio);
            }

            if (filtroDadosManifestacao.DadosManifestante)
            {
                if (manifestacaoModel.IdPessoa != null)
                {
                    manifestacaoModel.Pessoa = await ObterDadosPessoa((int)manifestacaoModel.IdPessoa);
                }

                if (manifestacaoModel.IdPessoaJuridica != null)
                {
                    manifestacaoModel.PessoaJuridica = await ObterDadosPessoaJuridica((int)manifestacaoModel.IdPessoaJuridica);
                }
            }
            if (filtroDadosManifestacao.DadosComplemento)
            {
                manifestacaoModel.ComplementoManifestacao = await ObterDadosComplemento(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosProrrogacao)
            {
                manifestacaoModel.ProrrogacaoManifestacao = await ObterDadosProrrogacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosDiligencia)
            {
                manifestacaoModel.DiligenciaManifestacao = await ObterDadosDiligencia(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosEncaminhamento)
            {
                manifestacaoModel.EncaminhamentoManifestacao = await ObterDadosEncaminhamento(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosResposta)
            {
                manifestacaoModel.RespostaManifestacao = await ObterDadosResposta(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosApuracao)
            {
                manifestacaoModel.ApuracaoManifestacao = await ObterDadosApuracao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosNotificacao)
            {
                manifestacaoModel.NotificacaoManifestacao = await ObterDadosNotificacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosAnotacao)
            {
                manifestacaoModel.AnotacaoManifestacao = await ObterDadosAnotacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosInterpelacao)
            {
                manifestacaoModel.InterpelacaoManifestacao = await ObterDadosInterpelacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosReclamacaoOmissao)
            {
                manifestacaoModel.ReclamacaoOmissaoManifestacaoPai = await ObterDadosReclamacaoOmissao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosRecursoNegativa)
            {
                manifestacaoModel.RecursoNegativa = await ObterDadosRecursoNegativa(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosDespacho)
            {
                manifestacaoModel.DespachoManifestacao = await ObterDadosDespacho(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosDesdobramento)
            {
                manifestacaoModel.DesdobramentoManifestacaoManifestacaoPai = await ObterDadosDesdobramento(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosHistorico)
            {
                manifestacaoModel.HistoricoManifestacao = await ObterDadosHistorico(idManifestacao);
            }

            return manifestacaoModel;
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
    }
}