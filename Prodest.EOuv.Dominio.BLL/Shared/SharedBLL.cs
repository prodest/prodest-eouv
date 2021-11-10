using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL.Shared
{
    public class SharedBLL : ISharedBLL
    {
        private readonly IUsuarioProvider _usuarioProvider;
        private readonly IManifestacaoRepository _manifestacaoRepository;
        private readonly IOrgaoRepository _orgaoRepository;
        private readonly ISetorRepository _setorRepository;
        private readonly IAcessoCidadaoService _acessoCidadaoService;


        public SharedBLL(IUsuarioProvider usuarioProvider, IManifestacaoRepository manifestacaoRepository, IOrgaoRepository orgaoRepository, ISetorRepository setorRepository, IAcessoCidadaoService acessoCidadaoService)
        {
            _usuarioProvider = usuarioProvider;
            _manifestacaoRepository = manifestacaoRepository;
            _orgaoRepository = orgaoRepository;
            _setorRepository = setorRepository;
            _acessoCidadaoService = acessoCidadaoService;
        }

        public async Task<bool> UsuarioPossuiAcessoManifestacao(int idManifestacao)
        {
            var usuario = _usuarioProvider.GetCurrent();

            bool podeVisualizar = false;

            ManifestacaoModel manifestacao = await _manifestacaoRepository.ObterManifestacaoPorId(idManifestacao);

            if (usuario.IdPerfilEouv == (int)Enums.PerfilUsuario.RepresentanteOuvidoria)
            {
                podeVisualizar = await VerificarPermissaoOrgaoManifestacao(manifestacao, (int)usuario.IdOrgaoEouv);
            }
            else if (usuario.IdPerfilEouv == (int)Enums.PerfilUsuario.ServidorOrgao)
            {
                podeVisualizar = (usuario.IdOrgaoEouv == manifestacao.IdOrgaoResponsavel);
            }

            return podeVisualizar;
        }

        public async Task<bool> VerificarPermissaoOrgaoManifestacao(ManifestacaoModel manifestacao, int idOrgao)
        {
            bool possuiPermissao = false;

            List<int> listaIdOrgaosVinculados = await _orgaoRepository.ObterIdOrgaosVinculadosByOrgaoResponsavel(idOrgao);

            if (listaIdOrgaosVinculados != null)
            {
                if (manifestacao.IdSituacaoManifestacao == (int)Enums.SituacaoManifestacao.ENCERRADA) //Para Manifestações encerradas, o órgão Interesse passa a ter acesso também
                {
                    possuiPermissao = listaIdOrgaosVinculados.Contains(manifestacao.IdOrgaoInteresse) || listaIdOrgaosVinculados.Contains(manifestacao.IdOrgaoResponsavel);
                }
                else
                {
                    possuiPermissao = listaIdOrgaosVinculados.Contains(manifestacao.IdOrgaoResponsavel);
                }
            }
            else
            {
                possuiPermissao = manifestacao.IdOrgaoResponsavel == idOrgao;
            }

            return possuiPermissao;
        }

        public async Task<ManifestacaoModel> ObterDadosCompletosManifestacao(int idManifestacao)
        {
            ManifestacaoModel manifestacaoModel = await _manifestacaoRepository.ObterDadosBasicosManifestacao(idManifestacao);

            if (manifestacaoModel != null)
            {

                if (manifestacaoModel.IdPessoa != null)
                {
                    manifestacaoModel.Pessoa = await _manifestacaoRepository.ObterDadosPessoa((int)manifestacaoModel.IdPessoa);
                }
                if (manifestacaoModel.IdPessoaJuridica != null)
                {
                    manifestacaoModel.PessoaJuridica = await _manifestacaoRepository.ObterDadosPessoaJuridica((int)manifestacaoModel.IdPessoaJuridica);
                }
                if (manifestacaoModel.IdMunicipio != 0)
                {
                    manifestacaoModel.Municipio = await _manifestacaoRepository.ObterDadosMunicipio((int)manifestacaoModel.IdMunicipio);
                }

                manifestacaoModel.AnexoManifestacao = await _manifestacaoRepository.ObterAnexosManifestacao(idManifestacao);
                manifestacaoModel.ComplementoManifestacao = await _manifestacaoRepository.ObterDadosComplemento(idManifestacao);
                manifestacaoModel.ProrrogacaoManifestacao = await _manifestacaoRepository.ObterDadosProrrogacao(idManifestacao);
                manifestacaoModel.DiligenciaManifestacao = await _manifestacaoRepository.ObterDadosDiligencia(idManifestacao);
                manifestacaoModel.EncaminhamentoManifestacao = await _manifestacaoRepository.ObterDadosEncaminhamento(idManifestacao);
                manifestacaoModel.RespostaManifestacao = await _manifestacaoRepository.ObterDadosResposta(idManifestacao);
                manifestacaoModel.ApuracaoManifestacao = await _manifestacaoRepository.ObterDadosApuracao(idManifestacao);
                manifestacaoModel.DespachoManifestacao = await _manifestacaoRepository.ObterDadosDespacho(idManifestacao);
                manifestacaoModel.NotificacaoManifestacao = await _manifestacaoRepository.ObterDadosNotificacao(idManifestacao);
                manifestacaoModel.AnotacaoManifestacao = await _manifestacaoRepository.ObterDadosAnotacao(idManifestacao);
                manifestacaoModel.InterpelacaoManifestacao = await _manifestacaoRepository.ObterDadosInterpelacao(idManifestacao);
                manifestacaoModel.ReclamacaoOmissaoManifestacaoPai = await _manifestacaoRepository.ObterDadosReclamacaoOmissao(idManifestacao);
                manifestacaoModel.RecursoNegativa = await _manifestacaoRepository.ObterDadosRecursoNegativa(idManifestacao);
                manifestacaoModel.DespachoManifestacao = await _manifestacaoRepository.ObterDadosDespacho(idManifestacao);
                manifestacaoModel.DesdobramentoManifestacaoManifestacaoPai = await _manifestacaoRepository.ObterDadosDesdobramento(idManifestacao);
                manifestacaoModel.HistoricoManifestacao = await _manifestacaoRepository.ObterDadosHistorico(idManifestacao);
            }

            return manifestacaoModel;
        }

        public async Task<ManifestacaoModel> ObterDadosFiltradosManifestacao(int idManifestacao, FiltroDadosManifestacaoModel filtroDadosManifestacao)
        {
            ManifestacaoModel manifestacaoModel = await _manifestacaoRepository.ObterDadosBasicosManifestacao(idManifestacao);

            if (filtroDadosManifestacao.DadosAnexo)
            {
                manifestacaoModel.AnexoManifestacao = await _manifestacaoRepository.ObterAnexosManifestacao(idManifestacao);
            }
            if (manifestacaoModel.IdMunicipio != 0)
            {
                manifestacaoModel.Municipio = await _manifestacaoRepository.ObterDadosMunicipio((int)manifestacaoModel.IdMunicipio);
            }

            if (filtroDadosManifestacao.DadosManifestante)
            {
                if (manifestacaoModel.IdPessoa != null)
                {
                    manifestacaoModel.Pessoa = await _manifestacaoRepository.ObterDadosPessoa((int)manifestacaoModel.IdPessoa);
                }

                if (manifestacaoModel.IdPessoaJuridica != null)
                {
                    manifestacaoModel.PessoaJuridica = await _manifestacaoRepository.ObterDadosPessoaJuridica((int)manifestacaoModel.IdPessoaJuridica);
                }
            }
            if (filtroDadosManifestacao.DadosComplemento)
            {
                manifestacaoModel.ComplementoManifestacao = await _manifestacaoRepository.ObterDadosComplemento(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosProrrogacao)
            {
                manifestacaoModel.ProrrogacaoManifestacao = await _manifestacaoRepository.ObterDadosProrrogacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosDiligencia)
            {
                manifestacaoModel.DiligenciaManifestacao = await _manifestacaoRepository.ObterDadosDiligencia(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosEncaminhamento)
            {
                manifestacaoModel.EncaminhamentoManifestacao = await _manifestacaoRepository.ObterDadosEncaminhamento(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosResposta)
            {
                manifestacaoModel.RespostaManifestacao = await _manifestacaoRepository.ObterDadosResposta(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosApuracao)
            {
                manifestacaoModel.ApuracaoManifestacao = await _manifestacaoRepository.ObterDadosApuracao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosNotificacao)
            {
                manifestacaoModel.NotificacaoManifestacao = await _manifestacaoRepository.ObterDadosNotificacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosAnotacao)
            {
                manifestacaoModel.AnotacaoManifestacao = await _manifestacaoRepository.ObterDadosAnotacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosInterpelacao)
            {
                manifestacaoModel.InterpelacaoManifestacao = await _manifestacaoRepository.ObterDadosInterpelacao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosReclamacaoOmissao)
            {
                manifestacaoModel.ReclamacaoOmissaoManifestacaoPai = await _manifestacaoRepository.ObterDadosReclamacaoOmissao(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosRecursoNegativa)
            {
                manifestacaoModel.RecursoNegativa = await _manifestacaoRepository.ObterDadosRecursoNegativa(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosDespacho)
            {
                manifestacaoModel.DespachoManifestacao = await _manifestacaoRepository.ObterDadosDespacho(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosDesdobramento)
            {
                manifestacaoModel.DesdobramentoManifestacaoManifestacaoPai = await _manifestacaoRepository.ObterDadosDesdobramento(idManifestacao);
            }
            if (filtroDadosManifestacao.DadosHistorico)
            {
                manifestacaoModel.HistoricoManifestacao = await _manifestacaoRepository.ObterDadosHistorico(idManifestacao);
            }

            return manifestacaoModel;
        }

        public async Task<AgenteManifestacaoModel> MontaAgenteSetor(string idAgente)
        {
            SetorModel setor = await _setorRepository.BuscarSetor(idAgente);

            AgenteManifestacaoModel agente = new AgenteManifestacaoModel();

            if (setor != null)
            {
                agente.GuidSetor = new Guid(idAgente);
                agente.NomeSetor = setor.NomeSetor;
                agente.SiglaSetor = setor.SiglaSetor;
                agente.GuidOrgao = setor.Orgao.GuidOrgao;
                agente.NomeOrgao = setor.Orgao.RazaoSocial;
                agente.SiglaOrgao = setor.Orgao.SiglaOrgao;
                agente.TipoAgente = (int)Enums.TipoAgente.Unidade;
            }

            return agente;
        }

        public async Task<AgenteManifestacaoModel> MontaAgenteGrupoComissao(string idAgente)
        {
            AgentePublicoPapelModel grupo = await _acessoCidadaoService.GetGrupo(idAgente);

            AgenteManifestacaoModel agente = new AgenteManifestacaoModel();

            if (grupo != null)
            {
                agente.GuidGrupo = new Guid(idAgente);
                agente.NomeGrupo = grupo.Nome;
                agente.TipoAgente = (int)Enums.TipoAgente.Grupo;
            }

            //TODO: Buscar informações de Setor e Orgao do Grupo

            return agente;
        }

        public async Task<AgenteManifestacaoModel> MontaAgenteUsuario(string idAgente)
        {
            AgentePublicoPapelModel papel = await _acessoCidadaoService.GetPapel(idAgente);
            SetorModel setor = null;
            if (papel != null && !String.IsNullOrEmpty(papel.LotacaoGuid))
            {
                setor = await _setorRepository.BuscarSetor(papel.LotacaoGuid);
            }
            AgenteManifestacaoModel agente = new AgenteManifestacaoModel
            {
                GuidPapel = new Guid(idAgente),
                NomePapel = papel.Nome,
                GuidUsuario = papel.AgentePublicoSub,
                NomeUsuario = papel.AgentePublicoNome,
                GuidSetor = new Guid(papel.LotacaoGuid),
                TipoAgente = (int)Enums.TipoAgente.Papel
            };
            if (setor is not null)
            {
                agente.NomeSetor = setor.NomeSetor;
                agente.SiglaSetor = setor.SiglaSetor;
                agente.GuidOrgao = setor.Orgao.GuidOrgao;
                agente.NomeOrgao = setor.Orgao.RazaoSocial;
                agente.SiglaOrgao = setor.Orgao.SiglaOrgao;
                /*
                //TODO: Adicionar Dados do Patriarca na API de Carga do Organograma no eOuv antigo
                AgenteResposta.GuidPatriarca = setor.Orgao.Patriaca.Guid;
                AgenteResposta.NomePatriarca = setor.Orgao.Patriaca.RazaoSocial;
                AgenteResposta.SiglaPatriarca = setor.Orgao.Patriaca.Sigla;
                */
                agente.GuidPatriarca = new Guid("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");
                agente.NomePatriarca = "ESTADO DO ESPIRITO SANTO";
                agente.SiglaPatriarca = "GOVES";
            }
            return agente;
        }
    }
}