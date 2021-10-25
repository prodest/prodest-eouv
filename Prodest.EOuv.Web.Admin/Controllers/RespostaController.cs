using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    public class RespostaController : Controller
    {
        private readonly IRespostaWorkService _respostaWorkService;

        public RespostaController(IRespostaWorkService respostaWorkService)
        {
            _respostaWorkService = respostaWorkService;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}