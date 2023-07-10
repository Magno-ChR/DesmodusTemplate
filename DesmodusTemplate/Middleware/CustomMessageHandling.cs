using System.Net;

namespace DesmodusTemplate.Middleware
{
    public class CustomMessageHandling
    {
        private readonly RequestDelegate _next;

        public CustomMessageHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            int statusCode = context.Response.StatusCode;
            switch (statusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    await HandleUnauthorizedAsync(context);
                    break;
                case (int)HttpStatusCode.Forbidden:
                    await HandleForbiddenAsync(context);
                    break;
                //case (int)HttpStatusCode.BadRequest:
                //    await HandleBadRequestAsync(context);
                //    break;
                case (int)HttpStatusCode.InternalServerError:
                    await HandleInternalServerErrorAsync(context);
                    break;
                default:
                    break;
            }
        }

        private async Task HandleUnauthorizedAsync(HttpContext context)
        {
            // Personaliza el mensaje de error para el código de estado Unauthorized (401)
            await context.Response.WriteAsync("No estás autorizado para acceder a este recurso.");
        }

        private async Task HandleForbiddenAsync(HttpContext context)
        {
            // Personaliza el mensaje de error para el código de estado Forbidden (403)
            await context.Response.WriteAsync("No tienes permisos para acceder a este recurso.");
        }

        private async Task HandleBadRequestAsync(HttpContext context)
        {
            // Personaliza el mensaje de error para el código de estado Bad Request (400)
            await context.Response.WriteAsync("La solicitud es incorrecta. Verifica los datos enviados.");
        }

        private async Task HandleInternalServerErrorAsync(HttpContext context)
        {
            // Personaliza el mensaje de error para el código de estado Internal Server Error (500)
            await context.Response.WriteAsync("Ocurrió un error interno en el servidor.");
        }
    }
}
