using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;

namespace RJ_NOC_API.Controllers
{
    [Route("api/HostelDetail")]
    [ApiController]
    public class HostelDetailController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public HostelDetailController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(HostelDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.HostelDetailUtility.IfExists(request.HostelDetailID, request.CollegeID, request.HostelName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.HostelDetailUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.HostelDetailID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.HostelDetailID, "Save", 0, "LegalEntity");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.HostelDetailID, "Update", request.HostelDetailID, "LegalEntity");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.HostelDetailID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.HostelName + " is Already Exist, It Can't Not Be Duplicate.!";
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

        [HttpGet("GetHostelDetailList_DepartmentCollegeWise/{DepartmentID}/{CollegeID}/{HostelDetailID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<HostelDataModel>>> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int HostelDetailID,int ApplyNOCID)
        {
            var result = new OperationResult<List<HostelDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HostelDetailUtility.GetHostelDetailList_DepartmentCollegeWise(DepartmentID, CollegeID, HostelDetailID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("HostelDetailController.GetStaffDetailList_DepartmentCollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DeleteHostelDetail/{HostelDetailID}")]
        public async Task<OperationResult<bool>> DeleteHostelDetail(int HostelDetailID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HostelDetailUtility.DeleteHostelDetail(HostelDetailID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(HostelDetailID, "DeleteHostelDetail", HostelDetailID, "HostelDetail");
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
                CommonDataAccessHelper.Insert_ErrorLog("HostelDetailController.DeleteHostelDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetHostelPdfDetails/{DepartmentID}/{CollageID}")]
        public async Task<OperationResult<List<CommonDataModel_DataSet>>> GetHostelPdfDetails(int DepartmentID, int CollageID)
        {
            var result = new OperationResult<List<CommonDataModel_DataSet>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HostelDetailUtility.GetHostelPdfDetails(DepartmentID, CollageID));
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
                CommonDataAccessHelper.Insert_ErrorLog("HostelController.GetHostelPdfDetails", ex.ToString());
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
