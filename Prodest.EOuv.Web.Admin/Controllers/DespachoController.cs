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

        public IActionResult Index()
        {
            return View("AcompanharDespachos");
            //return RedirectToAction(nameof(AcompanharDespachos), new { id = 583 });
        }

        public async Task<IActionResult> ObterDadosManifestacao(int idManifestacao)
        {
            var dadosManifestacao = await _manifestacaoWorkService.ObterDadosCompletosManifestacao(idManifestacao != 0 ? idManifestacao : 583);

            return Json(dadosManifestacao);
        }

        public async Task<IActionResult> AcompanharDespachos(int id)
        {
            var despachoViewModel = await _despachoWorkService.ObterDespachosPorManifestacao(id);
            return Json(despachoViewModel);
        }

        public IActionResult NovoDespacho()
        {
            return View();
        }

        public async Task<IActionResult> Despachar([FromBody] DespachoManifestacaoEntry despachoEntry)
        {
            await _despachoWorkService.Despachar(despachoEntry);

            return Json(despachoEntry.IdManifestacao);
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult EncerrarDespachoManualmente(int idDespacho)
        {
            _despachoWorkService.EncerrarDespachoManualmente(idDespacho);
            return View(nameof(AcompanharDespachos));
        }
    }
}