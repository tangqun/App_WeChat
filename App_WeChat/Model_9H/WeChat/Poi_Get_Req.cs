using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Poi_Get_Req
    {
        [JsonProperty("poi_id")]
        public string Poi_Id { get; set; }
    }
}