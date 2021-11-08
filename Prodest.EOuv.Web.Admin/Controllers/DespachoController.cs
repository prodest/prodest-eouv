using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
using Prodest.EOuv.Web.Admin.Filters;
using System;
using System.Threading.Tasks;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    [Authorize(Policy = "Despachar")]
    public class DespachoController : Controller
    {
        private readonly IDespachoWorkService _despachoWorkService;

        public DespachoController(IDespachoWorkService despachoWorkService)
        {
            _despachoWorkService = despachoWorkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NovoDespacho()
        {
            return View();
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        [AjaxResponseExceptionFilterAttribute]
        public async Task<IActionResult> ObterDespachosPorManifestacao(int id)
        {
            var despachoViewModel = await _despachoWorkService.ObterDespachosPorManifestacao(id);
            return Json(despachoViewModel);
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> Despachar([FromBody] DespachoManifestacaoEntry despachoEntry)
        {
            JsonReturnViewModel jsonReturn = await _despachoWorkService.Despachar(despachoEntry);
            return Json(jsonReturn);
        }

        [AjaxResponseExceptionFilterAttribute]
        public async Task<IActionResult> EncerrarDespachoManualmente(int id)
        {
            await _despachoWorkService.EncerrarDespachoManualmente(id);
            return Json(id);
        }
    }
}