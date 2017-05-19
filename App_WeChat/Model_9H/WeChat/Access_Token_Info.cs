using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Access_Token_Info
    {
        [JsonProperty("access_token")]
        public string Access_Token { get; set; }

        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }

        [JsonProperty("refresh_token")]
        public string Refresh_Token { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}