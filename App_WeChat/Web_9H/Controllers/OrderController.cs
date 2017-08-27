using Helper_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class OrderController : BaseController
    {
        /// <summary>
        /// 订单列表
        /// </summary>
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 订单详情，处理 已支付 和 未支付 状态
        /// </summary>
        public ActionResult Details()
        {
            return View();
        }

        /// <summary>
        /// 创建订单（去买单）
        /// </summary>
        public ActionResult Create()
        {
            return View();
            string openID = CookieHelper.GetCookie("uid");
            if (!string.IsNullOrEmpty(openID))
            {
                // 门店列表

                return View();
            }
            else
            {
                CookieHelper.SetCookie("redirect_uri", "/order/create");
                return Redirect("/oauth2/launch");
            }
        }

        [HttpPost]
        public ActionResult Create(PayModel model)
        {
            return Content("");
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        public ActionResult Pay()
        {
            return View();
        }
    }
}