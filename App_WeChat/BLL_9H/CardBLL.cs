using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model_9H;
using Helper_9H;
using IBLL_9H;
using IDAL_9H;
using DAL_9H;
using Newtonsoft.Json;

namespace BLL_9H
{
    public class CardBLL : ICardBLL
    {
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();

        //public Member_Card GetModel(string appid)
        //{
        //    try
        //    {
        //        string url_card = "https://api.weixin.qq.com/card/get?access_token=" + accessTokenDAL.Get(appid);

        //        LogHelper.Info("url_card: " + url_card);

        //        Card_Get_Req card_get_req = new Card_Get_Req();
        //        // 加入配置文件
        //        card_get_req.Card_Id = "p78OJv_vDkMNdB1xW8B6REvUWRVw";
        //        string para_card = JsonConvert.SerializeObject(card_get_req);

        //        string resp_card = "{\"errcode\":0,\"errmsg\":\"ok\",\"card\":{\"card_type\":\"MEMBER_CARD\",\"member_card\":{\"base_info\":{\"id\":\"p78OJv_vDkMNdB1xW8B6REvUWRVw\",\"logo_url\":\"http://mmbiz.qpic.cn/mmbiz_png/jTItpJe45JL4n4gS1FSI9cOBLH6VDLTZS5ckwGcmV1QYAxp4ZFXG5C8gmbLajPmJAHMdViaiaicD4YWX6nF5dlxPw/0?wx_fmt=png\",\"code_type\":\"CODE_TYPE_QRCODE\",\"brand_name\":\"九合天下测试号02\",\"title\":\"九合天下\",\"sub_title\":\"\",\"date_info\":{\"type\":\"DATE_TYPE_PERMANENT\"},\"color\":\"#1D75AC\",\"notice\":\"会员买单享9折优惠\",\"service_phone\":\"0515-8297401\",\"description\":\"每人限领一张\\r\\n1.消费时请出示会员卡\\r\\n2.会员余额不可体现\",\"location_id_list\":[468757507],\"get_limit\":1,\"can_share\":true,\"can_give_friend\":false,\"status\":\"CARD_STATUS_DISPATCH\",\"sku\":{\"quantity\":999999999,\"total_quantity\":1000000000},\"create_time\":1490083220,\"update_time\":1493137305,\"use_all_locations\":true,\"area_code_list\":[]},\"supply_bonus\":true,\"supply_balance\":false,\"prerogative\":\"用卡可享受9折优惠\\n1.会员等级随着客户成长值进行升级\\r\\n2.不同等级会员享受不同的折扣优惠\",\"discount\":10,\"auto_activate\":false,\"wx_activate\":true,\"bonus_rule\":{\"cost_money_unit\":100,\"increase_bonus\":1,\"cost_bonus_unit\":100,\"reduce_money\":100},\"background_pic_url\":\"http://mmbiz.qpic.cn/mmbiz_jpg/jTItpJe45JIpiaRMUFZ9YOOcZyeAvpb2UfNj7Cicic4yZpwsacGa9Hviaiboia0PJJeccDlRxGAyjK2qCDWJD35z9fRA/0?wx_fmt=jpeg\",\"advanced_info\":{\"time_limit\":[{\"type\":\"MONDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0},{\"type\":\"TUESDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0},{\"type\":\"WEDNESDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0},{\"type\":\"THURSDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0},{\"type\":\"FRIDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0},{\"type\":\"SATURDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0},{\"type\":\"SUNDAY\",\"begin_hour\":12,\"begin_minute\":0,\"end_hour\":18,\"end_minute\":0}],\"text_image_list\":[],\"business_service\":[\"BIZ_SERVICE_FREE_WIFI\"],\"consume_share_card_list\":[],\"use_condition\":{\"can_use_with_other_discount\":false,\"can_use_with_membercard\":false},\"share_friends\":false}}}}";// HttpHelper.Post(url_card, para_card);

        //        LogHelper.Info("resp_card: " + resp_card);

        //        Card_Get_Resp card_get_resp = JsonConvert.DeserializeObject<Card_Get_Resp>(resp_card);
        //        return card_get_resp.Card.Member_Card;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("唐群", ex);
        //        return null;
        //    }
        //}
    }
}