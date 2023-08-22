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
    [Route("api/DepartmentOfCollegeDocumentScrutiny")]
    [ApiController]
    public class DepartmentOfCollegeDocumentScrutinyController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DepartmentOfCollegeDocumentScrutinyController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("DocumentScrutiny_LandDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_LandDetails", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_CollegeDocument", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_OtherInformation", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>>> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_HostelDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_HostelDetail", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentFacilityDetail>>> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentFacilityDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_FacilityDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_HospitalDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>>> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_HospitalDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_HospitalDetail", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_AcademicInformation", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_LegalEntity", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_CollegeDetail", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentRoomDetails>>> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentRoomDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_RoomDetail", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentBuildingDetails>>> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentBuildingDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_BuildingDetails", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentStaffDetails>>> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentStaffDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_StaffDetails", e.ToString());
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
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentOldNOCDetails>>> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentOldNOCDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_OldNOCDetails", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("CheckDocumentScrutinyTabsData/{ApplyNOCID}/{RoleID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckDocumentScrutinyTabsData(int ApplyNOCID,int RoleID)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID,RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.CheckDocumentScrutinyTabsData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_ParamedicalHospitalDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail>>> DocumentScrutiny_ParamedicalHospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_ParamedicalHospitalDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_ParamedicalHospitalDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetNodalOfficerApplyNOCApplicationList/{RoleID}/{UserID}")]
        public async Task<OperationResult<List<ApplyNocApplicationDetails_DataModel>>> GetNodalOfficerApplyNOCApplicationList(int RoleID, int UserID)
        {
            var result = new OperationResult<List<ApplyNocApplicationDetails_DataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.GetNodalOfficerApplyNOCApplicationList(RoleID, UserID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.GetNodalOfficerApplyNOCApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetApplicationPvDetails/{ApplyNOCID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplicationPvDetails(int ApplyNOCID)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.GetApplicationPvDetails(ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.CheckDocumentScrutinyTabsData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpPost("GetPhysicalVerificationAppliationList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.GetPhysicalVerificationAppliationList(request));
                if (result.Data.Count>0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetPhysicalVerificationAppliationList", 0, "DepartmentOfCollegeDocumentScrutiny");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetPhysicalVerificationAppliationList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.GetPhysicalVerificationAppliationList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("FinalSubmitInspectionCommittee/{ApplyNOCID}")]
        public async Task<OperationResult<bool>> FinalSubmitInspectionCommittee(int ApplyNOCID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.FinalSubmitInspectionCommittee(ApplyNOCID));
                if (result.Data ==true)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "FinalSubmitInspectionCommittee", 0, "DepartmentOfCollegeDocumentScrutiny");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in FinalSubmitInspectionCommittee";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.FinalSubmitInspectionCommittee", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("DocumentScrutiny_ClassWiseStudentDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyClassWiseStudentDetails>>> DocumentScrutiny_ClassWiseStudentDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyClassWiseStudentDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_ClassWiseStudentDetail(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "error in data loading.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_ClassWiseStudentDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_SubjectWiseStudentDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinySubjectWiseStudentDetails>>> DocumentScrutiny_SubjectWiseStudentDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinySubjectWiseStudentDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfCollegeScrutinyUtility.DocumentScrutiny_SubjectWiseStudentDetail(CollageID, RoleID, ApplyNOCID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "error in data loading.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfCollegeDocumentScrutiny.DocumentScrutiny_SubjectWiseStudentDetail", e.ToString());
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

