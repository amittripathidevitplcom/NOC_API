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
    [Route("api/SocietyMaster")]
    [ApiController]
    public class SocietyMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public SocietyMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetSocietyList")]
        public async Task<OperationResult<bool>> GetSocietyList([FromQuery] int id)
        {
            var result = new OperationResult<bool>();

            //try
            //{
            //    SocietyMasterDataModel request = Newtonsoft.Json.JsonConvert.DeserializeObject<SocietyMasterDataModel>(json);
            //    result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.SaveData(request));
            //    if (result.Data)
            //    {
            //        result.State = OperationState.Success;
            //        if (request.SocietyID == 0)
            //        {
            //            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "SocietyMaster");
            //            result.SuccessMessage = "Saved successfully .!";
            //        }
            //    }
            //    else
            //    {
            //        result.State = OperationState.Error;
            //        if (request.SocietyID == 0)
            //            result.ErrorMessage = "There was an error adding data.!";
            //        else
            //            result.ErrorMessage = "There was an error updating data.!";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.SaveData", ex.ToString());
            //    result.State = OperationState.Error;
            //    result.ErrorMessage = ex.Message.ToString();

            //}
            return result;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromForm] IFormFile file, [FromForm] string json)
        {
            var result = new OperationResult<bool>();

            //try
            //{
            //    SocietyMasterDataModel request = Newtonsoft.Json.JsonConvert.DeserializeObject<SocietyMasterDataModel>(json);
            //    result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.SaveData(request));
            //    if (result.Data)
            //    {
            //        result.State = OperationState.Success;
            //        if (request.SocietyID == 0)
            //        {
            //            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "SocietyMaster");
            //            result.SuccessMessage = "Saved successfully .!";
            //        }
            //    }
            //    else
            //    {
            //        result.State = OperationState.Error;
            //        if (request.SocietyID == 0)
            //            result.ErrorMessage = "There was an error adding data.!";
            //        else
            //            result.ErrorMessage = "There was an error updating data.!";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.SaveData", ex.ToString());
            //    result.State = OperationState.Error;
            //    result.ErrorMessage = ex.Message.ToString();

            //}
            return result;
        }
        
        [HttpDelete("DeleteData")]
        public async Task<OperationResult<bool>> DeleteData([FromBody]int id)
        {
            var result = new OperationResult<bool>();

            //try
            //{
            //    SocietyMasterDataModel request = Newtonsoft.Json.JsonConvert.DeserializeObject<SocietyMasterDataModel>(json);
            //    result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.SaveData(request));
            //    if (result.Data)
            //    {
            //        result.State = OperationState.Success;
            //        if (request.SocietyID == 0)
            //        {
            //            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "SocietyMaster");
            //            result.SuccessMessage = "Saved successfully .!";
            //        }
            //    }
            //    else
            //    {
            //        result.State = OperationState.Error;
            //        if (request.SocietyID == 0)
            //            result.ErrorMessage = "There was an error adding data.!";
            //        else
            //            result.ErrorMessage = "There was an error updating data.!";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.SaveData", ex.ToString());
            //    result.State = OperationState.Error;
            //    result.ErrorMessage = ex.Message.ToString();

            //}
            return result;
        }

    }
}

