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
    [Route("api/FacilityDetails")]
    [ApiController]
    public class FacilityDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public FacilityDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] FacilityDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                
                result.Data = await Task.Run(() => UtilityHelper.FacilityDetailsUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.FacilityDetailID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "FacilityDetails");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.FacilityDetailID, "FacilityDetails");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.FacilityDetailID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
                
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("FacilityDetailsController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetFacilityDetailAllList/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<FacilityDetailsDataModels>>> GetFacilityDetailAllList(int UserID,int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "FacilityDetails");
            var result = new OperationResult<List<FacilityDetailsDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FacilityDetailsUtility.GetFacilityDetailAllList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("FacilityDetailsController.GetFacilityDetailAllList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetfacilityDetailsByID/{FacilityDetailID}/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<FacilityDetailsDataModel>>> GetfacilityDetailsByID(int FacilityDetailID, int UserID,int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", FacilityDetailID, "FacilityDetails");
            var result = new OperationResult<List<FacilityDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FacilityDetailsUtility.GetfacilityDetailsByID(FacilityDetailID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("FacilityDetailsController.GetfacilityDetailsByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Delete/{FacilityDetailID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int FacilityDetailID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FacilityDetailsUtility.DeleteData(FacilityDetailID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", FacilityDetailID, "FacilityDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("FacilityDetailsController.DeleteData", e.ToString());
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
