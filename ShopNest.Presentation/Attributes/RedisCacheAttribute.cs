using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ShopNest.Services.Abstraction.ServiceAbstractions;
using System.Text;

namespace ShopNest.Presentation.Attributes
{
    //Any Constructor From The ActionFilter is A Special Type Constructor
    //and Cant Ask the clr to inject an object into a Special Type Ctor
    public class RedisCacheAttribute : ActionFilterAttribute
    {
        private readonly int durationInMinutes;
        public RedisCacheAttribute(int durationInMinutes = 5)
        {
            this.durationInMinutes = durationInMinutes;
        }
        //Starts Before and After The Endpoint occur
        //Request called before entering the Att
        public override async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)//Next Action Could be another attribute or an endpoint
        {
            var CacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            //Create Cache Key Based On the Request Path & Query Param
            var CacheKey = CreateCacheKey(context.HttpContext.Request);
            //If Data Exists in the Cache 
            //if Exist -> Return Cache Data And Skip Executing the end point 
            var CacheValue = await CacheService.GetAsync(CacheKey);
            if (CacheValue is not null)
            {
                context.Result = new ContentResult()
                {
                    Content = CacheValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }
            //else -> Excecute the endpoint and store the result  in the Cache 
            var ExcecutedContext = await next.Invoke();

            if (ExcecutedContext.Result is OkObjectResult result)
            {
                await CacheService.SetAsync(CacheKey, result.Value!, TimeSpan.FromMinutes(durationInMinutes));
            }
        }
        //api/products/brandId/etc
        #region HelperMethod
        private static string CreateCacheKey(HttpRequest httpRequest)
        {
            //Mutable Collection
            StringBuilder CacheKey = new();
            CacheKey.Append(httpRequest.Path);//api/products
            foreach (var item in httpRequest.Query.OrderBy(x => x.Key))
            {
                CacheKey.Append($"|{item.Key} - {item.Value}");
            }
            return CacheKey.ToString();
        }
        #endregion
    }
}
