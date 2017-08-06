using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL_9H
{
    public interface ICardInfoDAL
    {
        // 创建时间正序取第一条满足条件的实体
        CardInfoModel GetModel(string authorizerAppID);
    }
}
