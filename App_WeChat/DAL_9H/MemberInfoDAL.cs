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
        public bool Insert(string authorizerID, string openID, string cardID, string code, string membershipNumber, string mobile, string realName, int gender, DateTime birthday, DateTime dt)
        {
            string sql =
                @"INSERT INTO `jhwechat`.`member_info`
                            (`authorizer_appid`,
                             `openid`,
                             `card_id`,
                             `code`,
                             `membership_number`,
                             `mobile`,
                             `realname`,
                             `gender`,
                             `birthday`,
                             `create_time`,
                             `update_time`)
                VALUES (@authorizer_appid,
                        @openid,
                        @card_id,
                        @code,
                        @membership_number,
                        @mobile,
                        @realname,
                        @gender,
                        @birthday,
                        @create_time,
                        @update_time);";
            MySqlParameter[] parameters = {
                new MySqlParameter("@authorizer_appid", authorizerID),
                new MySqlParameter("@openid", openID),
                new MySqlParameter("@card_id", cardID),
                new MySqlParameter("@code", code),
                new MySqlParameter("@membership_number", membershipNumber),
                new MySqlParameter("@mobile", mobile),
                new MySqlParameter("@realname", realName),
                new MySqlParameter("@gender", gender),
                new MySqlParameter("@birthday", birthday),
                new MySqlParameter("@create_time", dt),
                new MySqlParameter("@update_time", dt),
            };
            return MySqlHelper.ExecuteNonQuery(ConfigHelper.ConnStr, sql, parameters) > 0;
        }

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
                    MembershipNumber = dr["membership_number"].ToString(),
                    Mobile = dr["mobile"].ToString(),
                    RealName = dr["realname"].ToString(),
                    Gender = dr["gender"].ToInt(),
                    Birthday = dr["birthday"].ToDateTime()
                };
            }
            return null;
        }
    }
}
