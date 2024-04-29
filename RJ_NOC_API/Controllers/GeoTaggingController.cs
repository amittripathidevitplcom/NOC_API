using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using System.Net;
using Microsoft.AspNetCore.Rewrite;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<OperationResult<SSOUserDetailData>> AppLogin(SSOLandingDataDataModel sSOLandingDataDataModel)
        {
            sSOLandingDataDataModel.Password = UtilityHelper.GeoTaggingUtility.DecryptStringAES(sSOLandingDataDataModel.Password);
            var response = new HttpResponseMessage(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("https://www.google.com");
            var result = new OperationResult<SSOUserDetailData>();
            bool IsSSOAuthentication = false;
            try
            {
                IsSSOAuthentication = await UtilityHelper.GeoTaggingUtility.SSOAuthentication(sSOLandingDataDataModel);
                if (IsSSOAuthentication == true)
                {
                    result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.AppLogin(sSOLandingDataDataModel, _configuration));
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
                    result.SuccessMessage = "Please enter valid username or password.!";
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

        [HttpPost("AppCollegeSSOLogin/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> AppCollegeSSOLogin(string LoginSSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "GeoTagging");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
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

        [HttpGet("GetAPPApplicationCollegeList/{LoginSSOID}/{Type}/{ViewType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAPPApplicationCollegeList(string LoginSSOID, string Type, string ViewType)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "GeoTagging");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.GetAPPApplicationCollegeList(LoginSSOID, Type, ViewType));
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
        [HttpGet("GetAPPApplicationCollege_DashboardCount/{LoginSSOID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAPPApplicationCollege_DashboardCount(string LoginSSOID, string Type)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetDashboardCount", 0, "GeoTagging");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.GetAPPApplicationCollege_DashboardCount(LoginSSOID, Type));
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
                        result.SuccessMessage = "Updated successfully .!";
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


        [HttpPost("ReadNotification")]
        public async Task<OperationResult<bool>> ReadNotification(NotificationDataModel request)
        {

            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.ReadNotification(request));
                result.State = OperationState.Success;
                if (result.Data != null)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data Update successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "Error in read notification!";
                }

            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GeoTagging.ReadNotification", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("AppNotificationList/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> AppNotificationList(string LoginSSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "AppNotificationList", 0, "GeoTagging");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.AppNotificationList(LoginSSOID));
                result.State = OperationState.Success;
                if (result.Data[0].data != null)
                {
                    if (result.Data[0].data.Rows.Count > 0)
                    {
                        result.State = OperationState.Success;
                        result.SuccessMessage = "Data Load successfully  .!";
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
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.AppNotificationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveInspectionGeoTagging")]
        public async Task<OperationResult<bool>> SaveInspectionGeoTagging([FromBody] InspectionGeoTaggingDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.SaveInspectionGeoTagging(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(request.GT_CreatedBy, "Save", 0, "SaveInspectionGeoTagging");
                    result.SuccessMessage = "Saved successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.SaveInspectionGeoTagging", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }



        [HttpPost("GetCollegeWiseAllDocumnets/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> AppNotGetCollegeWiseAllDocumnetsificationList(int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "AppNotGetCollegeWiseAllDocumnetsificationList", 0, "GeoTagging");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GeoTaggingUtility.AppNotGetCollegeWiseAllDocumnetsificationList(CollegeID));
                result.State = OperationState.Success;
                if (result.Data[0].data != null)
                {
                    if (result.Data[0].data.Rows.Count > 0)
                    {
                        result.State = OperationState.Success;
                        result.SuccessMessage = "Data Load successfully  .!";
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
                CommonDataAccessHelper.Insert_ErrorLog("GeoTaggingController.AppNotGetCollegeWiseAllDocumnetsificationList", ex.ToString());
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
