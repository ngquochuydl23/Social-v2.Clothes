using Clothes.Commons.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Middlewares
{
    public class ErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = (int)(ex is AppException
              ? HttpStatusCode.BadRequest
              : HttpStatusCode.InternalServerError);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsJsonAsync(new
            {
                Error = ex.Message,
                StatusCode = statusCode
            });
        }
    }
}
