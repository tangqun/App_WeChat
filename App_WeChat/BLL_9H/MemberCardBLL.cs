using DAL_9H;
using Helper_9H;
using IBLL_9H;
using IDAL_9H;
using Model_9H;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_9H
{
    public class MemberCardBLL : IMemberCardBLL
    {
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();
        private IAuthorizerInfoDAL authorizerInfoDAL = new AuthorizerInfoDAL();

        /// <summary>
        /// 手机号显示在卡面上，Code用腾讯生成的
        /// </summary>
        public string Activate(string authorizerAppID, MemberCardActivateModel model)
        {
            try
            {
                // 验证参数

                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);
                string authorizerAccessToken = authorizationInfoModel.AuthorizerAccessToken;
                LogHelper.Info("6.1 接口激活 authorizerAccessToken", authorizerAccessToken);

                // Code解码
                string code = string.Empty;
                if (!DecryptCode(authorizerAccessToken, model.EncryptCode, out code))
                {
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.Code解码失败, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.Code解码失败), model.EncryptCode) });
                };

                string url = "https://api.weixin.qq.com/card/membercard/activate?access_token=" + authorizerAccessToken;
                LogHelper.Info("6.1 接口激活 url", url);
                MemberCardActivateReq req = new MemberCardActivateReq()
                {
                    // 手机号作为会员卡号
                    MembershipNumber = model.Mobile,
                    Code = code,
                    CardID = model.CardID,
                    //InitBonus = 0,
                    //InitBonusRecord = "",
                    //InitBalance = 0,
                    //InitCustomFieldValue1 = "0",
                    // 初始等级
                    InitCustomFieldValue2 = "查看",
                    // 优惠券
                    InitCustomFieldValue3 = "查看"
                };
                string requestBody = JsonConvert.SerializeObject(req);
                LogHelper.Info("6.1 接口激活 requestBody", requestBody);
                string responseBody = HttpHelper.Post(url, requestBody);
                LogHelper.Info("6.1 接口激活 responseBody", responseBody);
                MemberCardActivateResp resp = JsonConvert.DeserializeObject<MemberCardActivateResp>(responseBody);
                if (resp.ErrCode == 0)
                {
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "激活成功") });
                }
                else
                {
                    string msg = "errcode: " + resp.ErrCode + ", errmsg: " + resp.ErrMsg;
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.失败, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.失败), msg) });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) });
            }
        }

        private bool DecryptCode(string authorizerAccessToken, string encryptCode, out string code)
        {
            code = string.Empty;
            string url = "https://api.weixin.qq.com/card/code/decrypt?access_token=" + authorizerAccessToken;
            LogHelper.Info("2.2 Code解码接口 url", url);
            CardCodeDecryptReq req = new CardCodeDecryptReq()
            {
                EncryptCode = encryptCode
            };
            string requestBody = JsonConvert.SerializeObject(req);
            LogHelper.Info("2.2 Code解码接口 requestBody", requestBody);
            string responseBody = HttpHelper.Post(url, requestBody);
            LogHelper.Info("2.2 Code解码接口 responseBody", responseBody);
            CardCodeDecryptResp resp = JsonConvert.DeserializeObject<CardCodeDecryptResp>(responseBody);
            if (resp.ErrCode == 0)
            {
                code = resp.Code;
                return true;
            }
            return false;
        }
    }
}