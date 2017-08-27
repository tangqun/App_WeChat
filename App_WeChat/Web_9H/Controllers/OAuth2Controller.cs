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
    public class OAuth2Controller : BaseController
    {
        private IOAuth2BLL oauth2BLL = new OAuth2BLL();

        public ActionResult Launch()
        {
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?";

            url += "appid=" + AuthorizerAppID;

            url += "&redirect_uri=" + Url.Encode("http://" + AuthorizerAppID + ".wx.smartyancheng.com/oauth2/accept");

            url += "&response_type=code&scope=snsapi_base&state=&component_appid=" + ConfigHelper.ComponentAppID;

            url += "#wechat_redirect";

            return Redirect(url);
        }

        public ActionResult Accept(string code, string state, string appID)
        {
            if (string.IsNullOrEmpty(code))
            {
                // 用户取消了授权
                return Redirect("/error/canceloauth2");
            }
            else
            {
                //
                RESTfulModel resp = oauth2BLL.GetAuth(appID, code, state);
                if (resp.Code == 0)
                {
                    // 设置openid
                    CookieHelper.SetCookie("uid", resp.Data.ToString());

                    string redirect_uri = CookieHelper.GetCookie("redirect_uri");
                    return Redirect(redirect_uri);
                }
                else
                {
                    // 授权失败
                    return Redirect("/error/oauth2failed");
                }
            }
            // 定制500错误页
        }
    }
}