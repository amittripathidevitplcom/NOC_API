using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/AnimalMaster")]
    [ApiController]
    public class AnimalMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public AnimalMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllAnimalList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "AnimalMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalMasterUtility.GetAllAnimalList());
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalMasterController.GetAllAnimalList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{AnimalMasterID}/{UserID}")]
        public async Task<OperationResult<List<AnimalMasterDataModel>>> GetByID(int AnimalMasterID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", AnimalMasterID, "AnimalMaster");
            var result = new OperationResult<List<AnimalMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalMasterUtility.GetByID(AnimalMasterID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalMasterController.GetByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(AnimalMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.AnimalMasterUtility.IfExists(request.AnimalMasterID, request.DepartmentID,request.AnimalName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.AnimalMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.AnimalMasterID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.AnimalMasterID, "AnimalMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.AnimalMasterID, "AnimalMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.AnimalMasterID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.AnimalName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{AnimalMasterID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int AnimalMasterID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalMasterUtility.DeleteData(AnimalMasterID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", AnimalMasterID, "AnimalMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalMasterController.DeleteData", e.ToString());
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
