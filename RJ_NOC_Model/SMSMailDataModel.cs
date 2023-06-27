using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    //public class SmsResponseDataModel
    //{
    //    public bool IsSuccess { get; set; }
    //    public string ErrorMessage { get; set; }
    //    public int responseCode { get; set; }
    //    public string responseMessage { get; set; }
    //    public string responseID { get; set; }

    //}
    public class SMSTemplateDataModel
    {
        public int SMSTemplateID { get; set; }
        public string MessageType { get; set; }
        public string TemplateID { get; set; }
        public string MessageBody { get; set; }

    }
    public class SMSConfigurationSetting
    {
        public string ServiceName { get; set; }
        public string UniqueID { get; set; }
        public string SMSUrl { get; set; }
        public string SMSUserName { get; set; }
        public string SMSPassWord { get; set; }
        public string SmsClientID { get; set; }
    }


    public class UNOCSMSDataModel
    {
        public string UniqueID { get; set; }
        public string ServiceName { get; set; }
        public string Language { get; set; }
        public string Message { get; set; }
        public string MobileNo { get; set; }
        public string EntityID { get; set; }
        public string TemplateID { get; set; }
    }
}
