using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Pgpg.Submall.Lib;

namespace Pgpg.Submall.Utility
{
    public class HttpWebHelper
    {
        private const string APPID = "appid";
        private const string TIMESTAMP = "timestamp";
        private const string SIGN_TYPE = "sign_type";
        private const string SIGNATURE = "signature";
        private const string API_TIMESTAMP = "http://api.submail.cn/service/timestamp.json";

        private IAppConfig _appConfig;
        public HttpWebHelper(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }

        public string GetTimeStamp()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = httpClient.GetAsync(API_TIMESTAMP).Result)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    Dictionary<string, string> jsonMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResult);
                    if (jsonMap.ContainsKey(TIMESTAMP))
                    {
                        return jsonMap[TIMESTAMP];
                    }
                }
            }

            return null;
        }

        public static bool CheckReturnJsonStatus(string retrunJsonResult)
        {
            Dictionary<string, string> jsonMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(retrunJsonResult);
            if (jsonMap.ContainsKey("status") && jsonMap["status"].Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static bool CheckMultiReturnJsonStatus(string returnJsonResult)
        {
            JArray jarray = JArray.Parse(returnJsonResult);
            bool isAllSuccess = true;
            foreach (var item in jarray.Children())
            {
                if (CheckReturnJsonStatus(item.ToString()) == false)
                {
                    isAllSuccess = false;
                    break;
                }
            }

            return isAllSuccess;
        }

        public string HttpGet(string httpUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("charset", "UTF-8");
                using (HttpResponseMessage response = httpClient.GetAsync(httpUrl).Result)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        public string HttpPut(string httpUrl, Dictionary<string, object> dataPair)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("charset", "UTF-8");
                using (MultipartFormDataContent multipart = Build(dataPair))
                {
                    using (HttpResponseMessage response = httpClient.PutAsync(httpUrl, multipart).Result)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
        }

        public string HttpDelete(string httpUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("charset", "UTF-8");
                using (HttpResponseMessage response = httpClient.DeleteAsync(httpUrl).Result)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        public string HttpPost(string httpUrl, Dictionary<string, object> dataPair)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("charset", "UTF-8");
                using (MultipartFormDataContent multipart = Build(dataPair))
                {
                    using (HttpResponseMessage response = httpClient.PostAsync(httpUrl, multipart).Result)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
        }

        private MultipartFormDataContent Build(Dictionary<string, object> dataPair)
        {
            MultipartFormDataContent multipart = new MultipartFormDataContent();
            string timeStamp = this.GetTimeStamp();
            dataPair.Add(APPID, _appConfig.AppId);
            dataPair.Add(TIMESTAMP, timeStamp);
            dataPair.Add(SIGN_TYPE, _appConfig.SignType.ToString());

            SignatureHelper sigHelper = new SignatureHelper(_appConfig);
            string formatData = RequestHelper.FormatRequest(dataPair);
            multipart.Add(new StringContent(sigHelper.GetSignature(formatData)), SIGNATURE);

            foreach (string key in dataPair.Keys)
            {
                string value = dataPair[key] as string;
                if (value != null)
                {
                    multipart.Add(new StringContent(value), key);
                    continue;
                }

                FileInfo file = dataPair[key] as FileInfo;
                if (file != null)
                {
                    var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(file.FullName));
                    fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("multipart/form-data");
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        FileName = file.Name,
                        Name = key,
                    };

                    multipart.Add(fileContent);
                }
            }

            return multipart;
        }
    }
}
