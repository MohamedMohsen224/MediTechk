﻿using MediTech.Errors;
using System.Net;
using System.Text.Json;

namespace MediTech.Middelware
{
    public class ExceptionsMiddleware
    {
     
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionsMiddleware> logger;
         private readonly IHostEnvironment environment;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger, IHostEnvironment environment)
        {
                this.next = next;
                this.logger = logger;
                this.environment = environment;
        }
        public async Task IncokeAsync(HttpContext context)
        {

           try
           {
            await next.Invoke(context);
           }
            catch (Exception ex)
           {
             logger.LogError(ex, ex.Message);
             context.Response.ContentType = "application/json";
             context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

             var options = new JsonSerializerOptions()
             {
             PropertyNamingPolicy = JsonNamingPolicy.CamelCase
             };
              var response = environment.IsDevelopment() ? new ApiExceptionError((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
              new ApiExceptionError((int)HttpStatusCode.InternalServerError);
              var json = JsonSerializer.Serialize(response);
              await context.Response.WriteAsync(json);

           }
        }
    }
}

