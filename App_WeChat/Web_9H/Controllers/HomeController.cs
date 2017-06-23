using BLL_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat_9H.Controllers
{
    public class HomeController : Controller
    {
        private IMsgBLL msgBLL = new MsgBLL();

        public ActionResult Index()
        {
            return View();
        }

        public string RecvMsg(string id)
        {
            return msgBLL.Receive(id, Request.InputStream);
        }
    }
}