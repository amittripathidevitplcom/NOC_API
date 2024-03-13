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
using RJ_NOC_API.AuthModels;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ActivityDetails")]
    [ApiController]
    public class ActivityDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ActivityDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] ActivityDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                
                result.Data = await Task.Run(() => UtilityHelper.ActivityDetailsUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.ActivityDetailID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "ActivityDetails");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.ActivityDetailID, "ActivityDetails");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.ActivityDetailID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
                
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ActivityDetailsController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetActivityDetailAllList/{UserID}/{CollegeID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<ActivityDetailsDataModels>>> GetActivityDetailAllList(int UserID,int CollegeID,int ApplyNOCID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "ActivityDetails");
            var result = new OperationResult<List<ActivityDetailsDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ActivityDetailsUtility.GetActivityDetailAllList(CollegeID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ActivityDetailsController.GetActivityDetailAllList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetActivityDetailsByID/{ActivityDetailID}/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<ActivityDetailsDataModel>>> GetActivityDetailsByID(int ActivityDetailID, int UserID,int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", ActivityDetailID, "ActivityDetails");
            var result = new OperationResult<List<ActivityDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ActivityDetailsUtility.GetActivityDetailsByID(ActivityDetailID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ActivityDetailsController.GetActivityDetailsByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Delete/{ActivityDetailID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int ActivityDetailID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ActivityDetailsUtility.DeleteData(ActivityDetailID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", ActivityDetailID, "ActivityDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("ActivityDetailsController.DeleteData", e.ToString());
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
