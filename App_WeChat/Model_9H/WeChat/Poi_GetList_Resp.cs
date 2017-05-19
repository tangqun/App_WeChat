using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Poi_GetList_Resp
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<EntityShop> Business_List { get; set; }
        public int Total_Count { get; set; }
    }
}