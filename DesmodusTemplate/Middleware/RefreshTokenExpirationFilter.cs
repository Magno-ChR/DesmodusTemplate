﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace DesmodusTemplate.Middleware
{
    public class RefreshTokenExpirationFilter : IActionFilter
    {
        private const int RefreshThresholdMinutes = 5;
        private readonly IUserService userService;

        public RefreshTokenExpirationFilter(IUserService userService)
        {
            this.userService = userService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = userService.JWTClaims(); // Obtener el token de la petición (desde el encabezado, por ejemplo)

            if (token != null)
            {
                var tokenExpiration =DateTime.Parse(token.Expiracion);// Obtener la fecha de expiración del token (desde el token mismo, almacenamiento, etc.)

            if (tokenExpiration.Subtract(DateTime.UtcNow) <= TimeSpan.FromMinutes(RefreshThresholdMinutes))
                {
                    // Calcular la nueva fecha de expiración (agregar más tiempo, por ejemplo, otros 15 minutos)
                    var newExpiration = tokenExpiration.AddMinutes(15);

                    // Actualizar la fecha de expiración en el token (si es posible, dependiendo de la implementación del token)
                    // Esto puede implicar generar un nuevo token con la nueva fecha de expiración o actualizar la fecha de expiración en el token existente

                    // Actualizar la fecha de expiración en el almacenamiento del token (si es necesario)

                    // Agregar la nueva fecha de expiración al encabezado de respuesta para que el cliente pueda actualizar su copia del token (si es necesario)
                    context.HttpContext.Response.Headers.Add("X-Token-Expiration", newExpiration.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No se necesita ninguna lógica después de ejecutar la acción
        }
    }
}
