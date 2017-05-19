using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using Helper_9H;
using IDAL_9H;
using DAL_9H;
using Newtonsoft.Json;

namespace BLL_9H
{
    public class EntityShopBLL : IEntityShopBLL
    {
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();

        public List<EntityShop_Info> GetList(string appid)
        {
            try
            {
                string url_poilist = "https://api.weixin.qq.com/cgi-bin/poi/getpoilist?access_token=" + accessTokenDAL.Get(appid);

                LogHelper.Info("url_poilist: " + url_poilist);

                Poi_GetList_Req poi_getlist_req = new Poi_GetList_Req();
                poi_getlist_req.Begin = 0;
                poi_getlist_req.Limit = 20;
                string para_poilist = JsonConvert.SerializeObject(poi_getlist_req);

                string resp_poilist = "{\"errcode\":0,\"errmsg\":\"ok\",\"business_list\":[{\"base_info\":{\"sid\":\"\",\"business_name\":\"朝外MEN写字楼\",\"branch_name\":\"\",\"address\":\"朝外大街26号\",\"telephone\":\"15210470906\",\"categories\":[\"公司企业,企业/工厂\"],\"city\":\"北京市\",\"province\":\"\",\"offset_type\":1,\"longitude\":116.442108154,\"latitude\":39.9230194092,\"photo_list\":[{\"photo_url\":\"http://mmbiz.qpic.cn/mmbiz_png/jTItpJe45JLNBQjKKiapJicznbYVMicDXGzs4EaNVgiao57JSlLgYxrh1OplMF8tr8DJ7RmlAeJmv1h22EePgSl1OQ/0?wx_fmt=png\"}],\"introduction\":\"\",\"recommend\":\"\",\"special\":\"\",\"open_time\":\"10:00-21:00\",\"avg_price\":100,\"poi_id\":\"468757507\",\"available_state\":3,\"district\":\"朝阳区\",\"update_status\":0,\"qualification_list\":[]}}],\"total_count\":1}";//HttpHelper.Post(url_poilist, para_poilist);

                LogHelper.Info("resp_poilist: " + resp_poilist);

                Poi_GetList_Resp poi_getlist_resp = JsonConvert.DeserializeObject<Poi_GetList_Resp>(resp_poilist);
                return poi_getlist_resp.Business_List.Select(o => o.Base_Info).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.Error("唐群", ex);
                return null;
            }
        }

        public EntityShop_Info GetModel(string appid, string poi_id)
        {
            try
            {
                string url_poi = "http://api.weixin.qq.com/cgi-bin/poi/getpoi?access_token=" + accessTokenDAL.Get(appid);

                LogHelper.Info("url_poi: " + url_poi);

                Poi_Get_Req poi_get_req = new Poi_Get_Req();
                poi_get_req.Poi_Id = poi_id;
                string para_poi = JsonConvert.SerializeObject(poi_get_req);

                string resp_poi = "{\"errcode\":0,\"errmsg\":\"ok\",\"business\":{\"base_info\":{\"sid\":\"\",\"business_name\":\"朝外MEN写字楼\",\"branch_name\":\"\",\"address\":\"朝外大街26号\",\"telephone\":\"15210470906\",\"categories\":[\"公司企业,企业/工厂\"],\"city\":\"北京市\",\"province\":\"\",\"offset_type\":1,\"longitude\":116.442108154,\"latitude\":39.9230194092,\"photo_list\":[{\"photo_url\":\"http://mmbiz.qpic.cn/mmbiz_png/jTItpJe45JLNBQjKKiapJicznbYVMicDXGzs4EaNVgiao57JSlLgYxrh1OplMF8tr8DJ7RmlAeJmv1h22EePgSl1OQ/0?wx_fmt=png\"}],\"introduction\":\"\",\"recommend\":\"\",\"special\":\"\",\"open_time\":\"10:00-21:00\",\"avg_price\":100,\"poi_id\":\"468757507\",\"available_state\":3,\"district\":\"朝阳区\",\"update_status\":0,\"qualification_list\":[]}}}";//HttpHelper.Post(url_poi, para_poi);

                LogHelper.Info("resp_poi: " + resp_poi);

                Poi_Get_Resp poi_get_resp = JsonConvert.DeserializeObject<Poi_Get_Resp>(resp_poi);
                return poi_get_resp.Business.Base_Info;
            }
            catch (Exception ex)
            {
                LogHelper.Error("唐群", ex);
                return null;
            }
        }
    }
}