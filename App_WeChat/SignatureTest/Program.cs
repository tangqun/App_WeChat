using DAL_9H;
using Helper_9H;
using IDAL_9H;
using Model_9H;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTest
{
    class Program
    {
        private static IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();
        static void Main(string[] args)
        {
            //string cardID = "pp8Cv1bypNXD5z-KwoatVEaYJa0w";
            //string apiTicket = "9KwiourQPRN3vx3Nn1c_iXKXdRjqsvnKe_KV_HB6ZofIGZwZJ6XmXxkgI4xvjssApkcK8mxUN8jSd4EMcism-Q";
            //string timestamp = UtilsHelper.GetTimestamp();
            //string nonceStr = UtilsHelper.GetNonceStr();

            //string signature = UtilsHelper.GenarateSignature(apiTicket, timestamp, cardID, nonceStr);

            //Console.WriteLine(signature);

            AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get("wxab6d7123cc1125f5");



            Console.ReadLine();
        }
    }
}
