using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL_9H
{
    public interface IMemberInfoDAL
    {
        bool Insert(string authorizerID, string openID, string cardID, string code, string membershipNumber, string mobile, string realName, int gender, DateTime birthday, DateTime dt);

        // OpenID针对每一个公众号唯一
        MemberInfoModel GetModel(string openID, string cardID);
    }
}
