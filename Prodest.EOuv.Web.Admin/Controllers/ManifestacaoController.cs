using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils.Exceptions;
using Prodest.EOuv.UI.Apresentacao;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<IActionResult> ObterDadosCompletosManifestacao(int id)
        {
            try
            {
                var dadosManifestacao = await _manifestacaoWorkService.ObterDadosCompletosManifestacao(id);

                return Json(dadosManifestacao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> ObterManifestacaoPorId(int id)
        {
            ManifestacaoViewModel manifestacao = await _manifestacaoWorkService.ObterManifestacaoPorId(id);
            return Json(manifestacao);
        }
    }
}