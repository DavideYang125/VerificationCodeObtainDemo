using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using VerificationCodeObtainDemo.Util;

namespace VerificationCodeObtainDemo.Lianzhong
{
    public class LianzhongRun
    {
        private const string ApiCode = "https://v2-api.jsdama.com/upload";
        public static string LianZhongCode(string imgUrl)
        {
            var img64 = NetHandle.GetImageAsBase64Url(imgUrl).Result;
            LianZhongRequestModel param = new LianZhongRequestModel();
            param.captchaData = img64;
            param.softwareId = 0;
            param.softwareSecret = "";
            param.username = "";
            param.password = "";
            // captchaType 类型，查看：https://www.jsdati.com/docs/price
            param.captchaType = 1001;
            using (var _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("host", "v2-api.jsdama.com");
                _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36");
                StringContent content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8,
                                "application/json");
                HttpResponseMessage response = _client.PostAsync(ApiCode, content).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("返回结果--" + result);
                if (!result.Contains("recognition")) return string.Empty;
                dynamic resultObj = JsonConvert.DeserializeObject(result);
                var data = resultObj["data"];
                string recognition = data["recognition"];
                Console.WriteLine("验证码:" + recognition);
                return recognition.Trim();
            }
        }
    }
}
