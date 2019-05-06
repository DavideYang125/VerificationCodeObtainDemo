using System.Security.Cryptography;
using System.Text;

namespace VerificationCodeObtainDemo.Util
{
    public class SecurityHelper
    {
        #region MD5加密

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }


            MD5 myMd5 = new MD5CryptoServiceProvider();
            byte[] signed = myMd5.ComputeHash(encoding.GetBytes(input));
            string signResult = Byte2Mac(signed);
            return signResult.ToLower();
        }

        //MD5加密方法
        private static string Byte2Mac(byte[] signed)
        {
            StringBuilder enText = new StringBuilder();
            foreach (byte Byte in signed)
            {
                enText.AppendFormat("{0:x2}", Byte);
            }

            return enText.ToString();
        }

        #endregion


        public static string Md5(string src)
        {
            string str = "";
            byte[] data = Encoding.GetEncoding("utf-8").GetBytes(src);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(data);
            for (int i = 0; i < bytes.Length; i++)
            {
                str += bytes[i].ToString("x2");
            }
            return str;
        }
        public static string CalcSign(string id, string key, string tm)
        {
            string chk = Md5(tm + key);
            string sum = Md5(id + tm + chk);
            //Console.WriteLine("calc sign, id: {0} key: {1} tm: {2} chk: {3} sum: {4}", id, key, tm, chk, sum);
            return sum;
        }
    }
}
