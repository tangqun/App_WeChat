using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CardCodeDecryptReq
    {
        [JsonProperty("encrypt_code")]
        public string EncryptCode { get; set; }
    }
}
