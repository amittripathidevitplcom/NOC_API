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
    [Route("api/CollegeMaster")]
    [ApiController]
    public class CollegeMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public CollegeMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetData/{CollegeId}")]
        public async Task<OperationResult<CollegeMasterDataModel>> GetData(int collegeId)
        {
            var result = new OperationResult<CollegeMasterDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.GetCollegeById(collegeId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.GetData", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData([FromBody] CollegeMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.CollegeMasterUtility.IfExists(request.DepartmentID,request.CollegeID,request.MobileNumber,request.Email);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.CollegeID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", 0, "CollegeMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Update", 0, "CollegeMaster");
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
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "this mobile No - "+ request.MobileNumber+" or Email - "+request.Email+ " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("DraftApplicationList/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> DraftApplicationList(string LoginSSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.DraftApplicationList(LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.DraftApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("StatisticsCollegeList/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> StatisticsCollegeList(string LoginSSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.StatisticsCollegeList(LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.StatisticsCollegeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpGet("CollegeDetails/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CollegeDetails(string LoginSSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.CollegeDetails(LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.CollegeDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("DeleteData/{CollegeId}/{modifiedBy}")]
        public async Task<OperationResult<bool>> DeleteData(int CollegeId, int modifiedBy)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.DeleteData(CollegeId, modifiedBy));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "Delete", 0, "CollegeMaster");
                }
                else
                {
                    result.State = OperationState.Error;
                    result.SuccessMessage = "There was an error deleting data.!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "Delete", 0, "CollegeMaster");
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpPost("MapSSOIDInCollege/{CollegeId}/{modifiedBy}/{SSOID}")]
        public async Task<OperationResult<bool>> MapSSOIDInCollege(int CollegeId, int modifiedBy, string SSOID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.MapSSOIDInCollege(CollegeId, modifiedBy, SSOID));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "SSOID mapped successfully .!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "MapSSOID", 0, "CollegeMaster");
                }
                else
                {
                    result.State = OperationState.Error;
                    result.SuccessMessage = "There was an error mapping SSOID .!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "MapSSOID", 0, "CollegeMaster");
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.MapSSOIDInCollege", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("ViewTotalCollegeDataByID/{CollegeID}/{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataSet>>> ViewTotalCollegeDataByID(int CollegeID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", CollegeID, "CollegeMaster");
            var result = new OperationResult<List<CommonDataModel_DataSet>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.ViewTotalCollegeDataByID(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.ViewTotalCollegeDataByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("RevertedApplicationList/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> RevertedApplicationList(string LoginSSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.RevertedApplicationList(LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.RevertedApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("LOIApplicationList/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> LOIApplicationList(string LoginSSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.LOIApplicationList(LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.LOIApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("LOIFinalSubmit_OTPVerification/{CollegeID}")]
        public async Task<OperationResult<bool>> LOIFinalSubmit_OTPVerification(int CollegeID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.LOIFinalSubmit_OTPVerification(CollegeID));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.SuccessMessage = "There was an error deleting data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.LOIFinalSubmit_OTPVerification", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("RejectedApplicationList/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> RejectedApplicationList(string LoginSSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.RejectedApplicationList(LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.RejectedApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveLOIWorkFlow")]
        public async Task<OperationResult<bool>> SaveLOIWorkFlow(DocumentScrutinySave_DataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.SaveLOIWorkFlow(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "SaveLOIWorkFlow", request.ApplyNOCID, "ApplyLOI");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.DocumentScrutiny", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetCollegesByDepartmentID/{DepartmentID}")]
        public async Task<OperationResult<List<DataTable>>> GetCollegesByDepartmentID(int DepartmentID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.GetCollegesByDepartmentID(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.GetData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("TotalCollegeDetailsByDepartment")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> TotalCollegeDetailsByDepartment(TotalCollegeReportSearchFilter request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.TotalCollegeDetailsByDepartment(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.TotalCollegeDetailsByDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("CollegesReport")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CollegesReport(DCECollegesReportSearchFilter request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeMasterUtility.CollegesReport(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeMasterController.CollegesReport", ex.ToString());
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

