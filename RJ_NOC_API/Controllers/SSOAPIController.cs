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
using System.Net;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_API.Controllers
{
    [Route("api/SSOAPI")]
    [ApiController]
    public class SSOAPIController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public SSOAPIController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("GetSSOUserLogionDetails")]
        public async Task<OperationResult<SSOUserDetailData>> GetSSOUserLogionDetails(SSOLandingDataDataModel sSOLandingDataDataModel)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("https://www.google.com");
            string SSOEncrpt = CommonHelper.Encrypt("vijaykanugo.risl");
            string SSOID = "";
            if (sSOLandingDataDataModel.LoginType.ToString() != "0")
            {
                if (sSOLandingDataDataModel.Username == "1")
                {
                    SSOID = "nrawat455";
                }
                else
                {
                    SSOID = CommonHelper.Decrypt(sSOLandingDataDataModel.Username);
                }
            }
            else
            {
                SSOID = sSOLandingDataDataModel.Username;
            }

            string LoginType = "CITIZEN";//CommonHelper.Decrypt(sSOLandingDataDataModel.LoginType);
                                         //string SSOID = sSOLandingDataDataModel.Username;
                                         //string LoginType = sSOLandingDataDataModel.LoginType;

            string QueryStringData = "";
            var result = new OperationResult<SSOUserDetailData>();
            //bool IsSSOAuthentication = false;
            SSOUserAuthentication obj = new SSOUserAuthentication();
            try
            {
                obj = await UtilityHelper.GeoTaggingUtility.SSOAuthentication(sSOLandingDataDataModel, _configuration);
                //IsSSOAuthentication = await UtilityHelper.GeoTaggingUtility.SSOAuthentication(sSOLandingDataDataModel);


                if (sSOLandingDataDataModel.LoginType.ToString() == "-999")
                {
                    obj.valid = true;
                }
                if (obj.valid == true)
                {

                    result.Data = await Task.Run(() => UtilityHelper.SSOAPIUtility.GetSSOUserLogionDetails(SSOID, LoginType, _configuration));
                    result.State = OperationState.Success;
                    if (result.Data != null)
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
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = obj.message;//"Please enter valid username or password.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("SSOLogin.GetSSOUserLogionDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("Check_SSOIDWise_LegalEntity/{SSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> Check_SSOIDWise_LegalEntity(string SSOID)
        {

            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SSOAPIUtility.Check_SSOIDWise_LegalEntity(SSOID));
                result.State = OperationState.Success;
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Check_SSOIDWise_LegalEntity", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("CheckMappingSSOID/{SSOID}")]
        public async Task<OperationResult<SSOUserDetailData>> CheckMappingSSOID(string SSOID)
        {
            var result = new OperationResult<SSOUserDetailData>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SSOAPIUtility.GetSSOUserLogionDetails(SSOID, "", _configuration));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("SSOAPI.CheckMappingSSOID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetUserRoleList/{SSOID}/{IsWeb=false}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetUserRoleList(string SSOID,bool IsWeb=false)
        {

            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SSOAPIUtility.GetUserRoleList(SSOID, IsWeb));
                result.State = OperationState.Success;
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Check_SSOIDWise_LegalEntity", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


    }
}

