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
using AspNetCore.Reporting;


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
        [HttpGet("GetDepartmentList_IsOpenNOCApplication")]
        public async Task<OperationResult<List<CommonDataModel_DepartmentMasterList>>> GetDepartmentList_IsOpenNOCApplication()
        {
            var result = new OperationResult<List<CommonDataModel_DepartmentMasterList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDepartmentList_IsOpenNOCApplication());
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

        [HttpGet("GetDepartmentList_IsOpenDefaulter")]
        public async Task<OperationResult<List<CommonDataModel_DepartmentMasterList>>> GetDepartmentList_IsOpenDefaulter()
        {
            var result = new OperationResult<List<CommonDataModel_DepartmentMasterList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDepartmentList_IsOpenDefaulter());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDepartmentList_IsOpenDefaulter", ex.ToString());
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
                result.State = OperationState.Error;
                result.ErrorMessage = ex.ToString();
                //CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetActionHeadList", ex.ToString());

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
        [HttpGet("GetAddCourseList_DepartmentIDWise/{DepartmentID}/{CourseLevelID}")]
        public async Task<OperationResult<List<CommonDataModel_CourseMaster>>> GetAddCourseList_DepartmentIDWise(int DepartmentID, int CourseLevelID)
        {
            var result = new OperationResult<List<CommonDataModel_CourseMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAddCourseList_DepartmentIDWise(DepartmentID, CourseLevelID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAddCourseList_DepartmentIDWise", ex.ToString());
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
        [HttpGet("GetCommonMasterList_DTEManagementType/{DepartmentID}/{Type}/{SSOID}")]
        public async Task<OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>> GetCommonMasterList_DTEManagementType(int DepartmentID, string Type, string SSOID)
        {
            var result = new OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCommonMasterList_DTEManagementType(DepartmentID, Type, SSOID));
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

        [HttpGet("GetUniversityByDepartmentId/{departmentId}/{IsLaw}")]
        public async Task<OperationResult<List<CommonDataModel_UniversityDDL>>> GetUniversityByDepartmentId(int departmentId, int IsLaw)
        {
            var result = new OperationResult<List<CommonDataModel_UniversityDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetUniversityByDepartmentId(departmentId, IsLaw));
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

        [HttpGet("GetAllFinancialYear_AcademicInformation/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_FinancialYearDDL>>> GetAllFinancialYear_AcademicInformation(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_FinancialYearDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAllFinancialYear_AcademicInformation(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAllFinancialYear_AcademicInformation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAllFinancialYear_OldNOC/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_FinancialYearDDL>>> GetAllFinancialYear_OldNOC(int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_FinancialYearDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAllFinancialYear_OldNOC(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAllFinancialYear_OldNOC", ex.ToString());
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
        public async Task<OperationResult<List<CommonDataModel_LandTypeMasterList_DepartmentWise>>> GetLandTypeMasterList_DepartmentWise(int DepartmentID, string Type)
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

        [HttpGet("GetCourseList_CollegeWise/{CollegID}/{CourseType}")]
        public async Task<OperationResult<List<CommonDataModel_CollegeWiseCourseList>>> GetCourseList_CollegeWise(int CollegID, string CourseType = "All")
        {
            var result = new OperationResult<List<CommonDataModel_CollegeWiseCourseList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseList_CollegeWise(CollegID, CourseType));
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


        [HttpGet("Get_CollegeWiseCourse_Subject_OldNOC/{CollegeID}/{Type}/{CourseID}/{OldNocID}")]
        public async Task<OperationResult<List<DataTable>>> Get_CollegeWiseCourse_Subject_OldNOC(int CollegeID, string Type, int CourseID, int OldNocID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.Get_CollegeWiseCourse_Subject_OldNOC(CollegeID, Type, CourseID, OldNocID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Get_CollegeWiseCourse_Subject_OldNOC", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetCollegeWise_SubjectList_StaffDetails/{CollegeID}/{Type}/{CourseID}")]
        public async Task<OperationResult<List<DataTable>>> GetCollegeWise_SubjectList_StaffDetails(int CollegeID, string Type, int CourseID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeWise_SubjectList_StaffDetails(CollegeID, Type, CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeWise_SubjectList_StaffDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCollegeWise_CourseList_AcademicInformation/{CollegeID}/{Type}/{CourseID}")]
        public async Task<OperationResult<List<DataTable>>> GetCollegeWise_CourseList_AcademicInformation(int CollegeID, string Type, int CourseID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeWise_CourseList_AcademicInformation(CollegeID, Type, CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeWise_CourseList_AcademicInformation", ex.ToString());
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

        [HttpGet("GetDesignation_OfficersDetails/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_DesignationDDL>>> GetDesignation_OfficersDetails(string Type)
        {
            var result = new OperationResult<List<CommonDataModel_DesignationDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDesignation_OfficersDetails(Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDesignation_OfficersDetails", ex.ToString());
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



        [HttpGet("GetCourseRoomSize/{CourseID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_CourseRoomSize>>> GetCourseRoomSize(int CourseID, int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_CourseRoomSize>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseRoomSize(CourseID, CollegeID));
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

        [HttpGet("OtherInformationList_DepartmentCollegeAndTypeWise/{DepartmentID}/{CollegeID}/{OtherInformationID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>> OtherInformationList_DepartmentCollegeAndTypeWise(int DepartmentID, int CollegeID, int OtherInformationID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.OtherInformationList_DepartmentCollegeAndTypeWise(DepartmentID, CollegeID, OtherInformationID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.OtherInformationList_DepartmentCollegeAndTypeWise", ex.ToString());
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





        [HttpGet("GetBuildingTypeCheck/{SelectedDepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_BuildingType>>> GetBuildingTypeCheck(int SelectedDepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_BuildingType>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetBuildingTypeCheck(SelectedDepartmentID));
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
        [HttpGet("GetlstMGOneIstheCampusUnitaryChk/{SelectedDepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_BuildingType>>> GetlstMGOneIstheCampusUnitaryChk(int SelectedDepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_BuildingType>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetlstMGOneIstheCampusUnitaryChk(SelectedDepartmentID));
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

        [HttpGet("GetBuildingUploadDetails/{DepartmentId}")]
        public async Task<OperationResult<List<CommonDataModel_BuildingUploadDoc>>> GetBuildingUploadDetails(int DepartmentId = 0)
        {
            var result = new OperationResult<List<CommonDataModel_BuildingUploadDoc>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetBuildingUploadDetails(DepartmentId));
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

        [HttpGet("GetQualificationMasterList_DepartmentWise/{DepartmentID}/{IsTeaching}/{Type}/{DesignationID}")]
        public async Task<OperationResult<List<CommonDataModel_QualificationMasterDepartmentWise>>> GetQualificationMasterList_DepartmentWise(int DepartmentID, int IsTeaching, string Type, int DesignationID)
        {
            var result = new OperationResult<List<CommonDataModel_QualificationMasterDepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetQualificationMasterList_DepartmentWise(DepartmentID, IsTeaching, Type, DesignationID));
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
        [HttpGet("GetFacilitiesMasterList_DepartmentCollegeAndTypeWise/{DepartmentID}/{CollegeID}/{FacilitieID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>> GetFacilitiesMasterList_DepartmentCollegeAndTypeWise(int DepartmentID, int CollegeID, int FacilitieID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetFacilitiesMasterList_DepartmentCollegeAndTypeWise(DepartmentID, CollegeID, FacilitieID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetFacilitiesMasterList_DepartmentCollegeAndTypeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetActivityMasterList_DepartmentCollegeAndTypeWise/{DepartmentID}/{CollegeID}/{FacilitieID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_ActivityMasterDepartmentAndTypeWise>>> GetActivityMasterList_DepartmentCollegeAndTypeWise(int DepartmentID, int CollegeID, int FacilitieID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_ActivityMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetActivityMasterList_DepartmentCollegeAndTypeWise(DepartmentID, CollegeID, FacilitieID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetActivityMasterList_DepartmentCollegeAndTypeWise", ex.ToString());
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



        [HttpGet("GetDashboardDataSSOWise/{SSOID}/{DepartmentID}/{RoleID}/{UserID}/{IsWeb=false}/{SessionYear=0}")]
        public async Task<OperationResult<List<CommonDataModel_DashBoard>>> GetDashboardDataSSOWise(string SSOID, int DepartmentID, int RoleID, int UserID, bool IsWeb = false, int SessionYear = 0)
        {
            var result = new OperationResult<List<CommonDataModel_DashBoard>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDashboardDataSSOWise(SSOID, DepartmentID, RoleID, UserID, IsWeb, SessionYear));
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





        [HttpGet("GetCollegeBasicDetails/{CollegID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCollegeBasicDetails(int CollegID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeBasicDetails(CollegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeBasicDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("CheckTabsEntry/{CollegID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckTabsEntry(int CollegID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.CheckTabsEntry(CollegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.CheckTabsEntry", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("CheckTabsEntry_StatisticsEntry/{CollegID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckTabsEntry_StatisticsEntry(int CollegID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.CheckTabsEntry_StatisticsEntry(CollegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.CheckTabsEntry_StatisticsEntry", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("DraftFinalSubmit")]
        public async Task<OperationResult<bool>> DraftFinalSubmit(CommonDataModel_CollegeDraftFinal request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.DraftFinalSubmit(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.IsDraftSubmited, "DraftFinalSubmit", request.CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Draft Final Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.DraftFinalSubmit", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("LOIFinalSubmit/{CollegeID}")]
        public async Task<OperationResult<bool>> LOIFinalSubmit(int CollegeID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.LOIFinalSubmit(CollegeID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "LOIFinalSubmit", CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Draft Final Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.LOIFinalSubmit", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpGet("GetTabFieldByTabName/{TabName}")]
        public async Task<OperationResult<List<CommonDataModel_TabField>>> GetTabFieldByTabName(string TabName)
        {
            var result = new OperationResult<List<CommonDataModel_TabField>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetTabFieldByTabName(TabName));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetTabFieldByTabName", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetRoleList")]
        public async Task<OperationResult<List<CommonDataModel_RoleListByLevel>>> GetRoleList()
        {
            var result = new OperationResult<List<CommonDataModel_RoleListByLevel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRoleList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRoleList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetRoleList_CreateUser")]
        public async Task<OperationResult<List<CommonDataModel_RoleListByLevel>>> GetRoleList_CreateUser()
        {
            var result = new OperationResult<List<CommonDataModel_RoleListByLevel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRoleList_CreateUser());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRoleList_CreateUser", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("Load_StateWise_DistrictMaster/{StateID}")]
        public async Task<OperationResult<List<CommonDataModel_DistrictList>>> Load_StateWise_DistrictMaster(int StateID)
        {
            var result = new OperationResult<List<CommonDataModel_DistrictList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.Load_StateWise_DistrictMaster(StateID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Load_StateWise_DistrictMaster", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetRoleListByLevelID/{LevelID}")]
        public async Task<OperationResult<List<CommonDataModel_RoleListByLevel>>> GetRoleListByLevelID(int LevelID)
        {
            var result = new OperationResult<List<CommonDataModel_RoleListByLevel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRoleListByLevelID(LevelID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRoleListByLevelID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCommitteeList")]
        public async Task<OperationResult<List<CommonDataModel_CommitteeList>>> GetCommitteeList()
        {
            var result = new OperationResult<List<CommonDataModel_CommitteeList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCommitteeList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCommitteeList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetConnectionString")]
        public async Task<OperationResult<List<CommonDataModel_GetConnectionString>>> GetConnectionString()
        {
            var result = new OperationResult<List<CommonDataModel_GetConnectionString>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetConnectionString());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Load_StateWise_DistrictMaster", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpGet("GetRoleListForApporval/{RoleID}/{DepartmentID}/{NOCType=NOC}")]
        public async Task<OperationResult<List<CommonDataModel_RoleListByLevel>>> GetRoleListForApporval(int RoleID, int DepartmentID, string NOCType)
        {
            var result = new OperationResult<List<CommonDataModel_RoleListByLevel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRoleListForApporval(RoleID, DepartmentID, NOCType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRoleListForApporval", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetUserDetailsByRoleID/{RoleID}/{DepartmentID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<CreateUserDataModel>>> GetUserDetailsByRoleID(int RoleID, int DepartmentID, int ApplyNOCID)
        {
            var result = new OperationResult<List<CreateUserDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetUserDetailsByRoleID(RoleID, DepartmentID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRoleListForApporval", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetWorkFlowActionListByRole/{RoleID}/{Type}/{DepartmentID}/{NOCType=NOC}/{ApplyNOCID=0}")]
        public async Task<OperationResult<List<CommonDataModel_WorkFlowActionsByRole>>> GetWorkFlowActionListByRole(int RoleID, string Type, int DepartmentID, string NOCType, int ApplyNOCID)
        {
            var result = new OperationResult<List<CommonDataModel_WorkFlowActionsByRole>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetWorkFlowActionListByRole(RoleID, Type, DepartmentID, NOCType, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetWorkFlowActionListByRole", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetRNCCheckListByTypeDepartment/{Type}/{DepartmentID}/{ApplyNOCID}/{CreatedBy}/{RoleID}")]
        public async Task<OperationResult<List<CommonDataModel_RNCCheckListData>>> GetRNCCheckListByTypeDepartment(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            var result = new OperationResult<List<CommonDataModel_RNCCheckListData>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRNCCheckListByTypeDepartment(Type, DepartmentID, ApplyNOCID, CreatedBy, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRNCCheckListByTypeDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetApplicationTrail_DepartmentApplicationWise/{ApplicationID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_ApplicationTrail>>> GetApplicationTrail_DepartmentApplicationWise(int ApplicationID, int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_ApplicationTrail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetApplicationTrail_DepartmentApplicationWise(ApplicationID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetApplicationTrail_DepartmentApplicationWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetUnlockApplicationTrail_DepartmentApplicationWise/{ApplicationID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_ApplicationTrail>>> GetUnlockApplicationTrail_DepartmentApplicationWise(int ApplicationID, int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_ApplicationTrail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetUnlockApplicationTrail_DepartmentApplicationWise(ApplicationID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetUnlockApplicationTrail_DepartmentApplicationWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCourseList_ByCourseLevelIDWise/{CourseLevelID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_CourseMaster>>> GetCourseList_ByCourseLevelIDWise(int CourseLevelID, int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_CourseMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseList_ByCourseLevelIDWise(CourseLevelID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseList_ByCourseLevelIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetStreamList_CourseIDWise/{DepartmentID}/{CourseLevelID}/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_Stream>>> GetStreamList_CourseIDWise(int DepartmentID, int CourseLevelID, int CourseID)
        {
            var result = new OperationResult<List<CommonDataModel_Stream>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetStreamList_CourseIDWise(DepartmentID, CourseLevelID, CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRNCCheckListByTypeDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetSubjectList_StreamIDWise/{StreamID}/{DepartmentID}/{CourseLevelID}/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_SubjectMaster>>> GetSubjectList_StreamIDWise(int StreamID, int DepartmentID, int CourseLevelID, int CourseID)
        {
            var result = new OperationResult<List<CommonDataModel_SubjectMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSubjectList_StreamIDWise(StreamID, DepartmentID, CourseLevelID, CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSubjectList_StreamIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCollegeWiseCourseList/{CollegID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCollegeWiseCourseList(int CollegID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeWiseCourseList(CollegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeWiseCourseList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetCollegeWiseCourseIDSubjectList/{CollegeID}/{CollegeWiseCourseID}/{ViewMode}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCollegeWiseCourseIDSubjectList(int CollegeID, int CollegeWiseCourseID, string ViewMode)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeWiseCourseIDSubjectList(CollegeID, CollegeWiseCourseID, ViewMode));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeBasicDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetStreamMasterList/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetStreamMasterList(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetStreamMasterList(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetStreamMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetMappedStreamListByID/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetMappedStreamListByID(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMappedStreamListByID(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMappedStreamListByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetCourseByStreamID/{StreamID}/{DepartmentID}/{CourseLevelID}/{UniversityID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCourseByStreamID(int StreamID, int DepartmentID, int CourseLevelID, int UniversityID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseByStreamID(StreamID, DepartmentID, CourseLevelID, UniversityID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseByStreamID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetLandSqureMeterMappingDetails_DepartmentWise/{DepartmentID}/{CollageID}/{LandAreaId}")]
        public async Task<OperationResult<List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise>>> GetLandSqureMeterMappingDetails_DepartmentWise(int DepartmentID, int CollageID, int LandAreaId)
        {
            var result = new OperationResult<List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLandSqureMeterMappingDetails_DepartmentWise(DepartmentID, CollageID, LandAreaId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLandSqureMeterMappingDetails_DepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetDocumentScritintyTaril/{ID}/{NOCApplyID}/{CollageID}/{DepartmentID}/{ActionType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDocumentScritintyTaril(int ID, int NOCApplyID, int CollageID, int DepartmentID, string ActionType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDocumentScritintyTaril(ID, NOCApplyID, CollageID, DepartmentID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeBasicDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetStaffDesignation/{IsTeaching}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetStaffDesignation(int IsTeaching, int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetStaffDesignation(IsTeaching, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetStaffDesignation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetLandTypeDetails_CollegeWise/{DepartmentID}/{Type}/{LandDetailID}")]
        public async Task<OperationResult<List<CollegeLandTypeDetailsDataModel>>> GetLandTypeDetails_CollegeWise(int DepartmentID, string Type, int LandDetailID)
        {
            var result = new OperationResult<List<CollegeLandTypeDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLandTypeDetails_CollegeWise(DepartmentID, Type, LandDetailID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLandTypeDetails_CollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetUniversityDepartmentWise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_UniversityDDL>>> GetUniversityDepartmentWise(int DepartmentId)
        {
            var result = new OperationResult<List<CommonDataModel_UniversityDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetUniversityDepartmentWise(DepartmentId));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetUniversityDepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSubjectDepartmentWise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_SubjectMaster>>> GetSubjectDepartmentWise(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_SubjectMaster>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSubjectDepartmentWise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSubjectDepartmentWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCollegeInspectionFee/{CollegID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCollegeInspectionFee(int CollageID, int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeInspectionFee(CollageID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeInspectionFee", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetCollegeLandConversionDetail/{DepartmentID}/{LandDetailID}/{Type}")]
        public async Task<OperationResult<List<CollegeLandConversionDetailsDataModel>>> GetCollegeLandConversionDetail(int DepartmentID, int LandDetailID, string Type)
        {
            var result = new OperationResult<List<CollegeLandConversionDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeLandConversionDetail(DepartmentID, LandDetailID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeLandConversionDetail", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCommonMasterList_DepartmentAndTypeWises/{DepartmentID}/{CollageID}/{Type}")]
        public async Task<OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>> GetCommonMasterList_DepartmentAndTypeWises(int DepartmentID, int CollageID, string Type)
        {
            var result = new OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCommonMasterList_DepartmentAndTypeWises(DepartmentID, CollageID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCommonMasterList_DepartmentAndTypeWises", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetCityByDistrict/{DistrictID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCityByDistrict(int DistrictID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCityByDistrict(DistrictID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCityByDistrict", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetNOCApplicationStepList/{ApplyNocID}/{CurrentActionID}/{DepartmentID}/{ActionType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetNOCApplicationStepList(int ApplyNocID, int CurrentActionID, int DepartmentID, string ActionType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetNOCApplicationStepList(ApplyNocID, CurrentActionID, DepartmentID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetNOCApplicationStepList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetDownloadPdfDetails/{DepartmentID}/{CollageID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDownloadPdfDetails(int DepartmentID, int CollageID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDownloadPdfDetails(DepartmentID, CollageID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDownloadPdfDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetOldNOCCourseList_CollegeWise/{CollegID}")]
        public async Task<OperationResult<List<CommonDataModel_CollegeWiseCourseList>>> GetOldNOCCourseList_CollegeWise(int CollegID)
        {
            var result = new OperationResult<List<CommonDataModel_CollegeWiseCourseList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetOldNOCCourseList_CollegeWise(CollegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetOldNOCCourseList_CollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("CheckExistsDETGovernmentCollege/{SSOID}")]
        public async Task<OperationResult<List<DataTable>>> CheckExistsDETGovernmentCollege(string SSOID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.CheckExistsDETGovernmentCollege(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.CheckExistsDETGovernmentCollege", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("Get_LOIFeeMaster/{DepartmentID}")]
        public async Task<OperationResult<List<DataTable>>> Get_LOIFeeMaster(int DepartmentID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.Get_LOIFeeMaster(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.Get_LOIFeeMaster", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetPaymentMode")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPaymentMode()
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetPaymentMode());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetPaymentMode", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetCollegeID_SearchRecordIDWise/{SearchRecordID}")]
        public async Task<OperationResult<CommonDataModel_CollegeID_SearchRecordIDWise>> GetCollegeID_SearchRecordIDWise(string SearchRecordID)
        {
            var result = new OperationResult<CommonDataModel_CollegeID_SearchRecordIDWise>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeID_SearchRecordIDWise(SearchRecordID));
                result.State = OperationState.Success;
                if (result != null)
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

        [HttpGet("GetUsersByRoleDepartment/{DepartmentID}/{RoleID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetUsersByRoleDepartment(int DepartmentID, int RoleID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetUsersByRoleDepartment(DepartmentID, RoleID));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetUsersByRoleDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetWorkFlowStatusbyDepartment/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetWorkFlowStatusbyDepartment(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetWorkFlowStatusbyDepartment(DepartmentID));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetWorkFlowStatusbyDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetApplyNOCParameterbyDepartment/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplyNOCParameterbyDepartment(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetApplyNOCParameterbyDepartment(DepartmentID));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetApplyNOCParameterbyDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("WebsiteDetails")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> WebsiteDetails()
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.WebsiteDetails());
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.WebsiteDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("Enc_Text")]
        public string Enc_Text(string ID)
        {
            string Text = "";
            try
            {
                Text = CommonHelper.Encrypt(ID);

            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.WebsiteDetails", ex.ToString());
                Text = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return Text;
        }

        [HttpPost("GetTotalApplicationListByDepartment")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetTotalApplicationListByDepartment(CommonDataModel_TotalApplicationSearchFilter request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetTotalApplicationListByDepartment(request));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetTotalApplicationListByDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("GetPreviousTotalApplicationListByDepartment")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPreviousTotalApplicationListByDepartment(CommonDataModel_TotalApplicationSearchFilter request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetPreviousTotalApplicationListByDepartment(request));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetPreviousTotalApplicationListByDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetLOIApplicationTrail/{ApplicationID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_ApplicationTrail>>> GetLOIApplicationTrail(int ApplicationID, int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_ApplicationTrail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLOIApplicationTrail(ApplicationID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLOIApplicationTrail", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetLOIDocumentScritintyTaril/{ID}/{NOCApplyID}/{CollageID}/{DepartmentID}/{ActionType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetLOIDocumentScritintyTaril(int ID, int NOCApplyID, int CollageID, int DepartmentID, string ActionType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLOIDocumentScritintyTaril(ID, NOCApplyID, CollageID, DepartmentID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLOIDocumentScritintyTaril", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetSocietyByCollege/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetSocietyByCollege(int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSocietyByCollege(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSocietyByCollege", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetIntakeByCollegeCourse/{CollegeID}/{CourseID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetIntakeByCollegeCourse(int CollegeID, int CourseID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetIntakeByCollegeCourse(CollegeID, CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetIntakeByCollegeCourse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetProgrammeByCollegeDTE/{CollegeID}/{GetType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetProgrammeByCollegeDTE(int CollegeID, string GetType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetProgrammeByCollegeDTE(CollegeID, GetType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetProgrammeByCollegeDTE", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCourseLevelByCollegeDTE/{CollegeID}/{GetType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCourseLevelByCollegeDTE(int CollegeID, string GetType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseLevelByCollegeDTE(CollegeID, GetType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseLevelByCollegeDTE", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCourseByCollegeProgrammeDTE/{CollegeID}/{ProgrammeID}/{CourseLevelID}/{GetType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCourseByCollegeProgrammeDTE(int CollegeID, int ProgrammeID, int CourseLevelID, string GetType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCourseByCollegeProgrammeDTE(CollegeID, ProgrammeID, CourseLevelID, GetType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCourseByCollegeProgrammeDTE", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetCollegeDeficiency/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCollegeDeficiency(int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeDeficiency(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeDeficiency", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpPost("SSOUpdateSubmit/{CollegeID}/{SSOID}")]
        public async Task<OperationResult<bool>> SSOUpdateSubmit(int CollegeID, string SSOID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SSOUpdateSubmit(CollegeID, SSOID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "SSO UpdateSubmit", CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "SSO Update successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Same SSOID Already Exist.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SSOUpdateSubmit", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("{CollegeID}/{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetSSOByCollegeIDWise(int CollegeID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", CollegeID, "CommonFuncation");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetSSOByCollegeIDWise(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetSSOByCollegeIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("HomePage_IncreaseDate/{DepartmentID}/{Type}")]
        public async Task<OperationResult<List<DataTable>>> HomePage_IncreaseDate(int DepartmentID,string Type)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "HomePage_IncreaseDate", 0, "CommonFuncation");
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.HomePage_IncreaseDate(DepartmentID,Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.HomePage_IncreaseDate", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GetOnlinePaymentDetailsByDepartment")]
        public async Task<OperationResult<List<DataTable>>> GetOnlinePaymentDetailsByDepartment(PaymentDetailsDataModel_Filter request)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetOnlinePaymentDetailsByDepartment(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetOnlinePaymentDetailsByDepartment", request.DepartmentID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error in get data !";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetOnlinePaymentDetailsByDepartment", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("GetTotalDraftentryCollege")]
        public async Task<OperationResult<List<DataTable>>> GetTotalDraftentryCollege(CommonDataModel_TotalDraftEntrySearchFilter request)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetTotalDraftentryCollege(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetTotalDraftentryCollege", request.DepartmentID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error in get data !";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetTotalDraftentryCollege", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetDeficiencyAction/{ApplyNOCID}/{RoleID}")]
        public async Task<OperationResult<List<DataTable>>> GetDeficiencyAction(int ApplyNOCID, int RoleID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDeficiencyAction(ApplyNOCID, RoleID));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetDeficiencyAction", ApplyNOCID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error in get data !";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDeficiencyAction", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetApplicationCountRoleWise/{DepartmentID}/{SessionYear=0}")]
        public async Task<OperationResult<List<DataTable>>> GetApplicationCountRoleWise(int DepartmentID, int SessionYear = 0)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetApplicationCountRoleWise(DepartmentID, SessionYear));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetApplicationCountRoleWise", DepartmentID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error in get data !";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetApplicationCountRoleWise", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetLegelEntityDepartmentWise/{DepartmentID}/{Type=NA}")]
        public async Task<OperationResult<List<DataTable>>> GetLegelEntityDepartmentWise(int DepartmentID,string Type="NA")
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetLegelEntityDepartmentWise(DepartmentID,Type));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetLegelEntityDepartmentWise", DepartmentID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error in get data !";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetLegelEntityDepartmentWise", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }










        /// <summary>
        /// 
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>

        [HttpGet("ConvertBaseIntoImage")]
        public async Task<OperationResult<bool>> ConvertBaseIntoImage()
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.ConvertBaseIntoImage());
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error in get data !";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.ConvertBaseIntoImage", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("SaveNOCFormatMaster")]
        public async Task<OperationResult<bool>> SaveNOCFormatMaster(CommonDataModel_NOCFormatMaster request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveNOCFormatMaster(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.DepartmentID, "SaveNOCFormatMaster", request.NOCFormatID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "NOC Format Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveNOCFormatMaster", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetNOCFormatList/{NOCFormatID}")]
        public async Task<OperationResult<List<DataTable>>> GetNOCFormatList(int NOCFormatID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetNOCFormatList(NOCFormatID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetNOCFormatList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("UnlockApplication")]
        public async Task<OperationResult<bool>> UnlockApplication(UnlockApplicationDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.UnlockApplication(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.CreatedBy, "UnlockApplication", request.ApplyNOCID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Application Unlock successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.UnlockApplication", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("GetCollegeTabData_History")]
        public async Task<OperationResult<List<CommonDataModel_DataSet>>> GetCollegeTabData_History(CommonDataModel_TabHistory request)
        {
            var result = new OperationResult<List<CommonDataModel_DataSet>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetCollegeTabData_History(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetCollegeTabData_History", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetDashBoardFinancialYear")]
        public async Task<OperationResult<List<CommonDataModel_FinancialYearDDL>>> GetDashBoardFinancialYear()
        {
            var result = new OperationResult<List<CommonDataModel_FinancialYearDDL>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDashBoardFinancialYear());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDashBoardFinancialYear", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetAHDepartmentList")]
        public async Task<OperationResult<List<DataTable>>> GetAHDepartmentList()
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAHDepartmentList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAHDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetAHFacilityDepartmentList/{DepartmentID}/{CollegeID}")]
        public async Task<OperationResult<List<AHDepartmentDataModel>>> GetAHFacilityDepartmentList(int DepartmentID, int CollegeID)
        {
            var result = new OperationResult<List<AHDepartmentDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAHFacilityDepartmentList(DepartmentID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetAHFacilityDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("SaveAHDepartmentInfrastructure")]
        public async Task<OperationResult<bool>> SaveAHDepartmentInfrastructure(AHDepartmentDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveAHDepartmentInfrastructure(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.CollegeID, "SaveAHDepartmentInfrastructure", request.CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveAHDepartmentInfrastructure", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("CheckAHStaff/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataSet>>> CheckAHStaff(int CollegeID)
        {
            var result = new OperationResult<List<CommonDataModel_DataSet>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.CheckAHStaff(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SocietyMasterController.CheckAHStaff", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetStartDateEndDateDepartmentwise/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DepartmentWiseStartDateEndDate>>> GetStartDateEndDateDepartmentwise(int DepartmentID)
        {
            var result = new OperationResult<List<CommonDataModel_DepartmentWiseStartDateEndDate>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetStartDateEndDateDepartmentwise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetStartDateEndDateDepartmentwise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetDTEAffiliationApply/{SSOID}")]
        public async Task<OperationResult<List<CommonDataModel_DTEAffiliationApply>>> GetDTEAffiliationApply(string SSOID)
        {
            var result = new OperationResult<List<CommonDataModel_DTEAffiliationApply>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDTEAffiliationApply(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDTEAffiliationApply", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetAffiliationRegistrationList/{SSOID}")]
        public async Task<OperationResult<List<CommonDataModel_RegistrationDTEAffiliationApply>>> GetAffiliationRegistrationList(string SSOID)
        {
            var result = new OperationResult<List<CommonDataModel_RegistrationDTEAffiliationApply>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetAffiliationRegistrationList(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDTEAffiliationApply", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetDteAffiliation_SearchRecordIDWise/{SearchRecordID}")]
        public async Task<OperationResult<CommonDataModel_RegistrationDTEAffiliationApply>> GetDteAffiliation_SearchRecordIDWise(string SearchRecordID)
        {
            var result = new OperationResult<CommonDataModel_RegistrationDTEAffiliationApply>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDteAffiliation_SearchRecordIDWise(SearchRecordID));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDteAffiliation_SearchRecordIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetMGOneDepartmentList")]
        public async Task<OperationResult<List<DataTable>>> GetMGOneDepartmentList()
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMGOneDepartmentList());
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMGOneDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetMGOneFacilityDepartmentList/{DepartmentID}/{CollegeID}")]
        public async Task<OperationResult<List<MGOneDepartmentDataModel>>> GetMGOneFacilityDepartmentList(int DepartmentID, int CollegeID)
        {
            var result = new OperationResult<List<MGOneDepartmentDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMGOneFacilityDepartmentList(DepartmentID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMGOneFacilityDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("SaveMGOneDepartmentInfrastructure")]
        public async Task<OperationResult<bool>> SaveMGOneDepartmentInfrastructure(MGOneDepartmentDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveMGOneDepartmentInfrastructure(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.CollegeID, "SaveMGOneDepartmentInfrastructure", request.CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveMGOneDepartmentInfrastructure", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("OtherInformationList_CourseID/{CourseID}/{CollegeID}/{OtherInformationID}")]
        public async Task<OperationResult<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>> OtherInformationList_CourseID(int CourseID, int CollegeID, int OtherInformationID)
        {
            var result = new OperationResult<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.OtherInformationList_CourseID(CourseID, CollegeID, OtherInformationID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.OtherInformationList_CourseID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("SaveApplyNOCDocument")]
        public async Task<OperationResult<bool>> SaveApplyNOCDocument(ApplyNOCDocument_DataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveApplyNOCDocument(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.ApplyNOCID, "SaveApplyNOCDocument", request.ApplyNOCID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveApplyNOCDocument", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveApplyNOCDocumentList")]
        public async Task<OperationResult<bool>> SaveApplyNOCDocumentList(List<ApplyNOCDocument_DataModel> request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveApplyNOCDocumentList(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request[0].ApplyNOCID, "SaveApplyNOCDocumentList", request[0].ApplyNOCID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveApplyNOCDocumentList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GetApplyNOCDocumentList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplyNOCDocumentList(ApplyNOCDocumentFilter_DataModel request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetApplyNOCDocumentList(request));
                if (result.Data.Count>0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.ApplyNOCID, "GetApplyNOCDocumentList", request.ApplyNOCID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data fetch successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetApplyNOCDocumentList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetMGOneClinicalLabDetails/{CollegeID}")]
        public async Task<OperationResult<List<MGOneClinicalLabDataModel>>> GetMGOneClinicalLabDetails(int CollegeID)
        {
            var result = new OperationResult<List<MGOneClinicalLabDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMGOneClinicalLabDetails(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMGOneClinicalLabDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveMGOneClinicalLabDetails")]
        public async Task<OperationResult<bool>> SaveMGOneClinicalLabDetails(List<MGOneClinicalLabDataModel> request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveMGOneClinicalLabDetails(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request[0].CollegeID, "SaveMGOneDepartmentInfrastructure", request[0].CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveMGOneDepartmentInfrastructure", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetMGOneClassRoomDepartmentList/{DepartmentID}/{CollegeID}")]
        public async Task<OperationResult<List<MGOneClassRoomDepartmentDataModel>>> GetMGOneClassRoomDepartmentList(int DepartmentID, int CollegeID)
        {
            var result = new OperationResult<List<MGOneClassRoomDepartmentDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMGOneClassRoomDepartmentList(DepartmentID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMGOneClassRoomDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveMGOneDepartmentClassRoom")]
        public async Task<OperationResult<bool>> SaveMGOneClassRoomDetails(List<MGOneClassRoomDepartmentDataModel> request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveMGOneClassRoomDetails(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request[0].CollegeID, "SaveMGOneDepartmentInfrastructure", request[0].CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveMGOneDepartmentInfrastructure", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetMGOneFacilityList/{DepartmentID}/{CollegeID}")]
        public async Task<OperationResult<List<MGOneFacilityDataModel>>> GetMGOneFacilityList(int DepartmentID, int CollegeID)
        {
            var result = new OperationResult<List<MGOneFacilityDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMGOneFacilityList(DepartmentID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMGOneFacilityList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetMGoneFacilityEach/{CollegeID}")]
        public async Task<OperationResult<List<DataTable>>> GetMGoneFacilityEach(int CollegeID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMGoneFacilityEach(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMGoneFacilityEach", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("SaveMGoneFacilityEach")]
        public async Task<OperationResult<bool>> SaveMGoneFacilityEach(List<MGOneFacilityEachDataModel> request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveMGoneFacilityEach(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request[0].CollegeID, "SaveMGoneFacilityEach", request[0].CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveMGoneFacilityEach", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveMGOneFacility")]
        public async Task<OperationResult<bool>> SaveMGOneFacility(List<MGOneFacilityDataModel> request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveMGOneFacility(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request[0].CollegeID, "SaveSaveMGOneFacility", request[0].CollegeID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.SaveMGOneFacility", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetWorkflowPermissions/{DepartmentID}/{RoleID}")]
        public async Task<OperationResult<List<DataTable>>> GetWorkflowPermissions(int DepartmentID, int RoleID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetWorkflowPermissions(DepartmentID, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetWorkflowPermissions", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("Assessment_Print/{CollegeID}")]
        public IActionResult Assessment_Print(int CollegeID)
        {

            DataSet dataset = UtilityHelper.CommonFuncationUtility.GetMGoneASSESSMENTREPORT(CollegeID);

            string mimetype = "";
            int extension = 1;
            var path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\Assessmentreport_Print.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
            parameters.Add("test", "");
            LocalReport lr = new LocalReport(path);
            lr.AddDataSource("Assessment", dataset.Tables[0]);
            lr.AddDataSource("ASSESSMENT_Facility", dataset.Tables[1]);
            lr.AddDataSource("ASSESSMENT_FacilityDetailsforMuseum", dataset.Tables[2]);
            lr.AddDataSource("ASSESSMENT_DemonstrationRoomallthedepartment", dataset.Tables[3]);
            // lr.AddDataSource("ASSESSMENT_departmentwiseinfrastructure", dataset.Tables[4]);
            lr.AddDataSource("ASSESSMENT_ClinicalMaterialFacilities", dataset.Tables[4]);
            lr.AddDataSource("ASSESSMENT_DissectionHall", dataset.Tables[5]);
            lr.AddDataSource("ASSESSMENT_Skillslaboratory", dataset.Tables[6]);
            lr.AddDataSource("ASSESSMENT_Centralresearchlab", dataset.Tables[7]);
            lr.AddDataSource("ASSESSMENT_ClassRoomDetails", dataset.Tables[8]);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }
        [HttpGet("GetNOCFormat/{DepartmentID}/{CollegeID}/{ParameterID}/{NOCFor}")]
        public async Task<OperationResult<List<DataTable>>> GetNOCFormat(int DepartmentID, int CollegeID, int ParameterID, string NOCFor)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetNOCFormat(DepartmentID, CollegeID, ParameterID, NOCFor));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetNOCFormatList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("CheckCollegestatusIDWise/{DTEAffiliationID}")]
        public async Task<OperationResult<CommonDataModel_RegistrationDTEAffiliationApply>> CheckCollegestatusIDWise(int DTEAffiliationID)
        {
            var result = new OperationResult<CommonDataModel_RegistrationDTEAffiliationApply>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.CheckCollegestatusIDWise(DTEAffiliationID));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.CheckCollegestatusIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("CheckTabsEntryAffiliation/{DTEAffiliationID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckTabsEntryAffiliation(int DTEAffiliationID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.CheckTabsEntryAffiliation(DTEAffiliationID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.CheckTabsEntryAffiliation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }       
         [HttpGet("GetBTERCollegeBasicDetails/{DTEAffiliationID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetBTERCollegeBasicDetails(int DTEAffiliationID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetBTERCollegeBasicDetails(DTEAffiliationID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetBTERCollegeBasicDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetDownloadBTERPdfDetails/{DepartmentID}/{AffiliationRegID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetDownloadBTERPdfDetails(int DepartmentID, int AffiliationRegID)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetDownloadBTERPdfDetails(DepartmentID, AffiliationRegID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetDownloadPdfDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }       
        [HttpPost("BTERAffiliationFinalSubmit/{EnterInwordNo}/{ApplicationDateofReceived}/{SelectedDepartmentID}/{SelectedDTEAffiliationID}/{selectedApplicationNo}/{SelectedCollageID}/{ActionName}")]
        public async Task<OperationResult<bool>> BTERAffiliationFinalSubmit(string EnterInwordNo,string ApplicationDateofReceived,int SelectedDepartmentID,int SelectedDTEAffiliationID,string selectedApplicationNo,int SelectedCollageID,string ActionName)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.BTERAffiliationFinalSubmit(EnterInwordNo,ApplicationDateofReceived,SelectedDepartmentID,SelectedDTEAffiliationID,selectedApplicationNo,SelectedCollageID, ActionName));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "BTERAffiliationFinalSubmit", SelectedCollageID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = " Application Received successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.BTERAffiliationFinalSubmit", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetRevert_SearchRecordIDWiseDetails/{SearchRecordID}")]
        public async Task<OperationResult<CommonDataModel_RevertAffiliationApply>> GetRevert_SearchRecordIDWiseDetails(string SearchRecordID)
        {
            var result = new OperationResult<CommonDataModel_RevertAffiliationApply>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetRevert_SearchRecordIDWiseDetails(SearchRecordID));
                result.State = OperationState.Success;
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetRevert_SearchRecordIDWiseDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetBTERRevertApllicationRemark/{DepartmentID}/{ApplicationID}")]
        public async Task<OperationResult<List<DataTable>>> GetRevertApllicationRemark(int DepartmentID, int ApplicationID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetBTERRevertApllicationRemark(DepartmentID, ApplicationID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetBTERRevertApllicationRemark", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("BTEROrderGen/{GenOrderNumber}")]
        public  IActionResult BTEROrderGen(string GenOrderNumber)
        {
            DataSet dataset = UtilityHelper.CommonFuncationUtility.BTEROrderGen(GenOrderNumber);

            string mimetype = "";
            int extension = 1;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var fileName = System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff") + ".pdf";
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF");

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filepath = Path.Combine(directoryPath, fileName);
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;

            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BTERAffiliationOrderGenPDF.rdlc");
            LocalReport lr = new LocalReport(reportPath);
            lr.AddDataSource("BTERAffiliationOrderList", dataset.Tables[0]);
            lr.AddDataSource("BTERAffiliationOrderListClosed", dataset.Tables[1]);

            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

            // Save the file to the specified path
            System.IO.File.WriteAllBytes(filepath, result.MainStream);
            var pdfPathListResult =  UpdateGeneratedBTERPDF(fileName, GenOrderNumber);
            return File(System.IO.File.ReadAllBytes(filepath), "application/pdf", fileName);
        }
        [HttpGet("UpdateGeneratedBTERPDF")]
        public async Task<OperationResult<List<CommonDataModel_BTEROrderList>>> UpdateGeneratedBTERPDF(string fileName, string GenOrderNumber)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(GenOrderNumber))
            {
                throw new ArgumentException("fileName or GenOrderNumber is null or empty!");
            }

            // Proceed with logic
            var result = new OperationResult<List<CommonDataModel_BTEROrderList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.UpdateGeneratedBTERPDF(fileName, GenOrderNumber));
                result.State = OperationState.Success;
            }
            catch (Exception ex)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        [HttpGet("ChecSSOIDwiseLegalEntityDepartment/{SSOID}")]
        public async Task<OperationResult<List<DataTable>>> ChecSSOIDwiseLegalEntityDepartment(string SSOID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.ChecSSOIDwiseLegalEntityDepartment(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.ChecSSOIDwiseLegalEntityDepartment", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("UpdateInspectionFDRIntimationAH")]
        public async Task<OperationResult<bool>> UpdateInspectionFDRIntimationAH(UpdateIntimationInspectionFDRDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.UpdateInspectionFDRIntimationAH(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.ApplyNOCID, "UpdateInspectionFDRIntimationAH", request.ApplyNOCID, "CommonFuncation");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.UpdateInspectionFDRIntimationAH", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("SendMessage/{MobileNo}/{MessageType}/{ID=0}")]
        public async Task<OperationResult<string>> SendMessage(string MobileNo, string MessageType, int ID = 0)
        {
            var result = new OperationResult<string>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SendMessage(MobileNo, MessageType, ID));

                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("SMSMailController.SendOTP", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetMobileNumberSMSforwardnextlevel/{CollegID}/{ActionName}/{NextUserID}/{NextRoleID}")]
        public async Task<OperationResult<List<LOIMGOneSMSForwardnextlevel_DataTable>>> GetMobileNumberSMSforwardnextlevel(string CollegID, string ActionName, int NextUserID, int NextRoleID)
        {
            var result = new OperationResult<List<LOIMGOneSMSForwardnextlevel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetMobileNumberSMSforwardnextlevel(CollegID, ActionName, NextUserID, NextRoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetMobileNumberSMSforwardnextlevel", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("SendMessageMGOne/{MobileNo}/{MessageType}")]
        public async Task<OperationResult<string>> SendMessageMGOne(string MobileNo, string MessageType)
        {
            var result = new OperationResult<string>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SendMessageMGOne(MobileNo, MessageType));

                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("SMSMailController.SendMessageMGOne", ex.ToString());
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