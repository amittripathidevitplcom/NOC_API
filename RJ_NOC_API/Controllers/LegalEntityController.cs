using FIH_EPR_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/LegalEntity")]
    [ApiController]
    public class LegalEntityController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public LegalEntityController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(LegalEntityModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                //IfExits = UtilityHelper.ProjectMasterUtility.IfExists(request.ProjectID, request.ProjectName);
                //if (IfExits == false)
                //{
                result.Data = await Task.Run(() => UtilityHelper.LegalEntity.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.EnitityID == 0)
                    {
                        //CommonDataAccessHelper.Insert_TrnUserLog(request.EnitityID, "Save", 0, "ProjectMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        //CommonDataAccessHelper.Insert_TrnUserLog(request.EnitityID, "Update", request.EnitityID, "ProjectMaster");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.EnitityID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
                //}
                //else
                //{
                //    result.State = OperationState.Warning;
                //    result.ErrorMessage = request.ProjectName + " is Already Exist, It Can't Not Be Duplicate.!";
                //}
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ProjectMasterController.SaveData", e.ToString());
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
