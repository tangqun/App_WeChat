using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helper_9H
{
    public class UtilsHelper
    {
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static string SHA1(string stringToHash)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower(); ;
        }

        public static string GetTimestamp(bool bflag = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string timestamp = string.Empty;
            if (bflag)
                timestamp = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                timestamp = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return timestamp;
        }

        public static string GetNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string GenarateSignature(string apiTicket, string timestamp, string cardID, string nonceStr)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(apiTicket);
            arrayList.Add(timestamp);
            arrayList.Add(cardID);
            arrayList.Add(nonceStr);
            arrayList.Sort(new ValueComparer());

            string stringToHash =  string.Join("", arrayList.ToArray());

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower(); ;
        }

        public class ValueComparer : IComparer
        {
            public int Compare(object oLeft, object oRight)
            {
                string sLeft = oLeft as string;
                string sRight = oRight as string;
                int iLeftLength = sLeft.Length;
                int iRightLength = sRight.Length;
                int index = 0;
                while (index < iLeftLength && index < iRightLength)
                {
                    if (sLeft[index] < sRight[index])
                        return -1;
                    else if (sLeft[index] > sRight[index])
                        return 1;
                    else
                        index++;
                }
                return iLeftLength - iRightLength;
            }
        }
    }
}
