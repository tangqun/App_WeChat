using IDAL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using MySql.Data.MySqlClient;
using Helper_9H;
using System.Data;

namespace DAL_9H
{
    public class MemberInfoDAL : IMemberInfoDAL
    {
        public MemberInfoModel GetModel(string openID, string cardID)
        {
            string sql = "SELECT * FROM `member_info` WHERE openid = @openid AND card_id = @card_id;";
            MySqlParameter[] parameters = {
                new MySqlParameter("@openid", openID),
                new MySqlParameter("@card_id", cardID)
            };
            DataRow dr = MySqlHelper.ExecuteDataRow(ConfigHelper.ConnStr, sql, parameters);
            return EntityToModel(dr);
        }

        private MemberInfoModel EntityToModel(DataRow dr)
        {
            if (dr != null)
            {
                return new MemberInfoModel()
                {
                    ID = dr["id"].ToInt(),
                    AuthorizerAppID = dr["authorizer_appid"].ToString(),
                    OpenID = dr["openid"].ToString(),
                    CardID = dr["card_id"].ToString(),
                    Code = dr["code"].ToString(),
                    MembershipNumber = dr["membership_number"].ToString()
                };
            }
            return null;
        }
    }
}
