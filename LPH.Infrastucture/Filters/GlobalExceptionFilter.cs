using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LPH.Core.Exceptions;
using System;
using System.Net;


namespace LPH.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusisnessException))
            {
                var exception = (BusisnessException)context.Exception;
                var validation = new
                {
                    exception.Status,
                    Title = Enum.GetName(typeof(HttpStatusCode), ((HttpStatusCode)exception.Status)),
                    Detail = exception.Message,
                    All = exception.Details

                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = exception.Status;
                context.ExceptionHandled = true;
            }



        }
    }
}
