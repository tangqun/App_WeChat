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
        private ICardInfoDAL cardInfoDAL = new CardInfoDAL();
        private IMemberInfoDAL memberInfoDAL = new MemberInfoDAL();

        // 卡面
        public MemberCardModel GetModel(string authorizerAppID)
        {
            try
            {
                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);
                string authorizerAccessToken = authorizationInfoModel.AuthorizerAccessToken;
                LogHelper.Info("8.6.4 查看卡券详情 authorizerAccessToken", authorizerAccessToken);

                // 可以删除
                //string url = "https://api.weixin.qq.com/card/user/getcardlist?access_token=" + authorizerAccessToken;
                //LogHelper.Info("2 获取用户已领取卡券接口 url", url);
                //CardListGetReq req = new CardListGetReq()
                //{
                //    OpenID = openID, 
                //    CardID = cardID
                //};
                //string requestBody = JsonConvert.SerializeObject(req);
                //LogHelper.Info("2 获取用户已领取卡券接口 requestBody", requestBody);
                //string responseBody = HttpHelper.Post(url, requestBody);
                //LogHelper.Info("2 获取用户已领取卡券接口 responseBody", responseBody);
                //CardListGetResp resp = JsonConvert.DeserializeObject<CardListGetResp>(responseBody);

                CardInfoModel cardInfoModel = cardInfoDAL.GetModel(authorizerAppID);
                if (cardInfoModel == null)
                {
                    // 未创建会员卡
                }

                // 会员卡信息，建议先保存微信服务器，然后保存本地服务器，修改同理，这里可以从本地服务器查询
                string url = "https://api.weixin.qq.com/card/get?access_token=" + authorizerAccessToken;
                LogHelper.Info("8.6.4 查看卡券详情 url", url);
                CardGetReq req = new CardGetReq()
                {
                    CardID = cardInfoModel.CardID
                };
                string requestBody = JsonConvert.SerializeObject(req);
                LogHelper.Info("8.6.4 查看卡券详情 requestBody", requestBody);
                string responseBody = HttpHelper.Post(url, requestBody);
                LogHelper.Info("8.6.4 查看卡券详情 responseBody", responseBody);
                CardGetResp resp = JsonConvert.DeserializeObject<CardGetResp>(responseBody);
                
                var memberCard = resp.Card.MemberCard;
                return new MemberCardModel()
                {
                    CardID = cardInfoModel.CardID,
                    BackgroundPicUrl = memberCard.BackgroundPicUrl,
                    LogoUrl = memberCard.BaseInfo.LogoUrl,
                    BrandName = memberCard.BaseInfo.BrandName,
                    Title = memberCard.BaseInfo.Title
                };
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }

        private static MemberInfoGetResp GetMemberInfo(string authorizerAccessToken, string cardID, string code)
        {
            // 会员信息
            string url = "https://api.weixin.qq.com/card/membercard/userinfo/get?access_token=" + authorizerAccessToken;
            LogHelper.Info("8.1 拉取会员信息（积分查询）接口 url", url);
            MemberInfoGetReq req = new MemberInfoGetReq()
            {
                CardID = cardID,
                Code = code
            };
            string requestBody = JsonConvert.SerializeObject(req);
            LogHelper.Info("8.1 拉取会员信息（积分查询）接口 requestBody", requestBody);
            string responseBody = HttpHelper.Post(url, requestBody);
            LogHelper.Info("8.1 拉取会员信息（积分查询）接口 responseBody", responseBody);
            MemberInfoGetResp resp = JsonConvert.DeserializeObject<MemberInfoGetResp>(responseBody);
            return resp;
        }

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
                    // 优惠券
                    InitCustomFieldValue2 = "查看",
                    // 初始等级
                    InitCustomFieldValue3 = "查看"
                };
                string requestBody = JsonConvert.SerializeObject(req);
                LogHelper.Info("6.1 接口激活 requestBody", requestBody);
                string responseBody = HttpHelper.Post(url, requestBody);
                LogHelper.Info("6.1 接口激活 responseBody", responseBody);
                MemberCardActivateResp resp = JsonConvert.DeserializeObject<MemberCardActivateResp>(responseBody);
                if (resp.ErrCode == 0)
                {
                    DateTime dt = DateTime.Now;
                    // 保存 AuthorizerAppID、CardID、Code之间的关系
                    memberInfoDAL.Insert(authorizerAppID, model.OpenID, model.CardID, code, model.Mobile, model.Mobile, model.RealName, model.Gender, model.Birthday, dt);

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