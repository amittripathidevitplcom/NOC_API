using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/DefaulterCollegeRequest")]
    [ApiController]
    public class DefaulterCollegeRequestController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DefaulterCollegeRequestController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] DefaulterCollegeRequestDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                if (request.EverAppliedNOC == "Yes")
                {
                    bool IfExits = false;
                    IfExits = UtilityHelper.DefaulterCollegeRequestUtility.IfExists(request.LastApplicationNo, request.LastApplicationSubmittedDate);
                    if (IfExits == true)
                    {
                        result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.SaveData(request));
                        if (result.Data)
                        {
                            result.State = OperationState.Success;
                            if (request.RequestID == 0)
                            {
                                CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.RequestID, "DefaulterCollegeRequest");
                                result.SuccessMessage = "Saved successfully .!";
                            }
                            else
                            {
                                CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.RequestID, "DefaulterCollegeRequest");
                                result.SuccessMessage = "Updated successfully .!";
                            }
                        }
                        else
                        {
                            result.State = OperationState.Error;
                            if (request.RequestID == 0)
                                result.ErrorMessage = "There was an error adding data.!";
                            else
                                result.ErrorMessage = "There was an error updating data.!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Warning;
                        result.ErrorMessage = "this Last Application Number - " + request.LastApplicationNo + " or Submitted Application Date - " + request.LastApplicationSubmittedDate + " data not found.!";
                    }
                }
                else
                {
                    result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.RequestID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.RequestID, "DefaulterCollegeRequest");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.RequestID, "DefaulterCollegeRequest");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.RequestID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DefaulterCollegeRequestController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("GetDefaulterCollegeRequestData")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDefaulterCollegeRequestData(DefaulterCollegeSearchFilterDataModel request)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "GetDefaulterCollegeRequestData", 0, "DefaulterCollegeRequest");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.GetDefaulterCollegeRequestData(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("DefaulterCollegeRequest.GetDefaulterCollegeRequestData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{RequestID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int RequestID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.DeleteData(RequestID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", RequestID, "DefaulterCollegeRequest");
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
                CommonDataAccessHelper.Insert_ErrorLog("DefaulterCollegeRequestController.DeleteData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("SaveDefaulterCollegePenalty")]
        public async Task<OperationResult<bool>> SaveDefaulterCollegePenalty(ApplicationPenaltyDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.SaveDefaulterCollegePenalty(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.ApplyNOCID, "SaveDefaulterCollegePenalty", 0, "ApplyNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save Defaulter College Penalty";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DefaulterCollegeRequestController.SaveDefaulterCollegePenalty", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDefaulterCollegePenalty/{RequestID}/{PenaltyID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDefaulterCollegePenalty(int RequestID, int PenaltyID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.GetDefaulterCollegePenalty(RequestID, PenaltyID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DefaulterCollegeRequestController.GetDefaulterCollegePenalty", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("DeleteDefaulterCollegePenalty/{PenaltyID}")]
        public async Task<OperationResult<bool>> DeleteDefaulterCollegePenalty(int PenaltyID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DefaulterCollegeRequestUtility.DeleteDefaulterCollegePenalty(PenaltyID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "DeleteDefaulterCollegePenalty", PenaltyID, "DefaulterCollegeRequest");
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
                CommonDataAccessHelper.Insert_ErrorLog("DefaulterCollegeRequestController.DeleteDefaulterCollegePenalty", e.ToString());
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
