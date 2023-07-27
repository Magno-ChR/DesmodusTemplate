using Azure;
using Microsoft.AspNetCore.Mvc;

namespace DesmodusTemplate.DTOs
{
    public class Respuesta<T>
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "Ok";
        public T? Data { get; set; }
        public bool IsSuccess
        {
            get
            {
                // si el codigo es 200, es exitoso el request 
                return StatusCode >= 200 && StatusCode < 300;

            }
        }
    }

    public class Responses
    {
       

        public static ObjectResult Get<T>(T value, int statusCode = 200, string message = "Ok")
        {
            Respuesta<T> resp;
            Respuesta<string> respDefault; 
            if (value.Equals(null))
            {
                respDefault = new Respuesta<string> { Message = message, StatusCode = statusCode };
                return new ObjectResult(respDefault)
                {
                    Value = respDefault,
                    StatusCode = respDefault.StatusCode
                };
            }
            else
            {
                resp = new Respuesta<T> { Message = message, StatusCode = statusCode, Data = value };
                return new ObjectResult(resp)
                {
                    Value = resp,
                    StatusCode = resp.StatusCode
                };
            }
        }
   
        public static ObjectResult Ok(string message = "Ok")
        {
            var resp = new Respuesta<string> { Message = message, StatusCode = 200 };
            return new ObjectResult(resp)
            {
                Value = resp,
                StatusCode = resp.StatusCode
            };
        }
        public static ObjectResult Error400(string message = "Solicitud incorrecta")
        {
            var resp = new Respuesta<string> { Message = message, StatusCode = 400 };
            return new ObjectResult(resp)
            {
                Value = resp,
                StatusCode = resp.StatusCode
            };
        }
        public static ObjectResult Error404(string message = "No encontrado")
        {
            var resp = new Respuesta<string> { Message = message, StatusCode = 404 };
            return new ObjectResult(resp)
            {
                Value = resp,
                StatusCode = resp.StatusCode
            };
        }
        public static ObjectResult Error500(string message = "Error interno del servidor")
        {
            var resp = new Respuesta<string> { Message = message, StatusCode = 500 };
            return new ObjectResult(resp)
            {
                Value = resp,
                StatusCode = resp.StatusCode
            };
        }
    }

}