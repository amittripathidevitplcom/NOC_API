using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/LOIFeeMaster")]
    [ApiController]
    public class LOIFeeMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public LOIFeeMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllLOIFeeList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllLOIFeeList", 0, "LOIFeeMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LOIFeeMasterUtility.GetAllLOIFeeList());
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
                CommonDataAccessHelper.Insert_ErrorLog("LOIFeeMasterController.GetAllLOIFeeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{FeeID}/{UserID}")]
        public async Task<OperationResult<List<LOIFeeMasterDataModel>>> GetLOIFeeByID(int FeeID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", FeeID, "LOIFeeMaster");
            var result = new OperationResult<List<LOIFeeMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LOIFeeMasterUtility.GetLOIFeeByID(FeeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LOIFeeMasterController.GetLOIFeeByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(LOIFeeMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.LOIFeeMasterUtility.IfExists(request.FeeID, request.DepartmentID,request.FeeType);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.LOIFeeMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.FeeID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.FeeID, "LOIFeeMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.FeeID, "LOIFeeMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.FeeID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.FeeType + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LOIFeeMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{FeeID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int FeeID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LOIFeeMasterUtility.DeleteData(FeeID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", FeeID, "LOIFeeMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("LOIFeeMasterController.DeleteData", e.ToString());
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
