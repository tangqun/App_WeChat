using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class APIConfigModel
    {
        [JsonProperty("cardID")]
        public string CardID { get; set; }
        [JsonProperty("cardExt")]
        public string CardExt { get; set; }
    }
}
