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
                //IfExits = UtilityHelper.DTEAffilitionMasterUtility.IfExists(request.DTE_ARId, request.CommitteeType, request.CommitteeName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.DTEAffilitionCourseSaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.AffiliationCourseID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "DTEAffilitionCourseSaveData", 0, "DTEAffilitionMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.AffiliationCourseID, "DTEAffilitionMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.AffiliationCourseID == 0)
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
        [HttpGet("GetDTEAffiliationOtherDetailsPreviewData/{DepartmentID}")]
        public async Task<OperationResult<List<DTEAffiliationAddOtherDetailsPreviewDataModel>>> GetDTEAffiliationOtherDetailsPreviewData(int DepartmentID)
        {
            var result = new OperationResult<List<DTEAffiliationAddOtherDetailsPreviewDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEAffilitionMasterUtility.GetDTEAffiliationOtherDetailsPreviewData(DepartmentID));
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
       

    }
}

