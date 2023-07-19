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

        [HttpPost("PaymentRequest")]
        public async Task<OperationResult<PaymentRequest>> PaymentRequest(RequestDetails request)
        {

            PaymentGatewayDataModel Model = new PaymentGatewayDataModel();
            Model.PaymentGateway = (int)enmPaymentGatway.RPP;
            var data = UtilityHelper.PaymentUtility.GetpaymentGatewayDetails(Model);

            var result = new OperationResult<PaymentRequest>();
            Random rnd = new Random();
            string PRN = "PRN" + rnd.Next(100000, 999999);
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.SendRequest(PRN, request.AMOUNT, request.PURPOSE, request.USERNAME, request.USERMOBILE, request.USEREMAIL, request.ApplyNocApplicationID, data));
                if (result.Data != null)
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
        public IActionResult PaymentResponse()
        {
            PaymentGatewayDataModel Model = new PaymentGatewayDataModel();
            Model.PaymentGateway = (int)enmPaymentGatway.RPP;
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



        [HttpPost("EmitraPayment")]
        public async Task<EmitraRequestDetails> EmitraPayment(EmitraRequestDetails Model)
        {
            try
            {
                var EmitraServiceDetail = UtilityHelper.PaymentUtility.GetEmitraServiceDetails(Model);
                EmitraTransactions objEmitra = new EmitraTransactions();
                objEmitra.key = "InsertDetails";
                var result = UtilityHelper.PaymentUtility.CreateAddEmitraTransation(objEmitra);
                PGRequest data = new PGRequest();
                if (result.TransactionId > 0)
                {

                    data.MERCHANTCODE = EmitraServiceDetail.MERCHANTCODE;
                    //data.PRN = "NOC" + result.TransactionId;

                    Random rnd = new Random();
                    data.PRN = "PRN" + rnd.Next(100000, 999999) + rnd.Next(100000, 999999);

                    data.REQTIMESTAMP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    data.AMOUNT = Convert.ToString(Model.Amount);
                    data.SUCCESSURL = EmitraServiceDetail.REDIRECTURL + "?UniquerequestId=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(result.TransactionId)) + "&ApplicationIdEnc=" + PaymentEncriptionDec.EmitraEncrypt(Model.NocApplicationIdEnc) + "&ServiceID=" + Model.ServiceID + "&IsFailed=" + PaymentEncriptionDec.EmitraEncrypt("NO");
                    data.FAILUREURL = EmitraServiceDetail.REDIRECTURL + "?UniquerequestId=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(result.TransactionId)) + "&ApplicationIdEnc=" + PaymentEncriptionDec.EmitraEncrypt(Model.NocApplicationIdEnc) + "&ServiceID=" + Model.ServiceID + "&IsFailed=" + PaymentEncriptionDec.EmitraEncrypt("YES");
                    data.USERNAME = Model.UserName; ;
                    data.USERMOBILE = Model.MobileNo;
                    data.COMMTYPE = EmitraServiceDetail.COMMTYPE;
                    data.OFFICECODE = EmitraServiceDetail.OFFICECODE;
                    data.REVENUEHEAD = EmitraServiceDetail.REVENUEHEAD.Replace("##", Model.Amount.ToString());
                    data.SERVICEID = EmitraServiceDetail.SERVICEID;
                    data.UDF1 = Model.RegistrationNo;
                    data.UDF2 = Model.SsoID;
                    data.USEREMAIL = "";
                    data.CHECKSUM = PaymentEncriptionDec.CreateMD5(data.PRN + "|" + data.AMOUNT + "|" + EmitraServiceDetail.CHECKSUMKEY);
                    data.commissionAmount = "0";
                    // data.ServiceURL = EmitraServiceDetail.ServiceURL;
                    //string datad=  "?strdata=" + JsonConvert.SerializeObject(data) + "&enckey=" + EmitraServiceDetail.EncryptionKey;

                    EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration endpointConfiguration = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration();
                    EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient emitraencsev = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient(endpointConfiguration, EmitraServiceDetail.WebServiceURL);
                    EmitraEncryptStringResponse response = await emitraencsev.EmitraEncryptStringAsync(EmitraServiceDetail.EncryptionKey, JsonConvert.SerializeObject(data));

                    Model.ENCDATA = response.Body.EmitraEncryptStringResult;
                    Model.MERCHANTCODE = EmitraServiceDetail.MERCHANTCODE;
                    Model.PaymentRequestURL = EmitraServiceDetail.ServiceURL;
                    Model.ServiceID = EmitraServiceDetail.SERVICEID;
                }
            }
            catch (System.Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.EmitraPayment", ex.ToString());
            }
            finally
            {
                // UnitOfWork.Dispose();
            }

            return Model;
        }


        [HttpGet("GetPreviewPaymentDetails/{ApplyNocApplicationID}")]
        public async Task<OperationResult<List<ResponseParameters>>> GetPreviewPaymentDetails(int ApplyNocApplicationID)
        {
            var result = new OperationResult<List<ResponseParameters>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.GetPreviewPaymentDetails(ApplyNocApplicationID));
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
        public async Task<ActionResult> EmitraPaymentResponse(string UniquerequestId = "", string ApplicationIdEnc = "", string IsFailed = "")
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

            //ServiceID = ServiceID.Replace(' ', '+');
            //ServiceID = ServiceID.Replace(' ', '+');
            //ServiceID = ServiceID.Replace(' ', '+');


            var data = Convert.ToString(Request.Form["encData"]);
            var RetrunUrL = "";
            var vIsFailed = PaymentEncriptionDec.EmitraDecrypt(IsFailed);

            EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration endpointConfiguration = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient.EndpointConfiguration();
            EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient emitraencsev = new EmitraEmitraEncrytDecryptClient.EmitraEncrytDecryptSoapClient(endpointConfiguration, "https://localhost:44319/EmitraEncrytDecrypt.asmx");
            EmitraDecriptStringResponse response = await emitraencsev.EmitraDecriptStringAsync("EmitraNew@2016", data);

            var Data = JsonConvert.DeserializeObject<EmitraResponseParameters>(response.Body.EmitraDecriptStringResult);

            if (vIsFailed == "NO")
            {
                RetrunUrL = "http://localhost:4200/emitrapaymentsuccess";
            }
            else
            {
                RetrunUrL = "http://localhost:4200/emitrapaymentfail";
            }
            //return response;
            return new RedirectResult(RetrunUrL);
        }
    }
}
