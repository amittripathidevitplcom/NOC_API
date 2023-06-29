using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/FacilitiesMaser")]
    [ApiController]
    public class FacilitiesMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public FacilitiesMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<FacilitiesMasterDataModel_list>>> GetAllFacilitiesList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "FacilitiesMaser");
            var result = new OperationResult<List<FacilitiesMasterDataModel_list>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FacilitiesMasterUtility.GetAllFacilitiesList());
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
                CommonDataAccessHelper.Insert_ErrorLog("FacilitiesMasterController.GetAllFacilitiesList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{FID}/{UserID}")]
        public async Task<OperationResult<List<FacilitiesMasterDataModel>>> GetFacilitiesIDWise(int FID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", FID, "FacilitiesMaser");
            var result = new OperationResult<List<FacilitiesMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FacilitiesMasterUtility.GetFacilitiesIDWise(FID));
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
                CommonDataAccessHelper.Insert_ErrorLog("FacilitiesMasterController.GetFacilitiesIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(FacilitiesMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.FacilitiesMasterUtility.IfExists(request.FID, request.FacilitiesName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.FacilitiesMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.FID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.FID, "Save", 0, "FacilitiesMaser");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.FID, "Update", request.FID, "FacilitiesMaser");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.FID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.FacilitiesName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("FacilitiesMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{FID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int FID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FacilitiesMasterUtility.DeleteData(FID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", FID, "FacilitiesMaser");
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
                CommonDataAccessHelper.Insert_ErrorLog("FacilitiesMasterController.DeleteData", e.ToString());
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
