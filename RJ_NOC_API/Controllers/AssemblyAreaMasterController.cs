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
    [Route("api/AssemblyAreaMaster")]
    [ApiController]

    public class AssemblyAreaMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public AssemblyAreaMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAssemblyAreaList()
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAssemblyAreaList", 0, "AssemblyAreaMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AssemblyAreaMasterUtility.GetAssemblyAreaList());
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
                CommonDataAccessHelper.Insert_ErrorLog("AssemblyAreaMaster.GetAssemblyAreaList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("{AssemblyAreaID}")]
        public async Task<OperationResult<List<AssemblyAreaMasterDataModel>>> GetAssemblyAreaIDWise(int AssemblyAreaID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", AssemblyAreaID, "AssemblyAreaMaster");
            var result = new OperationResult<List<AssemblyAreaMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AssemblyAreaMasterUtility.GetAssemblyAreaIDWise(AssemblyAreaID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AssemblyAreaMaster.GetAssemblyAreaIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(AssemblyAreaMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.AssemblyAreaMasterUtility.IfExists(request.AssemblyAreaID, request.DistrictID, request.AssemblyAreaName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.AssemblyAreaMasterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.AssemblyAreaID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "AssemblyAreaMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.AssemblyAreaID, "AssemblyAreaMaster");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.AssemblyAreaID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.AssemblyAreaName + " is Already Exist, It Can't Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AssemblyAreaMaster.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{AssemblyAreaID}")]
        public async Task<OperationResult<bool>> DeleteData(int AssemblyAreaID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AssemblyAreaMasterUtility.DeleteData(AssemblyAreaID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", AssemblyAreaID, "AssemblyAreaMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("AssemblyAreaMaster.DeleteData", e.ToString());
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

