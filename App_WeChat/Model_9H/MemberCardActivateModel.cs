using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    /// <summary>
    /// 激活会员卡
    /// </summary>
    public class MemberCardActivateModel
    {
        public string Mobile { get; set; }
        public string RealName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string CardID { get; set; }
        public string EncryptCode { get; set; }
        public string OpenID { get; set; }
    }
}
