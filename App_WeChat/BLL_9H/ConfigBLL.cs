using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using Helper_9H;
using IDAL_9H;
using DAL_9H;
using Newtonsoft.Json;

namespace BLL_9H
{
    public class ConfigBLL : IConfigBLL
    {
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();

        public RESTfulModel GetJSAPIConfig(string authorizerAppID, string url)
        {
            try
            {
                LogHelper.Info("GetJSAPIConfig para", "authorizerAppID = " + authorizerAppID + ", url = " + url);

                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);

                string jsapiTicket = authorizationInfoModel.JSAPITicket;
                string timestamp = UtilsHelper.GetTimestamp();
                string nonceStr = UtilsHelper.GetNonceStr();

                string format = "jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}";

                string stringToHash = string.Format(format, jsapiTicket, nonceStr, timestamp, url);

                string signature = UtilsHelper.SHA1(stringToHash);

                LogHelper.Info("GetJSAPIConfig resp", "");

                return new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "成功"), Data = new JSAPIConfigModel() { Timestamp = timestamp, NonceStr = nonceStr, Signature = signature } };
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) };
            }
        }

        public RESTfulModel GetAPIConfig(string authorizerAppID)
        {
            try
            {
                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);

                string cardID = "pp8Cv1YDI4ID5yIL4IC6_bhWEq4o";
                string apiTicket = authorizationInfoModel.APITicket;
                string timestamp = UtilsHelper.GetTimestamp();
                string nonceStr = UtilsHelper.GetNonceStr();
                string signature = UtilsHelper.GenarateSignature(apiTicket, timestamp, cardID, nonceStr);

                string cardExt = JsonConvert.SerializeObject(new { signature = signature, timestamp = timestamp, nonce_str = nonceStr });

                return new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "成功"), Data = new APIConfigModel() { CardID = cardID, CardExt = cardExt } };
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) };
            }
        }
    }
}
