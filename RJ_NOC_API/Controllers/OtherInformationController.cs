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
    [Route("api/OtherInformation")]
    [ApiController]
    public class OtherInformationController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public OtherInformationController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody] OtherInformationDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {

                result.Data = await Task.Run(() => UtilityHelper.OtherInformationUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.CollegeWiseOtherInfoID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "OtherInformation");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.CollegeWiseOtherInfoID, "OtherInformation");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.CollegeWiseOtherInfoID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("OtherInformationController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetOtherInformationAllList/{UserID}/{CollegeID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<OtherInformationDataModels>>> GetOtherInformationAllList(int UserID,int CollegeID,int ApplyNOCID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "OtherInformation");
            var result = new OperationResult<List<OtherInformationDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OtherInformationUtility.GetOtherInformationAllList(CollegeID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("OtherInformationController.GetOtherInformationAllList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetOtherInformationByID/{CollegeWiseOtherInfoID}/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<OtherInformationDataModel>>> GetOtherInformationByID(int CollegeWiseOtherInfoID, int UserID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", CollegeWiseOtherInfoID, "OtherInformation");
            var result = new OperationResult<List<OtherInformationDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OtherInformationUtility.GetOtherInformationByID(CollegeWiseOtherInfoID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("OtherInformationController.GetOtherInformationByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Delete/{CollegeWiseOtherInfoID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int CollegeWiseOtherInfoID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OtherInformationUtility.DeleteData(CollegeWiseOtherInfoID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", CollegeWiseOtherInfoID, "OtherInformation");
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
                CommonDataAccessHelper.Insert_ErrorLog("OtherInformationController.DeleteData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCollegeLabInformationList/{CollegeID}/{key}")]
        public async Task<OperationResult<List<CollegeLabInformationDataModel>>> GetCollegeLabInformationList( int CollegeID, string key)
        {

            var result = new OperationResult<List<CollegeLabInformationDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OtherInformationUtility.GetCollegeLabInformationList(CollegeID,key));
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
                CommonDataAccessHelper.Insert_ErrorLog("OtherInformationController.GetCollegeLabInformationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("SaveLabData")]
        public async Task<OperationResult<bool>> SaveLabData(PostCollegeLabInformation request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.OtherInformationUtility.SaveLabData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(request.CollegeID, "Save", 0, "CollegeDocument");
                    result.SuccessMessage = "Saved successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error adding data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("OtherInformationController.SaveLabData", e.ToString());
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
