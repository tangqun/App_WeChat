using Helper_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_9H
{
    public class MsgBLL : IMsgBLL
    {
        public string Receive(string authorizerAppID, Stream requestStream)
        {
            try
            {
                byte[] requestBytes = new byte[requestStream.Length];
                requestStream.Read(requestBytes, 0, (int)requestStream.Length);
                string requestBody = Encoding.UTF8.GetString(requestBytes);

                LogHelper.Info("公众号消息与事件 requestBody", requestBody);

                return "success";
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                // 微信服务器在五秒内收不到响应会断掉连接，并且重新发起请求，总共重试三次。
                // 假如服务器无法保证在五秒内处理并回复，可以直接回复空串，微信服务器不会对此作任何处理，并且不会发起重试。
                return "exception";
            }
        }
    }
}
