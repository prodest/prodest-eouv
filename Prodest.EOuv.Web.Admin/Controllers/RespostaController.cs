﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly IDespachoWorkService _despachoWorkService;
        private readonly IManifestacaoWorkService _manifestacaoWorkService;

        public RespostaController(IRespostaWorkService respostaWorkService, IDespachoWorkService despachoWorkService, IManifestacaoWorkService manifestacaoWorkService)
        {
            _respostaWorkService = respostaWorkService;
            _despachoWorkService = despachoWorkService;
            _manifestacaoWorkService = manifestacaoWorkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ObterManifestacaoPorId(int id)
        {
            ManifestacaoViewModel manifestacao = await _manifestacaoWorkService.ObterManifestacaoPorId(id);
            return Json(manifestacao);
        }

        public async Task<IActionResult> ObterResultadosRespostaPorTipologia(int id)
        {
            List<ResultadoRespostaViewModel> listaResultadosResposta = await _respostaWorkService.ObterResultadosRespostaPorTipologia(id);
            return Json(listaResultadosResposta);
        }

        public async Task<IActionResult> ObterOrgaosCompetenciaFato()
        {
            List<OrgaoViewModel> listaOrgaosCompetenciaFato = await _respostaWorkService.ObterOrgaosCompetenciaFato();
            return Json(listaOrgaosCompetenciaFato);
        }

        public async Task<IActionResult> ResponderManifestacao()
        {
            return View();
        }

        public async Task<IActionResult> Responder([FromBody] RespostaManifestacaoEntry respostaEntry)
        {
            respostaEntry.IdManifestacao = 583;
            respostaEntry.IdResultadoResposta = 8;
            respostaEntry.IdOrgaoCompetenciaFato = 862;
            respostaEntry.TextoResposta = "TESTE DE RESPOSTA!!!";

            await _respostaWorkService.ResponderManifestacao(respostaEntry);

            return Json(respostaEntry.IdManifestacao);
        }

        public async Task<IActionResult> ObterDocumentosEncaminhamentoEDocs(int id)
        {
            var listaDocumentos = await _despachoWorkService.ObterDocumentosEncaminhamentoEDocs(id);
            return Json(listaDocumentos);
        }
    }
}