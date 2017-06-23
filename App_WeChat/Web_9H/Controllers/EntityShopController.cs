using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class EntityShopController : BaseController
    {
        /// <summary>
        /// 门店列表
        /// </summary>
        public ActionResult List()
        {
            return View();
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