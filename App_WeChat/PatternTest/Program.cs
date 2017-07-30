using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://wxab6d7123cc1125f5.wx.smartyancheng.com/membercard/activate");

            Regex regex = new Regex("^([a-z0-9]{18})\\.wx\\.smartyancheng\\.com$", RegexOptions.IgnoreCase);

            string host = uri.Host;
            if (regex.IsMatch(host))
            {
                string authorizerAppID = regex.Match(host).Groups[1].Value;
                Console.WriteLine(authorizerAppID);
            }

            Console.ReadLine();
        }
    }
}
