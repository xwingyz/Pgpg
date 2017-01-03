using System.Collections.Generic;
using Pgpg.Application.Submall.Utility;
using Pgpg.Core.Validation;

namespace Pgpg.Application.Submall.Lib
{
    public class Mobiledata
    {
        private const string API_CHARGE = "https://api.submail.cn/mobiledata/charge.json";
        private const string API_TOSERVICE = "https://api.submail.cn/mobiledata/TOservice.json";
        private const string API_PACKAGE = "https://api.submail.cn/mobiledata/package.json";

        private HttpWebHelper _httpWebHelper;
        public Mobiledata(IAppConfig appConfig)
        {
            _httpWebHelper = new HttpWebHelper(appConfig);
        }

        public bool Charge(string to, string packageType)
        {
            var dataPair = new Dictionary<string, object>();
            dataPair.Add("to", to);
            var v = new ValidationHelper();
            if (v.IsChinaMobilePhoneNumber(to))
            {
                dataPair.Add("cm", packageType);
            }
            else if (v.IsChinaUnicomPhoneNumber(to))
            {
                dataPair.Add("cu", packageType);
            }
            else if (v.IsChinaTelecomPhoneNumber(to))
            {
                dataPair.Add("ct", packageType);
            }
            string retrunJsonResult = _httpWebHelper.HttpPost(API_CHARGE, dataPair);
            return retrunJsonResult.Contains("charge_id");
        }
    }
}