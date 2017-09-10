using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using Helper_9H;
using Newtonsoft.Json;
using IDAL_9H;
using DAL_9H;

namespace BLL_9H
{
    public class OrderBLL : IOrderBLL
    {
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();

        public RESTfulModel Create(string authorizerAppID, string openID, OrderModel model, string ip)
        {
            try
            {
                // 
                string url = "http://pay.smartyancheng.com/api/pay/unifiedorder?authorizerappid={0}&openid={1}&totalfee={2}&body={3}";

                string body = "店内消费";

                url = string.Format(url, authorizerAppID, openID, model.TotalFee, body);

                string responseBody = HttpHelper.Get(url);

                RESTfulModel resp = JsonConvert.DeserializeObject<RESTfulModel>(responseBody);

                if (resp.Code == 0)
                {
                    UnifiedOrderResp unifiedOrderResp = JsonConvert.DeserializeObject<UnifiedOrderResp>(resp.Data.ToString());

                    // 获取预支付信息
                    return WXUnifiedOrder(unifiedOrderResp.OutTradeNo, ip);
                }
                return resp;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) };
            }
        }

        private RESTfulModel WXUnifiedOrder(string outTradeNo, string ip)
        {
            string url = "http://pay.smartyancheng.com/api/wxpay/unifiedorder?outtradeno={0}&ip={1}";

            url = string.Format(url, outTradeNo, ip);

            string responseBody = HttpHelper.Get(url);

            RESTfulModel resp = JsonConvert.DeserializeObject<RESTfulModel>(responseBody);

            if (resp.Code == 0)
            {
                WXUnifiedOrderResp wxUnifiedOrderResp = JsonConvert.DeserializeObject<WXUnifiedOrderResp>(resp.Data.ToString());

                string appID = wxUnifiedOrderResp.AppID;
                string timeStamp = wxUnifiedOrderResp.TimeStamp;
                string nonceStr = wxUnifiedOrderResp.NonceStr;
                string package = "prepay_id=" + wxUnifiedOrderResp.PrePayID;
                string signType = "MD5";

                string preStr = "appId=" + appID + "&nonceStr=" + nonceStr + "&package=" + package + "&signType=" + signType + "&timeStamp=" + timeStamp + "&key=" + "7fa914d492b9a0e27013db9300ffb2e8";
                string paySign = UtilsHelper.MD5(preStr);

                LogHelper.Info("支付签名信息: ", preStr + "\r\n" + paySign);

                return new RESTfulModel() { Code = 0, Msg = "成功", Data = new { appID = appID, timeStamp = timeStamp, nonceStr = nonceStr, package = package, signType = signType, paySign = paySign } };
            }

            return resp;
        }
    }
}
