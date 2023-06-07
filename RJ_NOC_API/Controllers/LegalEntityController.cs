using RJ_NOC_DataAccess.Common;
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
                result.Data = await Task.Run(() => UtilityHelper.LegalEntity.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.LegalEntityID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.LegalEntityID, "Save", 0, "LegalEntity");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.LegalEntityID, "Update", request.LegalEntityID, "LegalEntity");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.LegalEntityID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }

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
