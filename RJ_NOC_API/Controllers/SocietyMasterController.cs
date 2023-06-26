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
    [Route("api/SocietyMaster")]
    [ApiController]
    public class SocietyMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public SocietyMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData([FromBody]SocietyMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                //SocietyMasterDataModel request = Newtonsoft.Json.JsonConvert.DeserializeObject<SocietyMasterDataModel>(json);
                //bool IfExits = false;
                //IfExits = UtilityHelper.SocietyMasterUtility.IfExists(request.SocietyID, request.PersonName);
                //if (IfExits == false)
                //{
                    result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.SocietyID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "SocietyMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.SocietyID, "SocietyMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.SocietyID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                //}
                //else
                //{
                    //result.State = OperationState.Warning;
                    //result.ErrorMessage = request.PersonName + " is Already Exist, It Can't Not Be Duplicate.!";
                //}
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("SocietyMaster.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSocietyAllList/{UserID}")]
        public async Task<OperationResult<List<SocietyMasterDataModels>>> GetSocietyAllList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "SocietyMaster");
            var result = new OperationResult<List<SocietyMasterDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.GetSocietyAllList());
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
                CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.GetSocietyAllList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetSocietyByID/{SocietyID}/{UserID}")]
        public async Task<OperationResult<List<SocietyMasterDataModel>>> GetSocietyByID(int SocietyID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", SocietyID, "SocietyMaster");
            var result = new OperationResult<List<SocietyMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.GetSocietyByID(SocietyID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.GetSocietyByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("Delete/{SocietyID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int SocietyID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SocietyMasterUtility.DeleteData(SocietyID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", SocietyID, "SocietyMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.DeleteData", e.ToString());
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
