using System;
using VerificationCodeObtainDemo.Feifei;

namespace VerificationCodeObtainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var imgUrl = "https://newopen.imdada.cn/common/kaptcha.json";
            var code = FeifeiRun.FeifeiCode(imgUrl);
        }
    }
}
