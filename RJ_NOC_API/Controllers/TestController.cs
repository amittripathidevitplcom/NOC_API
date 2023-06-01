using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_API.AuthModels;

namespace RJ_NOC_API.Controllers
{
    [CustomeAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Test()  
        {
            return "success";
        }
    }
}
