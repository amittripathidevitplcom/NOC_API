using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using System.Net;

namespace RJ_NOC_API.Controllers
{
    [Route("api/AadharService")]
    [ApiController]
    public class AadharServiceController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public AadharServiceController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SendAdharOTP")]
        public CommonDataModel_DataTable SendAdharOTP(CommonDataModel_AadharDataModel Model)
        {
            return UtilityHelper.AadharServiceUtility.SendOtpByAadharNo(Model, _configuration);

        }
    }
}