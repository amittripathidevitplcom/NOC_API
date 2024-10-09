using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/DentalChairMGOneNOC")]
    [ApiController]
    public class DentalChairMGOneNOCController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DentalChairMGOneNOCController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("SaveDentalChairs")]
        public async Task<OperationResult<bool>> SaveDentalChairs(DentalChairsMGOneNOCModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DentalChairsMGOneNOC.SaveDentalChairs(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "SaveDentalChairs", request.ApplyNocID, "DentalChairMGOneNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DentalChairMGOneNOC.SaveDentalChairs", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDentalChairs/{ApplyNOCID}/{CollegeId}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDentalChairs(int ApplyNOCID, int CollegeId)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetDentalChairs", 0, "DentalChairMGOneNOC");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DentalChairsMGOneNOC.GetDentalChairsById(ApplyNOCID, CollegeId));
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
                CommonDataAccessHelper.Insert_ErrorLog("DentalChairMGOneNOC.GetDentalChairs", ex.ToString());
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
