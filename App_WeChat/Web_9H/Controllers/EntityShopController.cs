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
    public class EntityShopController : BaseController
    {
        private IOAuth2BLL oauth2BLL = new OAuth2BLL();

        /// <summary>
        /// 门店列表
        /// </summary>
        public ActionResult List()
        {
            string openID = CookieHelper.GetCookie("uid");
            if (!string.IsNullOrEmpty(openID))
            {
                return View();
            }
            else
            {
                CookieHelper.SetCookie("redirect_uri", AbsoluteURL);
                return Redirect("/oauth2/launch");
            }
        }

        /// <summary>
        /// 门店详情
        /// </summary>
        public ActionResult Details(string id)
        {
            return View();
        }
    }
}