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

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/WorkFlowMaster")]
    [ApiController]
    public class WorkFlowMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public WorkFlowMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]

        public async Task<OperationResult<bool>> SaveData(WorkFlowMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.WorkFlowMasterUtility.IfExists(request.WorkFlowMasterID, request.SubModuleID,request.RoleID);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.WorkFlowMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.WorkFlowMasterID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", 0, "WorkFlowMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.WorkFlowMasterID, "WorkFlowMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.WorkFlowMasterID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "WorkFlow" + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("WorkFlowMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetWorkFlowMasterList/{WorkFlowMasterID}")]
        public async Task<OperationResult<List<WorkFlowMasterDataModel>>> GetWorkFlowMasterList(int WorkFlowMasterID)
        {
            var result = new OperationResult<List<WorkFlowMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.WorkFlowMasterUtility.GetWorkFlowMasterList(WorkFlowMasterID));
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
                CommonDataAccessHelper.Insert_ErrorLog("WorkFlowMasterController.GetWorkFlowMasterList", ex.ToString());
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

