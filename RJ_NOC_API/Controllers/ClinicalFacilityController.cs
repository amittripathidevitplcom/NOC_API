using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ClinicalFacility")]
    [ApiController]
    public class ClinicalFacilityController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ClinicalFacilityController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetAllClinicalFacilityList/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllClinicalFacilityList(int UserID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllClinicalFacilityList", 0, "ClinicalFacility");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AddCourseMasterUtility.GetAllCourseList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ClinicalFacility.GetAllClinicalFacilityList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(ClinicalFacilityModel clinicalFacility)
        {
            var result = new OperationResult<bool>();

            try
            {

                bool IfExits = false;
                IfExits = UtilityHelper.BuildingDetailsMasterUtility.IfExists(clinicalFacility.SchoolBuildingDetailsID, buildingdetails.OwnerName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.BuildingDetailsMasterUtility.SaveData(buildingdetails));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (buildingdetails.SchoolBuildingDetailsID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(buildingdetails.SchoolBuildingDetailsID, "Save", 0, "BuildingDetailsMasterService");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(buildingdetails.SchoolBuildingDetailsID, "Update", buildingdetails.SchoolBuildingDetailsID, "BuildingDetailsMasterService");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (buildingdetails.SchoolBuildingDetailsID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = buildingdetails.OwnerName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("BuildingDetailsMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Delete/{SchoolBuildingDetailsID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int SchoolBuildingDetailsID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.BuildingDetailsMasterUtility.DeleteData(SchoolBuildingDetailsID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", SchoolBuildingDetailsID, "BuildingDetailsMasterService");
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
                CommonDataAccessHelper.Insert_ErrorLog("BuildingDetailsMasterController.DeleteData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("StatusUpdate/{SchoolBuildingDetailsID}/{ActiveStatus}/{UserID}")]
        public async Task<OperationResult<bool>> StatusUpdate(int SchoolBuildingDetailsID, bool ActiveStatus, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.BuildingDetailsMasterUtility.StatusUpdate(SchoolBuildingDetailsID, ActiveStatus));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "StatusUpdate", SchoolBuildingDetailsID, "BuildingDetailsMasterService");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Update successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error Updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("BuildingDetailsMasterController.StatusUpdate", e.ToString());
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
