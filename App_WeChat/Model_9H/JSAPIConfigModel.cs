using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class JSAPIConfigModel
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("nonceStr")]
        public string NonceStr { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
