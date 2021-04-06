using Microsoft.AspNetCore.Http;
using PomoControl.API.Utilities;
using PomoControl.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace PomoControl.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            PomoControlException ex = null;
            if (exception is PomoControlException)
                ex = (PomoControlException)exception;
            else
                ex = new PomoControlException(exception);

            //log here

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;
            if (!context.Response.Headers.Keys.Contains(AppSettings.HeaderSourceInfo))
                context.Response.Headers.Add(AppSettings.HeaderSourceInfo, ex.SourceResponseAsString);
            return context.Response.WriteAsync(ex.ToString());
        }
    }
}
