using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class EntityShop_Info
    {
        public string SId { get; set; }

        public string Business_Name { get; set; }

        public string Branch_Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public List<string> Categories { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public int Offset_Type { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public List<Photo_Info> Photo_List { get; set; }

        public string Introduction { get; set; }

        public string Recomend { get; set; }

        public string Special { get; set; }

        public string Open_Time { get; set; }

        public int Avg_Price { get; set; }

        public string Poi_Id { get; set; }

        public int Available_State { get; set; }

        public string District { get; set; }

        public int Update_Status { get; set; }
    }
}