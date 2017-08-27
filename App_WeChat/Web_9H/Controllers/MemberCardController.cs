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
    public class MemberCardController : BaseController
    {
        private IMemberCardBLL memberCardBLL = new MemberCardBLL();
        private IMemberInfoBLL memberInfoBLL = new MemberInfoBLL();

        /// <summary>
        /// 会员卡主页
        /// </summary>
        public ActionResult Index()
        {
            // 重定向要授权页
            // https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxab6d7123cc1125f5&redirect_uri=
            //   http://wxab6d7123cc1125f5.wx.smartyancheng.com/membercard/index&response_type=code&scope=snsapi_base&state=&component_appid=wx6230602b18fb87dc#wechat_redirect"

            string openID = CookieHelper.GetCookie("uid");
            if (!string.IsNullOrEmpty(openID))
            {
                MemberCardModel model = memberCardBLL.GetModel(AuthorizerAppID);
                if (model != null)
                {
                    // 会员信息
                    ViewBag.MemberInfo = memberInfoBLL.GetModel(openID, model.CardID);
                }

                return View(model);
            }
            else
            {
                CookieHelper.SetCookie("redirect_uri", "/membercard/index");
                return Redirect("/oauth2/launch");
            }
        }

        /// <summary>
        /// 会员卡激活
        /// 当用户领取会员卡“卡套”后，支持调用该接口对会员卡进行激活，并设置会员信息的初始值，如积分、余额、等级、会员卡编号等会员信息。
        /// 目前，微信会员卡支持三种激活方式，分别是接口激活、一键激活和自动激活。
        /// 6.1接口激活方式https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1451025283
        /// 接口激活通常需要开发者开发用户填写资料的网页。通常有两种激活流程：
        /// 1. 用户必须在填写资料后才能领卡，领卡后开发者调用激活接口为用户激活会员卡；（✓）
        /// 2. 是用户可以先领取会员卡，点击激活会员卡跳转至开发者设置的资料填写页面，填写完成后开发者调用激活接口为用户激活会员卡。
        /// /membercard/activate?card_id=pp8Cv1ZG5EF4xANmM1MgIsbnsGUE&encrypt_code=wCjto%2FaJVWVk8BqrTfYw0q2WNkTVAD%2F1Sq1r0oh%2BLB0%3D&openid=op8Cv1bJrYMGkOciHUmkzs6cHsEc
        /// </summary>
        public ActionResult Activate(string card_id, string encrypt_code, string openid)
        {
            ViewBag.CardID = card_id;
            ViewBag.EncryptCode = encrypt_code;
            ViewBag.OpenID = openid;
            return View();
        }

        [HttpPost]
        public ActionResult Activate(MemberCardActivateModel model)
        {
            return Content(memberCardBLL.Activate(AuthorizerAppID, model), "application/json");
        }
    }
}