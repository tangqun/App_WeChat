﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Helper_9H
{
    public class ConfigHelper
    {
        public static string ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public static string ComponentAppID = GetConfig("ComponentAppID");
        public static string DomainToken = GetConfig("DomainToken");
        public static string UniversalHost = GetConfig("UniversalHost");

        public static string GetConfig(string key)
        {
            string value = "";
            try
            {
                value = ConfigurationManager.AppSettings[key].Trim();
            }
            catch
            {
                value = "";
            }
            return string.IsNullOrEmpty(value) ? "" : value;
        }
    }
}
