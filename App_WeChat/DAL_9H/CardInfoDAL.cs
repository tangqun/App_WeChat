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
    public class CardInfoDAL : ICardInfoDAL
    {
        public CardInfoModel GetModel(string authorizerAppID)
        {
            string sql = "SELECT * FROM `card_info` WHERE authorizer_appid = @authorizer_appid AND card_status = 'card_pass_check' ORDER BY create_time;";
            DataRow dr = MySqlHelper.ExecuteDataRow(ConfigHelper.ConnStr, sql, new MySqlParameter("@authorizer_appid", authorizerAppID));
            return EntityToModel(dr);
        }

        private CardInfoModel EntityToModel(DataRow dr)
        {
            if (dr != null)
            {
                return new CardInfoModel()
                {
                    ID = dr["id"].ToInt(),
                    AuthorizerAppID = dr["authorizer_appid"].ToString(),
                    CardID = dr["card_id"].ToString(),
                    CardStatus = dr["card_status"].ToString()
                };
            }
            return null;
        }
    }
}
