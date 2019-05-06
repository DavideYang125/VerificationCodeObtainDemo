using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace VerificationCodeObtainDemo.Util
{
    public class NetHandle
    {
        public async static Task<string> GetImageAsBase64Url(string url)
        {
            using (var handler = new HttpClientHandler { })
            using (var client = new HttpClient(handler))
            {
                var bytes = await client.GetByteArrayAsync(url);
                return Convert.ToBase64String(bytes);//"image/jpeg;base64," + 
            }
        }
        public static byte[] ReadBytes(string url)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(url);
            return imageBytes;
        }
    }
}
