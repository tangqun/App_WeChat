using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using Helper_9H;
using Newtonsoft.Json;

namespace BLL_9H
{
    public class PayBLL : IPayBLL
    {
        public RESTfulModel Create(string authorizerAppID, PayModel model)
        {
            try
            {
                // 
                string url = "http://pay.smartyancheng.com/api/pay/unifiedorder?authorizerappid={0}&openid={1}&outtradeno={2}&totalfee={3}&body={4}";

                DateTime dt = DateTime.Now;
                Random r = new Random();
                string outTradeNo = dt.ToString("yyyyMMddHHmmssfff") + r.Next(100000, 999999);
                string body = "店内消费";

                url = string.Format(url, authorizerAppID, model.OpenID, outTradeNo, model.TotalFee, body);

                string responseBody = HttpHelper.Get(url);

                RESTfulModel resp = JsonConvert.DeserializeObject<RESTfulModel>(responseBody);

                return resp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
