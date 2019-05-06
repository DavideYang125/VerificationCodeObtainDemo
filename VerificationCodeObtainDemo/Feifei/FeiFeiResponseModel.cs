using System;
using System.Collections.Generic;
using System.Text;

namespace VerificationCodeObtainDemo.Feifei
{
    public class HttpExtraInfo
    {
        public double cust_val;
        public string result;
    }
    public class HttpRspData
    {
        public string RetCode;
        public string ErrMsg;
        public string RequestId;
        public string RspData;
        public HttpExtraInfo einfo;
    }
}
