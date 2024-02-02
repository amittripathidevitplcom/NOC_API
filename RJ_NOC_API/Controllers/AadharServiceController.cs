using ikvm.@internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Bcpg;
using RestSharp;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using sun.security.krb5.@internal;
using System.Data;
using System.Net;
using System.Text.Json;
using System.Xml;

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

        [HttpPost("SendAadharOTPOLD")]
        public DataTable SendAadharOTPOLD(CommonDataModel_AadharDataModel Model)
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

        [HttpPost("SendOtpByAadharNo_Esign")]
        public DataTable SendOtpByAadharNo_Esign(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                DataTable dt = UtilityHelper.AadharServiceUtility.SendOtpByAadharNo_Esign(Model, _configuration);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString().Contains("Service"))
                    {
                        urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                                dt.Rows[0][0].ToString() });
                    }
                    else if (dt.Rows[0][0].ToString().Contains("NO#"))
                    {
                        urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                                dt.Rows[0][0].ToString() });
                    }
                    else
                    {
                        urldt.Rows.Add(new Object[]{
                               "success",0,
                              dt.Rows[0][0].ToString()});

                        //// insert row values
                        //if (dt.Rows[0][0].ToString().Contains("DOIT"))
                        //{
                        //    urldt.Rows.Add(new Object[]{
                        //        "success",0,
                        //       dt.Rows[0][0].ToString()});
                        //}
                        //else
                        //{
                        //    urldt.Rows.Add(new Object[]{
                        //        dt.Rows[0][0].ToString(),1,
                        //       dt.Rows[0][0].ToString()});
                        //}
                    }
                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "AadharID is null",1,
                                "AadharID is null"
                                });
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



        [HttpPost("ValidateAadharOTPOLD")] 
        public DataTable ValidateAadharOTPOLD(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                //return string.Empty;
                PaymentEncriptionDec.EmitraEncrypt(Model.OTP);
                PaymentEncriptionDec.EmitraEncrypt(Model.TransactionNo);
                PaymentEncriptionDec.EmitraEncrypt(Model.AadharNo);
                DataTable dt = UtilityHelper.AadharServiceUtility.ValidateAadhaarOTP(Model, _configuration);
                //create table
                if (dt.Rows[0][0].ToString().ToLower().Contains("success"))
                {


                    urldt.Rows.Add(new Object[]{
                                "success",0,
                                CommonHelper.ConvertDataTable(dt)
                });
                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Invalid OTP!",1,
                                dt.Rows[0][0].ToString() });

                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
                CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.ValidateAadharOTP", ex.ToString());
            }
            return urldt;
        }

        [HttpPost("ValidateAadharOTP_Esign")]
        public DataTable ValidateAadharOTP_Esign(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                //return string.Empty;
                PaymentEncriptionDec.EmitraEncrypt(Model.OTP);
                PaymentEncriptionDec.EmitraEncrypt(Model.TransactionNo);
                PaymentEncriptionDec.EmitraEncrypt(Model.AadharNo);
                DataTable dt = UtilityHelper.AadharServiceUtility.ValidateAadhaarOTP_Esign(Model, _configuration);
                //create table
                if (dt.Rows[0][0].ToString().ToLower().Contains("success"))
                {
                    urldt.Rows.Add(new Object[]{
                                "success",0,
                                CommonHelper.ConvertDataTable(dt)
                });
                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Invalid OTP!",1,
                                dt.Rows[0][0].ToString() });

                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
                CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.ValidateAadharOTP", ex.ToString());
            }
            return urldt;
        }



        [HttpPost("GetAadharByVID")]
        public DataTable GetAadharByVID(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                string strResult = UtilityHelper.AadharServiceUtility.GetAadharByVID(Model, _configuration);
                if (!string.IsNullOrEmpty(strResult))
                {
                    if (strResult.Contains("NO"))
                    {
                        urldt.Rows.Add(new Object[]{
                                "Failed",1,
                                strResult });

                    }
                    else
                    {
                        //create table
                        urldt.Rows.Add(new Object[]{
                                "success",0,
                                strResult });
                    }
                }
                else
                {
                    //create table
                    urldt.Rows.Add(new Object[]{
                                "Failed",1,
                                "something went wrong" });

                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GetAadharByVID.SaveData", ex.ToString());
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                               ex.Message
                                });
            }
            return urldt;
        }


        [HttpGet("eSignPDF/{PDFFileName}/{OTPTransactionID}/{DepartmentID}/{ParamID}")]
        public async Task<DataTable> eSignPDF(string PDFFileName, string OTPTransactionID,int DepartmentID,int ParamID)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            try
            {
                string str = await Task.Run(() => UtilityHelper.AadharServiceUtility.eSignPDF(PDFFileName, OTPTransactionID,  DepartmentID,  ParamID, _configuration));
                if (str == "Success")
                {
                    urldt.Rows.Add(new Object[]{
                                "E-Sign Successfully",0
                });
                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Transaction Id Invalid!",1,
                                });

                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1
                                });
                CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.ValidateAadharOTP", ex.ToString());
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return urldt;
        }



        [HttpPost("SendAadharOTP")]
        public DataTable SendAadharOTP(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                var options = new RestClientOptions("https://rajkisan.rajasthan.gov.in")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/rajkisanapp/Service/ChatBotAppService", Method.Post);
                request.AddHeader("Content-Type", "application/json");



                var body = "{\"obj\":{\"usrnm\":\"rajkisan\",\"psw\":\"rajkisan@123\",\"AppType\":\"ChatbotAPIs\",\"Aadhaar\":\""+ Model.AadharNo + "\",\"srvnm\":\"ChatbotAPIs\",\"srvmethodnm\":\"SendOtpByAadharNoCB\"}}";


                request.AddStringBody(body, DataFormat.Json);
                RestResponse response =client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var response1 = JsonSerializer.Deserialize<List<ResponseDataModal>>(response.Content);

                    if (response1 != null)
                    {

                        urldt.Rows.Add(new Object[]{
                             response1.FirstOrDefault().message,0,
                              response1.FirstOrDefault().data });
                    }
                    else 
                    { 
                     urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
                    }

                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
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
            var urldt = new System.Data.DataTable("tableName");
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                var options = new RestClientOptions("https://rajkisan.rajasthan.gov.in")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/rajkisanapp/Service/ChatBotAppService", Method.Post);
                request.AddHeader("Content-Type", "application/json");

                var body = "{\"obj\":{\"usrnm\":\"rajkisan\",\"psw\":\"rajkisan@123\",\"AppType\":\"ChatbotAPIs\",\"Aadhaar\":\"" + Model.AadharNo + "\",\"otp\":\"" + Model.OTP + "\",\"txn\":\"" + Model.TransactionNo + "\",\"srvnm\":\"ChatbotAPIs\",\"srvmethodnm\":\"VerifyAadhaarOTPCB\"}}";


                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var response1 = JsonSerializer.Deserialize<List<ResponseDataModal>>(response.Content);
                    if (response1 != null)
                    {

                        urldt.Rows.Add(new Object[]{
                             response1.FirstOrDefault().message,0,
                              response1.FirstOrDefault().data });
                    }
                    else
                    {
                        urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
                    }

                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
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

        //class for data handle
        public class ResponseDataModal
        {
            public string message { get; set; }
            public string status { get; set; }
            public object data { get; set; }
        }



    }
}