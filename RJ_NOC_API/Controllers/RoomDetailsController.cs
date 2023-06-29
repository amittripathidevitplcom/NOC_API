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
    [Route("api/RoomDetails")]
    [ApiController]
    public class RoomDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public RoomDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] RoomDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {

                result.Data = await Task.Run(() => UtilityHelper.RoomDetailsUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.CollegeWiseRoomID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "RoomDetails");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.CollegeWiseRoomID, "RoomDetails");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.CollegeWiseRoomID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("RoomDetailsController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetRoomDetailAllList/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<RoomDetailsDataModels>>> GetRoomDetailAllList(int UserID,int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "RoomDetails");
            var result = new OperationResult<List<RoomDetailsDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.RoomDetailsUtility.GetRoomDetailAllList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("RoomDetailsController.GetRoomDetailAllList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetRoomDetailsByID/{CollegeWiseRoomID}/{UserID}")]
        public async Task<OperationResult<List<RoomDetailsDataModel>>> GetRoomDetailsByID(int CollegeWiseRoomID, int UserID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", CollegeWiseRoomID, "RoomDetails");
            var result = new OperationResult<List<RoomDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.RoomDetailsUtility.GetRoomDetailsByID(CollegeWiseRoomID,CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("RoomDetailsController.GetRoomDetailsByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Delete/{CollegeWiseRoomID}/{UserID}/{CollegeID}")]
        public async Task<OperationResult<bool>> DeleteData(int CollegeWiseRoomID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.RoomDetailsUtility.DeleteData(CollegeWiseRoomID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", CollegeWiseRoomID, "RoomDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("RoomDetailsController.DeleteData", e.ToString());
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
