using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using Azure.Core;
using Newtonsoft.Json;
using System.Data;

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
            var result = new OperationResult<PaymentRequest>();
            Random rnd = new Random();
            string PRN = "PRN" + rnd.Next(100000, 999999);
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentUtility.SendRequest(PRN, request.AMOUNT, request.PURPOSE, request.USERNAME, request.USERMOBILE, request.USEREMAIL, request.ApplyNocApplicationID));
                if (result.Data!=null)
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
            catch (Exception e)
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
        public IActionResult  PaymentResponse()
        {
            string STATUS = Request.Form["STATUS"];
            string ENCDATA = Request.Form["ENCDATA"];
            var result = new OperationResult<PaymentResponse>();
            try
            {
                result.Data = UtilityHelper.PaymentUtility.GetResponse(STATUS, ENCDATA);
                result.State = OperationState.Success;
                if (result.Data != null)
                {

                    if (UtilityHelper.PaymentUtility.SaveData(result.Data))
                    {
                        if (result.Data.CHECKSUMVALID)
                        {

                            if (result.Data.RESPONSEPARAMETERS.STATUS.ToLower() == "Success".ToLower())
                            {
                                result.State = OperationState.Success;
                                result.SuccessMessage = "Data load successfully .!";
                                return Redirect(string.Format("http://localhost:4200/paymentsuccess/{0}", result.Data.RESPONSEPARAMETERS.PRN));
                            }
                            else
                            {
                                return Redirect(string.Format("http://localhost:4200/paymentfailed/{0}", result.Data.RESPONSEPARAMETERS.PRN));
                            }
                        }
                        else
                        {
                            return Redirect(string.Format("http://localhost:4200/paymentfailed/{0}", result.Data.RESPONSEPARAMETERS.PRN));
                        }
                    }
                   
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("PaymentController.PaymentResponse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return Redirect("http://localhost:4200/paymentsuccess");

            //return result;
        }





        [HttpGet("GetTransactionDetails/{TransID}")]
        public async Task<OperationResult<List<ResponseParameters>>> GetTransactionDetails(int TransID)
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
            catch (Exception ex)
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

    }
}
