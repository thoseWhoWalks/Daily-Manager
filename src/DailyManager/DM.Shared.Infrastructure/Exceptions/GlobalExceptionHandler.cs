using DM.Shared.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace DM.Shared.Infrastructure.Exceptions
{
    public class GlobalExceptionHandler
    {
        #region Constants

        private const string ContentType = "application/json";

        #endregion

        #region Dependencies

        private readonly RequestDelegate _next;

        #endregion

        public GlobalExceptionHandler(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                // TODO: Logging via Serilog.

                context.Response.ContentType = ContentType;
                context.Response.StatusCode = (int) GetStatusCode(ex);

                await context.Response.WriteAsJsonAsync(ex.Message);
            }
        }

        #region Private methods

        private HttpStatusCode GetStatusCode(Exception ex)
            => ex switch
            {
                DmException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

        #endregion
    }
}
