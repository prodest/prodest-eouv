using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;
using Prodest.EOuv.Web.Admin.Filters;
using System.Threading.Tasks;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    [Authorize]
    public class ManifestacaoController : Controller
    {
        private readonly IManifestacaoWorkService _manifestacaoWorkService;

        public ManifestacaoController(IManifestacaoWorkService manifestacaoWorkService)
        {
            _manifestacaoWorkService = manifestacaoWorkService;
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> ObterDadosCompletosManifestacao(int id)
        {
            JsonReturnViewModel jsonReturn = await _manifestacaoWorkService.ObterDadosCompletosManifestacao(id);
            return Json(jsonReturn);
        }

        [AjaxResponseExceptionFilter]
        public async Task<IActionResult> ObterManifestacaoPorId(int id)
        {
            JsonReturnViewModel jsonReturn = await _manifestacaoWorkService.ObterManifestacaoPorId(id);
            return Json(jsonReturn);
        }
    }
}