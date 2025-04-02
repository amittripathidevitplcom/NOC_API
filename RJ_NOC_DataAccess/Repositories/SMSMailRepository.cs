using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;

namespace RJ_NOC_DataAccess.Repository
{
    public class SMSMailRepository : ISMSMailRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public SMSMailRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public SMSConfigurationSetting GetConfigurationSetting()
        {
            string SqlQuery = "exec USP_GetSMSConfiguration";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SMSMail.GetConfigurationSetting");
            SMSConfigurationSetting mSConfigurationSetting = new SMSConfigurationSetting();
            if (dataTable.Rows.Count > 0)
            {
                mSConfigurationSetting.ServiceName = dataTable.Rows[0]["ServiceName"].ToString();
                mSConfigurationSetting.UniqueID = dataTable.Rows[0]["UniqueID"].ToString();
                mSConfigurationSetting.SMSUrl = dataTable.Rows[0]["SMSUrl"].ToString();
                mSConfigurationSetting.SMSUserName = dataTable.Rows[0]["SMSUserName"].ToString();
                mSConfigurationSetting.SMSPassWord = dataTable.Rows[0]["SMSPassWord"].ToString();
                mSConfigurationSetting.SmsClientID = dataTable.Rows[0]["SmsClientID"].ToString();
            }
            return mSConfigurationSetting;
        }

        public string SendMessage(string MobileNo, string MessageType, int ID)
        {
            string ReturnOTP = "";
            string MessageBody = "";
            string TempletID = "";
            string SqlQuery = " exec USP_GetSMSTemplateByMessageType @MessageType='" + MessageType + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SMSMail.GetTemplateByKey");
            SMSConfigurationSetting mSConfigurationSetting = new SMSConfigurationSetting();
            mSConfigurationSetting = this.GetConfigurationSetting();
            List<SMSTemplateDataModel> dataModels = new List<SMSTemplateDataModel>();
            if (dataTable.Rows.Count > 0)
            {
                MessageBody = dataTable.Rows[0]["MessageBody"].ToString();
                TempletID = dataTable.Rows[0]["TemplateID"].ToString(); 
            }
            if (MessageType == "OTP")
            {
                ReturnOTP = GenerateNewRandom();
                MessageBody = MessageBody.Replace("{#OTP#}", ReturnOTP);
                CommonHelper.SendSMS(mSConfigurationSetting, MobileNo, MessageBody, TempletID);
            }
            if (MessageType == "AppFinalSubmit")
            {
                var ds = this.GetApplyNocApplicationByApplicationID(ID);
                if (ds != null && ds.Tables.Count >= 1)
                {
                    MessageBody = MessageBody.Replace("{#ApplicationNo#}", ds.Tables[0].Rows[0]["ApplicationNo"].ToString());
                }

                MessageBody = MessageBody.Replace("{#College/Institute#}", "College/Institute");
                MessageBody = MessageBody.Replace("{#MobileAppLink#}", "https://rajnoc.rajasthan.gov.in/assets/MobileApp/RajNocMobileApp.rar");
                MessageBody = MessageBody.Replace("{#WebLink#}", "https://rajnoc.rajasthan.gov.in/");
                CommonHelper.SendSMS(mSConfigurationSetting, MobileNo, MessageBody, TempletID);
            }
            if (MessageType == "Revert")
            {
                var ds = this.GetApplyNocApplicationByApplicationID(ID);
                if (ds != null && ds.Tables.Count >= 1)
                {
                    MessageBody = MessageBody.Replace("{#appno#}", ds.Tables[0].Rows[0]["ApplicationNo"].ToString());
                }

                MessageBody = MessageBody.Replace("{#portal#}", "RAJNOC PORTAL");
                CommonHelper.SendSMS(mSConfigurationSetting, MobileNo, MessageBody, TempletID);
            }
            return ReturnOTP;
        }
        private static string GenerateNewRandom()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateNewRandom();
            }
            return r;
        }
        public DataSet GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID)
        {
            string SqlQuery = $"exec USP_Trn_ApplyNocApplication @action='GetApplyNocApplicationTrnByApplicationID',@ApplyNocApplicationID={ApplyNocApplicationID}";
            var ds = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNocParameterMaster.GetApplyNocApplicationList");
            return ds;
        }


        public string SendMessage_Local()
        {
            string? MessageBody = "";
            string? TempletID = "";
            string? MobileNo = "";
            string? AID = "0";
            string SqlQuery = " select * from Trn_SendSMS where IsSend=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SMSMail.SendMessage_Local");
            SMSConfigurationSetting mSConfigurationSetting = new SMSConfigurationSetting();
            mSConfigurationSetting = this.GetConfigurationSetting();
            List<SMSTemplateDataModel> dataModels = new List<SMSTemplateDataModel>();
            foreach (DataRow item in dataTable.Rows)
            {
                AID = item["AID"].ToString();
                MessageBody = item["SMSText"].ToString();
                TempletID = item["TemplateID"].ToString();
                MobileNo = item["MobileNo"].ToString();
                try
                {
                    string Response = CommonHelper.SendSMS(mSConfigurationSetting, MobileNo, MessageBody, TempletID);
                    int Rows = _commonHelper.NonQuerry("update Trn_SendSMS set SMS_Status='" + Response + "',IsSend=1,Sending_RTS=Getdate() Where aid='" + AID + "'", "SMS.SendMessage_Local");
                }
                catch (Exception ex)
                { }
            }
            return "Done";
        }
    }
}
