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
using FIH_EPR_DataAccess.Common;

namespace RJ_NOC_API.Controllers
{
    [Route("api/CommonFuncation")]
    [ApiController]
    public class CommonFuncationController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public CommonFuncationController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

      
        [HttpGet("GetDepartmentList")]
        public async Task<OperationResult<List<CommonDataModel_DepartmentMasterList>>> GetDepartmentList()
        {
            var result = new OperationResult<List<CommonDataModel_DepartmentMasterList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDepartmentList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSchemeListByDepartment/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_SchemeListByDepartment>>> GetSchemeListByDepartment(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_SchemeListByDepartment>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSchemeListByDepartment(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSchemeListByDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetModuleList")]
        public async Task<OperationResult<List<CommonDataModel_ModuleMasterList>>> GetModuleList()
        {
            var result = new OperationResult<List<CommonDataModel_ModuleMasterList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetModuleList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetModuleList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSubmoduleListByModule/{ModuleID}")]
        public async Task<OperationResult<List<CommonDataModel_SubModuleListByModule>>> GetSubModuleListByModule(int ModuleID)
        {
            var result = new OperationResult<List<CommonDataModel_SubModuleListByModule>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSubModuleListByModule(ModuleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSubmoduleListByModule", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetLevelList")]
        public async Task<OperationResult<List<CommonDataModel_LevelMasterList>>> GetLevelList()
        {
            var result = new OperationResult<List<CommonDataModel_LevelMasterList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLevelList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLevelList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetRoleListByLevel/{LevelID}")]
        public async Task<OperationResult<List<CommonDataModel_RoleListByLevel>>> GetRoleListByLevel(int LevelID)
        {
            var result = new OperationResult<List<CommonDataModel_RoleListByLevel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRoleListByLevel(LevelID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRoleListByLevel", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetActionHeadList")]
        public async Task<OperationResult<List<CommonDataModel_ActionHeadList>>> GetActionHeadList()
        {
            var result = new OperationResult<List<CommonDataModel_ActionHeadList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetActionHeadList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetActionHeadList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetActionListByActionHead/{ActionHeadID}")]
        public async Task<OperationResult<List<CommonDataModel_ActionListByActionHead>>> GetActionListByActionHead(int ActionHeadID)
        {
            var result = new OperationResult<List<CommonDataModel_ActionListByActionHead>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetActionListByActionHead(ActionHeadID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetActionListByActionHead", ex.ToString());
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

