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
using FIH_EPR_DataAccess.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RJ_NOC_API.Controllers
{
    [Route("api/UserMaster")]
    [ApiController]
    public class UserMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public UserMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login/{LoginID}/{Password}")]
        public async Task<OperationResult<List<UserMasterDataModel>>> Login(string LoginID, string Password)
        {
            var result = new OperationResult<List<UserMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UserMasterUtility.Login(LoginID, Password));
                if (result.Data.Count > 0)
                {
                    result.Data[0].Token = await CreateAuthentication(new UserMasterDataModel
                    {
                        UserID = result.Data[0].UserID,
                        UserName = result.Data[0].UserName
                    });
                    HttpContext.Session.SetString("jwttoken", result.Data[0].Token);
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
                CommonDataAccessHelper.Insert_ErrorLog("UserMasterController.UserMaster", e.ToString());
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

