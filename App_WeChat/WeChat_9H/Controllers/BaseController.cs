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
        public string AppID = "wxae43212cd9f3ed6e";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string host = filterContext.HttpContext.Request.Url.Host;
            Regex regex = new Regex("([0-9]{1,6})\\.wechat\\.smartyc\\.com", RegexOptions.IgnoreCase);

            if (regex.IsMatch(host))
            {
                // 根据编号查询真实AppID
                string replacedAppID = regex.Match(host).Groups[1].Value;

                base.OnActionExecuting(filterContext);
            }
        }
    }
}