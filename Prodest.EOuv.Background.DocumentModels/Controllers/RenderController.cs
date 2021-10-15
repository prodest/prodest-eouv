using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.Dominio.Modelo;
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

        public IActionResult ResumoManifestacao()//[FromBody] ManifestacaoModel manifestacao)
        {
            //ManifestacaoViewModel manifestacao = new ManifestacaoViewModel();
            return View();
        }
    }
}