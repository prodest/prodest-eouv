using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Model.Edocs;
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
        private readonly IEDocsBLL _edocsBLL;


        public EdocsController(IDespachoWorkService despachoWorkService, IEDocsBLL edocsBLL)
        {
            _despachoWorkService = despachoWorkService;
            _edocsBLL = edocsBLL;
        }

        public JsonResult BuscarPatriarca()
        {
            System.Threading.Tasks.Task<List<PatriarcaModel>> task = _edocsBLL.GetPatriarca();

            Task.WaitAll(task);

            List<PatriarcaModel> patriarca = task.Result;
            return Json(patriarca);
        }
        public JsonResult BuscarOrganizacoes()
        {
            System.Threading.Tasks.Task<List<PatriarcaModel>> task = _edocsBLL.GetOrganizacoes("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");// ESGOV

            Task.WaitAll(task);

            List<PatriarcaModel> organizacoes = task.Result;
            return Json(organizacoes);
        }

        public JsonResult BuscarSetores()
        {
            System.Threading.Tasks.Task<List<PatriarcaSetorModel>> task = _edocsBLL.GetSetores("3ca6ea0e-ca14-46fa-a911-22e616303722");// Prodest

            Task.WaitAll(task);

            List<PatriarcaSetorModel> setor = task.Result;
            return Json(setor);
        }
        public JsonResult BuscarGrupoTrabalho()
        {
            System.Threading.Tasks.Task<List<PatriarcaSetorModel>> task = _edocsBLL.GetGrupoTrabalho("3ca6ea0e-ca14-46fa-a911-22e616303722");// Prodest

            Task.WaitAll(task);

            List<PatriarcaSetorModel> grupo = task.Result;
            return Json(grupo);
        }
        public JsonResult BuscarComissoes()
        {
            System.Threading.Tasks.Task<List<PatriarcaSetorModel>> task = _edocsBLL.GetComissoes("3ca6ea0e-ca14-46fa-a911-22e616303722");// Prodest

            Task.WaitAll(task);

            List<PatriarcaSetorModel> comissoes = task.Result;
            return Json(comissoes);
        }
        public JsonResult BuscarPapeis()
        {
            Task<List<PapelModel>> task = _edocsBLL.GetPapeis();
            Task.WaitAll(task);

            List<PapelModel> papel = task.Result;
            return Json(papel);
        }

        public string EnviarArquivo()
        {
            string caminhoCompletoArquivoLocal = @"C:\Temp\TesteEDOCS.pdf";
            FileInfo fi = new FileInfo(caminhoCompletoArquivoLocal);
            int tamanhoArquivo = Convert.ToInt32(fi.Length);

            Task<GerarUrlModel> task = _edocsBLL.GetGerarUrl(tamanhoArquivo);
            byte[] readText = System.IO.File.ReadAllBytes(caminhoCompletoArquivoLocal);
            Task<string> task2 = _edocsBLL.PostTempUrlMinio(task.Result, readText);
            Task.WaitAll(task);

            string result = task2.Result;
            //IdentificadorTemporarioArquivoNaNuvem
            return result;
        }

        public JsonResult BuscarPlanosAtivos()
        {
            Task<PlanoModel[]> task = _edocsBLL.GetPlanosAtivos("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");// ESGOV

            Task.WaitAll(task);

            PlanoModel[] planos = task.Result;
            return Json(planos);
        }

        public JsonResult BuscarClassesAtivas()
        {
            System.Threading.Tasks.Task<ClasseModel[]> task = _edocsBLL.GetClassesAtivas("c4496f9f-e366-4383-945f-de3fe5762c3a");// "nome": "PLANO DE CLASSIFICAÇÃO DE DOCUMENTOS: ATIVIDADES-MEIO"

            Task.WaitAll(task);

            ClasseModel[] planos = task.Result;
            return Json(planos);
        }

        public JsonResult BuscarFundamentosLegais()
        {
            System.Threading.Tasks.Task<FundamentoLegalModel[]> task = _edocsBLL.GetFundamentosLegais("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");// ESGOV

            Task.WaitAll(task);

            FundamentoLegalModel[] planos = task.Result;
            return Json(planos);
        }
        //ainda precisa de mais informações
        public string DocumentoCapturarNatoDigitalCopiaServidor()
        {
            //Task<string> task = _edocsBLL.PostDocumentoCapturarNatoDigitalCopiaServidor(parameters);
            //Task.WaitAll(task);

            //string result = task.Result;
            //string identificadorTemporarioArquivoNaNuvem = JsonConvert.SerializeObject(EnviarArquivo());
            string identificadorTemporarioArquivoNaNuvem = EnviarArquivo();

            DocumentoRequestModel parameters = new DocumentoRequestModel {
                IdPapelCapturador = "ec00931d-74a2-4877-9b93-95ce029ba7f6", //analista
                IdClasse = "b84db19f-7c05-44b8-9f07-9592e3a91f0a", //"01.01.05.01"
                ValorLegalDocumentoConferencia = Shared.Util.Enums.DocumentoValorLegal.CopiaSimples,
                ValorLegal = Shared.Util.Enums.DocumentoValorLegal.CopiaSimples,
                NomeArquivo = "Manifestação número",
                CredenciarCapturador = true,
                RestricaoAcesso = new RestricaoAcessoModel() {
                    TransparenciaAtiva = false,
                    IdsFundamentosLegais = new Guid[1] { new Guid("d4ecc485-d889-4e2f-848c-b2099b3412b7") }, //"Sigilo das Manifestações de Ouvidoria"
                    ClassificacaoInformacao = new ClassificacaoInformacaoModel() {
                        PrazoAnos = 1,
                        PrazoMeses = 0,
                        PrazoDias = 0,
                        Justificativa = "Ouvidoria",
                        IdPapelAprovador = "ec00931d-74a2-4877-9b93-95ce029ba7f6", //mesmo do capturador
                    }
                },
                IdentificadorTemporarioArquivoNaNuvem = identificadorTemporarioArquivoNaNuvem,
            };

            //var auxJson = JsonConvert.SerializeObject(parameters);

            Task<string> task = _edocsBLL.PostDocumentoCapturarNatoDigitalCopiaServidor(parameters);
            Task.WaitAll(task);

            string result = task.Result;
            return result;
        }

        public string Encaminhar() {
            //DOCUMENTO CAPTURADO -> DocumentoCapturarNatoDigitalCopiaServidor
            string idDocumento = "233c654d-5721-45e6-8306-6ffbfa5822c2"; //usuário logado deve ter acesso ao documento
            var parametros = new EncaminhamentoRequestModel() {
                Assunto = "Manifestação número",
                Mensagem = "Manifestação número",
                IdResponsavel = "ec00931d-74a2-4877-9b93-95ce029ba7f6",
                IdsDestinos = new string[] { "ec00931d-74a2-4877-9b93-95ce029ba7f6" },
                IdsDocumentos = new string[] { idDocumento },
                RestricaoAcesso = new RestricaoAcessoModel()
                {
                    TransparenciaAtiva = false,
                    IdsFundamentosLegais = new Guid[1] { new Guid("d4ecc485-d889-4e2f-848c-b2099b3412b7") }, //"Sigilo das Manifestações de Ouvidoria"
                    ClassificacaoInformacao = new ClassificacaoInformacaoModel()
                    {
                        PrazoAnos = 1,
                        PrazoMeses = 0,
                        PrazoDias = 0,
                        Justificativa = "Ouvidoria",
                        IdPapelAprovador = "ec00931d-74a2-4877-9b93-95ce029ba7f6", //mesmo do capturador
                    }
                },
            };

            Task<string> task = _edocsBLL.PostEncaminhamentoNovo(parametros);
            Task.WaitAll(task);

            string result = task.Result;
            return result;
        }

    }
}