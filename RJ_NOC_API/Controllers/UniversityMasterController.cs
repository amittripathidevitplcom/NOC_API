using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/UniversityMaster")]
    [ApiController]
    public class UniversityMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public UniversityMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<UniversityasterDataModel_list>>> GetAllUniversityList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "UiversityMaster");
            var result = new OperationResult<List<UniversityasterDataModel_list>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UniversityMasterUtility.GetAllUniversityList());
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
                CommonDataAccessHelper.Insert_ErrorLog("UniversityMasterController.GetAllUniversityList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{UniversityID}/{UserID}")]
        public async Task<OperationResult<List<UniversityasterDataModel>>> GetUniversityIDWise(int UniversityID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", UniversityID, "UiversityMaster");
            var result = new OperationResult<List<UniversityasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UniversityMasterUtility.GetUniversityIDWise(UniversityID));
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
                CommonDataAccessHelper.Insert_ErrorLog("UniversityMasterController.GetUniversityIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(UniversityasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.UniversityMasterUtility.IfExists(request.UniversityID, request.UniversityName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.UniversityMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.UniversityID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UniversityID, "Save", 0, "UiversityMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UniversityID, "Update", request.UniversityID, "UiversityMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.UniversityID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.UniversityName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("UniversityMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{UniversityID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int UniversityID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UniversityMasterUtility.DeleteData(UniversityID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", UniversityID, "UiversityMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("UniversityMasterController.DeleteData", e.ToString());
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
