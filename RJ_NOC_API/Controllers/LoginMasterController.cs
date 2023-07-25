using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Cors;
using RJ_NOC_DataAccess;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_API.Controllers
{
    [Route("api/LoginMaster")]
    [ApiController]
    public class LoginMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public LoginMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login/{UserName}/{Password}")]
        public async Task<OperationResult<List<LoginMasterDataModel>>> Login(string UserName, string Password)
        {
            var result = new OperationResult<List<LoginMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LoginMasterUtility.Login(UserName, Password));
                if (result.Data.Count > 0)
                {
                    //result.Data[0].Token = await CreateAuthentication(new LoginMasterDataModel
                    //{
                    //    UserID = result.Data[0].UserID,
                    //    UserName = result.Data[0].UserName
                    //});
                    //HttpContext.Session.SetString("jwttoken", result.Data[0].Token);
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LoginMasterController.LoginMaster", e.ToString());
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

