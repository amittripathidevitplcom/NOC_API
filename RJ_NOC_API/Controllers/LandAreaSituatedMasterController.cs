using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/LandAreaSituatedMaster")]
    [ApiController]
    public class LandAreaSituatedMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public LandAreaSituatedMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetStateList")]
        public async Task<OperationResult<List<LandAreaSituatedModel_StateList>>> GetStateList()
        {
            var result = new OperationResult<List<LandAreaSituatedModel_StateList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandAreaSituatedMasterUtility.GetStateList());
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
                CommonDataAccessHelper.Insert_ErrorLog("LandAreaSituatedMasterController.GetStateList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDistrictList")]
        public async Task<OperationResult<List<LandAreaSituated_DistrictList>>> GetDistrictList()
        {
            var result = new OperationResult<List<LandAreaSituated_DistrictList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandAreaSituatedMasterUtility.GetDistrictList());
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
                CommonDataAccessHelper.Insert_ErrorLog("LandAreaSituatedMasterController.GetDistrictList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllLandAreaSituatedList/{UserID}/{DepartmentID}")]
        public async Task<OperationResult<List<LandAreaSituatedMasterDataModel_list>>> GetAllLandAreaSituatedList(int UserID,int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "LandAreaSituatedMaster");
            var result = new OperationResult<List<LandAreaSituatedMasterDataModel_list>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandAreaSituatedMasterUtility.GetAllLandAreaSituatedList(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LandAreaSituatedMasterController.GetAllLandAreaSituatedList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{LandAreaID}/{UserID}")]
        public async Task<OperationResult<List<LandAreaSituatedMasterDataModel>>> GetLandAreaSituatedIDWise(int LandAreaID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", LandAreaID, "LandAreaSituatedMaster");
            var result = new OperationResult<List<LandAreaSituatedMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandAreaSituatedMasterUtility.GetLandAreaSituatedIDWise(LandAreaID));
                if (result.Data.Count > 0)
                {

                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LandAreaSituatedMasterController.GetLandAreaSituatedIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost]
        public async Task<OperationResult<bool>> SaveData(LandAreaSituatedMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.LandAreaSituatedMasterUtility.IfExists(request.LandAreaID, request.LandAreaName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.LandAreaSituatedMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.LandAreaID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.LandAreaID, "Save", 0, "LandAreaSituatedMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.LandAreaID, "Update", request.LandAreaID, "LandAreaSituatedMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.LandAreaID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.LandAreaName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LandAreaSituatedMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{LandAreaID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int LandAreaID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandAreaSituatedMasterUtility.DeleteData(LandAreaID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", LandAreaID, "LandAreaSituatedMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("LandAreaSituatedMasterController.DeleteData", e.ToString());
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
