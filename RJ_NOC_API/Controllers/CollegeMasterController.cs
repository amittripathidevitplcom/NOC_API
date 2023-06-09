using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/CollegeMaster")]
    [ApiController]
    public class CollegeMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public CollegeMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromForm] IFormFile file, [FromForm] string json)
        {
            var result = new OperationResult<bool>();

            try
            {
                CollegeMasterDataModel request = Newtonsoft.Json.JsonConvert.DeserializeObject<CollegeMasterDataModel>(json);
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.CollegeID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "CollegeMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.CollegeID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

    }
}

