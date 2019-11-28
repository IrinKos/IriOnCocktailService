using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Middlewares
{
    public class PageNotFound
    {
        private readonly RequestDelegate requestDelegate;

        public PageNotFound(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await this.requestDelegate.Invoke(httpContext);

            if(httpContext.Response.StatusCode==404)
            {
                httpContext.Response.Redirect("/Home/PageNotFound");
            }
        }
    }
}
