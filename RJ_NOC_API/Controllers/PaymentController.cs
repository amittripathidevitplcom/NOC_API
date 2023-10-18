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




        
    }
}
