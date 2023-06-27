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

        public string SendMessage(string MobileNo, string MessageType)
        {
            string MessageBody = "";
            string TempletID = "";
            string SqlQuery = " exec USP_GetSMSTemplateByMessageType @MessageType='" + MessageType + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SMSMail.GetTemplateByKey");

            List<SMSTemplateDataModel> dataModels = new List<SMSTemplateDataModel>();
            if (dataTable.Rows.Count > 0)
            {
                MessageBody = dataTable.Rows[0]["MessageBody"].ToString();
                TempletID = dataTable.Rows[0]["TemplateID"].ToString(); ;
            }
            if (MessageType == "OTP")
            {
                SMSConfigurationSetting mSConfigurationSetting = new SMSConfigurationSetting();
                mSConfigurationSetting = this.GetConfigurationSetting();
                MessageBody = MessageBody.Replace("{#OTP#}", "123456");
                CommonHelper.SendSMS(mSConfigurationSetting, MobileNo, MessageBody, TempletID);
            }
            return MessageBody;
        }
    }
}
