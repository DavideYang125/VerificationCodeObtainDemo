using System;

namespace VerificationCodeObtainDemo.Util
{
    public class TimeHelper
    {
        public static string GetCurrentTimeUnix()
        {
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long unixTime = ((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
            return unixTime.ToString();
            TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
            long t = (long)cha.TotalSeconds;
            return t.ToString();
        }
    }
}
