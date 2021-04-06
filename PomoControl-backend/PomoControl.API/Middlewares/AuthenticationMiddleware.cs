using Microsoft.AspNetCore.Http;
using PomoControl.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.API.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (!context.User.Identity.IsAuthenticated)
                    throw new InvalidTokenException();

            }
            catch(PomoControlException ex)
            {
                throw; //Go to ExceptionMiddleware
            }
            await _next(context);
        }
    }
}
