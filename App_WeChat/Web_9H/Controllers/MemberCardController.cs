using BLL_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class MemberCardController : BaseController
    {
        private IOAuth2BLL oauth2BLL = new OAuth2BLL();

        /// <summary>
        /// 会员卡主页
        /// </summary>
        public ActionResult Index(string code, string state, string appID)
        {
            if (string.IsNullOrEmpty(code))
            {
                // 用户取消了授权
                return View();
            }
            else
            {
                RESTfulModel resp = oauth2BLL.GetAuth(appID, code, state);
                if (resp.Code == 0)
                {
                    ViewBag.OpenID = resp.Data;
                    return View();
                }
                else
                {
                    return View();
                }
            }
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