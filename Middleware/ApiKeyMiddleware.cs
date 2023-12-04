using System.Net;
using Demo.Constants;
using Demo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo.Middleware
{
    public class ApiKeyMiddleware : IMiddleware
    {
       private readonly IApiKeyValidationService _apiKeyValidationService;
        public ApiKeyMiddleware(IApiKeyValidationService apiKeyValidationService)
        {
            _apiKeyValidationService = apiKeyValidationService;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var headerKey = context.Request.Headers[AppConstant.ApiKeyHeaderName].ToString();

            if(!_apiKeyValidationService.IsValidApiKey(headerKey)) 
            {      
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;  
                var message = new { message = "Api Key Invalid or not present"};
                context.Response.WriteAsync(new (JsonConvert.SerializeObject(message)));
                return Task.CompletedTask;      
            }
            next(context);  
            return Task.CompletedTask;         
        }
    }
}