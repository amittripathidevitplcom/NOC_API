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
    [Route("api/HospitalMaster")]
    [ApiController]
    public class HospitalMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public HospitalMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetHospitalAreaValidation")]
        public async Task<OperationResult<List<HospitalAreaValidation>>> GetHospitalAreaValidation()
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "ProjectMaster");
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

    }
}

