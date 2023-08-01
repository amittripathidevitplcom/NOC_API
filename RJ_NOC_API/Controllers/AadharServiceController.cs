using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using System.Data;
using System.Net;

namespace RJ_NOC_API.Controllers
{
    [Route("api/AadharService")]
    [ApiController]
    public class AadharServiceController : RJ_NOC_ControllerBase
    {

        private IConfiguration _configuration;
        public AadharServiceController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SendAdharOTP")]
        public DataTable SendAadharOTP(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                
                DataTable dt = UtilityHelper.AadharServiceUtility.SendOtpByAadharNo(Model, _configuration);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString().Contains("Service"))
                    {
                        urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                                dt.Rows[0][0].ToString() });
                    }
                    else
                    {
                        // insert row values
                        if (dt.Rows[0][0].ToString().Contains("DOIT"))
                        {
                            urldt.Rows.Add(new Object[]{
                                "success",0,
                               dt.Rows[0][0].ToString()});
                        }
                        else
                        {
                            urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                               dt.Rows[0][0].ToString()});
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
            }
            return urldt;
        }

        [HttpPost("ValidateAadharOTP")]
        public DataTable ValidateAadharOTP(CommonDataModel_AadharDataModel Model)
        {
            string Certificatename = "uidai_auth_prod.cer";
            string CertificatePath = Path.Combine(Directory.GetCurrentDirectory(), "Content" , Certificatename);
            //return string.Empty;
            PaymentEncriptionDec.EmitraEncrypt(Model.OTP);
            PaymentEncriptionDec.EmitraEncrypt(Model.TransactionNo);
            PaymentEncriptionDec.EmitraEncrypt(Model.OTP);
            return  UtilityHelper.AadharServiceUtility.ValidateAadhaarOTP(Model, _configuration);
        }
    }
}