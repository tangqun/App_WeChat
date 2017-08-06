using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using IDAL_9H;
using DAL_9H;
using Helper_9H;

namespace BLL_9H
{
    public class MemberInfoBLL : IMemberInfoBLL
    {
        private IMemberInfoDAL memberInfoDAL = new MemberInfoDAL();
        public MemberInfoModel GetModel(string openID, string cardID)
        {
            try
            {
                return memberInfoDAL.GetModel(openID, cardID);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }
    }
}
