using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Member_Card
    {
        public Member_Card_Info Base_Info { get; set; }
        public bool Supply_Bonus { get; set; }
        public bool Supply_Balance { get; set; }
        public string Prerogative { get; set; }
        public int Discount { get; set; }
        public bool Auto_Activate { get; set; }
        public bool WX_Activate { get; set; }
        public object Bonus_Rule { get; set; }
        public string Background_Pic_Url { get; set; }
        public object Advanced_Info { get; set; }
    }
}