using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.DAL
{
    public class ManifestacaoRepository : IManifestacaoRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public ManifestacaoRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<ManifestacaoModel> ObterDadosBasicosManifestacao(int idManifestacao)
        {
            Manifestacao manifestacao = await _eouvContext.Manifestacao
                                                            .Include(m => m.TipoManifestacao)
                                                            .Include(m => m.OrgaoInteresse)
                                                            .Include(m => m.Assunto)
                                                            .Include(m => m.SituacaoManifestacao)
                                                            .Include(m => m.OrgaoResponsavel)
                                                            .Include(m => m.CanalEntrada)
                                                            .Include(m => m.ModoResposta)
                                                            .Include(m => m.UsuarioCadastrador).ThenInclude(m => m.Pessoa)
                                                            .Include(m => m.TipoIdentificacao)
                                                            .Include(m => m.TipoManifestante)
                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().FirstOrDefaultAsync();

            var resposta = _mapper.Map<ManifestacaoModel>(manifestacao);

            return resposta;
        }

        public async Task<PessoaModel> ObterDadosPessoa(int idPessoa)
        {
            Pessoa pessoa = await _eouvContext.Pessoa
                                    .Include(m => m.Municipio).ThenInclude(m => m.Uf)
                                    .Where(m => m.IdPessoa == idPessoa).AsNoTracking().FirstOrDefaultAsync();

            return _mapper.Map<PessoaModel>(pessoa);
        }

        public async Task<PessoaJuridicaModel> ObterDadosPessoaJuridica(int idPessoaJuridica)
        {
            PessoaJuridica pessoaJuridica = await _eouvContext.PessoaJuridica
                                                        .Where(m => m.IdPessoaJuridica == idPessoaJuridica).AsNoTracking().FirstOrDefaultAsync(); ;

            return _mapper.Map<PessoaJuridicaModel>(pessoaJuridica); ;
        }

        public async Task<MunicipioModel> ObterDadosMunicipio(int idMunicipio)
        {
            Municipio municipio = await _eouvContext.Municipio
                                    .Include(m => m.Uf)
                                    .Where(m => m.IdMunicipio == idMunicipio).AsNoTracking().FirstOrDefaultAsync();

            return _mapper.Map<MunicipioModel>(municipio);
        }

        public async Task<ManifestacaoModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            Manifestacao manifestacao = await _eouvContext.Manifestacao
                                                            .Include(m => m.TipoManifestacao)
                                                            .Include(m => m.OrgaoInteresse)
                                                            .Include(m => m.Assunto)
                                                            .Include(m => m.SituacaoManifestacao)
                                                            .Include(m => m.OrgaoResponsavel)
                                                            .Include(m => m.CanalEntrada)
                                                            .Include(m => m.ModoResposta)
                                                            .Include(m => m.TipoIdentificacao)
                                                            .Include(m => m.AnexoManifestacao)
                                                            .Include(m => m.ComplementoManifestacao)
                                                            .Include(m => m.Pessoa).ThenInclude(m => m.Municipio).ThenInclude(m => m.Uf)
                                                            .Include(m => m.RespostaManifestacao)
                                                            .Include(m => m.ProrrogacaoManifestacao)
                                                            .Include(m => m.ApuracaoManifestacao)
                                                            .Include(m => m.EncaminhamentoManifestacao)
                                                            .Include(m => m.DespachoManifestacao)
                                                            .Include(m => m.DesdobramentoManifestacaoManifestacaoPai)
                                                            .Include(m => m.DiligenciaManifestacao)
                                                            .Include(m => m.InterpelacaoManifestacao)
                                                            .Include(m => m.NotificacaoManifestacao)
                                                            .Include(m => m.AnotacaoManifestacao)
                                                            .Include(m => m.ReclamacaoOmissaoManifestacaoPai)
                                                            .Include(m => m.RecursoNegativa)
                                                            .Include(m => m.HistoricoManifestacao)
                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().FirstOrDefaultAsync();

            return _mapper.Map<ManifestacaoModel>(manifestacao);
        }

        public async Task<List<AnexoManifestacaoModel>> ObterAnexosManifestacao(int idManifestacao)
        {
            List<AnexoManifestacao> listaAnexoManifestacao = await _eouvContext.AnexoManifestacao
                                                                    .Include(m => m.TipoAnexoManifestacao)
                                                                    .Include(m => m.ArquivoFisicoAnexoManifestacao)
                                                                    .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<AnexoManifestacaoModel>>(listaAnexoManifestacao);
        }

        public async Task<List<ComplementoManifestacaoModel>> ObterDadosComplemento(int idManifestacao)
        {
            List<ComplementoManifestacao> listaComplementoManifestacao = await _eouvContext.ComplementoManifestacao
                                                                                .Include(m => m.UsuarioLeitura)
                                                                                .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<ComplementoManifestacaoModel>>(listaComplementoManifestacao);
        }

        public async Task<List<RespostaManifestacaoModel>> ObterDadosResposta(int idManifestacao)
        {
            List<RespostaManifestacao> listaRespostaManifestacao = await _eouvContext.RespostaManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Include(m => m.Orgao)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<RespostaManifestacaoModel>>(listaRespostaManifestacao);
        }

        public async Task<List<ProrrogacaoManifestacaoModel>> ObterDadosProrrogacao(int idManifestacao)
        {
            List<ProrrogacaoManifestacao> listaProrrogacaoManifestacao = await _eouvContext.ProrrogacaoManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Include(m => m.Orgao)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<ProrrogacaoManifestacaoModel>>(listaProrrogacaoManifestacao);
        }

        public async Task<List<ApuracaoManifestacaoModel>> ObterDadosApuracao(int idManifestacao)
        {
            List<ApuracaoManifestacao> listaApuracaoManifestacao = await _eouvContext.ApuracaoManifestacao
                                                                            .Include(m => m.UsuarioSolicitacaoApuracao)
                                                                            .Include(m => m.OrgaoOrigem)
                                                                            .Include(m => m.OrgaoDestino)
                                                                            .Include(m => m.UsuarioRespostaApuracao)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<ApuracaoManifestacaoModel>>(listaApuracaoManifestacao);
        }

        public async Task<List<EncaminhamentoManifestacaoModel>> ObterDadosEncaminhamento(int idManifestacao)
        {
            List<EncaminhamentoManifestacao> listaEncaminhamentoManifestacao = await _eouvContext.EncaminhamentoManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Include(m => m.OrgaoOrigem)
                                                                            .Include(m => m.OrgaoDestino)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<EncaminhamentoManifestacaoModel>>(listaEncaminhamentoManifestacao);
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDadosDespacho(int idManifestacao)
        {
            List<DespachoManifestacao> listaDespachoManifestacao = await _eouvContext.DespachoManifestacao
                                                                            .Include(m => m.UsuarioSolicitacaoDespacho)
                                                                            .Include(m => m.Orgao)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<DespachoManifestacaoModel>>(listaDespachoManifestacao);
        }

        public async Task<List<DesdobramentoManifestacaoModel>> ObterDadosDesdobramento(int idManifestacao)
        {
            List<DesdobramentoManifestacao> listaDesdobramentoManifestacao = await _eouvContext.DesdobramentoManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Include(m => m.Orgao)
                                                                            .Where(m => m.IdManifestacaoPai == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<DesdobramentoManifestacaoModel>>(listaDesdobramentoManifestacao);
        }

        public async Task<List<DiligenciaManifestacaoModel>> ObterDadosDiligencia(int idManifestacao)
        {
            List<DiligenciaManifestacao> listaDiligenciaManifestacao = await _eouvContext.DiligenciaManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Include(m => m.Orgao)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<DiligenciaManifestacaoModel>>(listaDiligenciaManifestacao);
        }

        public async Task<List<InterpelacaoManifestacaoModel>> ObterDadosInterpelacao(int idManifestacao)
        {
            List<InterpelacaoManifestacao> listaInterpelacaoManifestacao = await _eouvContext.InterpelacaoManifestacao
                                                                                .Include(m => m.UsuarioResposta)
                                                                                .Include(m => m.OrgaoResposta)
                                                                                .Include(m => m.SituacaoInterpelacao)
                                                                                .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<InterpelacaoManifestacaoModel>>(listaInterpelacaoManifestacao);
        }

        public async Task<List<NotificacaoManifestacaoModel>> ObterDadosNotificacao(int idManifestacao)
        {
            List<NotificacaoManifestacao> listaNotificacaoManifestacao = await _eouvContext.NotificacaoManifestacao
                                                                                .Include(m => m.Usuario)
                                                                                .Include(m => m.Orgao)
                                                                                .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<NotificacaoManifestacaoModel>>(listaNotificacaoManifestacao);
        }

        public async Task<List<AnotacaoManifestacaoModel>> ObterDadosAnotacao(int idManifestacao)
        {
            List<AnotacaoManifestacao> listaAnotacaoManifestacao = await _eouvContext.AnotacaoManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<AnotacaoManifestacaoModel>>(listaAnotacaoManifestacao);
        }

        public async Task<List<ReclamacaoOmissaoModel>> ObterDadosReclamacaoOmissao(int idManifestacao)
        {
            List<ReclamacaoOmissao> listaReclamacaoOmissao = await _eouvContext.ReclamacaoOmissao
                                                                    .Include(m => m.ManifestacaoPai)
                                                                    .Include(m => m.ManifestacaoFilha)
                                                                    .Where(m => m.IdManifestacaoPai == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<ReclamacaoOmissaoModel>>(listaReclamacaoOmissao);
        }

        public async Task<List<RecursoNegativaModel>> ObterDadosRecursoNegativa(int idManifestacao)
        {
            List<RecursoNegativa> listaRecursoNegativa = await _eouvContext.RecursoNegativa
                                                                            .Include(m => m.UsuarioResposta)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<RecursoNegativaModel>>(listaRecursoNegativa);
        }

        public async Task<List<HistoricoManifestacaoModel>> ObterDadosHistorico(int idManifestacao)
        {
            List<HistoricoManifestacao> listaHistoricoManifestacao = await _eouvContext.HistoricoManifestacao
                                                                            .Include(m => m.Usuario)
                                                                            .Include(m => m.Orgao)
                                                                            .Include(m => m.SituacaoManifestacao)
                                                                            .Where(m => m.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();

            return _mapper.Map<List<HistoricoManifestacaoModel>>(listaHistoricoManifestacao);
        }
    }
}