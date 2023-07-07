using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using System.Net;
using Microsoft.AspNetCore.Rewrite;

namespace RJ_NOC_API.Controllers
{
    [Route("api/GeoTagging")]
    [ApiController]
    public class GeoTaggingController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public GeoTaggingController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("GetSSOUserLogionDetails")]
        public async Task<OperationResult<SSOUserDetailData>> GetSSOUserLogionDetails([FromBody] SSOLandingDataDataModel sSOLandingDataDataModel)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("https://www.google.com");
            string SSOID = CommonHelper.Decrypt(sSOLandingDataDataModel.Username);
            string LoginType = CommonHelper.Decrypt(sSOLandingDataDataModel.LoginType);

            string QueryStringData = "";
            var result = new OperationResult<SSOUserDetailData>();
            try
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



        //[HttpPost("AppCollegeSSOLogin/{LoginSSOID}")]
        //public async Task<OperationResult<List<GeoTaggingDataModels>>> AppCollegeSSOLogin(string LoginSSOID)
        //{
        //    var result = new OperationResult<List<GeoTaggingDataModels>>();
        //    try
        //    {
        //        result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.AppCollegeSSOLogin(LoginSSOID));
        //        if (result.Data.Count > 0)
        //        {
        //            //result.Data[0].Token = await CreateGeoTaggingAuthentication(new GeoTaggingDataModels
        //            //{
        //            //    UserID = result.Data[0].UserID,
        //            //    UserName = result.Data[0].UserName
        //            //});
        //            //HttpContext.Session.SetString("jwttoken", result.Data[0].Token);
        //            result.State = OperationState.Success;
        //            result.SuccessMessage = "Login successfully .!";
        //        }
        //        else
        //        {
        //            result.State = OperationState.Error;
        //            result.ErrorMessage = "SSO ID not registered, Please enter valid  SSO ID.!";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.GeoTagging", e.ToString());
        //        result.State = OperationState.Error;
        //        result.ErrorMessage = e.Message.ToString();
        //    }
        //    finally
        //    {
        //        //UnitOfWork.Dispose();
        //    }
        //    return result;
        //}
        [HttpPost("AppCollegeSSOLogin/{LoginSSOID}")]
        public async Task<OperationResult<List<GeoTaggingDataModels>>> AppCollegeSSOLogin(string LoginSSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "GeoTagging");
            var result = new OperationResult<List<GeoTaggingDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.AppCollegeSSOLogin(LoginSSOID));
                result.State = OperationState.Success;                
                if (result.Data[0].data != null)
                {
                    if (result.Data[0].data.Rows.Count > 0)
                    {
                        result.State = OperationState.Success;
                        result.SuccessMessage = "Login successfully  .!";
                    }
                    else
                    {
                        result.State = OperationState.Warning;
                        result.SuccessMessage = "SSO ID not registered, Please enter valid  SSO ID.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.AppCollegeSSOLogin", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAPPApplicationCollegeList/{LoginSSOID}/{Type}")]
        public async Task<OperationResult<List<GeoTaggingDataModels>>> GetAPPApplicationCollegeList(string LoginSSOID, string Type)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "GeoTagging");
            var result = new OperationResult<List<GeoTaggingDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.GetAPPApplicationCollegeList(LoginSSOID, Type));
                result.State = OperationState.Success;
                if (result.Data[0].data != null)
                {
                    if (result.Data[0].data.Rows.Count > 0)
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
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.GetAPPApplicationCollegeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAPPApplicationCollege_DashboardCount/{LoginSSOID}")]
        public async Task<OperationResult<List<GeoTaggingDataModels>>> GetAPPApplicationCollege_DashboardCount(string LoginSSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetDashboardCount", 0, "GeoTagging");
            var result = new OperationResult<List<GeoTaggingDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.GetAPPApplicationCollege_DashboardCount(LoginSSOID));
                result.State = OperationState.Success;
                if (result.Data[0].data != null)
                {
                    if (result.Data[0].data.Rows.Count > 0)
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
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.GetAPPApplicationCollege_DashboardCount", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] GeoTaggingDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.CollegeID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", 0, "GeoTagging");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Update", 0, "GeoTagging");
                        result.SuccessMessage = "Updateed successfully .!";
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
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }
    }
}
