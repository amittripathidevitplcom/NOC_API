using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using Azure.Core;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using javax.swing.text;
using sun.security.krb5;

using java.lang;
using java.security;
using EmitraEmitraEncrytDecryptClient;
using System.Xml.Linq;
using System.Threading.Tasks;
using java.awt;
using sun.security.jca;
using System.Net;
using java.sql;
using sun.security.x509;
using System.Drawing;
using System.Web.Http;
using sun.net.idn;
using System.Collections.Specialized;

namespace RJ_NOC_API.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : RJ_NOC_ControllerBase
    {
        const string MERCHANTCODE = "rppTestMerchant";
        const string CHECKSUMKEY = "UWf6a7cDCP";
        private IConfiguration _configuration;
        public PaymentController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region "RPP PAYMENT INTEGRAION"
        [HttpPost("PaymentRequest")]
        public async Task<OperationResult<PaymentRequest>> PaymentRequest(RequestDetails request)
        {

            PaymentGatewayDataModel Model = new PaymentGatewayDataModel();
            Model.PaymentGateway = (int)enmPaymentGatway.RPP;
            Model.DepartmentID = request.DepartmentID;
            var data = UtilityHelper.PaymentUtility.GetpaymentGatewayDetails(Model);

            var result = new OperationResult<PaymentRequest>();
            Random rnd = new Random();
            //string PRN = "PRN" + rnd.Next(100000, 999999)+ rnd.Next(100000, 999999);
            string PRN = "TXN"+ CommonHelper.GenerateTransactionNumber();
            try
            {
                if (!string.IsNullOrEmpty(data.MerchantCode))
                {
                    result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.SendRequest(PRN, request.AMOUNT, request.PURPOSE, request.USERNAME, request.USERMOBILE, request.USEREMAIL, request.ApplyNocApplicationID, data));
                    if (result.Data != null)
                    {
                        result.Data.CreatedBy = request.CreatedBy;
                        result.Data.SSOID = request.SSOID;
                        result.Data.REQUESTPARAMETERS.RequestType = (int)enmPaymetRequest.PaymentRequest;
                        bool isSuccess = UtilityHelper.PaymentUtility.CreatePaymentRequest(result.Data);
                        if (isSuccess)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "PaymentRequest", 0, "Payment");
                            result.State = OperationState.Success;
                            result.SuccessMessage = "Payment successfully .!";
                        }
                        else
                        {
                            result.State = OperationState.Error;
                            result.ErrorMessage = "There was an error payment.!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "There was an error payment.!";
                    }
                }
                else 
                {
                    result.State = OperationState.Error;
                    result.Data = new PaymentRequest();
                    result.ErrorMessage = "Payment Integraion Details Not Found.!";
                }
            }
            catch (System.Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.PaymentRequest", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        //  public IActionResult Task<OperationResult<PaymentResponse>> PaymentResponse()
        [HttpPost("PaymentResponse")] //IActionResult
        public IActionResult PaymentResponse(string DepartmentID = "0")
        {

            //Get Department ID
            DepartmentID = DepartmentID.Replace(' ', '+');
            DepartmentID = DepartmentID.Replace(' ', '+');
            DepartmentID = DepartmentID.Replace(' ', '+');

            //Get Payment Details 
            PaymentGatewayDataModel Model = new PaymentGatewayDataModel();
            Model.PaymentGateway = (int)enmPaymentGatway.RPP;
            Model.DepartmentID = Convert.ToInt32(PaymentEncriptionDec.EmitraDecrypt(DepartmentID));
            var data = UtilityHelper.PaymentUtility.GetpaymentGatewayDetails(Model);

            string RetrunUrL = "";
            string STATUS = Request.Form["STATUS"];
            string ENCDATA = Request.Form["ENCDATA"];
            var result = new OperationResult<PaymentResponse>();
            try
            {

                result.Data = UtilityHelper.PaymentUtility.GetResponse(STATUS, ENCDATA, data);
                result.State = OperationState.Success;
                if (result.Data != null)
                {
                    UtilityHelper.PaymentUtility.SaveData(result.Data);
                    if (result.Data.CHECKSUMVALID)
                    {

                        if (result.Data.RESPONSEPARAMETERS.STATUS.ToLower() == "Success".ToLower())
                        {
                            result.State = OperationState.Success;
                            result.SuccessMessage = "Data load successfully .!";
                            RetrunUrL = string.Format("{0}{1}", data.RedirectURL, result.Data.RESPONSEPARAMETERS.PRN);
                        }
                        else
                        {
                            RetrunUrL = string.Format("{0}{1}", data.RedirectURL, result.Data.RESPONSEPARAMETERS.PRN);
                        }
                    }
                    else
                    {
                        RetrunUrL = string.Format("{0}{1}", data.RedirectURL, result.Data.RESPONSEPARAMETERS.PRN);
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.PaymentResponse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
                RetrunUrL = string.Format("{0}/{1}", data.FailureURL, result.Data.RESPONSEPARAMETERS.PRN);

            }
            finally
            {
                //UnitOfWork.Dispose();

            }
            return Redirect(RetrunUrL);
            // return Redirect("http://localhost:4200/paymentsuccess");

            //return result;
        }
        [HttpGet("GetTransactionDetails/{TransID}")]
        public async Task<OperationResult<List<ResponseParameters>>> GetTransactionDetails(string TransID)
        {
            var result = new OperationResult<List<ResponseParameters>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.GetPaymentListIDWise(TransID));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GetTransactionDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("GetTransactionStatus")]
        public async Task<OperationResult<ResponseParameters>> GetTransactionStatus(TransactionStatusDataModel Model)
        {
            var result = new OperationResult<ResponseParameters>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                //get payment details form database
                PaymentGatewayDataModel dataModel = new PaymentGatewayDataModel();
                dataModel.PaymentGateway = (int)enmPaymentGatway.RPP;
                dataModel.DepartmentID = Model.DepartmentID;
                var data = UtilityHelper.PaymentUtility.GetpaymentGatewayDetails(dataModel);

                if (!string.IsNullOrEmpty(data.MerchantCode))
                {
                    HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(data.VerificationURL + "?MERCHANTCODE=" + data.MerchantCode + "&&PRN=" + Model.PRN + "&&AMOUNT=" + Model.AMOUNT);
                    webrequest.Method = "POST";
                    webrequest.ContentType = "application/x-www-form-urlencoded";
                    webrequest.ContentLength = 0;

                    Stream stream = webrequest.GetRequestStream();
                    stream.Close();
                    string RESPONSEJSON;
                    using (WebResponse response = webrequest.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            RESPONSEJSON = reader.ReadToEnd();
                            ResponseParameters RESPONSEPARAMS = JsonConvert.DeserializeObject<ResponseParameters>(RESPONSEJSON);
                            dynamic stuff = JsonConvert.DeserializeObject(RESPONSEJSON);
                            string STATUS = stuff.STATUS;
                            string RESPONSECODE = stuff.RESPONSECODE;
                            if (STATUS == "SUCCESS")
                            {
                                result.State = OperationState.Success;
                                result.Data = RESPONSEPARAMS;
                                result.SuccessMessage = RESPONSEPARAMS.RESPONSEMESSAGE;

                                //Update Database
                                PaymentResponse objresponse = new PaymentResponse();
                                objresponse.STATUS = RESPONSEPARAMS.STATUS;
                                objresponse.RESPONSEJSON = RESPONSEJSON;
                                objresponse.RESPONSEPARAMETERS = RESPONSEPARAMS;
                                UtilityHelper.PaymentUtility.SaveData(objresponse);

                            }
                            else
                            {
                                result.State = OperationState.Error;
                                result.Data = RESPONSEPARAMS;
                                result.ErrorMessage = RESPONSEPARAMS.RESPONSEMESSAGE;


                                //Update Database
                                PaymentResponse objresponse = new PaymentResponse();
                                objresponse.STATUS = RESPONSEPARAMS.STATUS;
                                objresponse.RESPONSEJSON = RESPONSEJSON;
                                objresponse.RESPONSEPARAMETERS = RESPONSEPARAMS;
                                UtilityHelper.PaymentUtility.SaveData(objresponse);
                            }
                        }
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.Data = new ResponseParameters();
                    result.ErrorMessage = "Payment Integrations Details Not Found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GetTransactionStatus", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("RPPTransactionRefund")]
        public async Task<OperationResult<ResponseParameters>> RPPTransactionRefund(TransactionStatusDataModel Model)
        {
            var result = new OperationResult<ResponseParameters>();
            try
            {
                string APINAME = "TXNREFUND";
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
               
                //get payment details form database
                PaymentGatewayDataModel dataModel = new PaymentGatewayDataModel();
                dataModel.PaymentGateway = (int)enmPaymentGatway.RPP;
                dataModel.DepartmentID = Model.DepartmentID;
                var data = UtilityHelper.PaymentUtility.GetpaymentGatewayDetails(dataModel);
     
                if (!string.IsNullOrEmpty(data.MerchantCode))
                {
                    //Save Data in database
                    PaymentRequest paymentRequest = new PaymentRequest();
                    //
                    paymentRequest.REQUESTPARAMETERS = new RequestParameters();//assign memory

                    Model.SubOrderID = paymentRequest.REQUESTPARAMETERS.PRN;
                    paymentRequest.REQUESTJSON = JsonConvert.SerializeObject(Model);
                    paymentRequest.REQUESTPARAMETERS.UDF1= Model.ApplyNocApplicationID;
                    paymentRequest.REQUESTPARAMETERS.RequestType = (int)enmPaymetRequest.RefundRequest;
                    paymentRequest.REQUESTPARAMETERS.PRN ="RFD"+ CommonHelper.GenerateTransactionNumber();
                    paymentRequest.REQUESTPARAMETERS.AMOUNT = Model.AMOUNT;
                    paymentRequest.REQUESTPARAMETERS.MERCHANTCODE = data.MerchantCode;
                    paymentRequest.REQUESTPARAMETERS.RPPTXNID = Model.RPPTXNID;
                    paymentRequest.SSOID= Model.SSOID;
                    bool isSuccess = UtilityHelper.PaymentUtility.CreatePaymentRequest(paymentRequest);
                    if (isSuccess)
                    {

                        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(data.RefundURL + "?MERCHANTCODE=" + data.MerchantCode + "&PRN=" + Model.PRN + "&AMOUNT=" + Model.AMOUNT + "&RPPTXNID=" + Model.RPPTXNID + "&SUBORDERID=" + paymentRequest.REQUESTPARAMETERS.PRN + "&APINAME=" + APINAME);
                        webrequest.Method = "POST";
                        webrequest.ContentType = "application/x-www-form-urlencoded";
                        webrequest.ContentLength = 0;

                        Stream stream = webrequest.GetRequestStream();
                        stream.Close();
                        string RESPONSEJSON;
                        using (WebResponse response = webrequest.GetResponse())
                        {
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                RESPONSEJSON = reader.ReadToEnd();
                                ResponseParameters RESPONSEPARAMS = JsonConvert.DeserializeObject<ResponseParameters>(RESPONSEJSON);
                                dynamic stuff = JsonConvert.DeserializeObject(RESPONSEJSON);
                                string STATUS = stuff.STATUS;
                                string RESPONSECODE = stuff.RESPONSECODE;
                                if (STATUS == "SUCCESS")
                                {
                                    result.State = OperationState.Success;
                                    result.Data = RESPONSEPARAMS;
                                    result.SuccessMessage = RESPONSEPARAMS.REMARKS;

                                    #region "Update Payment Status Success Case"
                                    PaymentResponse obj = new PaymentResponse();
                                    obj.RESPONSEPARAMETERS = RESPONSEPARAMS;
                                    obj.RESPONSEJSON = RESPONSEJSON;
                                    obj.RESPONSEPARAMETERS.UDF1 = Model.ApplyNocApplicationID;
                                    obj.RESPONSEPARAMETERS.PRN = paymentRequest.REQUESTPARAMETERS.PRN;
                                    obj.RESPONSEPARAMETERS.REFUNDID = RESPONSEPARAMS.REFUNDID;
                                    obj.RESPONSEPARAMETERS.REFUNDTIMESTAMP = RESPONSEPARAMS.REFUNDTIMESTAMP;
                                    obj.RESPONSEPARAMETERS.REMARKS = RESPONSEPARAMS.REMARKS;
                                    obj.RESPONSEPARAMETERS.RESPONSEMESSAGE = RESPONSEPARAMS.REFUNDSTATUS;
                                    obj.RESPONSEPARAMETERS.REFUNDSTATUS = RESPONSEPARAMS.REFUNDSTATUS;
                                    obj.RESPONSEPARAMETERS.RPPTXNID= Model.RPPTXNID;
                                    UtilityHelper.PaymentUtility.UpdateRefundStatus(obj);
                                    #endregion
                                }
                                else
                                {
                                    result.State = OperationState.Error;
                                    result.Data = RESPONSEPARAMS;
                                    result.ErrorMessage = RESPONSEPARAMS.RESPONSEMESSAGE;

                                    #region "Update Payment Status Failed Case"
                                    PaymentResponse obj = new PaymentResponse();
                                    obj.RESPONSEPARAMETERS = RESPONSEPARAMS;
                                    obj.RESPONSEJSON = RESPONSEJSON;
                                    obj.RESPONSEPARAMETERS.UDF1 = Model.ApplyNocApplicationID;
                                    obj.RESPONSEPARAMETERS.PRN = paymentRequest.REQUESTPARAMETERS.PRN;
                                    obj.RESPONSEPARAMETERS.RESPONSECODE = RESPONSEPARAMS.RESPONSECODE;
                                    obj.RESPONSEPARAMETERS.REFUNDSTATUS = RESPONSEPARAMS.STATUS;
                                    obj.RESPONSEPARAMETERS.RPPTXNID = Model.RPPTXNID;
                                    UtilityHelper.PaymentUtility.UpdateRefundStatus(obj);
                                    #endregion

                                }
                            }
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.Data = new ResponseParameters();
                        result.ErrorMessage = "Something went wrong";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.Data = new ResponseParameters();
                    result.ErrorMessage = "Payment Integrations Details Not Found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GetTransactionStatus", ex.ToString());
                result.State = OperationState.Error;
                result.Data = new ResponseParameters();
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("RPPTransactionRefundStatus")]
        public async Task<OperationResult<RefundTransactionDataModel>> RPPTransactionRefundStatus(TransactionStatusDataModel Model)
        {
            var result = new OperationResult<RefundTransactionDataModel>();
            try
            {
                string APINAME = "REFUNDSTATUS";
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                //get payment details form database
                PaymentGatewayDataModel dataModel = new PaymentGatewayDataModel();
                dataModel.PaymentGateway = (int)enmPaymentGatway.RPP;
                dataModel.DepartmentID = Model.DepartmentID;
                var data = UtilityHelper.PaymentUtility.GetpaymentGatewayDetails(dataModel);

                if (!string.IsNullOrEmpty(data.MerchantCode))
                {
                    HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(data.RefundStatusURL + "?MERCHANTCODE=" + data.MerchantCode + "&RPPTXNID=" + Model.RPPTXNID + "&APINAME=" + APINAME );
                    webrequest.Method = "POST";
                    webrequest.ContentType = "application/x-www-form-urlencoded";
                    webrequest.ContentLength = 0;

                    Stream stream = webrequest.GetRequestStream();
                    stream.Close();
                    string RESPONSEJSON;
                    using (WebResponse response = webrequest.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            RESPONSEJSON = reader.ReadToEnd();
                            RefundTransactionDataModel RESPONSEPARAMS = JsonConvert.DeserializeObject<RefundTransactionDataModel>(RESPONSEJSON);
                            dynamic stuff = JsonConvert.DeserializeObject(RESPONSEJSON);
                            string STATUS = stuff.STATUS;
                            string RESPONSECODE = stuff.RESPONSECODE;
                            if (STATUS == "SUCCESS")
                            {
                                result.State = OperationState.Success;
                                result.Data = RESPONSEPARAMS;
                                result.SuccessMessage = RESPONSEPARAMS.STATUS;


                                RESPONSEPARAMS.ApplyNocApplicationID = Convert.ToInt32(Model.ApplyNocApplicationID);
                                //Update Status In DataBase
                                RESPONSEPARAMS.PRN = Model.PRN;
                                RESPONSEPARAMS.RESPONSEJSON = RESPONSEJSON;
                                UtilityHelper.PaymentUtility.UpdateRefundTransactionStatus(RESPONSEPARAMS);


                            }
                            else
                            {
                                result.State = OperationState.Error;
                                result.Data = RESPONSEPARAMS;
                                result.ErrorMessage = RESPONSEPARAMS.STATUS;
                                //Update Status
                                RESPONSEPARAMS.ApplyNocApplicationID = Convert.ToInt32(Model.ApplyNocApplicationID);
                                RESPONSEPARAMS.PRN = Model.PRN;
                                RESPONSEPARAMS.RESPONSEJSON = RESPONSEJSON;
                                UtilityHelper.PaymentUtility.UpdateRefundTransactionStatus(RESPONSEPARAMS);
                            }
                        }
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.Data = new RefundTransactionDataModel();
                    result.ErrorMessage = "Payment Integrations Details Not Found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GetTransactionStatus", ex.ToString());
                result.State = OperationState.Error;
                result.Data = new RefundTransactionDataModel();
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

   
        [HttpPost("RPPTransactionCallback")]
        public IActionResult RPPTransactionCallback()
        {
            try
            {
                string STATUS = Request.Form["STATUS"];
                string ENCDATA = Request.Form["ENCDATA"];
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.RPPTransactionCallbackLogs", string.Format("Status={0},EncData={1}", STATUS, ENCDATA));
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.RPPTransactionCallback", ex.ToString());
            }
            return Ok();
        }


        [HttpPost("GetRPPTransactionList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetRPPTransactionList(TransactionSearchFilterModel Model)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.GetRPPTransactionList(Model));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRPPTransactionList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        #endregion
        //[HttpPost("EmitraPayment")]
        //public async Task<EmitraRequestDetails> EmitraPayment(EmitraRequestDetails Model)
        //{
        //    try
        //    {
        //        var EmitraServiceDetail = UtilityHelper.PaymentUtility.GetEmitraServiceDetails(Model);
        //        EmitraTransactions objEmitra = new EmitraTransactions();
        //        objEmitra.key = "InsertDetails";
        //        var result = UtilityHelper.PaymentUtility.CreateAddEmitraTransation(objEmitra);
        //        PGRequest data = new PGRequest();
        //        if (result.TransactionId > 0)
        //        {

        //            data.MERCHANTCODE = EmitraServiceDetail.MERCHANTCODE;
        //            //data.PRN = "NOC" + result.TransactionId;

        //            Random rnd = new Random();
        //            data.PRN = "PRN" + rnd.Next(100000, 999999) ;

        //            data.REQTIMESTAMP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //            data.AMOUNT = "10.00";
        //            data.SUCCESSURL = EmitraServiceDetail.REDIRECTURL; //+ "?UniquerequestId=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(result.TransactionId)) + "&ApplicationIdEnc=" + PaymentEncriptionDec.EmitraEncrypt(Model.ApplicationIdEnc) + "&ServiceID=" + Model.ServiceID + "&IsFailed=" + PaymentEncriptionDec.EmitraEncrypt("NO");
        //            data.FAILUREURL = EmitraServiceDetail.REDIRECTURL;// + "?UniquerequestId=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(result.TransactionId)) + "&ApplicationIdEnc=" + PaymentEncriptionDec.EmitraEncrypt(Model.ApplicationIdEnc) + "&ServiceID=" + Model.ServiceID + "&IsFailed=" + PaymentEncriptionDec.EmitraEncrypt("YES");
        //            data.USERNAME = Model.UserName; ;
        //            data.USERMOBILE = Model.MobileNo;
        //            data.COMMTYPE = EmitraServiceDetail.COMMTYPE;
        //            data.OFFICECODE = EmitraServiceDetail.OFFICECODE;
        //            data.REVENUEHEAD = EmitraServiceDetail.REVENUEHEAD.Replace("##", data.AMOUNT.ToString());
        //            data.SERVICEID = EmitraServiceDetail.SERVICEID;
        //            data.UDF1 = Model.RegistrationNo;
        //            data.UDF2 = Model.SsoID;
        //            data.USEREMAIL = "r.rajsingh04@gmail.com";
        //            data.ApplicationIdEnc = "10075";
        //            data.UniquerequestId = "100104251";

        //            data.CHECKSUM = PaymentEncriptionDec.CreateMD5(data.PRN + "|" + data.AMOUNT + "|" + EmitraServiceDetail.CHECKSUMKEY);







        //            // data.commissionAmount = "0";
        //            // data.ServiceURL = EmitraServiceDetail.ServiceURL;
        //            //string datad=  "?strdata=" + JsonConvert.SerializeObject(data) + "&enckey=" + EmitraServiceDetail.EncryptionKey;

        //            EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration endpointConfiguration = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration();
        //            EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient emitraencsev = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient(endpointConfiguration, EmitraServiceDetail.WebServiceURL);
        //            EmitraEncryptStringResponse response = await emitraencsev.EmitraEncryptStringAsync(EmitraServiceDetail.EncryptionKey, JsonConvert.SerializeObject(data));

        //            Model.ENCDATA = response.Body.EmitraEncryptStringResult;
        //            Model.MERCHANTCODE = EmitraServiceDetail.MERCHANTCODE;
        //            Model.PaymentRequestURL = EmitraServiceDetail.ServiceURL;
        //            Model.ServiceID = EmitraServiceDetail.SERVICEID;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        CommonDataAccessHelper.Insert_ErrorLog("PaymentController.EmitraPayment", ex.ToString());
        //    }
        //    finally
        //    {
        //        // UnitOfWork.Dispose();
        //    }

        //    return Model;
        //}




        [HttpPost("EmitraPayment")]
        public async Task<OperationResult<EmitraRequestDetails>> EmitraPayment(EmitraRequestDetails Model)
        {
            var requestDetailsModel = new OperationResult<EmitraRequestDetails>();
            try
            {


                var EmitraServiceDetail = UtilityHelper.PaymentUtility.GetEmitraServiceDetails(Model);

                if (EmitraServiceDetail.REVENUEHEAD != null)
                {

                    EmitraTransactions objEmitra = new EmitraTransactions();
                    objEmitra.key = "InsertDetails";
                    objEmitra.ApplicationIdEnc = Model.ApplicationIdEnc;
                    objEmitra.Amount = Model.Amount;
                    var result = UtilityHelper.PaymentUtility.CreateAddEmitraTransation(objEmitra);

                    if (result.TransactionId > 0)
                    {
                        PGRequest data = new PGRequest();
                        data.MERCHANTCODE = EmitraServiceDetail.MERCHANTCODE;
                        //data.PRN = "NOC" + result.TransactionId;
                        Random rnd = new Random();
                        data.PRN = "NOC" + rnd.Next(100000, 999999) + rnd.Next(100000, 999999);

                        data.REQTIMESTAMP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        data.AMOUNT = Convert.ToString(Model.Amount);
                        data.SUCCESSURL = EmitraServiceDetail.REDIRECTURL + "?UniquerequestId=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(result.TransactionId)) + "&ApplicationIdEnc=" + PaymentEncriptionDec.EmitraEncrypt(Model.ApplicationIdEnc) + "&ServiceID=" + Model.ServiceID.ToString() + "&IsFailed=" + PaymentEncriptionDec.EmitraEncrypt("NO");
                        data.FAILUREURL = EmitraServiceDetail.REDIRECTURL + "?UniquerequestId=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(result.TransactionId)) + "&ApplicationIdEnc=" + PaymentEncriptionDec.EmitraEncrypt(Model.ApplicationIdEnc) + "&ServiceID=" + Model.ServiceID.ToString() + "&IsFailed=" + PaymentEncriptionDec.EmitraEncrypt("YES");
                        data.USERNAME = Model.UserName;
                        data.USERMOBILE = Model.MobileNo;
                        data.COMMTYPE = EmitraServiceDetail.COMMTYPE;
                        data.OFFICECODE = EmitraServiceDetail.OFFICECODE;
                        data.REVENUEHEAD = EmitraServiceDetail.REVENUEHEAD.Replace("##", Model.Amount.ToString());
                        data.SERVICEID = EmitraServiceDetail.SERVICEID;
                        data.UDF1 = Model.RegistrationNo;
                        data.UDF2 = Model.SsoID;
                        data.USEREMAIL = "";
                        data.CHECKSUM = PaymentEncriptionDec.CreateMD5(data.PRN + "|" + data.AMOUNT + "|" + EmitraServiceDetail.CHECKSUMKEY);

                        // data.ServiceURL = EmitraServiceDetail.ServiceURL;
                        //string datad=  "?strdata=" + JsonConvert.SerializeObject(data) + "&enckey=" + EmitraServiceDetail.EncryptionKey;

                        EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration endpointConfiguration = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration();

                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                        EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient emitraencsev = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient(endpointConfiguration, EmitraServiceDetail.WebServiceURL);
                        EmitraEncryptStringResponse response = await emitraencsev.EmitraEncryptStringAsync(EmitraServiceDetail.EncryptionKey, JsonConvert.SerializeObject(data));

                        if (data != null)
                        {
                            try
                            {
                                objEmitra.key = "UpdateDetails";
                                objEmitra.RequestString = JsonConvert.SerializeObject(data);
                                objEmitra.TransactionId = result.TransactionId;
                                objEmitra.ServiceID = EmitraServiceDetail.SERVICEID;
                                objEmitra.PRN = data.PRN;
                                var UpdateStatus = UtilityHelper.PaymentUtility.CreateAddEmitraTransation(objEmitra);
                            }
                            catch (System.Exception ex)
                            {
                                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.EmitraPaymentUpdateDetails", ex.ToString());
                            }

                        }

                        Model.ENCDATA = response.Body.EmitraEncryptStringResult;
                        Model.MERCHANTCODE = EmitraServiceDetail.MERCHANTCODE;
                        Model.PaymentRequestURL = EmitraServiceDetail.ServiceURL;
                        Model.ServiceID = EmitraServiceDetail.SERVICEID;
                        Model.IsSucccess = true;

                        requestDetailsModel.Data = Model;
                        requestDetailsModel.State = OperationState.Success;
                        requestDetailsModel.SuccessMessage = "successfully .!";
                    }
                }
                else
                {
                    requestDetailsModel.Data = Model;
                    requestDetailsModel.State = OperationState.Error;
                    requestDetailsModel.ErrorMessage = "Service Id Not Mapped";
                }

            }

            catch (System.Exception ex)
            {
                requestDetailsModel.Data = Model;
                requestDetailsModel.State = OperationState.Error;
                requestDetailsModel.ErrorMessage = ex.Message.ToString();
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.EmitraPayment", ex.ToString());
            }
            finally
            {
                // UnitOfWork.Dispose();
            }

            return requestDetailsModel;
        }


        [HttpGet("GetPreviewPaymentDetails/{CollegeID}")]
        public async Task<OperationResult<List<ResponseParameters>>> GetPreviewPaymentDetails(int CollegeID)
        {
            var result = new OperationResult<List<ResponseParameters>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.GetPreviewPaymentDetails(CollegeID));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GetPreviewPaymentDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("EmitraPaymentResponse")] //IActionResult
        public async Task<IActionResult> EmitraPaymentResponse(string UniquerequestId = "", string ApplicationIdEnc = "", string ServiceID = "", string IsFailed = "")
        {
            var RetrunUrL = "";
            try
            {

                UniquerequestId = UniquerequestId.Replace(' ', '+');
                UniquerequestId = UniquerequestId.Replace(' ', '+');
                UniquerequestId = UniquerequestId.Replace(' ', '+');

                ApplicationIdEnc = ApplicationIdEnc.Replace(' ', '+');
                ApplicationIdEnc = ApplicationIdEnc.Replace(' ', '+');
                ApplicationIdEnc = ApplicationIdEnc.Replace(' ', '+');

                IsFailed = IsFailed.Replace(' ', '+');
                IsFailed = IsFailed.Replace(' ', '+');
                IsFailed = IsFailed.Replace(' ', '+');

                ServiceID = ServiceID.Replace(' ', '+');
                ServiceID = ServiceID.Replace(' ', '+');
                ServiceID = ServiceID.Replace(' ', '+');

                EmitraRequestDetails Model = new EmitraRequestDetails();
                Model.ServiceID = ServiceID;
                var EmitraServiceDetail = UtilityHelper.PaymentUtility.GetEmitraServiceDetails(Model);

                var data = Convert.ToString(Request.Form["encData"]);

                var vIsFailed = PaymentEncriptionDec.EmitraDecrypt(IsFailed);

                EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration endpointConfiguration = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration();
                EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient emitraencsev = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient(endpointConfiguration, EmitraServiceDetail.WebServiceURL);
                EmitraDecriptStringResponse response = await emitraencsev.EmitraDecriptStringAsync(EmitraServiceDetail.EncryptionKey, data);
                var EmitraResponseData = JsonConvert.DeserializeObject<EmitraResponseParameters>(response.Body.EmitraDecriptStringResult);

                if (EmitraResponseData != null)
                {
                    EmitraResponseData.ApplicationIdEnc = PaymentEncriptionDec.EmitraDecrypt(ApplicationIdEnc);
                    EmitraResponseData.TRANSACTIONID = PaymentEncriptionDec.EmitraDecrypt(UniquerequestId);
                    //EmitraResponseData.ResponseString = JsonConvert.SerializeObject(response.Body.EmitraDecriptStringResult);
                    UtilityHelper.PaymentUtility.UpdateEmitraPaymentStatus(EmitraResponseData);
                }

                if (vIsFailed == "NO")
                {
                    RetrunUrL = string.Format("{0}{1}", EmitraServiceDetail.SuccessFailedURL, EmitraResponseData.PRN);
                }
                else
                {
                    RetrunUrL = string.Format("{0}{1}", EmitraServiceDetail.SuccessFailedURL, EmitraResponseData.PRN);
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.EmitraPaymentResponse", ex.ToString());
            }

            //return response;
            return new RedirectResult(RetrunUrL);
        }





        [HttpGet("GetEmitraTransactionDetails/{TransID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetEmitraTransactionDetails(string TransID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.GetEmitraTransactionDetails(TransID));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetEmitraTransactionDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        #region "Egrass  Payment Integration"

        [HttpPost("GRAS_PaymentRequest")]
        public async Task<OperationResult<PaymentRequest>> GRAS_PaymentRequest(RequestDetails request)
        {
            var result = new OperationResult<PaymentRequest>();
            result.Data = new PaymentRequest();
            Random rnd = new Random();
           // string PRN = "TXN" + CommonHelper.GenerateTransactionNumber();
            string PRN =  DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                EgrassNocEncrypt oEgrassFabEncrypt = new EgrassNocEncrypt();

                // Server.MapPath("~/SystemGeneratedPDF/rajnoc.key");
                string keypath= Path.Combine(Directory.GetCurrentDirectory(), "PaymentKey","rajnoc.key");

                string Head_Amount1 = "10000.00";
                string Head_Name1 = "040100800500100000";

                string dtFrom = DateTime.Now.ToString("yyyy/MM/dd");
                string dtTo = DateTime.Now.ToString("yyyy/MM/dd");
                dtFrom = "2023/12/08";
                dtTo = "2024/12/08";

                string factAdrees = "Jaipur";
                string Pincode = "302020";
                string city = "Jaipur";
                string RemitterName = "Jaipur";

                string finyear = FinancialYear.Current.ToString();

                //F@bE*D$g^s# 
                //N*($%^$#)il^%$OC

    


                //string CHECKSUM = oEgrassFabEncrypt.Encrypt(PRN + "|" + Head_Amount1 + "|N*($%^$#)il^%$OC", keypath);
                string CHECKSUM = oEgrassFabEncrypt.Encrypt(PRN + "|" + Head_Amount1 + "|N*($%^$#)il^%$OC", keypath);
                //string paystring = "AUIN=" + ds.Tables[0].Rows[0]["AUIN"].ToString() + "|Head_Name1=" + ds.Tables[0].Rows[0]["Head_Name1"].ToString() + "|Head_Amount1=" + ds.Tables[0].Rows[0]["Head_Amount1"].ToString() + "|Head_Name2=0|Head_Amount2=0|Head_Name3=0|Head_Amount3=0|Head_Name4=0|Head_Amount4=0|Head_Name5=0|Head_Amount5=0|Head_Name6=0|Head_Amount6=0|Head_Name7=0|Head_Amount7=0|Head_Name8=0|Head_Amount8=0|Head_Name9=0|Head_Amount9=0|RemitterName=Abc Chemicals|Discount=0|TotalAmount=100|MerchantCode=32|PaymentMode=N|REGTINNO=302004|Location=" + ds.Tables[0].Rows[0]["Location"].ToString() + "|DistrictCode=" + ds.Tables[0].Rows[0]["DistrictCode"].ToString() + "|OfficeCode=" + ds.Tables[0].Rows[0]["OfficeCode"].ToString() + "|DepartmentCode=32|FromDate=2018/12/03|ToDate=2019/12/31|Address=Jhalana Industrial area jaipur|PIN=302004|City=Jaipur|Remarks=SampleRemark|Filler=A|ChallanYear=1819|Checksum=" + CHECKSUM + "";

                string paystring = "AUIN=" + PRN + "|Head_Name1=" + Head_Name1 + "|Head_Amount1=" + Head_Amount1 + "|Head_Name2=0|Head_Amount2=0|Head_Name3=0|Head_Amount3=0|Head_Name4=0|Head_Amount4=0|Head_Name5=0|Head_Amount5=0|Head_Name6=0|Head_Amount6=0|Head_Name7=0|Head_Amount7=0|Head_Name8=0|Head_Amount8=0|Head_Name9=0|Head_Amount9=0|RemitterName=" + RemitterName + "|Discount=0|TotalAmount=" + Head_Amount1 + "|MerchantCode=15|PaymentMode=N|REGTINNO=302004|Location=2100|DistrictCode=12|OfficeCode=395|DepartmentCode=32|FromDate=" + dtFrom + "|ToDate=" + dtTo + "|Address=" + factAdrees + "|PIN=" + Pincode + "|City=" + city + "|Remarks=SampleRemark|Filler=A|ChallanYear="+ finyear + "|Checksum=" + CHECKSUM + "";

                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GRAS_RawRequest",
                    string.Format("paystring = {0} ", paystring));

                string ENCDATA1 = oEgrassFabEncrypt.Encrypt(paystring, keypath);
                //this.AUIN.Value = ds.Tables[0].Rows[0]["AUIN"].ToString();
                //this.ENCDATA.Value = ENCDATA1;
                NameValueCollection data = new NameValueCollection();

                result.Data.MERCHANTCODE = "15";
                result.Data.ENCDATA = ENCDATA1;
                result.Data.AUIN = PRN;
                //result.Data.PaymentRequestURL = "https://egras.rajasthan.gov.in/samplemerchantprelogin.aspx";

                result.Data.PaymentRequestURL = "http://10.68.69.46:62778/api/Payment/GRAS_PaymentRequest";

                 


                //data.Add("Merchant_code", "32");
                //data.Add("AUIN", ds.Tables[0].Rows[0]["PRN"].ToString());
                //data.Add("ENCDATA", ENCDATA1);
                //RedirectAndPOST(this.Page, "https://egras.rajasthan.gov.in/samplemerchantprelogin.aspx", data);


                string json = JsonConvert.SerializeObject(result);
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GRAS_PaymentRequestENC", string.Format("Request String = {0}",json));


            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GRAS_PaymentRequest", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("GRAS_PaymentResponse")]
        public IActionResult GRAS_PaymentResponse()
        {
            try
            {
                string ENCDATA = Request.Form["ENCDATA"];
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GRAS_PaymentResponse", "Redirect Success");
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.GRAS_PaymentResponse", ex.ToString());
            }
           return Redirect("http://172.22.33.75:81/paymentsuccess/1235480");
        }
        #endregion

        [HttpGet("GetOfflinePaymentDetails/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetOfflinePaymentDetails(int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.GetOfflinePaymentDetails(CollegeID));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetOfflinePaymentDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
    }
}
