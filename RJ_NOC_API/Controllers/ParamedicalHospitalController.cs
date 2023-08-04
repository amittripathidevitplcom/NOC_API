using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Azure.Core;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/ParamedicalHospital")]
    [ApiController]
    public class ParamedicalHospitalController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ParamedicalHospitalController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetHospitalAreaValidation")]
        public async Task<OperationResult<List<HospitalAreaValidation>>> GetHospitalAreaValidation()
        {
            var result = new OperationResult<List<HospitalAreaValidation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.GetHospitalAreaValidation());
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
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.GetHospitalAreaValidation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] ParamedicalHospitalDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ParamedicalHospitalUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.HospitalID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", 0, "HospitalMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Update", 0, "HospitalMaster");
                        result.SuccessMessage = "Updateed successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.HospitalID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ParamedicalHospitalController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

    }
}

