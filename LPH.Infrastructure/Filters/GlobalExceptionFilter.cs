using LPH.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using LPH.Core.Interfaces;
using LPH.Core.Validations;

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

                return;
            }

            else if (context.Exception.GetType() == typeof(ValidationException))
            {
                ValidationException exception = (ValidationException)context.Exception;

                if (string.IsNullOrEmpty(exception.Message))
                {
                    var result = new { Message = "Error de validacion, revisar para mas detalles", ValidacionesFallidas = exception.FailValidators };

                    context.Result = new ObjectResult(result);
                    var vali = exception.FailValidators.FirstOrDefault();

                    var errfirs = (BaseValidation)vali;

                    context.HttpContext.Response.StatusCode = (int)errfirs.StatusCode;
                    context.ExceptionHandled = true;
                }
                else
                {
                    var result = new { Message = exception.Message, FailValidators = exception.FailValidators };

                    context.Result = new ObjectResult(result);
                    var vali = exception.FailValidators.FirstOrDefault();

                    var errfirs = (BaseValidation)vali;

                    context.HttpContext.Response.StatusCode =(int)errfirs.StatusCode;
                    context.ExceptionHandled = true;
                }

                return;
             

               
            }

            else if (context.Exception is Exception)
            {
                if (context.Exception.InnerException != null)
                {
                    context.Result = new BadRequestObjectResult(new  { message = $"Error: {context.Exception.Message}\n Inner Error: {context.Exception.InnerException}" });
                    context.HttpContext.Response.StatusCode = 500;
                    context.ExceptionHandled = true;
                }
                else
                {
                   context.Result = new BadRequestObjectResult(new  { message = $"Error: {context.Exception.Message} " });
                    context.HttpContext.Response.StatusCode = 500;
                    context.ExceptionHandled = true;
                }
            }

        }
    }
}
