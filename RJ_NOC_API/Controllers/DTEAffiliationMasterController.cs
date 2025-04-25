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
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Authorization;
using RJ_NOC_API.AuthModels;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/DTEAffilitionMaster")]
    [ApiController]
    public class DTEAffilitionMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DTEAffilitionMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("DTEAffilitionSaveData")]
        public async Task<OperationResult<bool>> SaveData(DTEAffiliationRegistrationDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.DTE_ARId == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.DTE_ARId, "DTEAffilitionMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.DTE_ARId == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.College_Name + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DTEAffilitionCourseSaveData")]
        public async Task<OperationResult<bool>> DTEAffilitionCourseSaveData(DTEAffiliationCourseDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.DTEAffilitionMasterUtility.IfExists(request.BTERRegID,request.BTERCourseID,request.CourseTypeId, request.CourseId);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.DTEAffilitionCourseSaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.BTERCourseID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "DTEAffilitionCourseSaveData", request.BTERCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.BTERCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.BTERCourseID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage ="is Already Exist, It Can't Not Be Duplicate.!";
                }
            }

            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.DTEAffilitionCourseSaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DTEAffilitionOtherDetailsSaveData")]
        public async Task<OperationResult<bool>> DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.DTEAffilitionOtherDetailsSaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.OtherDetailsID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "DTEAffilitionOtherDetailsSaveData", 0, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.OtherDetailsID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.OtherDetailsID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                //else
                //{
                //    result.State = OperationState.Warning;
                //    result.ErrorMessage = request.CourseIntakeAsPerAICTELOA + " is Already Exist, It Can't Not Be Duplicate.!";
                //}

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.DTEAffilitionOtherDetailsSaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDTEAffiliationCoursePreviewData/{DepartmentID}")]
        public async Task<OperationResult<List<DTEAffiliationAddCoursePreviewDataModel>>> GetDTEAffiliationCoursePreviewData(int DepartmentID)
        {
            var result = new OperationResult<List<DTEAffiliationAddCoursePreviewDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetDTEAffiliationCoursePreviewData(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetDTEAffiliationCoursePreviewData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetDTEAffiliationOtherDetailsPreviewData/{BTERRegID}")]
        public async Task<OperationResult<List<DTEAffiliationAddOtherDetailsPreviewDataModel>>> GetDTEAffiliationOtherDetailsPreviewData(int BTERRegID)
        {
            var result = new OperationResult<List<DTEAffiliationAddOtherDetailsPreviewDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetDTEAffiliationOtherDetailsPreviewData(BTERRegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetDTEAffiliationOtherDetailsPreviewData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAllDTEAffiliationCourseList/{BTERRegID}")]
        public async Task<OperationResult<List<DTEAffiliationCommonDataModel_DataTable>>> GetAllDTEAffiliationCourseList(int BTERRegID)
        {
            var result = new OperationResult<List<DTEAffiliationCommonDataModel_DataTable>>();
            try
            {

                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetAllDTEAffiliationCourseList(BTERRegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetAllDTEAffiliationCourseList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("Edit_OnClick/{DTE_ARId}")]
        public async Task<OperationResult<List<DTEAffiliationRegistrationDataModel>>> Edit_OnClick(int DTE_ARId)
        {
            var result = new OperationResult<List<DTEAffiliationRegistrationDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.Edit_OnClick(DTE_ARId));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.Edit_OnClick", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        
        [HttpPost("Delete/{AffiliationCourseID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int AffiliationCourseID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {         
                        result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.DeleteData(AffiliationCourseID));
                        if (result.Data)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", AffiliationCourseID, "DTEAffilitionMaster");
                            result.State = OperationState.Success;
                            result.SuccessMessage = "Deleted successfully .!";
                        }
                        else
                        {
                            result.State = OperationState.Error;
                            result.ErrorMessage = "There was an error deleting data.!";
                        }
                
                    
                }
           
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.DeleteData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("generateYears/{YearofstartingID}")]
        public async Task<OperationResult<List<BTERAffiliationfeesdeposited>>> generateYears(int YearofstartingID)
        {
            var result = new OperationResult<List<BTERAffiliationfeesdeposited>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.generateYears(YearofstartingID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.generateYears", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetOtherinformation/{BTERRegID}")]
        public async Task<OperationResult<List<BTEROtherDetailsDataModel>>> GetOtherinformation(int BTERRegID)
        {
            var result = new OperationResult<List<BTEROtherDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetOtherinformation(BTERRegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetOtherinformation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        } 
        [HttpGet("GetAllBTERAffiliationCourseFeeList/{BTERRegID}")]
        public async Task<OperationResult<List<BTERFeeDetailsDataModel>>> GetAllBTERAffiliationCourseFeeList(int BTERRegID)
        {
            var result = new OperationResult<List<BTERFeeDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetAllBTERAffiliationCourseFeeList(BTERRegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetAllBTERAffiliationCourseFeeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetDeficiencyHistoryApplicationID/{BTERRegID}/{ApplicationStatus}")]
        public async Task<OperationResult<List<BTERFeeDetailsDataModel>>> GetDeficiencyHistoryApplicationID(int BTERRegID,string ApplicationStatus)
        {
            var result = new OperationResult<List<BTERFeeDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetDeficiencyHistoryApplicationID(BTERRegID, ApplicationStatus));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetAllBTERAffiliationCourseFeeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("RevertnocSaveData/{ActionName}")]
        public async Task<OperationResult<bool>> RevertnocSaveData(NOCRevertOtherDetailsDataModel request,string ActionName)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.RevertnocSaveData(request, ActionName));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.OtherDetailsID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.OtherDetailsID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Resubmit successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.OtherDetailsID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    //result.ErrorMessage = request.College_Name + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.RevertnocSaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("RevertEOALOASaveData/{ActionName}")]
        public async Task<OperationResult<bool>> RevertEOALOASaveData(EOALOARevertOtherDetailsDataModel request,string ActionName)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.RevertEOALOASaveData(request, ActionName));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.OtherDetailsID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.OtherDetailsID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Resubmit successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.OtherDetailsID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    //result.ErrorMessage = request.College_Name + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.RevertEOALOASaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("RevertApplicationSaveData/{ActionName}")]
        public async Task<OperationResult<bool>> RevertApplicationSaveData(ApplicationRevertOtherDetailsDataModel request,string ActionName)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.RevertApplicationSaveData(request, ActionName));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.OtherDetailsID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.OtherDetailsID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Resubmit successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.OtherDetailsID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                   // result.ErrorMessage = request.College_Name + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.RevertApplicationSaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("ApplicationSubmit/{BTERRegID}/{ActionName}/{AMOUNT}")]
        public async Task<OperationResult<List<BTEROtherDetailsDataModel>>> ApplicationSubmit(int BTERRegID,string ActionName,decimal AMOUNT)
        {
            var result = new OperationResult<List<BTEROtherDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.ApplicationSubmit(BTERRegID, ActionName, AMOUNT));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Application Submited successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.ApplicationSubmit", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Generateorder_SaveData")]
        public async Task<OperationResult<bool>> Generateorder_SaveData(Generateorderforbter request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                //IfExits = UtilityHelper.DTEAffilitionMasterUtility.IfExists(request.BTERRegID, request.BTERCourseID, request.CourseTypeId, request.CourseId);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.Generateorder_SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.DTEAffiliationID == 0)
                        {
                            //CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Generateorder_SaveData", request.BTERCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Order Generated successfully.!";
                        }
                        else
                        {
                            //CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.BTERCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.DTEAffiliationID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "is Already Exist, It Can't Not Be Duplicate.!";
                }
            }

            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.Generateorder_SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllBTERFeeList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllBTERFeeList", 0, "BTERFeeMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetAllBTERFeeList());
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.GetAllBTERFeeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("{BTERCourseID}/{LoginSSOID}/{UserID}")]
        public async Task<OperationResult<List<BTERCourseAffiliationDataModel>>> GetDTEAffiliationWiseCourseIDWise(int BTERCourseID, string LoginSSOID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", BTERCourseID, "CourseMaster");
            var result = new OperationResult<List<BTERCourseAffiliationDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetDTEAffiliationWiseCourseIDWise(BTERCourseID, LoginSSOID));
                if (result.Data.Count > 0)
                {

                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetDTEAffiliationWiseCourseIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }     

        [HttpGet("{FeeID}/{UserID}")]
        public async Task<OperationResult<List<BTERFeeMasterDataModel>>> GetBTERFeeByID(int FeeID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", FeeID, "LOIFeeMaster");
            var result = new OperationResult<List<BTERFeeMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetBTERFeeByID(FeeID));
                if (result.Data.Count > 0)
                {

                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.GetLOIFeeByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("BTERFeeSaveData")]
        public async Task<OperationResult<bool>> SaveDataBTERFee(BTERFeeMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.DTEAffilitionMasterUtility.IfExists(request.FeeID, request.DepartmentID, request.FeeType);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.SaveDataBTERFee(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.FeeID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.FeeID, "BTERFeeMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.FeeID, "BTERFeeMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.FeeID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.FeeType + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("BTERDeleteData/{FeeID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteDataBter(int FeeID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.DeleteDataBter(FeeID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", FeeID, "BTERFeeMaster");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error deleting data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.DeleteData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveDataBTERApplicationOpenSession")]
        public async Task<OperationResult<bool>> SaveDataBTERApplicationOpenSession(BTERApplicationOpensessionDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                //IfExits = UtilityHelper.DTEAffilitionMasterUtility.IfExists(request.BTERRegID, request.BTERCourseID, request.CourseTypeId, request.CourseId);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.SaveDataBTERApplicationOpenSession(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.ID == 0)
                        {
                            //CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Generateorder_SaveData", request.BTERCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Save successfully.!";
                        }
                        else
                        {
                            //CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.BTERCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.ID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "is Already Exist, It Can't Not Be Duplicate.!";
                }
            }

            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.SaveDataBTERApplicationOpenSession", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAllOpenSessionApplicationList")]
        public async Task<OperationResult<List<BTERApplicationOpensessionDataModel>>> GetAllOpenSessionApplicationList()
        {
            var result = new OperationResult<List<BTERApplicationOpensessionDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetAllOpenSessionApplicationList());
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data Load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetAllOpenSessionApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetByIDOpenSessionApplicationList/{MID}")]
        public async Task<OperationResult<List<BTERApplicationOpensessionDataModel>>> GetByIDOpenSessionApplicationList(int MID)
        {
            var result = new OperationResult<List<BTERApplicationOpensessionDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetByIDOpenSessionApplicationList(MID));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data Load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetByIDOpenSessionApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DeleteDataOpenSessionApplicationList/{ID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteDataOpenSessionApplicationList(int ID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.DeleteDataOpenSessionApplicationList(ID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", ID, "OpenSessionApplication");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error deleting data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.DeleteDataOpenSessionApplicationList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("GetPaymenthistoryList/{DepartmentID}")]
        public async Task<OperationResult<List<BTERPaymentHistoryeMitraDataModel_List>>> TotalBTERCollegeDetailsByDepartment(BTERPaymentHistoryeMitraDataModel request, int DepartmentID)
        {
            var result = new OperationResult<List<BTERPaymentHistoryeMitraDataModel_List>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetPaymenthistoryList(request, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMasterController.GetPaymenthistoryList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAllCollegeList")]
        public async Task<OperationResult<List<BTERPaymentHistoryeMitraDataModel_List>>> GetAllCollegeList()
        {
            var result = new OperationResult<List<BTERPaymentHistoryeMitraDataModel_List>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetAllCollegeList());
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data Load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEAffilitionMaster.GetAllCollegeList", ex.ToString());
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

