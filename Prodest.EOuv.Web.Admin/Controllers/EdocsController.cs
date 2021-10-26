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
    public class EdocsController : Controller
    {
        private readonly IDespachoWorkService _despachoWorkService;
        private readonly IEDocsService _edocsService;
        private readonly IAcessoCidadaoService _acessoCidadaoService;
        private readonly IPdfApiService _pdfApiService;
        private readonly IDespachoBLL _despachoBLL;

        public EdocsController(IDespachoWorkService despachoWorkService, IEDocsService edocsService, IAcessoCidadaoService acessoCidadaoService, IPdfApiService pdfApiService, IDespachoBLL despachoBLL)
        {
            _despachoWorkService = despachoWorkService;
            _edocsService = edocsService;
            _acessoCidadaoService = acessoCidadaoService;
            _pdfApiService = pdfApiService;
            _despachoBLL = despachoBLL;
        }

        public FileContentResult Pdf()
        {
            var teste = "<html> <head>     <title></title> </head> <body>     <div class='text-center'>         <h1 class='display-4'>EOuv</h1>         <p>Sistema de Ouvidoria do Espírito Santo</p>     </div> </body> </html>";

            Task<byte[]> task = _pdfApiService.GerarPdfByHtml(teste);
            Task.WaitAll(task);
            var resultado = task.Result;

            //System.IO.File.WriteAllBytes(@"C:\Temp\hello.pdf", resultado);

            return File(resultado, "application/pdf");
        }

        public JsonResult BuscarPatriarca()
        {
            System.Threading.Tasks.Task<List<PatriarcaModel>> task = _edocsService.GetPatriarca();

            Task.WaitAll(task);

            List<PatriarcaModel> patriarca = task.Result;
            return Json(patriarca);
        }

        public JsonResult BuscarAgentes(String nome)
        {
            Task<AgentePublicoPapelModel[]> task = _acessoCidadaoService.GetAgentePublico("3ca6ea0e-ca14-46fa-a911-22e616303722", nome);// Prodest

            Task.WaitAll(task);

            AgentePublicoPapelModel[] agente = task.Result;
            return Json(agente);
        }

        public JsonResult BuscarOrganizacoes()
        {
            System.Threading.Tasks.Task<List<PatriarcaModel>> task = _edocsService.GetOrganizacoes("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");// ESGOV

            Task.WaitAll(task);

            List<PatriarcaModel> organizacoes = task.Result;
            return Json(organizacoes);
        }

        public JsonResult BuscarSetores()
        {
            System.Threading.Tasks.Task<List<PatriarcaSetorModel>> task = _edocsService.GetSetores("3ca6ea0e-ca14-46fa-a911-22e616303722");// Prodest

            Task.WaitAll(task);

            List<PatriarcaSetorModel> setor = task.Result;
            return Json(setor);
        }

        public JsonResult BuscarGrupoTrabalho()
        {
            System.Threading.Tasks.Task<List<PatriarcaSetorModel>> task = _edocsService.GetGrupoTrabalho("3ca6ea0e-ca14-46fa-a911-22e616303722");// Prodest

            Task.WaitAll(task);

            List<PatriarcaSetorModel> grupo = task.Result;
            return Json(grupo);
        }

        public JsonResult BuscarComissoes()
        {
            System.Threading.Tasks.Task<List<PatriarcaSetorModel>> task = _edocsService.GetComissoes("3ca6ea0e-ca14-46fa-a911-22e616303722");// Prodest

            Task.WaitAll(task);

            List<PatriarcaSetorModel> comissoes = task.Result;
            return Json(comissoes);
        }

        public JsonResult BuscarPapeis()
        {
            Task<List<PapelModel>> task = _edocsService.GetPapeis();
            Task.WaitAll(task);

            List<PapelModel> papel = task.Result;
            return Json(papel);
        }

        public JsonResult BuscarPlanosAtivos()
        {
            Task<PlanoModel[]> task = _edocsService.GetPlanosAtivos("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");// ESGOV

            Task.WaitAll(task);

            PlanoModel[] planos = task.Result;
            return Json(planos);
        }

        public JsonResult BuscarClassesAtivas()
        {
            System.Threading.Tasks.Task<ClasseModel[]> task = _edocsService.GetClassesAtivas("c4496f9f-e366-4383-945f-de3fe5762c3a");// "nome": "PLANO DE CLASSIFICAÇÃO DE DOCUMENTOS: ATIVIDADES-MEIO"

            Task.WaitAll(task);

            ClasseModel[] planos = task.Result;
            return Json(planos);
        }

        public EventoModel BuscarEvento(string id)
        {
            System.Threading.Tasks.Task<EventoModel> task = BuscarEventoConcluidoAsync(id);

            Task.WaitAll(task);

            EventoModel evento = task.Result;
            return evento;
        }

        public async Task<EventoModel> BuscarEventoConcluidoAsync(string id,
            int? tries = 30,
            int? delayMs = 1000)
        {
            var evento = new EventoModel();

            // realiza polling na API do E-Docs até que o Evento esteja disponível
            do
            {
                await Task.Delay(delayMs.Value);
                evento = await _edocsService.GetEvento(id);
                tries--;
            } while (evento.Situacao.ToUpper() != nameof(Enums.EventoSituacao.Concluido).ToUpper() && tries > 0);

            if (evento.Situacao.ToUpper() != nameof(Enums.EventoSituacao.Concluido).ToUpper() && tries == 0)
            {
                // caso o número máximo de tentativas seja extrapolado
                throw new EDocsApiException();
            }

            return evento;
        }

        public JsonResult BuscarFundamentosLegais()
        {
            System.Threading.Tasks.Task<FundamentoLegalModel[]> task = _edocsService.GetFundamentosLegais("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");// ESGOV

            Task.WaitAll(task);

            FundamentoLegalModel[] planos = task.Result;
            return Json(planos);
        }

        public JsonResult GetConjuntoAgentesPublicos()
        {
            System.Threading.Tasks.Task<AgentePublicoModel[]> task = _acessoCidadaoService.GetConjuntoAgentesPublicos("ec00931d-74a2-4877-9b93-95ce029ba7f6");// analista

            Task.WaitAll(task);

            AgentePublicoModel[] planos = task.Result;
            return Json(planos);
        }

        public string GetDocumentoDownloadUrl()
        {
            System.Threading.Tasks.Task<string> task = _edocsService.GetDocumentoDownloadUrl("38683aef-0613-45ea-bfd0-663783a7bfe0");// Documento

            Task.WaitAll(task);

            string url = task.Result;
            return url;
        }

        //public JsonResult GetEncaminhamentoPorProtocolo()
        //{//Retorna o encaminhamento inicial do protocolo
        //    string idProtocolo = "2021-RXRGDG";
        //    return GetEncaminhamentoPorProtocolo(idProtocolo);
        //}
        public JsonResult GetEncaminhamentoPorProtocolo(string id)
        {//Retorna o encaminhamento inicial do protocolo
            string idProtocolo = id;
            System.Threading.Tasks.Task<EncaminhamentoModel> task = _edocsService.GetEncaminhamentoPorProtocolo(idProtocolo);

            Task.WaitAll(task);

            EncaminhamentoModel idEncaminhamento = task.Result;
            return Json(idEncaminhamento);
        }

        //public string GetProtocoloEncaminhamento()
        //{//Retorna o encaminhamento inicial do protocolo
        //    string idEncaminhamento = "22a16dcb-8248-4655-ad33-6d7df581d7f2";
        //    System.Threading.Tasks.Task<string> task = _edocsService.GetProtocoloEncaminhamento(idEncaminhamento);

        //    Task.WaitAll(task);

        //    string protocolo = task.Result;
        //    return protocolo;
        //}

        public JsonResult GetDocumentoEncaminhamento()
        {
            System.Threading.Tasks.Task<DocumentoControladoModel[]> task = _edocsService.GetDocumentoEncaminhamento("89565801-9382-4785-94f8-cd35d4ab39d2");// Documento

            Task.WaitAll(task);

            DocumentoControladoModel[] documentos = task.Result;
            return Json(documentos);
        }

        public JsonResult BuscarRastreio()
        {
            System.Threading.Tasks.Task<EncaminhamentoRastreioModel> task = _edocsService.GetRastreio("89565801-9382-4785-94f8-cd35d4ab39d2");// Documento

            Task.WaitAll(task);

            EncaminhamentoRastreioModel rastreio = task.Result;
            return Json(rastreio);
        }

        public JsonResult EncontraDestinatarioHangFire()
        {
            System.Threading.Tasks.Task<EncaminhamentoRastreioDestinoModel> task = _edocsService.ResponsavelPorResponderAoDestinatario("89565801-9382-4785-94f8-cd35d4ab39d2", new[] { "43ccc355-87e9-4f14-8812-6469f8f0c81b", new Guid().ToString(), new Guid().ToString() });// Encaminhamento, grupo
            //System.Threading.Tasks.Task<bool> task = _edocsBLL.EncontraDestinatario("89565801-9382-4785-94f8-cd35d4ab39d2", new[]{ new Guid().ToString(), new Guid().ToString()});// Encaminhamento, grupo

            Task.WaitAll(task);

            EncaminhamentoRastreioDestinoModel encontrado = task.Result;
            return Json(encontrado);
        }

        public JsonResult GetPapelAcessoCidadao()
        {
            //"Roberto Marconi de Macedo Filho - ANALISTA DE TECNOLOGIA DA INFORMACAO - SGPRJ - PRODEST - GOVES",
            System.Threading.Tasks.Task<AgentePublicoPapelModel> task = _acessoCidadaoService.GetPapel("90dab47e-e5ef-481e-8d0f-8a90d9390f4d");// Encaminhamento, grupo
            //System.Threading.Tasks.Task<bool> task = _edocsBLL.EncontraDestinatario("89565801-9382-4785-94f8-cd35d4ab39d2", new[]{ new Guid().ToString(), new Guid().ToString()});// Encaminhamento, grupo

            Task.WaitAll(task);

            AgentePublicoPapelModel encontrado = task.Result;
            return Json(encontrado);
        }

        public JsonResult BuscarRastreioCompleto()
        {
            System.Threading.Tasks.Task<EncaminhamentoRastreioModel> task = _edocsService.GetRastreioCompleto("89565801-9382-4785-94f8-cd35d4ab39d2");// Documento

            Task.WaitAll(task);

            EncaminhamentoRastreioModel rastreio = task.Result;
            return Json(rastreio);
        }

        #region hangfire

        //public JsonResult GetDespachoEmAberto()
        //{
        //    Task<List<int>> task = _despachoBLL.ObterDespachosEmAberto();
        //    Task.WaitAll(task);
        //    List<int> despachos = task.Result;
        //    return Json(despachos);
        //}

        //public string ResponderDespacho()
        //{
        //    Task<AgenteManifestacaoModel> task = _despachoBLL.MontaAgente("90dab47e-e5ef-481e-8d0f-8a90d9390f4d", 2);
        //    Task.WaitAll(task);
        //    AgenteManifestacaoModel agenteResposta = task.Result;
        //    //salva quem respondeu e marca como respondido
        //    Task.WaitAll(_despachoBLL.ResponderDespacho(33));
        //    return "Despacho respondido";
        //}

        //public string EncontraDestinatarioHangFireTeste()
        //{
        //    int idDespacho = 39;
        //    string retorno = "";
        //    try
        //    {
        //        //busca destinatario
        //        Task<DespachoManifestacaoModel> taskDespacho = _despachoBLL.ObterDespachoEDestinatario(idDespacho);
        //        Task.WaitAll(taskDespacho);
        //        DespachoManifestacaoModel despacho = taskDespacho.Result;

        //        //busca se o encaminhamento foi respondido pelo destinatario, retorna quem respondeu
        //        Task<EncaminhamentoRastreioDestinoModel> task = _edocsBLL.ResponsavelPorResponderAoDestinatario(despacho.IdEncaminhamento.ToString(), new[] { despacho.AgenteDestinatario.GuidUsuario });
        //        Task.WaitAll(task);

        //        EncaminhamentoRastreioDestinoModel responsavel = task.Result;
        //        if (responsavel != null)//encontrado
        //        {
        //            retorno += $"\n o responsavel{responsavel.Id} - {responsavel.Nome} respondeu pelo encaminhamento {despacho.IdEncaminhamento.ToString()}";
        //            //verificar se o despacho já foi respondido
        //            if (despacho.IdSituacaoDespacho == (int)Enums.SituacaoDespacho.Aberto)
        //            {
        //                retorno += $"\n o encaminhamento {despacho.IdEncaminhamento.ToString()} esta {despacho.SituacaoDespacho.DescSituacaoDespacho}";
        //                Task<AgenteManifestacaoModel> taskAgente = _despachoBLL.MontaAgente(responsavel.Id, responsavel.TipoAgente);
        //                AgenteManifestacaoModel agenteResposta = taskAgente.Result;
        //                //salva quem respondeu e marca como respondido
        //                _despachoBLL.ResponderDespacho(despacho.IdDespachoManifestacao);
        //                //Task taskResponderDespacho = _despachoBLL.AdicionarDespacho(despacho.IdDespachoManifestacao, agenteResposta);
        //                //Task.WaitAll(taskResponderDespacho);
        //                retorno += $"\n o Despacho {despacho.IdDespachoManifestacao} foi alterado";
        //            }
        //        }
        //        return retorno;
        //    }
        //    catch (Exception e)
        //    {
        //        throw (new Exception(retorno + "\n" + e.StackTrace));
        //    }
        //}

        //public void EncontraDestinatarioHangFireTeste2()
        //{
        //    int idDespacho = 39;
        //    string retorno = "";
        //    try
        //    {
        //        Task.WaitAll(_despachoBLL.ResponderDespacho(idDespacho));
        //    }
        //    catch (Exception e)
        //    {
        //        throw (new Exception(e.StackTrace));
        //    }
        //}

        #endregion hangfire
    }
}