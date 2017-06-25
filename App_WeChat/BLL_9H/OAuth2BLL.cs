using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using IDAL_9H;
using DAL_9H;
using Newtonsoft.Json;
using Helper_9H;

namespace BLL_9H
{
    public class OAuth2BLL : IOAuth2BLL
    {
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();
        private IComponentAccessTokenDAL componentAccessTokenDAL = new ComponentAccessTokenDAL();
        
        public RESTfulModel GetAuth(string authorizerAppID, string code, string state)
        {
            try
            {
                string componentAppID = ConfigHelper.ComponentAppID;
                string componentAccessToken = componentAccessTokenDAL.Get();
                // 白名单要求
                string url = "https://api.weixin.qq.com/sns/oauth2/component/access_token?appid=" + authorizerAppID + "&code=" + code + "&grant_type=authorization_code&component_appid="+ componentAppID + "&component_access_token=" + componentAccessToken;

                LogHelper.Info("通过code换取access_token url", url);

                string responseBody = HttpHelper.Get(url);

                LogHelper.Info("通过code换取access_token responseBody", responseBody);

                OAuth2GetResp resp = JsonConvert.DeserializeObject<OAuth2GetResp>(responseBody);
                if (resp.ErrCode == 0)
                {
                    return new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "授权成功"), Data = resp.OpenID };
                }
                else
                {
                    string msg = "errcode: " + resp.ErrCode + ", errmsg: " + resp.ErrMsg;
                    return new RESTfulModel() { Code = (int)CodeEnum.失败, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.失败), msg) };
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) };
            }
        }
    }
}
