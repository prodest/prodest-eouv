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
            var despachoViewModel = await _despachoWorkService.ObterDespachosPorManifestacao(idManifestacao != 0 ? idManifestacao : 250);
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

        [Route("Despacho/Despachar")]
        public async Task<IActionResult> Despachar([FromBody] DespachoManifestacaoEntry despachoEntry)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            //Validações de tela

            despachoEntry.GuidPapelResponsavel = despachoEntry.GuidPapelResponsavel; //"6470bd19-c178-4824-8edc-e8c3ef22a536";
            despachoEntry.GuidPapelDestinatario = despachoEntry.GuidPapelDestinatario; //"90dab47e-e5ef-481e-8d0f-8a90d9390f4d";

            await _despachoWorkService.Despachar(despachoEntry);

            return RedirectToAction(nameof(Index), new { IdManifestacao = despachoEntry.IdManifestacao });
        }

        public IActionResult Detalhes()
        {
            return View();
        }
    }
}