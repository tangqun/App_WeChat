using Model_9H;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelSerializeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberCardActivateReq req = new MemberCardActivateReq()
            {
                // 手机号作为会员卡号
                MembershipNumber = "15210470906",
                Code = "819991369998",
                CardID = "pp8Cv1YDI4ID5yIL4IC6_bhWEq4o",
                
                // 初始积分
                //InitCustomFieldValue1 = "0",
                // 初始等级
                // 铜牌、银牌、黄金、铂金、钻石、至尊
                InitCustomFieldValue2 = "查看",
                // 优惠券
                InitCustomFieldValue3 = "查看"
            };
            string requestBody = JsonConvert.SerializeObject(req);

            Console.WriteLine(requestBody);

            Console.ReadLine();
        }
    }
}
