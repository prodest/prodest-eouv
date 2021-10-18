using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.UI.Apresentacao;

namespace DocumentModels.Controllers
{
    public class RenderController : Controller
    {
        public class Teste
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; }
        }

        public IActionResult ResumoManifestacao([FromBody] ManifestacaoViewModel manifestacao)
        {
            ManifestacaoViewModel manifestacao2 = new ManifestacaoViewModel();
            return View(manifestacao);
        }

        public IActionResult ResumoManifestacao2()
        {
            ManifestacaoViewModel manifestacao = new ManifestacaoViewModel();
            return View("ResumoManifestacao", manifestacao);
        }
    }
}