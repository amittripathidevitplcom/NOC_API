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


        [HttpGet("GetDepartmentMaster")]
        public async Task<OperationResult<List<CommonDataModel_DepartmentMaster>>> GetDepartmentMaster()
        {
            var result = new OperationResult<List<CommonDataModel_DepartmentMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDepartmentMaster());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDepartmentMaster", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCollageList_DepartmentAndSSOIDWise/{DepartmentID}/{LoginSSOID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster>>> GetCollageList_DepartmentAndSSOIDWise(int DepartmentID, string LoginSSOID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollageList_DepartmentAndSSOIDWise(DepartmentID, LoginSSOID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDepartmentMaster", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCourseList_DepartmentIDWise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_CourseMaster>>> GetCourseList_DepartmentIDWise(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_CourseMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseList_DepartmentIDWise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseList_DepartmentIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetSubjectList_CourseIDWise/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_SubjectMaster>>> GetSubjectList_CourseIDWise(int CourseID)
        {
            var result = new OperationResult<List<CommonDataModel_SubjectMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSubjectList_CourseIDWise(CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSubjectList_CourseIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSeatInformation_CourseIDWise/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_SeatInformationMaster>>> GetSeatInformation_CourseIDWise(int CourseID)
        {
            var result = new OperationResult<List<CommonDataModel_SeatInformationMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSeatInformation_CourseIDWise(CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSeatInformation_CourseIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCommonMasterList_DepartmentAndTypeWise/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>> GetCommonMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCommonMasterList_DepartmentAndTypeWise(DepartmentID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCommonMasterList_DepartmentAndTypeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDistrictList")]
        public async Task<OperationResult<List<CommonDataModel_DistrictList>>> GetDistrictList()
        {
            var result = new OperationResult<List<CommonDataModel_DistrictList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDistrictList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDistrictList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetState")]
        public async Task<OperationResult<List<CommonDataModel_StateList>>> GetState()
        {
            var result = new OperationResult<List<CommonDataModel_StateList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetStateList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDistrictList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDistrictListByStateID/{StateID}")]
        public async Task<OperationResult<List<CommonDataModel_DistrictList>>> GetDistrictListByStateID(int StateID)
        {
            var result = new OperationResult<List<CommonDataModel_DistrictList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDistrictListByStateID(StateID));
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

        [HttpGet("GetDivisionList")]
        public async Task<OperationResult<List<CommonDataModel_DivisionDDL>>> GetDivisionList()
        {
            var result = new OperationResult<List<CommonDataModel_DivisionDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAllDivision());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDivisionList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDistrictByDivsionId/{divisionId}")]
        public async Task<OperationResult<List<CommonDataModel_DistrictList>>> GetDistrictByDivsionId(int divisionId)
        {
            var result = new OperationResult<List<CommonDataModel_DistrictList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDistrictByDivsionId(divisionId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDistrictByDivsionId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetUniversityByDepartmentId/{departmentId}")]
        public async Task<OperationResult<List<CommonDataModel_UniversityDDL>>> GetUniversityByDepartmentId(int departmentId)
        {
            var result = new OperationResult<List<CommonDataModel_UniversityDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetUniversityByDepartmentId(departmentId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDistrictByDivsionId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSuvdivisionByDistrictId/{districtId}")]
        public async Task<OperationResult<List<CommonDataModel_SuvdivisionDDL>>> GetSuvdivisionByDistrictId(int districtId)
        {
            var result = new OperationResult<List<CommonDataModel_SuvdivisionDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSuvdivisionByDistrictId(districtId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSuvdivisionByDistrictId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetTehsilByDistrictId/{districtId}")]
        public async Task<OperationResult<List<CommonDataModel_TehsilDDL>>> GetTehsilByDistrictId(int districtId)
        {
            var result = new OperationResult<List<CommonDataModel_TehsilDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetTehsilByDistrictId(districtId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetTehsilByDistrictId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetPanchyatSamitiByDistrictId/{districtId}")]
        public async Task<OperationResult<List<CommonDataModel_PanchyatSamitiDDL>>> GetPanchyatSamitiByDistrictId(int districtId)
        {
            var result = new OperationResult<List<CommonDataModel_PanchyatSamitiDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetPanchyatSamitiByDistrictId(districtId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetPanchyatSamitiByDistrictId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetParliamentAreaByDistrictId/{districtId}")]
        public async Task<OperationResult<List<CommonDataModel_ParliamentAreaDDL>>> GetParliamentAreaByDistrictId(int districtId)
        {
            var result = new OperationResult<List<CommonDataModel_ParliamentAreaDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetParliamentAreaByDistrictId(districtId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetParliamentAreaByDistrictId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

         

        [HttpGet("GetAllFinancialYear")]
        public async Task<OperationResult<List<CommonDataModel_FinancialYearDDL>>> GetAllFinancialYear()
        {
            var result = new OperationResult<List<CommonDataModel_FinancialYearDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAllFinancialYear());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAllFinancialYear", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        //Deepak 05062023
        [HttpGet("GetDocumentMasterList_DepartmentAndTypeWise/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_DocumentMasterDepartmentAndTypeWise>>> GetDocumentMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_DocumentMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDocumentMasterList_DepartmentAndTypeWise(DepartmentID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDocumentMasterList_DepartmentAndTypeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetLandAreaMasterList_DepartmentWise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_LandAreaMasterList_DepartmentWise>>> GetLandAreaMasterList_DepartmentWise(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_LandAreaMasterList_DepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLandAreaMasterList_DepartmentWise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLandAreaMasterList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetLandTypeMasterList_DepartmentAndLandConvertWise/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_LandTypeMasterList_DepartmentWise>>> GetLandTypeMasterList_DepartmentWise(int DepartmentID,string Type)
        {
            var result = new OperationResult<List<CommonDataModel_LandTypeMasterList_DepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLandTypeMasterList_DepartmentAndLandConvertWise(DepartmentID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLandTypeMasterList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetLandDoucmentTypeMasterList_DepartmentWise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise>>> GetLandDoucmentTypeMasterList_DepartmentWise(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLandDoucmentTypeMasterList_DepartmentWise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLandDoucmentTypeMasterList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCourseList_CollegeWise/{CollegID}")]
        public async Task<OperationResult<List<CommonDataModel_CollegeWiseCourseList>>> GetCourseList_CollegeWise(int CollegID)
        {
            var result = new OperationResult<List<CommonDataModel_CollegeWiseCourseList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseList_CollegeWise(CollegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseList_CollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllDesignation")]
        public async Task<OperationResult<List<CommonDataModel_DesignationDDL>>> GetAllDesignation()
        {
            var result = new OperationResult<List<CommonDataModel_DesignationDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAllDesignation());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAllDesignation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllOccupation")]
        public async Task<OperationResult<List<CommonDataModel_OccupationDDL>>> GetAllOccupation()
        {
            var result = new OperationResult<List<CommonDataModel_OccupationDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAllOccupation());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Occupation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetCourseRoomSize/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_CourseRoomSize>>> GetCourseRoomSize(int CourseID)
        {
            var result = new OperationResult<List<CommonDataModel_CourseRoomSize>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseRoomSize(CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseRoomSize", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("OtherInformationList_DepartmentAndTypeWise/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>> OtherInformationList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.OtherInformationList_DepartmentAndTypeWise(DepartmentID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.OtherInformationList_DepartmentAndTypeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("OtherInformationSize/{OtherInformationID}")]
        public async Task<OperationResult<List<CommonDataModel_OtherInformationSize>>> OtherInformationSize(int OtherInformationID)
        {
            var result = new OperationResult<List<CommonDataModel_OtherInformationSize>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.OtherInformationSize(OtherInformationID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.OtherInformationSize", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        



        [HttpGet("GetBuildingTypeCheck")]
        public async Task<OperationResult<List<CommonDataModel_BuildingType>>> GetBuildingTypeCheck()
        {
            var result = new OperationResult<List<CommonDataModel_BuildingType>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetBuildingTypeCheck());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetBuildingTypeCheck", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetBuildingUploadDetails")]
        public async Task<OperationResult<List<CommonDataModel_BuildingUploadDoc>>> GetBuildingUploadDetails()
        {
            var result = new OperationResult<List<CommonDataModel_BuildingUploadDoc>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetBuildingUploadDetails());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetBuildingTypeCheck", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetLandAreaMasterList_DepartmentWise/{DepartmentID}/{CollageID}")]
        public async Task<OperationResult<List<CommonDataModel_LandAreaMasterList_DepartmentWise>>> GetLandAreaMasterList_DepartmentWise(int DepartmentID, int CollageID)
        {
            var result = new OperationResult<List<CommonDataModel_LandAreaMasterList_DepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLandAreaMasterList_DepartmentWise(DepartmentID, CollageID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLandAreaMasterList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetTermAndConditionList_DepartmentWise/{departmentId}")]
        public async Task<OperationResult<List<CommonDataModel_TermAndCondition>>> GetTermAndConditionList_DepartmentWise(int departmentId)
        {
            var result = new OperationResult<List<CommonDataModel_TermAndCondition>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetTermAndConditionList_DepartmentWise(departmentId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetTermAndConditionList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAnnexureDataList_DepartmentWise/{departmentId}/{LandDocumentTypeID}/{LandConvertedID}")]
        public async Task<OperationResult<List<CommonDataModel_Annexure>>> GetAnnexureDataList_DepartmentWise(int departmentId, int LandDocumentTypeID, int LandConvertedID)
        {
            var result = new OperationResult<List<CommonDataModel_Annexure>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAnnexureDataList_DepartmentWise(departmentId, LandDocumentTypeID, LandConvertedID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAnnexureDataList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetQualificationMasterList_DepartmentWise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_QualificationMasterDepartmentWise>>> GetQualificationMasterList_DepartmentWise(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_QualificationMasterDepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetQualificationMasterList_DepartmentWise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetQualificationMasterList_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        //Deepak

        [HttpGet("GetCollegeWiseSubjectList/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_CollegeWiseSubject>>> GetCollegeWiseSubjectList(int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_CollegeWiseSubject>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeWiseSubjectList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeWiseSubjectList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetFacilitiesMasterList_DepartmentAndTypeWise/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>> GetFacilitiesMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetFacilitiesMasterList_DepartmentAndTypeWise(DepartmentID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetFacilitiesMasterList_DepartmentAndTypeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetFacilitesMinSize/{FacilitieID}")]
        public async Task<OperationResult<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>> GetFacilitesMinSize(int FacilitieID)
        {
            var result = new OperationResult<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetFacilitesMinSize(FacilitieID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetFacilitesMinSize", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetAssemblyAreaByDistrictId/{districtId}")]
        public async Task<OperationResult<List<CommonDataModel_AssemblyAreaDDL>>> GetAssembelyAreaByDistrictId(int districtId)
        {
            var result = new OperationResult<List<CommonDataModel_AssemblyAreaDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAssembelyAreaByDistrictId(districtId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAssembelyAreaByDistrictId", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetDashboardDataSSOWise/{SSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DashBoard>>> GetDashboardDataSSOWise(string SSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DashBoard>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDashboardDataSSOWise(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDashboardDataSSOWise", ex.ToString());
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