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
    [Route("api/CourseMaster")]
    [ApiController]
    public class CourseMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public CourseMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}/{LoginSSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllCourse(int UserID, string LoginSSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "CourseMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.GetAllCourse(LoginSSOID));
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
        [HttpGet("{CollegeWiseCourseID}/{LoginSSOID}/{UserID}")]
        public async Task<OperationResult<List<CourseMasterDataModel>>> GetCollegeWiseCourseIDWise(int CollegeWiseCourseID, string LoginSSOID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", CollegeWiseCourseID, "CourseMaster");
            var result = new OperationResult<List<CourseMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.GetCollegeWiseCourseIDWise(CollegeWiseCourseID, LoginSSOID));
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
        [HttpPost]
        public async Task<OperationResult<bool>> SaveData(CourseMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.CourseMasterUtility.IfExists(request.CourseID, request.DepartmentID, request.CollegeWiseCourseID, request.CollegeID, request.StreamID);
                if (IfExits == false)
                {
                    //Edit Time check Course and Subject Exits or not exits
                    if (request.CollegeWiseCourseID > 0)
                    {
                        string SubjectIDs = "";
                        foreach (var item in request.SelectedSubjectDetails)
                        {
                            SubjectIDs += item.SubjectID + ",";
                        }
                        DataTable dataTable = new DataTable();
                        dataTable = UtilityHelper.CourseMasterUtility.IfExists_CheckCourseandSubject("Edit", request.CollegeWiseCourseID, SubjectIDs);
                        if (dataTable.Rows.Count > 0)
                        {
                            if (dataTable.Rows[0]["Status"].ToString() == "T")
                            {
                            }
                            else
                            {
                                result.State = OperationState.Error;
                                result.ErrorMessage = dataTable.Rows[0]["Message"].ToString();
                            }
                        }
                    }

                    result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.CollegeWiseCourseID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "CourseMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.CollegeWiseCourseID, "CourseMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.CollegeWiseCourseID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }

                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "This course is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{CollegeWiseCourseID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int CollegeWiseCourseID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {


                DataTable dataTable = new DataTable();
                dataTable = UtilityHelper.CourseMasterUtility.IfExists_CheckCourseandSubject("Delete", CollegeWiseCourseID, "");
                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["Status"].ToString() == "T")
                    {

                        result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.DeleteData(CollegeWiseCourseID));
                        if (result.Data)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", CollegeWiseCourseID, "CourseMaster");
                            result.State = OperationState.Success;
                            result.SuccessMessage = "Deleted successfully .!";
                        }
                        else
                        {
                            result.State = OperationState.Error;
                            result.ErrorMessage = "There was an error deleting data.!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = dataTable.Rows[0]["Message"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.DeleteData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCoursesByCollegeID/{CollegeID}/{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCoursesByCollegeID(int CollegeID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", CollegeID, "CourseMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.GetCoursesByCollegeID(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.GetCoursesByCollegeID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DTESaveData")]
        public async Task<OperationResult<bool>> DTESaveData(DTECourseMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.CourseMasterUtility.IfExists(request.CourseID, request.DepartmentID, request.CollegeWiseCourseID, request.CollegeID, request.StreamID);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.DTESaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.CollegeWiseCourseID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "CourseMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.CollegeWiseCourseID, "CourseMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.CollegeWiseCourseID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }

                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "This course is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.SaveData", e.ToString());
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

