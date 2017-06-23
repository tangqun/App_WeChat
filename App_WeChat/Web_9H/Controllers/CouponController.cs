using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class CouponController : Controller
    {
        /// <summary>
        /// 优惠券列表，仅支持部分券
        /// </summary>
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}