using Microsoft.AspNetCore.Mvc;

namespace Educa.Web.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected string IpAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
