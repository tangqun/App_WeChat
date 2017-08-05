using Model_9H;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializeModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"errcode\":0,\"errmsg\":\"ok\",\"card\":{\"card_type\":\"MEMBER_CARD\",\"member_card\":{\"base_info\":{\"id\":\"pp8Cv1YDI4ID5yIL4IC6_bhWEq4o\",\"logo_url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_jpg\\/Wj6TwkVleG6srmSo10D9l0ayKjj7Jaq6m68PcSYJ8Pk4wkHGHdbg1iaogWDeRic86ibXxpGxl31yibuY9ics6OETBvw\\/0\",\"code_type\":\"CODE_TYPE_QRCODE\",\"brand_name\":\"现代纯K量贩式KTV\",\"title\":\"现代纯K量贩式KTV\",\"date_info\":{\"type\":\"DATE_TYPE_PERMANENT\"},\"color\":\"#63b359\",\"notice\":\"使用时向服务员出示此券\",\"service_phone\":\"15210470906\",\"description\":\"1.消费时请出示会员卡 2.会员余额不可提现 3.会员积分可以兑换相应的奖品或者优惠 3.具体积分使用规则参考商家制定的积分政策\",\"location_id_list\":[],\"get_limit\":1,\"can_share\":false,\"can_give_friend\":false,\"use_custom_code\":false,\"status\":\"CARD_STATUS_VERIFY_OK\",\"sku\":{\"quantity\":99999998,\"total_quantity\":100000000},\"create_time\":1498409465,\"update_time\":1498409475,\"use_all_locations\":true,\"center_title\":\"会员买单\",\"center_url\":\"http:\\/\\/wxab6d7123cc1125f5.wx.smartyancheng.com\\/membercard\\/gopay\",\"area_code_list\":[]},\"supply_bonus\":true,\"supply_balance\":false,\"prerogative\":\"1.会员等级随着客户成长值进行升级 2.不同等级会员享受不同的折扣优惠\",\"activate_url\":\"http:\\/\\/wxab6d7123cc1125f5.wx.smartyancheng.com\\/membercard\\/activate\",\"discount\":10,\"auto_activate\":false,\"wx_activate\":false,\"custom_field2\":{\"name_type\":\"FIELD_NAME_TYPE_LEVEL\",\"url\":\"http:\\/\\/wxab6d7123cc1125f5.wx.smartyancheng.com\\/level\"},\"custom_field3\":{\"name_type\":\"FIELD_NAME_TYPE_COUPON\",\"url\":\"http:\\/\\/wxab6d7123cc1125f5.wx.smartyancheng.com\\/coupon\"},\"bonus_rule\":{\"cost_money_unit\":1,\"increase_bonus\":1,\"max_increase_bonus\":0,\"init_increase_bonus\":20,\"cost_bonus_unit\":100,\"reduce_money\":100,\"least_money_to_use_bonus\":0,\"max_reduce_bonus\":0},\"background_pic_url\":\"http:\\/\\/mmbiz.qpic.cn\\/mmbiz_png\\/Wj6TwkVleG6srmSo10D9l0ayKjj7Jaq6zUmVo7xEKgfxWDBpzBx1M0QzIsgaDwPqLkhHcnnYgjft3qgSmJQczw\\/0\",\"advanced_info\":{\"time_limit\":[],\"text_image_list\":[],\"business_service\":[\"BIZ_SERVICE_FREE_WIFI\",\"BIZ_SERVICE_WITH_PET\",\"BIZ_SERVICE_FREE_PARK\",\"BIZ_SERVICE_DELIVER\"],\"consume_share_card_list\":[],\"share_friends\":false}}}}";

            CardGetResp resp = JsonConvert.DeserializeObject<CardGetResp>(json);

            Console.ReadLine();
        }
    }
}
