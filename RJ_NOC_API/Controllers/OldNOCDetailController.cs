using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;

namespace RJ_NOC_API.Controllers
{
    [Route("api/OldNOCDetail")]
    [ApiController]
    public class OldNOCDetailController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public OldNOCDetailController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(OldNocDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits =UtilityHelper.OldNOCDetailUtility.IfExists(request.OldNocID, request.NOCNumber);
                if (IfExits == false)
                {
                    result.Data= await Task.Run(() => UtilityHelper.OldNOCDetailUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.OldNocID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.OldNocID, "Save", 0, "OldNocDetail");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.OldNocID, "Update", request.OldNocID, "OldNocDetail");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.OldNocID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.NOCNumber + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HostelDetailController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetOldNOCDetailList_DepartmentCollegeWise/{DepartmentID}/{CollegeID}/{OldNocID}")]
        public async Task<OperationResult<List<OldNocDetailsDataModel>>> GetOldNOCDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int OldNocID)
        {
            var result = new OperationResult<List<OldNocDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OldNOCDetailUtility.GetOldNOCDetailList_DepartmentCollegeWise(DepartmentID, CollegeID, OldNocID));
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
                CommonDataAccessHelper.Insert_ErrorLog("OldNOCDetailController.GetOldNOCDetailList_DepartmentCollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DeleteOldNocDetail/{OldNocID}")]
        public async Task<OperationResult<bool>> DeleteOldNocDetail(int OldNocID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OldNOCDetailUtility.DeleteOldNocDetail(OldNocID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(OldNocID, "DeleteOldNocDetail", OldNocID, "OldNocDetail");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error deleting data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("OldNocDetailController.DeleteOldNocDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
    }
}
