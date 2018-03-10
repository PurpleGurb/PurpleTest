using System.Web.Mvc;

namespace OrangeBricks.Web.Attributes
{
    public class ContentSecurityPolicyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            response.AddHeader("Content-Security-Policy", "script-src 'self'");
            response.AddHeader("X-WebKit-CSP", "script-src 'self'");
            response.AddHeader("X-Content-Security-Policy", "script-src 'self'");
            base.OnActionExecuting(filterContext);
        }
    }
}