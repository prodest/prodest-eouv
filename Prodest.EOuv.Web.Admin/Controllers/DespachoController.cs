using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
using System.Threading.Tasks;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    [Authorize]
    public class DespachoController : Controller
    {
        private readonly IDespachoWorkService _despachoWorkService;
        private readonly IManifestacaoWorkService _manifestacaoWorkService;

        public DespachoController(IDespachoWorkService despachoWorkService, IManifestacaoWorkService manifestacaoWorkService)
        {
            _despachoWorkService = despachoWorkService;
            _manifestacaoWorkService = manifestacaoWorkService;
        }

        [Route("Despacho")]
        [Route("Despacho/{idManifestacao}")]
        public async Task<IActionResult> Index(int idManifestacao)
        {
            TempData["idManifestacao"] = idManifestacao;
            var despachoViewModel = await _despachoWorkService.ObterDespachosPorManifestacao(idManifestacao != 0 ? idManifestacao : 583);
            return View(despachoViewModel);
        }

        [Route("Despacho/ObterDadosManifestacao")]
        [Route("Despacho/ObterDadosManifestacao/{idManifestacao}")]
        public async Task<IActionResult> ObterDadosManifestacao(int idManifestacao)
        {
            var dadosManifestacao = await _manifestacaoWorkService.ObterDadosCompletosManifestacao(idManifestacao != 0 ? idManifestacao : 583);

            return Json(dadosManifestacao);
        }

        [Route("Despacho/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Despacho/Despachar")]
        public async Task<IActionResult> Despachar([FromBody] DespachoManifestacaoEntry despachoEntry)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ListaDadosManifestacaoSelecionadosEntry dadosSelecionados = new ListaDadosManifestacaoSelecionadosEntry();
            dadosSelecionados.DadosBasicos = true;
            dadosSelecionados.DadosManifestante = true;
            dadosSelecionados.DadosComplemento = true;
            dadosSelecionados.DadosProrrogacao = true;
            dadosSelecionados.DadosDiligencia = true;
            dadosSelecionados.DadosEncaminhamento = true;
            dadosSelecionados.DadosResposta = true;
            dadosSelecionados.DadosApuracao = true;
            dadosSelecionados.DadosDespacho = true;
            dadosSelecionados.DadosNotificacao = true;
            dadosSelecionados.DadosAnotacao = true;
            dadosSelecionados.DadosInterpelacao = true;
            dadosSelecionados.DadosReclamacaoOmissao = true;
            dadosSelecionados.DadosRecursoNegativa = true;
            dadosSelecionados.DadosDesdobramento = true;
            dadosSelecionados.DadosHistorico = true;

            despachoEntry.ListaDadosSelecionados = dadosSelecionados;

            despachoEntry.GuidDestinatario = "";
            despachoEntry.GuidPapelResponsavel = "6470bd19-c178-4824-8edc-e8c3ef22a536";

            despachoEntry.IdManifestacao = 583;
            //Receber:
            //    - Lista de dados selecionados
            //    - Formulário de Despacho (Prazo resposta, Texto despacho e anexos)
            //    - Destinatário
            //    - Papel do Responsável pelo encaminhamento (Representante)

            await _despachoWorkService.Despachar(despachoEntry);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes()
        {
            return View();
        }
    }
}