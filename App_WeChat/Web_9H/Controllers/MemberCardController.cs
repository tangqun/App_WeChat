using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class MemberCardController : Controller
    {
        /// <summary>
        /// 会员卡主页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 会员卡激活
        /// </summary>
        public ActionResult Activate()
        {
            return View();
        }
    }
}