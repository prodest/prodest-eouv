using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Prodest.EOuv.Shared.Utils;
using Prodest.EOuv.UI.Apresentacao;
using System;

namespace Prodest.EOuv.Web.Admin.Filters
{
    public class AjaxResponseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception e = context.Exception;
            if (e != null)
            {

                var model = new JsonReturnViewModel();
                var result = new ObjectResult(model);

                if (e.InnerException.GetType() == typeof(EouvUsuarioSemAcessoException))
                {
                    model.Mensagem = (e.InnerException != null ? e.InnerException.Message : e.Message);
                    result.StatusCode = StatusCodes.Status500InternalServerError;
                }
                else if (e.InnerException.GetType() == typeof(EouvPaginaNaoEncontradaException))
                {
                    model.Mensagem = (e.InnerException != null ? e.InnerException.Message : e.Message);
                    result.StatusCode = StatusCodes.Status400BadRequest;
                }
                else 
                {
                    model.Mensagem = "Ocorreu um erro ao processar sua solicitação. Tente novamente.";
                    result.StatusCode = StatusCodes.Status500InternalServerError;
                }

                context.Result = result;
            }
        }
    }
}