using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // F9mwwU/GshmAmyX4UPttXV8XwRZFuDuhoWey1dHdb47Q9K0q04qRVaLW1EMQV9KQ3P1GLyotEaLnvS82HXo7Mrj+14WxOZhuO1MoRuKUmfpRgUZ6trRvFPMfXDJ+wwLcxwNn54tvIlGbXjPVhfpME47tWzGAYb5GhrqMxcEiMjXfL4kaI1zKRHTHc6MLaXZ8oR3sqCbyVFVIA5EFkd+e6q7FgjsufbudhxOMmf7RgmCN+0W4YO21uRxxUHQTzvbqRXmBIHGhc73C95am+rjM7V/6E6WzpfCNFq6svE3NAIo0DaRKKjRQMqYpdzGl9Ttoof+XtKqbsdgLM9vJUV5ur8uVEPlruP+TxfXIPpZrys1knNk7fdpUsIFAMXFeIpHTQFgYc2a8sTexmsItYzO1qj4Z+SE2KnNxDHOtCXnQaSBh68vNsXPB1z8krKo0fo4jYQOzT/U7AQ/IoL9mM69APek9fmJ5VtKFRKLSYGOSt0/2DKSVMeX5C/XQI/EBCTZAGAaKs164/XmeEUUnyVK7LWl/t0/XtDL0kUT7yxJRoUaGGaeTuootITLln7Nigw+3noRvSZT1zxVuEPijZHmFGx0d+om8u43K3xMUh0jsGTPNKnsF9xBLk3tuxb4JCer+Nz978LbcCx2Zj0+WmKVDu+2YsMpB9bk81Nwdw8Utg3/W0PK14xSHh96Z4B/SBu5Xcii2BH/9K0KDWEyiyXQTerRid4ACUBNo6NUCoxh9Ckn3gYgw7PwUzNTe+a7Yas7xB3dteHOKQWuINhjAfnc73Y4E+/kSYyIPXLtfbI5XV0g=
            string encrypt_Cipher = "F9mwwU/GshmAmyX4UPttXV8XwRZFuDuhoWey1dHdb47Q9K0q04qRVaLW1EMQV9KQ3P1GLyotEaLnvS82HXo7Mrj+14WxOZhuO1MoRuKUmfpRgUZ6trRvFPMfXDJ+wwLcxwNn54tvIlGbXjPVhfpME47tWzGAYb5GhrqMxcEiMjXfL4kaI1zKRHTHc6MLaXZ8oR3sqCbyVFVIA5EFkd+e6q7FgjsufbudhxOMmf7RgmCN+0W4YO21uRxxUHQTzvbqRXmBIHGhc73C95am+rjM7V/6E6WzpfCNFq6svE3NAIo0DaRKKjRQMqYpdzGl9Ttoof+XtKqbsdgLM9vJUV5ur8uVEPlruP+TxfXIPpZrys1knNk7fdpUsIFAMXFeIpHTQFgYc2a8sTexmsItYzO1qj4Z+SE2KnNxDHOtCXnQaSBh68vNsXPB1z8krKo0fo4jYQOzT/U7AQ/IoL9mM69APek9fmJ5VtKFRKLSYGOSt0/2DKSVMeX5C/XQI/EBCTZAGAaKs164/XmeEUUnyVK7LWl/t0/XtDL0kUT7yxJRoUaGGaeTuootITLln7Nigw+3noRvSZT1zxVuEPijZHmFGx0d+om8u43K3xMUh0jsGTPNKnsF9xBLk3tuxb4JCer+Nz978LbcCx2Zj0+WmKVDu+2YsMpB9bk81Nwdw8Utg3/W0PK14xSHh96Z4B/SBu5Xcii2BH/9K0KDWEyiyXQTerRid4ACUBNo6NUCoxh9Ckn3gYgw7PwUzNTe+a7Yas7xB3dteHOKQWuINhjAfnc73Y4E+/kSYyIPXLtfbI5XV0g=";

            string componentAppID = "wx6230602b18fb87dc";

            string requestBody = Tencent.Cryptography.AES_decrypt(encrypt_Cipher, "Fuz0D8R15WOPEtvfXzU5XnC8GYrsOhLoX3UrHkufnAt", ref componentAppID);

            Console.ReadLine();
        }
    }
}
