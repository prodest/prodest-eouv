using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
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

        public RespostaController(IRespostaWorkService respostaWorkService)
        {
            _respostaWorkService = respostaWorkService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(ResponderManifestacao), new { id = 583 });
        }

        public async Task<IActionResult> ObterResultadosRespostaPorTipologia()
        {
            List<ResultadoRespostaViewModel> listaResultadosResposta = await _respostaWorkService.ObterResultadosRespostaPorTipologia(1);
            return Json(listaResultadosResposta);
        }

        public async Task<IActionResult> ObterOrgaosCompetenciaFato()
        {
            List<OrgaoViewModel> listaOrgaosCompetenciaFato = await _respostaWorkService.ObterOrgaosCompetenciaFato();
            return Json(listaOrgaosCompetenciaFato);
        }

        public async Task<IActionResult> ResponderManifestacao(int id)
        {
            return View();
        }

        public async Task<IActionResult> Responder()//[FromBody] RespostaManifestacaoEntry respostaEntry)
        {
            RespostaManifestacaoEntry respostaEntry = new RespostaManifestacaoEntry();
            respostaEntry.IdManifestacao = 583;
            respostaEntry.IdResultadoResposta = 8;
            respostaEntry.IdOrgaoCompetenciaFato = 862;
            respostaEntry.TextoResposta = "TESTE DE RESPOSTA!!!";

            await _respostaWorkService.ResponderManifestacao(respostaEntry);

            return Json(respostaEntry.IdManifestacao);
        }
    }
}