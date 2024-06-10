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
                bool IfExits = false;
                //IfExits = UtilityHelper.DefaulterCollegeRequestUtility.IfExists(request.RNCCheckListID,request.DepartmentID, request.RNCCheckListName);
                //if (IfExits == false)
                //{
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
                //}
                //else
                //{
                //    result.State = OperationState.Warning;
                //    result.ErrorMessage = request.RNCCheckListName + " is Already Exist, It Can't Not Be Duplicate.!";
                //}
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

    }
}
