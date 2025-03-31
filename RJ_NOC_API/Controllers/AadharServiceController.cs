using ikvm.@internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
using System.Xml.Linq;
using System.Text;
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
                CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.SendOtpByAadharNo_Esign", ex.ToString());
                

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
        public async Task<DataTable> eSignPDF(string PDFFileName, string OTPTransactionID, int DepartmentID, int ParamID)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            try
            {
                string str = await Task.Run(() => UtilityHelper.AadharServiceUtility.eSignPDF(PDFFileName, OTPTransactionID, DepartmentID, ParamID, _configuration));
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
            urldt.Columns.Add("optionMsg", typeof(string));
            try
            {
                var options = new RestClientOptions("https://rajkisan.rajasthan.gov.in")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/Service/ChatBotAppService", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Access-Control-Allow-Origin", "*");

                var body = new
                {
                    obj = new { usrnm = "rajkisan", psw = "rajkisan@123", AppType = "ChatbotAPIs", Aadhaar = Model.AadharNo, srvnm = "ChatbotAPIs", srvmethodnm = "SendOtpByAadharNoCB" }
                };

                request.AddJsonBody(body);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var response1 = JsonSerializer.Deserialize<List<ResponseDataModal>>(response.Content);

                    if (response1 != null)
                    {

                        urldt.Rows.Add(new Object[]{
                             response1.FirstOrDefault().message,0,
                              response1.FirstOrDefault().data,"optionMsg" });
                    }
                    else
                    {
                        urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again","optionMsg"
                                });
                    }

                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again","optionMsg"
                                });
                }

            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                ex.Message,"optionMsg"
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
                var request = new RestRequest("/Service/ChatBotAppService", Method.Post);
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

        [HttpPost("CA_eSignPDF")]
        public async Task<OperationResult<CAAadharResponseForESPRedirect>> CA_eSignPDF(CAGetSignedXmlApiRequest request)
        {
            var result = new OperationResult<CAAadharResponseForESPRedirect>();
            result.Data = new CAAadharResponseForESPRedirect();
            try
            {
                string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF") + "/" + request.PDFFileName;
                byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfPath);
                request.pdfBase64 = Convert.ToBase64String(pdfBytes);
                string CA_Requesturl = _configuration["AadharServiceDetails:CAeSignGetSignedXMLRSDUrl"].ToString();
                string CA_ESPportal = _configuration["AadharServiceDetails:CAeSignRedirectESPportal"].ToString();
                string URLType = Request.GetDisplayUrl();

                if (URLType.Contains("localhost"))
                {
                    request.successFailureurl = "http://localhost:62778/api/AadharService/CA_eSignPDFResponse/";
                }
                else if (URLType.Contains("172.22.33.75"))
                {
                    request.successFailureurl = "http://172.22.33.75/api/api/AadharService/CA_eSignPDFResponse/";
                }
                else
                {
                    request.successFailureurl = "https://rajnoc.rajasthan.gov.in/api/api/AadharService/CA_eSignPDFResponse/";
                }

                request.TransactionID = _configuration["AadharServiceDetails:CAClientCode"].ToString() + "_" + System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff");
                request.RequestType = "esignRSDURL";
                request.RSDRequestUrl = CA_Requesturl;
                request.ESPRequestURL = CA_ESPportal;
                //SAVE IN DATABASE GET DATA TO PUSH IN URL
                //request.RequestJson = "{\"pdfFile1\":\"" + request.pdfBase64 + "\",\"signatureOnPageNumber\":\"" + request.signatureOnPageNumber + "\",\"clientCode\":\"" + _configuration["AadharServiceDetails:CAClientCode"].ToString() + "\",\"designation\": \"" + request.designation + "\",\"txn\": \"" + request.TransactionID + "\",\"responseUrl\":\"" + request.successFailureurl + "\" ,\"location\":\"" + request.location + "\",\"xcord\":\"" + request.xcord + "\",\"ycord\":\"" + request.ycord + "\",\"sigsize\":\"" + request.sigsize + "\"}";
                bool reqStatus = UtilityHelper.AadharServiceUtility.CAeSign_Req_Res(request);
                if (reqStatus == true)
                {
                    //GET DATA
                    DataTable dt_RSDDATA = new DataTable();
                    dt_RSDDATA = CommonDataAccessHelper.GetCAeSign_Req_Res(request.TransactionID);
                    request.RequestJson = "{\"pdfFile1\":\"" + request.pdfBase64 + "\",\"signatureOnPageNumber\":\"" + dt_RSDDATA.Rows[0]["signatureOnPageNumber"].ToString() + "\",\"clientCode\":\"" + _configuration["AadharServiceDetails:CAClientCode"].ToString() + "\",\"designation\": \"" + dt_RSDDATA.Rows[0]["designation"].ToString() + "\",\"txn\": \"" + dt_RSDDATA.Rows[0]["TransactionID"].ToString() + "\",\"responseUrl\":\"" + dt_RSDDATA.Rows[0]["successFailureurl"].ToString() + "\" ,\"location\":\"" + dt_RSDDATA.Rows[0]["designation"].ToString() + "\",\"xcord\":\"" + dt_RSDDATA.Rows[0]["xcord"].ToString() + "\",\"ycord\":\"" + dt_RSDDATA.Rows[0]["ycord"].ToString() + "\",\"sigsize\":\"" + dt_RSDDATA.Rows[0]["sigsize"].ToString() + "\"}";
                    string res = string.Empty;

                    try
                    {
                        StreamWriter requestWriter;
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                        var webRequest = System.Net.WebRequest.Create(CA_Requesturl) as HttpWebRequest;
                        if (webRequest != null)
                        {
                            webRequest.Method = "POST";
                            webRequest.ServicePoint.Expect100Continue = false;
                            webRequest.Timeout = 40000;
                            webRequest.ContentType = "application/json";
                            //POST the data.
                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                requestWriter.Write(request.RequestJson);
                            }
                        }

                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        res = reader.ReadToEnd();
                        CommonDataAccessHelper.Insert_ErrorLog("AadharService.CA_eSignPDF", res);

                    }
                    catch (WebException wex)
                    {
                        CommonDataAccessHelper.Insert_ErrorLog("PaymentController.CA_eSignPDF", wex.ToString());
                        result.State = OperationState.Error;
                        result.ErrorMessage = wex.Message.ToString();
                        result.Data.RequestStatus = false;
                        CommonDataAccessHelper.Insert_ErrorLog("AadharService.CA_WebRequestinJson", wex.ToString());
                    }
                    if (res != null && res != "")
                    {

                        //string _resultOut = System.IO.File.ReadAllText(@"D:\2025_RAJ_NOC_PROJECTS\EmitraPayment\EmitraPayment\resposne.txt");
                        //var CAResponseData = JsonSerializer.Deserialize<CAAadharResponseForESPRedirect>(_resultOut);
                        var CAResponseData = JsonSerializer.Deserialize<CAAadharResponseForESPRedirect>(res);
                        if (CAResponseData != null)
                        {
                            result.Data.responseMsg = CAResponseData.responseMsg;
                            result.Data.ESPRequestURL = _configuration["AadharServiceDetails:CAeSignRedirectESPportal"].ToString();
                            result.Data.responseCode = CAResponseData.responseCode;
                            result.Data.signedXMLData = CAResponseData.signedXMLData;
                            result.Data.txn = CAResponseData.txn;
                            if (CAResponseData.responseCode == "REA_001")
                            {
                                result.Data.RequestStatus = true;
                                result.SuccessMessage = CAResponseData.responseMsg.ToString();
                            }
                            else
                            {
                                result.Data.RequestStatus = false;
                                result.State = OperationState.Error;
                                result.ErrorMessage = CAResponseData.responseMsg.ToString();
                            }
                        }
                        else
                        {
                            result.State = OperationState.Error;
                            result.ErrorMessage = "Please try again";
                            result.Data.RequestStatus = false;
                        }

                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "Please try again";
                        result.Data.RequestStatus = false;
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Something went wrong in Request";
                    result.Data.RequestStatus = false;
                }

            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AadharServiceController.CA_eSignPDF", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
                result.Data.RequestStatus = false;
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("CA_eSignPDFResponse")]
        public IActionResult CA_eSignPDFResponse(string DepartmentID = "0")
        //public async Task<OperationResult<CAGetSignedPDFAPIRequestResponse>>CA_eSignPDFResponse(string DepartmentID = "0")
        {
            string RetrunUrL = "";
            CAGetSignedXmlApiRequest request = new CAGetSignedXmlApiRequest();
            //Get Department ID
            DepartmentID = DepartmentID.Replace(' ', '+');
            DepartmentID = DepartmentID.Replace(' ', '+');
            DepartmentID = DepartmentID.Replace(' ', '+');
            var result = new OperationResult<CAGetSignedPDFAPIRequestResponse>();
            result.Data = new CAGetSignedPDFAPIRequestResponse();
            CAGetSignedPDFAPIRequestResponse _CAGetSignedPDFAPIRequestResponse = new CAGetSignedPDFAPIRequestResponse();
            try
            {
                string esignData = Request.Form["esignData"];
                XDocument doc = XDocument.Parse(esignData);
                XElement root = doc.Root;
                // Extracting attributes from EsignResp
                string errCode = root.Attribute("errCode")?.Value;
                string errMsg = root.Attribute("errMsg")?.Value;
                string resCode = root.Attribute("resCode")?.Value;
                string status = root.Attribute("status")?.Value;
                request.TransactionID = root.Attribute("txn")?.Value;
                if (status == "1")
                {


                    byte[] bytes = Encoding.UTF8.GetBytes(esignData);
                    request.esignResponse = Convert.ToBase64String(bytes);
                    if (request.esignResponse != null && request.esignResponse != "" && request.esignResponse != "string")
                    {
                        //GET DATA
                        DataTable dt_RSDDATA = new DataTable();
                        dt_RSDDATA = CommonDataAccessHelper.GetCAeSign_Req_Res(request.TransactionID);
                        string CA_Requesturl = _configuration["AadharServiceDetails:CAeSignedPDFapiUrl"].ToString();
                        string requestJson = "";
                        requestJson = "{\"clientCode\":\"" + _configuration["AadharServiceDetails:CAClientCode"].ToString() + "\",\"username\":\"" + dt_RSDDATA.Rows[0]["SSOdisplayName"].ToString() + "\",\"txn\": \"" + request.TransactionID + "\",\"esignResponse\":\"" + request.esignResponse + "\"}";
                        string res = string.Empty;
                        StreamWriter requestWriter;
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                        var webRequest = System.Net.WebRequest.Create(CA_Requesturl) as HttpWebRequest;
                        if (webRequest != null)
                        {
                            webRequest.Method = "POST";
                            webRequest.ServicePoint.Expect100Continue = false;
                            webRequest.Timeout = 40000;
                            webRequest.ContentType = "application/json";
                            //POST the data.
                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                requestWriter.Write(requestJson);
                            }
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        res = reader.ReadToEnd();
                        CommonDataAccessHelper.Insert_ErrorLog("AadharService.CA_eSignPDFResponse", res);
                        if (res != null && res != "")
                        {
                            var CAResponseData = JsonSerializer.Deserialize<CAGetSignedPDFAPIRequestResponse>(res);
                            if (CAResponseData != null)
                            {
                                result.Data.responseMsg = CAResponseData.responseMsg;
                                result.Data.responseCode = CAResponseData.responseCode;
                                result.Data.signedPDFUrl = CAResponseData.signedPDFUrl;
                                result.Data.txn = CAResponseData.txn;
                                result.Data.username = request.SSOdisplayName;

                                if (CAResponseData.responseCode == "REA_001")
                                {
                                    result.Data.RequestStatus = true;
                                }
                                else
                                {
                                    result.Data.RequestStatus = false;
                                }
                                request.RequestType = "InserteSignResponse";
                                request.ResponseCode = CAResponseData.responseCode;
                                request.ResponseMessage = CAResponseData.responseMsg;
                                request.ResponseJson = res;
                                request.esignResponseUrl = CAResponseData.signedPDFUrl; //FOR DOWNLOAD 
                                bool reqStatus = UtilityHelper.AadharServiceUtility.CAeSign_Req_Res(request);
                            }
                            else
                            {
                                result.State = OperationState.Error;
                                result.ErrorMessage = "Please try again";
                                result.Data.RequestStatus = false;
                            }

                        }
                        else
                        {
                            result.State = OperationState.Error;
                            result.ErrorMessage = "Something went wrong.";
                            result.Data.RequestStatus = false;
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "Required Base64 string of ESP Response";
                        result.Data.RequestStatus = false;
                    }
                }
                else
                {
                    //Update Response after Failed
                    request.RequestType = "InserteSignResponse";
                    request.ResponseCode = errCode;
                    request.ResponseMessage = errMsg;
                    request.ResponseJson = esignData;
                    bool reqStatus = UtilityHelper.AadharServiceUtility.CAeSign_Req_Res(request);
                    result.State = OperationState.Error;
                    result.ErrorMessage = errMsg;
                    result.Data.RequestStatus = false;
                    RetrunUrL = string.Format("{0}{1}", "");
                }

            }
            catch (System.Exception ex)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
                result.Data.RequestStatus = false;
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.CA_eSignPDF_response", ex.ToString());
            }
            //return result;
            return Redirect("http://localhost:4200/paymentsuccess");
        }

        [HttpPost("CA_eSignDownlaod")]
        public async Task<OperationResult<CAGetSignedPDFAPIRequestResponse>> CA_eSignPDF_Download()
        {
            var result = new OperationResult<CAGetSignedPDFAPIRequestResponse>();
            result.Data = new CAGetSignedPDFAPIRequestResponse();
            string _resultOut = System.IO.File.ReadAllText(@"D:\2025_RAJ_NOC_PROJECTS\EmitraPayment\EmitraPayment\responseurl.txt");

            if (_resultOut != null && _resultOut != "")
            {
                var CAResponseData = JsonSerializer.Deserialize<CAGetSignedPDFAPIRequestResponse>(_resultOut);
                if (CAResponseData != null)
                {
                    result.Data.responseMsg = CAResponseData.responseMsg;
                    result.Data.responseCode = CAResponseData.responseCode;
                    result.Data.signedPDFUrl = CAResponseData.signedPDFUrl;
                    result.Data.txn = CAResponseData.txn;
                    if (CAResponseData.responseCode == "REA_001")
                    {
                        result.Data.RequestStatus = true;
                    }
                    else
                    {
                        result.Data.RequestStatus = false;
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please try again";
                    result.Data.RequestStatus = false;
                }

            }
            else
            {
                result.State = OperationState.Error;
                result.ErrorMessage = "Please try again";
                result.Data.RequestStatus = false;
            }
            return result;
        }


    }
}