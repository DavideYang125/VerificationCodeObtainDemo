using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using VerificationCodeObtainDemo.Util;

namespace VerificationCodeObtainDemo.Feifei
{
    public class FeifeiRun
    {
        private static string ApiCode = "http://pred.fateadm.com/api/capreg";
        private static string PdId = "";
        private static string PdKey = "";
        private static string AppKey = "";
        private static string AppId = "";

        /// <summary>
        /// 斐斐打码
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static string FeifeiCode(string imgUrl)
        {
            var img64 = NetHandle.GetImageAsBase64Url(imgUrl).Result;
            var timestamp = TimeHelper.GetCurrentTimeUnix();
            string cur_tm = TimeHelper.GetCurrentTimeUnix();
            string sign = SecurityHelper.CalcSign(PdId, PdKey, cur_tm);
            string asign = SecurityHelper.CalcSign(AppId, AppKey, cur_tm);
            var predict_type = "30400";
            var imgBytes = NetHandle.ReadBytes(imgUrl);
            var values = new Dictionary<string, string>
            {
                { "user_id",PdId},
                { "timestamp",timestamp},
                { "sign",sign},
                { "app_id",AppId},
                { "asign",asign},
                { "predict_type",predict_type},
                { "img_data",img64}
            };

            using (var _client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = _client.PostAsync(ApiCode, content).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<HttpRspData>(result);
                if (!string.IsNullOrEmpty(data.RspData))
                {
                    // 附带附加信息
                    HttpExtraInfo einfo = JsonConvert.DeserializeObject<HttpExtraInfo>(data.RspData);
                    data.einfo = einfo;
                }
                var resultCode = data.einfo.result.Trim();
                Console.WriteLine("code:" + resultCode);
                return resultCode;
            }
        }
    }

}
