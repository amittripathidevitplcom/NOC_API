using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;

namespace RJ_NOC_API.Controllers
{
    [Route("api/StaffDetail")]
    [ApiController]
    public class StaffDetailController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public StaffDetailController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(StaffDetailDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.StaffDetailUtility.IfExistsPrincipal(request.CollegeID,request.RoleID);
                if (IfExits == false)
                {
                    result.Data= await Task.Run(() => UtilityHelper.StaffDetailUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StaffDetailID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StaffDetailID, "Save", 0, "LegalEntity");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StaffDetailID, "Update", request.StaffDetailID, "LegalEntity");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StaffDetailID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage ="Principal is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StaffDetailController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetStaffDetailList_DepartmentCollegeWise/{DepartmentID}/{CollegeID}/{StaffDetailID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<StaffDetailDataModel>>> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int StaffDetailID,int ApplyNOCID)
        {
            var result = new OperationResult<List<StaffDetailDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffDetailUtility.GetStaffDetailList_DepartmentCollegeWise(DepartmentID,CollegeID,StaffDetailID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("StaffDetailController.GetStaffDetailList_DepartmentCollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("DeleteStaffDetail/{StaffDetailID}")]
        public async Task<OperationResult<bool>> DeleteStaffDetail(int StaffDetailID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffDetailUtility.DeleteStaffDetail(StaffDetailID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(StaffDetailID, "DeleteStaffDetail", StaffDetailID, "StaffDetai");
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
                CommonDataAccessHelper.Insert_ErrorLog("StaffDetailController.DeleteStaffDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetStaffDetailListForPDF/{DepartmentID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataSet>>> GetStaffDetailListForPDF(int DepartmentID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetStaffDetailListForPDF", 0, "StaffDetail");
            var result = new OperationResult<List<CommonDataModel_DataSet>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffDetailUtility.GetStaffDetailListForPDF( DepartmentID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LandDetailsController.GetLandDetailsListForPDF", ex.ToString());
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
