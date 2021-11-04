using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prodest.EOuv.UI.Apresentacao;

namespace DocumentModels.Controllers
{
    public class RenderController : Controller
    {
        public IActionResult ResumoManifestacao([FromBody] ManifestacaoViewModel manifestacao)
        {
            return View(manifestacao);
        }

        public IActionResult ResumoManifestacao2()
        {
            string manifestacaostr = @"{
  'IdManifestacao': 583,
  'NumProtocolo': '2021090001',
  'Senha': 'CsFWTE2v',
  'IdPessoa': 34,
  'IdUsuario': 29,
  'IdTipoManifestacao': 1,
  'IdTipoIdentificacao': 1,
  'IdTipoManifestante': 1,
  'IdAssunto': 701,
  'IdOrgaoInteresse': 862,
  'IdOrgaoResponsavel': 877,
  'IdCanalEntrada': 7,
  'IdModoResposta': 5,
  'TextoManifestacao': 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel auctor metus. Nam nec quam non eros posuere tristique vel at lorem. Ut in nisl eget quam placerat vestibulum sit amet non ipsum. Mauris eget lorem eget dui imperdiet ultricies ut vitae felis. Nullam porttitor elit ex, non ultrices nulla dignissim a. Suspendisse dignissim quam eget magna luctus malesuada. Sed nisl ipsum, eleifend at feugiat eu, rhoncus vitae urna. Sed ultrices sapien orci. Nulla facilisi. Morbi non tristique sem. Curabitur porta est maximus, volutpat turpis vel, blandit libero. Phasellus euismod mauris sem, ac gravida ipsum malesuada vitae. Mauris condimentum eleifend dolor vitae interdum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed mollis, mi et dapibus fringilla, justo ex pretium eros, viverra euismod lorem felis at magna. Donec nec mauris eu sem pretium pretium.',
  'IdMunicipio': 0,
  'IdSituacaoManifestacao': 9,
  'IndProrrogada': true,
  'IdUsuarioAnalise': 29,
  'IdUsuarioCadastrador': null,
  'DataRegistro': '2021-09-23T09:38:09.307',
  'PrazoResposta': '2021-12-06T23:59:59',
  'DataEncerramento': '2021-09-23T09:47:49.273',
  'IdResultadoResposta': 8,
  'IdOrgaoCompetenciaFato': 862,
  'IdPessoaJuridica': null,
  'Assunto': {
    'IdAssunto': 701,
    'DescAssunto': 'Cargo Público',
    'IndAssuntoGeral': true,
    'IndAssuntoSic': false,
    'Observacao': null
  },
  'CanalEntrada': {
    'IdCanalEntrada': 7,
    'DescCanalEntrada': 'Internet'
  },
  'ModoResposta': {
    'IdModoResposta': 5,
    'DescModoResposta': 'Internet'
  },
  'OrgaoCompetenciaFato': null,
  'OrgaoInteresse': {
    'IdOrgao': 862,
    'GuidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
    'SiglaOrgao': 'PRODEST                                           ',
    'NomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
    'RazaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           ',
    'DatAtualizacao': '2021-09-27T00:00:00',
    'IndAtivo': true,
    'IndOutrasCompetencias': false,
    'IndInsercaoManual': false
  },
  'OrgaoResponsavel': {
    'IdOrgao': 877,
    'GuidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
    'SiglaOrgao': 'SECONT                                            ',
    'NomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
    'RazaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 ',
    'DatAtualizacao': '2021-09-27T00:00:00',
    'IndAtivo': true,
    'IndOutrasCompetencias': false,
    'IndInsercaoManual': false
  },
  'PessoaJuridica': null,
  'Pessoa': null,
  'ResultadoResposta': null,
  'SituacaoManifestacao': {
    'IdSituacaoManifestacao': 9,
    'DescSituacaoManifestacao': 'Encerrada'
  },
  'TipoIdentificacao': {
    'IdTipoIdentificacao': 1,
    'DescTipoIdentificacao': 'Identificada'
  },
  'TipoManifestacao': {
    'IdTipoManifestacao': 1,
    'DescTipoManifestacao': 'Denúncia',
    'DiasPrazo': 30,
    'DiasProrrogacao': 30,
    'DiasDiligencia': 10,
    'DiasInterpelacao': 10,
    'DiasReclamacaoOmissao': null,
    'DiasRecursoNegativa': null
  },
  'TipoManifestante': {
    'IdTipoManifestante': 1,
    'DescTipoManifestante': 'Pessoa Física'
  },
  'UsuarioAnalise': null,
  'UsuarioCadastrador': null,
  'Usuario': null,
  'Municipio': null,
  'AnexoManifestacao': [],
  'AnotacaoManifestacao': [],
  'ApuracaoManifestacao': [],
  'ArquivamentoManifestacao': [],
  'ComplementoManifestacao': [],
  'DesdobramentoManifestacaoManifestacaoFilha': [],
  'DesdobramentoManifestacaoManifestacaoPai': [],
  'DespachoManifestacao': [],
  'DiligenciaManifestacao': [],
  'EncaminhamentoManifestacao': [],
  'HistoricoManifestacao': [],
  'InterpelacaoManifestacao': [],
  'NotificacaoManifestacao': [],
  'PesquisaSatisfacao': [],
  'ProrrogacaoManifestacao': [],
  'ReclamacaoOmissaoManifestacaoFilha': [],
  'ReclamacaoOmissaoManifestacaoPai': [],
  'RecursoNegativa': [],
  'RespostaManifestacao': []
}";
            ManifestacaoViewModel manifestacao = new ManifestacaoViewModel();
            manifestacao = JsonConvert.DeserializeObject<ManifestacaoViewModel>(manifestacaostr);
            return View("ResumoManifestacao", manifestacao);
        }
    }
}