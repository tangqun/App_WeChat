using BLL_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class HomeController : BaseController
    {
        private IMsgBLL msgBLL = new MsgBLL();
        private IConfigBLL configBLL = new ConfigBLL();

        public ActionResult Index()
        {
            return View();
        }

        public string RecvMsg(string id)
        {
            return msgBLL.Receive(id, Request.InputStream);
        }

        public ActionResult GetJSAPIConfig(string authorizerAppID, string url)
        {
            return Content(configBLL.GetJSAPIConfig(authorizerAppID, url).ToString(), "application/json");
        }

        public ActionResult GetAPIConfig(string authorizerAppID, string cardID)
        {
            return Content(configBLL.GetAPIConfig(authorizerAppID, cardID).ToString(), "application/json");
        }
    }
}