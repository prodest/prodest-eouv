using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
using Prodest.EOuv.Web.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    [Authorize]
    public class RespostaController : Controller
    {
        private readonly IRespostaWorkService _respostaWorkService;
        private readonly IDespachoWorkService _despachoWorkService;

        public RespostaController(IRespostaWorkService respostaWorkService, IDespachoWorkService despachoWorkService)
        {
            _respostaWorkService = respostaWorkService;
            _despachoWorkService = despachoWorkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ResponderManifestacao()
        {
            return View();
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> ObterResultadosRespostaPorTipologia(int id)
        {
            JsonReturnViewModel jsonReturn = await _respostaWorkService.ObterResultadosRespostaPorTipologia(id);
            return Json(jsonReturn);
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> ObterOrgaosCompetenciaFato()
        {
            JsonReturnViewModel jsonReturn = await _respostaWorkService.ObterOrgaosCompetenciaFato();
            return Json(jsonReturn);
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> Responder([FromBody] RespostaManifestacaoEntry respostaEntry)
        {
            JsonReturnViewModel jsonReturn = await _respostaWorkService.ResponderManifestacao(respostaEntry);
            return Json(jsonReturn);
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> ObterDocumentosEncaminhamentoEDocs(int id)
        {
            JsonReturnViewModel jsonReturn = await _despachoWorkService.ObterDocumentosEncaminhamentoEDocs(id);
            return Json(jsonReturn);
        }
    }
}