using BLL_9H;
using Helper_9H;
using IBLL_9H;
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
        private IOrderBLL orderBLL = new OrderBLL();

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
        public ActionResult Confirm(string entityShopID, int totalFee)
        {
            string aus = CookieHelper.GetCookie("aus");
            string openID = CookieHelper.GetCookie("uid");
            if (aus == "tjh")
            {
                CookieHelper.ClearCookie("aus");
                if (!string.IsNullOrEmpty(openID))
                {
                    // 
                    ViewBag.EntityShop = new EntityShopModel() { ID = entityShopID, Name = "现代纯K盐城中南店" };
                    ViewBag.TotalFee = totalFee;

                    return View();
                }
                else
                {
                    return Redirect("/error/code500");
                }
            }
            else
            {
                CookieHelper.SetCookie("redirect_uri", AbsoluteURL);
                return Redirect("/oauth2/forcelaunch");
            }
        }

        /// <summary>
        /// 创建订单并支付
        /// </summary>
        [HttpPost]
        public ActionResult Create(OrderModel model)
        {
            return Content(orderBLL.Create(AuthorizerAppID, CookieHelper.GetCookie("uid"), model, IP).ToString(), "application/json");
        }
    }
}