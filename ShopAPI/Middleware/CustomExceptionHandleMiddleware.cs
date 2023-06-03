using FluentValidation;
using Newtonsoft.Json;
using ShopDAL.Scenarios.Common.Exceptions;
using System.Net;

namespace ShopAPI.Middleware
{
    public class CustomExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandleMiddleware(RequestDelegate next) => _next = next;

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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(ex) 
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotEnoughProductException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new {errpr = ex.Message});
            }

            return context.Response.WriteAsync(result);
        }
    }
}
