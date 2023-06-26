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


namespace RJ_NOC_API.Controllers
{
    [Route("api/ParliamentAreaMaster")]
    [ApiController]

    public class ParliamentAreaMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ParliamentAreaMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetParliamentAreaList()
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetParliamentAreaList", 0, "ParliamentAreaMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ParliamentAreaMasterUtility.GetParliamentAreaList());
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
                CommonDataAccessHelper.Insert_ErrorLog("ParliamentAreaMaster.GetParliamentAreaList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("{ParliamentAreaID}")]
        public async Task<OperationResult<List<ParliamentAreaMasterDataModel>>> GetParliamentAreaIDWise(int ParliamentAreaID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", ParliamentAreaID, "CommonMaster");
            var result = new OperationResult<List<ParliamentAreaMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ParliamentAreaMasterUtility.GetParliamentAreaIDWise(ParliamentAreaID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ParliamentAreaMaster.GetParliamentAreaIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(ParliamentAreaMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.ParliamentAreaMasterUtility.IfExists(request.ParliamentAreaID,request.DistrictID, request.ParliamentAreaName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.ParliamentAreaMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.ParliamentAreaID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "ParliamentAreaMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.ParliamentAreaID, "ParliamentAreaMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.ParliamentAreaID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.ParliamentAreaName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ParliamentAreaMaster.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{ParliamentAreaID}")]
        public async Task<OperationResult<bool>> DeleteData(int ParliamentAreaID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ParliamentAreaMasterUtility.DeleteData(ParliamentAreaID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", ParliamentAreaID, "ParliamentAreaMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("ParliamentAreaMaster.DeleteData", e.ToString());
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

