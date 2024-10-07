using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RJ_NOC_API.Controllers
{
    [Route("api/[MGOneNOC]")]
    [ApiController]
    public class MGOneNOCController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public MGOneNOCController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
    }
}
