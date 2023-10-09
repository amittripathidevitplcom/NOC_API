using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;

namespace RJ_NOC_API.Controllers
{
    [Route("api/StaffAttendance")]
    [ApiController]
    public class StaffAttendanceController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public StaffAttendanceController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetStaffList_CollegeWise/{CollegeID}/{StaffType}/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetStaffList_CollegeWise(int CollegeID,string StaffType, int CourseID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetStaffDetailListForPDF", 0, "StaffDetail");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffAttendanceUtility.GetStaffList_CollegeWise(CollegeID, StaffType, CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("StaffAttendanceController.GetStaffList_CollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveStaffAttendanceData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] StaffAttendanceDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.StaffAttendanceUtility.IfExists(request.StaffAttendanceID, request.CollegeID,request.StaffType, request.CourseID, request.Date);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.StaffAttendanceUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StaffAttendanceID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "StaffAttendance");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", 0, "StaffAttendance");
                            result.SuccessMessage = "Updateed successfully .!";
                        }
                    }

                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StaffAttendanceID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "Data Already Exist, It Can't Not Be Duplicate.!";
                }

            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StaffAttendanceController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("GetStaffAttendanceReportData/{CollegeID}/{StaffType}/{CourseID}/{FromDate}/{ToDate}/{StatusID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetStaffAttendanceReportData(int CollegeID,string StaffType, int CourseID, string FromDate, string ToDate, int StatusID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetStaffDetailListForPDF", 0, "StaffDetail");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffAttendanceUtility.GetStaffAttendanceReportData(CollegeID, StaffType, CourseID,FromDate,ToDate,StatusID));
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
                CommonDataAccessHelper.Insert_ErrorLog("StaffAttendanceController.GetStaffAttendanceReportData", ex.ToString());
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
