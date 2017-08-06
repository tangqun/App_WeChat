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
        // OpenID针对每一个公众号唯一
        MemberInfoModel GetModel(string openID, string cardID);
    }
}
