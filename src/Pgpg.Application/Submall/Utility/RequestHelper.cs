using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pgpg.Application.Submall.Utility
{
    public class RequestHelper
    {
        // �������ύ�Ĳ����������У��������ύ�Ĳ����������� signature �ֶ�����A-Z������
        public static string FormatRequest(Dictionary<string, object> data)
        {
            StringBuilder builder = new StringBuilder();
            var list = data.Keys.ToList();
            list.Sort();

            foreach (string key in list)
            {
                string value = data[key] as string;
                if (value != null)
                {
                    builder.Append(string.Format("{0}={1}&", key, value));
                }
            }

            string formatData = builder.ToString();
            if (formatData.Length > 0)
            {
                return formatData.Substring(0, formatData.Length - 1);
            }

            return null;
        }
    }
}