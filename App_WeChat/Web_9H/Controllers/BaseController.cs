using Helper_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class BaseController : Controller
    {
        protected string AuthorizerAppID { get; set; }
        protected string IP { get; set; }
        protected string AbsoluteURL { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;

            LogHelper.Info("原始请求 url", request.Url.ToString());

            string host = request.Url.Host;

            Regex regex = new Regex("^([a-z0-9]{18})\\.wx\\.smartyancheng\\.com$", RegexOptions.IgnoreCase);
            
            // 主机头
            if (regex.IsMatch(host))
            {
                // 请求子页
                string authorizerAppID = regex.Match(host).Groups[1].Value;

                AuthorizerAppID = authorizerAppID;

                IP = request.UserHostAddress;

                AbsoluteURL = request.Url.ToString();
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(404);
            }
            
            ViewBag.AuthorizerAppID = AuthorizerAppID;
            base.OnActionExecuting(filterContext);
        }
    }
}