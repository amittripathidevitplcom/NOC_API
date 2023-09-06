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
using Microsoft.AspNetCore.Http.HttpResults;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    // [CustomeAuthorize]
    [Route("api/StreamSubjectMappingMaster")]
    [ApiController]
    public class StreamSubjectMappingMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public StreamSubjectMappingMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("GetSubjectMappingList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetSubjectMappingList(StreamSubjectMappingDetailDataModel Model)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(Model.UserID, "StreamSubjectMappingDetailDataModel", 0, "StreamSubject");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StreamSubjectMaster.GetAllStream(Model));
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
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.GetAllCourse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetStreamMappingDetailsByID/{StreamMappingID}/{LoginSSOID}/{UserID}")]
        public async Task<OperationResult<List<StreamSubjectMappingDetailDataModel>>> GetStreamMappingDetailsByID(int StreamMappingID, string LoginSSOID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", StreamMappingID, "GetStreamMappingDetailsByID");
            var result = new OperationResult<List<StreamSubjectMappingDetailDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StreamSubjectMaster.GetStreamIDWise(StreamMappingID, LoginSSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.GetCollegeWiseCourseIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(StreamSubjectMappingDetailDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                //bool IfExits = false;
                //IfExits = UtilityHelper.CourseMasterUtility.IfExists(request.CourseID, request.DepartmentID, request.CollegeWiseCourseID, request.CollegeID);
                //if (IfExits == false)
                //{
                    result.Data = await Task.Run(() => UtilityHelper.StreamSubjectMaster.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StreamMappingID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.StreamMappingID, "SubjectStream");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.StreamMappingID, "SubjectStream");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StreamMappingID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                //}
                //else
                //{
                //    result.State = OperationState.Warning;
                //    result.ErrorMessage = "This course is Already Exist, It Can't Not Be Duplicate.!";
                //}
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("SubjectSream.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{StreamMappingID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int StreamMappingID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StreamSubjectMaster.DeleteData(StreamMappingID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", StreamMappingID, "SreamMapping");
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
                CommonDataAccessHelper.Insert_ErrorLog("StreamSubjectMappingMasterController.DeleteData", e.ToString());
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

