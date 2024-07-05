using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/PaymentReport")]
    [ApiController]
    public class PaymentReportController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public PaymentReportController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("GetPaymentReport/{FromDate}/{ToDate}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPaymentReport(string FromDate, string ToDate,int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.PaymentReportUtility.GetPaymentReport(FromDate, ToDate, DepartmentID));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("PaymentReportController.GetPaymentReport", ex.ToString());
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
