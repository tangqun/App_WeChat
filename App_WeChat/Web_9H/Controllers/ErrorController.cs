using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult CancelOAuth2()
        {
            return View();
        }

        public ActionResult OAuth2Failed()
        {
            return View();
        }

        public ActionResult Code500()
        {
            return View();
        }
    }
}