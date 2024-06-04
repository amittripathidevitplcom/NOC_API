using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/DuplicateAadharReport")]
    [ApiController]
    public class DuplicateAadharReportController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DuplicateAadharReportController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("GetDuplicateAadhaarReportDatail")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDuplicateAadhaarReportDatail(DuplicateAadharReportDataModel request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DuplicateAadharReportUtility.GetDuplicateAadhaarReportDatail(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("DuplicateAadharReportController.GetDuplicateAadhaarReportDatail", ex.ToString());
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

