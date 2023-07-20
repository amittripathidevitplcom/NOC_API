using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/StreamMaster")]
    [ApiController]
    public class StreamMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public StreamMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllStreamList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "StreamMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StreamMasterUtility.GetAllStreamList());
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
                CommonDataAccessHelper.Insert_ErrorLog("StreamMasterController.GetAllStreamList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{StreamMasterID}/{UserID}")]
        public async Task<OperationResult<List<StreamMasterDataModel>>> GetByID(int StreamMasterID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", StreamMasterID, "StreamMaster");
            var result = new OperationResult<List<StreamMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StreamMasterUtility.GetByID(StreamMasterID));
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
                CommonDataAccessHelper.Insert_ErrorLog("StreamMasterController.GetByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(StreamMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.StreamMasterUtility.IfExists(request.StreamMasterID, request.DepartmentID,request.StreamName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.StreamMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StreamMasterID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StreamMasterID, "Save", 0, "StreamMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StreamMasterID, "Update", request.StreamMasterID, "StreamMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StreamMasterID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.StreamName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StreamMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{StreamMasterID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int StreamMasterID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StreamMasterUtility.DeleteData(StreamMasterID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", StreamMasterID, "StreamMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("StreamMasterController.DeleteData", e.ToString());
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
