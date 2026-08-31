
using Microsoft.AspNetCore.Mvc;

namespace ShopNest.API.CustomMiddlwares
{
    public class ExceptionHandlerMiddleware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await Next.Invoke(httpContext);

                if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var problem = new ProblemDetails()
                    {
                        Title = "Error While Processing Http Request Endpoint Not Found",
                        Status = StatusCodes.Status404NotFound,
                        Detail = $"Not Found Endpoint - {httpContext.Request.Path}",
                        Instance = httpContext.Request.Path
                    };
                    await httpContext.Response.WriteAsJsonAsync(problem);

                }
            }
            catch (Exception ex)
            {
                //Logging
                logger.LogError(ex, "Something Went Wrong");
                //Return Custom Error Response
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var problem = new ProblemDetails()
                {
                    Title = "Unexpected Error ",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = ex.Message,
                    Instance = httpContext.Request.Path
                };
                await httpContext.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}
