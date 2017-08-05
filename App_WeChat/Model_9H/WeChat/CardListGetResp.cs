using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CardListGetResp
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
        [JsonProperty("card_list")]
        public List<CardCode> CardList { get; set; }
        [JsonProperty("has_share_card")]
        public bool HasShareCard { get; set; }
    }
}
