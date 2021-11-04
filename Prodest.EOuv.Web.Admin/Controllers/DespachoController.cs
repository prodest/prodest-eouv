using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
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

        public async Task<IActionResult> ObterDespachosPorManifestacao(int id)
        {
            try
            {
                var despachoViewModel = await _despachoWorkService.ObterDespachosPorManifestacao(id);
                return Json(despachoViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult NovoDespacho()
        {
            return View();
        }

        public async Task<IActionResult> Despachar([FromBody] DespachoManifestacaoEntry despachoEntry)
        {
            try
            {
                await _despachoWorkService.Despachar(despachoEntry);
                return Json(despachoEntry.IdManifestacao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public async Task<IActionResult> EncerrarDespachoManualmente(int id)
        {
            try
            {
                await _despachoWorkService.EncerrarDespachoManualmente(id);
                return Json(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}