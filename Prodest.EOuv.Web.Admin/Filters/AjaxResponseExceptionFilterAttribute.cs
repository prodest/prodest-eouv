using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
                //e.Log(context.HttpContext);

                var model = new JsonReturnViewModel();
                model.Mensagem = "Ocorreu um erro ao processar sua solicitação. Tente novamente.";
                var result = new ObjectResult(model);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = result;
            }
        }
    }
}