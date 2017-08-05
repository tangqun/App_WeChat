using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CardCode
    {
        [JsonProperty("card_id")]
        public string CardID { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
