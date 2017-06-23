using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class OrderController : Controller
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