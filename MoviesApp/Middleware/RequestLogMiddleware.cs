using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using MoviesApp.Controllers;

namespace MoviesApp.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        //Следим только за ActorsController
        public async Task Invoke(HttpContext httpContext, ILogger<ActorsController> logger)
        {
            logger.LogTrace($"Request: {httpContext.Request.Path}  Method: {httpContext.Request.Method} Query: {(httpContext.Request.Query)}");
            await _next(httpContext);
        }
    }
}