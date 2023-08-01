using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/SubjectMasterService")]
    [ApiController]
    public class SubjectMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public SubjectMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetDepartmentByCourse/{DepartmentID}")]        
        public async Task<OperationResult<List<CourseList>>> GetDepartmentByCourse(int DepartmentID)
        {
            var result = new OperationResult<List<CourseList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.GetDepartmentByCourse(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SubjectMasterController.GetDepartmentByCourse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAllSubjectList/{UserID}/{DepartmentID}")]
        public async Task<OperationResult<List<SubjectMasterDataModel_list>>> GetAllSubjectList(int UserID,int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "SubjectMasterService");
            var result = new OperationResult<List<SubjectMasterDataModel_list>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.GetAllSubjectList(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SubjectMasterController.GetAllSubjectList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{SubjectID}/{UserID}")]
        public async Task<OperationResult<List<SubjectMasterDataModel>>> GetSubjectIDWise(int SubjectID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise",SubjectID, "SubjectMasterService");
            var result = new OperationResult<List<SubjectMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.GetSubjectIDWise(SubjectID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SubjectMasterController.GetSubjectIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(SubjectMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.SubjectMasterUtility.IfExists(request.DepartmentID,request.SubjectID, request.SubjectName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.SubjectID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.SubjectID, "Save", 0, "SubjectMasterService");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.SubjectID, "Update", request.SubjectID, "SubjectMasterService");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.SubjectID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.SubjectName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("SubjectMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{SubjectID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int SubjectID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.DeleteData(SubjectID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", SubjectID, "SubjectMasterService");
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
                CommonDataAccessHelper.Insert_ErrorLog("SubjectMasterController.DeleteData", e.ToString());
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
