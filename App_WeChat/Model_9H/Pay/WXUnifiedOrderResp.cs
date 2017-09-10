using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class WXUnifiedOrderResp
    {
        public string AppID { get; set; }
        public string PartnerID { get; set; }
        public string PrePayID { get; set; }
        public string Package { get; set; }
        public string NonceStr { get; set; }
        public string TimeStamp { get; set; }
        public string Sign { get; set; }
    }
}
