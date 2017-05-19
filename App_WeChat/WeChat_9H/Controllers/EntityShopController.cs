using BLL_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat_9H.Controllers
{
    public class EntityShopController : BaseController
    {
        private IEntityShopBLL entityShopBLL = new EntityShopBLL();

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