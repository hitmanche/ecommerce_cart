using CL.Filter;
using DeviceDetectorNET;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;

namespace BL.Business.FilterOperations
{
    public class AgentFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string prmUserAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            try
            {
                var dd = new DeviceDetector(prmUserAgent);
                dd.Parse();
                if (dd.IsBot())
                {
                    context.Result = new CustomUnauthorizedResult(new language(null, context.HttpContext).GetErrorString("1001"), statusCode: 403, "1001");
                }
            }
            catch
            {
                context.Result = new CustomUnauthorizedResult(new language(null, context.HttpContext).GetErrorString("1002"), statusCode: 403, "1002");
            }
        }
    }

    public class CustomUnauthorizedResult : JsonResult
    {
        public CustomUnauthorizedResult(string message, int statusCode, string code = "") : base(new CustomError(message, code))
        {
            StatusCode = statusCode;
        }
    }
}
