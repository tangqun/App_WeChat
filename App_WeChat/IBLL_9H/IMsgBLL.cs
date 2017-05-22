using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IBLL_9H
{
    public interface IMsgBLL
    {
        string Receive(string authorizer_appid, Stream requestStream);
    }
}
