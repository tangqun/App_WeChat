using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WeChat_9H.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string host = filterContext.HttpContext.Request.Url.Host;
            Regex regex = new Regex("[0-9]{1,6}\\.wechat.smartyancheng.com", RegexOptions.IgnoreCase);

            base.OnActionExecuting(filterContext);
        }
    }
}