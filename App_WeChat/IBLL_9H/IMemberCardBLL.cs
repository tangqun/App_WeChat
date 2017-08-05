using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL_9H
{
    public interface IMemberCardBLL
    {
        MemberCardModel GetModel(string authorizerAppID, string openID, string cardID);

        /// <summary>
        /// 手机号显示在卡面上，Code用腾讯生成的
        /// </summary>
        /// <returns></returns>
        string Activate(string authorizerAppID, MemberCardActivateModel model);
    }
}
