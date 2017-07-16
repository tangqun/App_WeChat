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
        public string AuthorizerAppID = string.Empty;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;

            LogHelper.Info("原始请求 url", request.Url.AbsoluteUri);

            string host = request.Url.Host;

            // wxae43212cd9f3ed6e
            // wxae43212cd9f3ed6e
            Regex regex = new Regex("^([a-z0-9]{18})\\.wx\\.smartyancheng\\.com$", RegexOptions.IgnoreCase);

            // 主机头
            if (true)
            {

            }
            else if (ConfigHelper.UniversalHost == host.ToLower())
            {
                // 授权、分享、消息
                
            }
            else if (regex.IsMatch(host))
            {
                // 请求子页
                string authorizerAppID = regex.Match(host).Groups[1].Value;

                AuthorizerAppID = authorizerAppID;

                
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(404);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}