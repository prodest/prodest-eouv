using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Web.Admin.Controllers
{
    public class RespostaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
