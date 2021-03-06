﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class MemberInfoModel
    {
        public int ID { get; set; }
        public string AuthorizerAppID { get; set; }
        public string OpenID { get; set; }
        public string CardID { get; set; }
        public string Code { get; set; }
        public string MembershipNumber { get; set; }

        // 会员信息
        public string Mobile { get; set; }
        public string RealName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
