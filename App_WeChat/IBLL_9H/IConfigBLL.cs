using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL_9H
{
    public interface IConfigBLL
    {
        RESTfulModel GetJSAPIConfig(string authorizerAppID, string url);
        RESTfulModel GetAPIConfig(string authorizerAppID, string cardID);
    }
}
