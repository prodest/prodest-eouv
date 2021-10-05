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

        [Route("Despacho/{idManifestacao}")]
        public async Task<IActionResult> Index(int idManifestacao)
        {
            var despachoViewModel = await _despachoWorkService.ObterDespachosPorManifestacao(idManifestacao != 0 ? idManifestacao : 583);
            return View(despachoViewModel);
        }

        [Route("Despacho/NovoDespacho")]
        [Route("Despacho/NovoDespacho/{idManifestacao}")]
        public async Task<IActionResult> NovoDespacho(int idManifestacao)
        {
            var dadosManifestacao = await _manifestacaoWorkService.ObterDadosCompletosManifestacao(idManifestacao != 0 ? idManifestacao : 583);

            return Json(dadosManifestacao);
        }

        [Route("Despacho/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoDespacho(DespachoManifestacaoViewModel despachoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _despachoWorkService.AdicionarDespacho(despachoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes()
        {
            return View();
        }
    }
}