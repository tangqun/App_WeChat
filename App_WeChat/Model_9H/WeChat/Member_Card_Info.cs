using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Member_Card_Info
    {
        public string Id { get; set; }
        public string Logo_Url { get; set; }
        public string Code_Type { get; set; }
        public string Brand_Name { get; set; }
        public string Title { get; set; }
        public string Sub_Title { get; set; }
        public object Date_Info { get; set; }
        public string Color { get; set; }
        public string Notice { get; set; }
        public string Service_Phone { get; set; }
        public string Description { get; set; }
        public int[] Location_Id_List { get; set; }
        public int Get_Limit { get; set; }
        public bool Can_Share { get; set; }
        public bool Can_Give_Friend { get; set; }
        public string Status { get; set; }
        public object Sku { get; set; }
        public int Create_Time { get; set; }
        public int Update_Time { get; set; }
        public bool Use_All_Locations { get; set; }
        public object Area_Code_List { get; set; }
    }
}