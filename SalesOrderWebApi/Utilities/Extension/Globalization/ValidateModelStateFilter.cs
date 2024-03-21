using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using ViewModel;

namespace SalesOrderWebApi.Utilities.Extension.CustomMiddleware
{
    public class ValidateModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Check if ModelState is invalid and any of the model binding sources contain null values
            if (!context.ModelState.IsValid && context.ActionArguments.Any(c=>string.IsNullOrEmpty(c.Key) || c.Value == null))
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                // Here you need to write your custom error response
                var errorDetail = new ErrorDetailViewModel()
                {
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Message = "Bad Request: " + string.Join(Environment.NewLine, context.ModelState.Where(s => s.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                                                .Select(s => s.Key + " is invalid"))
                };
                await context.HttpContext.Response.WriteAsync(errorDetail.ToString());
                return;
            }

            await next();
        }
    }
}
