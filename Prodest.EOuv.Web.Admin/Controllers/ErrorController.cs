using Microsoft.AspNetCore.Mvc;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(string msg)
        {
            ViewBag.Message = msg;
            return View("Error");
        }

        public IActionResult AccessDenied()
        {
            ViewBag.Message = "Conteúdo indisponível ou o usuário não possui permissão.";
            return View("Error");
        }

        public IActionResult UserAgentDenied()
        {
            ViewBag.Message = "O sistema é compatível apenas com o navegador Google Chrome.";
            return View("Error");
        }
    }
}