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
    [Route("api/BEdRoomDetail")]
    [ApiController]
    public class BEdRoomDetailController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public BEdRoomDetailController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetBEdRoomDetailList/{DepartmentID}/{CollegeID}")]
        public async Task<OperationResult<List<BEdRoomDetailDetailsDataModel>>> GetBEdRoomDetailList(int DepartmentID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(CollegeID, "GetBEdRoomDetailList", 0, "BEdRoomDetail");
            var result = new OperationResult<List<BEdRoomDetailDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.BEdRoomDetailUtility.GetBEdRoomDetailList(DepartmentID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("BEdRoomDetailController.GetBEdRoomDetailList", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData([FromBody] BEdRoomDetailDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {

                result.Data = await Task.Run(() => UtilityHelper.BEdRoomDetailUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.BEdRoomDetailID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "BEdRoomDetail");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.BEdRoomDetailID, "BEdRoomDetail");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.BEdRoomDetailID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("BEdRoomDetailController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("Delete/{BEdRoomDetailID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int BEdRoomDetailID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.BEdRoomDetailUtility.Delete(BEdRoomDetailID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", BEdRoomDetailID, "BEdRoomDetail");
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
                CommonDataAccessHelper.Insert_ErrorLog("BEdRoomDetailController.DeleteData", e.ToString());
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

