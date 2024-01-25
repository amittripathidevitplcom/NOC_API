using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{

    [Route("api/UserManualDocumentMaster")]
    [ApiController]
    public class UserManualDocumentMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;

        public UserManualDocumentMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetUserManualDocumentMasterList/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<UserManualDocumentMasterDataModel_List>>> GetUserManualDocumentMasterList(int DepartmentID,string Type)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "UserManualDocumentMaster");
            var result = new OperationResult<List<UserManualDocumentMasterDataModel_List>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UserManualDocumentMasterUtility.GetUserManualDocumentMasterList(DepartmentID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("UserManualDocumentMasterController.GetUserManualDocumentMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("{ID}")]
        public async Task<OperationResult<List<UserManualDocumentMasterDataModel>>> GetUserManualDocumentMasterIDWise(int ID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", ID, "UserManualDocumentMaster");
            var result = new OperationResult<List<UserManualDocumentMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UserManualDocumentMasterUtility.GetUserManualDocumentMasterIDWise(ID));
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
                CommonDataAccessHelper.Insert_ErrorLog("UserManualDocumentMasterController.GetUserManualDocumentMasterIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(UserManualDocumentMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UserManualDocumentMasterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.ID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "UserManualDocumentMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.ID, "UserManualDocumentMaster");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.ID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("UserManualDocumentMaster.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{ID}")]
        public async Task<OperationResult<bool>> DeleteData(int ID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UserManualDocumentMasterUtility.DeleteData(ID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", ID, "UserManualDocumentMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("UserManualDocumentMasterController.DeleteData", e.ToString());
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
