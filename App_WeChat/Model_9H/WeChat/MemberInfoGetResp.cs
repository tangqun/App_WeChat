using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class MemberInfoGetResp
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
        [JsonProperty("openid")]
        public string OpenID { get; set; }
        [JsonProperty("nickname")]
        public string NickName { get; set; }
        [JsonProperty("membership_number")]
        public string MembershipNumber { get; set; }
        [JsonProperty("bonus")]
        public int Bonus { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonProperty("user_card_status")]
        public string UserCardStatus { get; set; }
        [JsonProperty("has_active")]
        public bool HasActive { get; set; }
    }
}
