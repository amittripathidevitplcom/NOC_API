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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_API.Controllers
{
    [Route("api/DepartmentOfTechnicalDocumentScrutiny")]
    [ApiController]
    public class DepartmentOfTechnicalDocumentScrutinyController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DepartmentOfTechnicalDocumentScrutinyController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("DocumentScrutiny_LandDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_LandDetails", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DocumentScrutiny_CollegeDocument/{DepartmentID}/{CollageID}/{RoleID}/{ApplyNOCID}/{Type}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_CollegeDocument", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_OtherInformation/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_OtherInformation", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_HostelDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>>> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_HostelDetail(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_HostelDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DocumentScrutiny_FacilityDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail>>> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_FacilityDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("DocumentScrutiny_AcademicInformation/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_AcademicInformation", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_CollegeManagementSociety/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_LegalEntity/{CollegeID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_LegalEntity", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_CollegeDetail/{CollegeID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_CollegeDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_RoomDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails>>> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_RoomDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DocumentScrutiny_BuildingDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails>>> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_BuildingDetails", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DocumentScrutiny_StaffDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails>>> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_StaffDetails", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("DocumentScrutiny_OldNOCDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails>>> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_OldNOCDetails", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_CourseDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCourseDetail>>> DocumentScrutiny_CourseDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCourseDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CourseDetails(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.DocumentScrutiny_CourseDetails", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("CheckDocumentScrutinyTabsData/{ApplyNOCID}/{RoleID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutiny.CheckDocumentScrutinyTabsData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetApplyNOCApplicationList/{RoleID}/{UserID}/{Status}/{ActionName}")]
        public async Task<OperationResult<List<ApplyNocApplicationDetails_DataModel>>> GetApplyNOCApplicationList(int RoleID, int UserID, string Status, string ActionName)
        {
            var result = new OperationResult<List<ApplyNocApplicationDetails_DataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.GetApplyNOCApplicationList(RoleID, UserID, Status, ActionName));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOftechnicalDocumentScrutiny.GetApplyNOCApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("WorkflowInsertDTE")]
        public async Task<OperationResult<bool>> WorkflowInsertDTE(DocumentScrutinySave_DataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.WorkflowInsertDTE(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "WorkflowInsertDTE", request.ApplyNOCID, "DTE");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error forward application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.WorkflowInsertDTE", e.ToString());
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

