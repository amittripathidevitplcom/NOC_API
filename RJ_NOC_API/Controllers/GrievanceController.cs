using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/Grievance")]
    [ApiController]
    public class GrievanceController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public GrievanceController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllGrievance(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "Grievance");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GrievanceUtility.GetAllGrievance());
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
                CommonDataAccessHelper.Insert_ErrorLog("GrievanceController.GetAllAnimalList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetGrievance_AddedSSOIDWise/{SSOID}")]
        public async Task<OperationResult<List<DataTable>>> GetGrievance_AddedSSOIDWise(string SSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetGrievance_AddedSSOIDWise", 0, "Grievance");
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GrievanceUtility.GetGrievance_AddedSSOIDWise(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("GrievanceController.GetGrievance_AddedSSOIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("{GrievanceID}/{UserID}")]
        public async Task<OperationResult<List<GrievanceDataModel>>> GetByID(int GrievanceID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", GrievanceID, "Grievance");
            var result = new OperationResult<List<GrievanceDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GrievanceUtility.GetByID(GrievanceID));
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
                CommonDataAccessHelper.Insert_ErrorLog("GrievanceController.GetByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(GrievanceDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                //bool IfExits = false;
                //IfExits = UtilityHelper.GrievanceUtility.IfExists(request.GrievanceID, request.DepartmentID,request.AnimalName);
                //if (IfExits == false)
                //{
                    result.Data = await Task.Run(() => UtilityHelper.GrievanceUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.GrievanceID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", request.GrievanceID, "Grievance");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.GrievanceID, "Grievance");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.GrievanceID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                //}
                //else
                //{
                //    result.State = OperationState.Warning;
                //    result.ErrorMessage = request.AnimalName + " is Already Exist, It Can't Not Be Duplicate.!";
                //}
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GrievanceController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{GrievanceID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int GrievanceID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.GrievanceUtility.DeleteData(GrievanceID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", GrievanceID, "Grievance");
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
                CommonDataAccessHelper.Insert_ErrorLog("GrievanceController.DeleteData", e.ToString());
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
