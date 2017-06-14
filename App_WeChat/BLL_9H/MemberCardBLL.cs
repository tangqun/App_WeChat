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
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();
        private IAuthorizerInfoDAL authorizerInfoDAL = new AuthorizerInfoDAL();

        // 手机号 姓名
        public string Activate(int replacedAppID, string mobile, string realName)
        {
            try
            {
                AuthorizerInfoModel authorizerInfoModel = authorizerInfoDAL.GetModel(replacedAppID);

                string url = "https://api.weixin.qq.com/card/membercard/activate?access_token=" + accessTokenDAL.Get(authorizerInfoModel.AuthorizerAppID);

                LogHelper.Info("接口激活url: " + url);

                MemberCardActivateReq req = new MemberCardActivateReq()
                {
                    // 手机号作为会员卡号
                    MembershipNumber = mobile,
                    Code = mobile,
                    CardID = "",
                    InitBonus = 0,
                    InitBonusRecord = "",
                    InitBalance = 0,
                    // 初始积分
                    InitCustomFieldValue1 = "0",
                    // 初始等级
                    // 铜牌、银牌、黄金、铂金、钻石、至尊
                    InitCustomFieldValue2 = "铜牌会员",
                    // 优惠券
                    InitCustomFieldValue3 = "查看"
                };

                string requestBody = JsonConvert.SerializeObject(req);

                LogHelper.Info("接口激活requestBody: " + requestBody);

                string responseBody = HttpHelper.Post(url, requestBody);

                LogHelper.Info("接口激活responseBody: " + responseBody);

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
                LogHelper.Error("唐群", ex);
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) });
            }
        }
    }
}