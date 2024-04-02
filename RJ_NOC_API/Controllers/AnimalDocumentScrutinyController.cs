using iTextSharp.text.pdf;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using static RJ_NOC_API.Controllers.ApplyNOCController;
using System.Text;
using iTextSharp.text;
using iTextSharp.tool.xml.parser;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
using RJ_NOC_Utility.CustomerDomain;
using AspNetCore.Reporting;
using System.Data;

namespace RJ_NOC_API.Controllers
{
    [Route("api/AnimalDocumentScrutiny")]
    [ApiController]
    public class AnimalDocumentScrutinyController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public AnimalDocumentScrutinyController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("DocumentScrutiny_LegalEntity/{CollegeID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity>>> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_LegalEntity", e.ToString());
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
        public async Task<OperationResult<List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_CollegeDetail", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_CollegeManagementSociety", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_LandDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_LandDetails", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail>>> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_FacilityDetail", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocuemntScrutinyCommonModel>>> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            var result = new OperationResult<List<AnimalDocuemntScrutinyCommonModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_CollegeDocument", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails>>> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_RoomDetail", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails>>> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_BuildingDetails", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails>>> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_StaffDetails", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails>>> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_OldNOCDetails", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_AcademicInformation", e.ToString());
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
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_OtherInformation", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_VeterinaryHospital/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital>>> DocumentScrutiny_VeterinaryHospital(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.DocumentScrutiny_VeterinaryHospital(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.DocumentScrutiny_VeterinaryHospital", e.ToString());
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
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.CheckDocumentScrutinyTabsData", ex.ToString());
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
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetPhysicalVerificationAppliationList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetPhysicalVerificationAppliationList", 0, "AnimalDocumentScrutinyController");
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPhysicalVerificationAppliationList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("FinalSubmitInspectionCommittee/{ApplyNOCID}/{DepartmentID}/{UserID}/{ActionName}")]
        public async Task<OperationResult<bool>> FinalSubmitInspectionCommittee(int ApplyNOCID, int DepartmentID, int UserID, string ActionName)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.FinalSubmitInspectionCommittee(ApplyNOCID, DepartmentID, UserID, ActionName));
                if (result.Data == true)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "FinalSubmitInspectionCommittee", 0, "AnimalDocumentScrutinyController");
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.FinalSubmitInspectionCommittee", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("GetPreVerificationDoneList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPreVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetPreVerificationDoneList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetPreVerificationDoneList", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetPreVerificationDoneList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPreVerificationDoneList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetPreVerificationchecklistDetails/{Type}/{DepartmentID}/{ApplyNOCID}/{CreatedBy}/{RoleID}")]
        public async Task<OperationResult<List<CommonDataModel_RNCCheckListData>>> GetPreVerificationchecklistDetails(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            var result = new OperationResult<List<CommonDataModel_RNCCheckListData>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetPreVerificationchecklistDetails(Type, DepartmentID, ApplyNOCID, CreatedBy, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPreVerificationchecklistDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("FinalSubmitPreVerification/{ApplyNOCID}/{DepartmentID}/{UserID}/{ActionName}/{Remarks}")]
        public async Task<OperationResult<bool>> FinalSubmitPreVerification(int ApplyNOCID, int DepartmentID, int UserID, string ActionName, string Remarks)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.FinalSubmitPreVerification(ApplyNOCID, DepartmentID, UserID, ActionName, Remarks));
                if (result.Data == true)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "FinalSubmitPreVerification", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in FinalSubmitPreVerification";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.FinalSubmitPreVerification", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetNOCApplicationList/{UserID}/{RoleID}/{DepartmentID}/{ActionType}")]
        public async Task<OperationResult<List<ApplyNocApplicationDetails_DataModel>>> GetNOCApplicationList(int UserID, int RoleID, int DepartmentID, string ActionType)
        {
            var result = new OperationResult<List<ApplyNocApplicationDetails_DataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetApplyNOCApplicationList(RoleID, UserID, DepartmentID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPreVerificationchecklistDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("GetPostVerificationAppliationList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPostVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetPostVerificationAppliationList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetPreVerificationDoneList", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetPreVerificationDoneList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPreVerificationDoneList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GetPostVerificationDoneList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPostVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetPostVerificationDoneList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetPostVerificationDoneList", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetPostVerificationDoneList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPostVerificationDoneList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GetFinalVerificationAppliationList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetFinalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetFinalVerificationAppliationList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetPreVerificationDoneList", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetPreVerificationDoneList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetPreVerificationDoneList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GetFinalVerificationDoneList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetFinalVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetFinalVerificationDoneList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetFinalVerificationDoneList", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetFinalVerificationDoneList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetFinalVerificationDoneList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GetFinalNOCApplicationList")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetFinalNOCApplicationList(GetPhysicalVerificationAppliationList request)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetFinalNOCApplicationList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "GetFinalNOCApplicationList", 0, "AnimalDocumentScrutinyController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in GetFinalNOCApplicationList";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetFinalNOCApplicationList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetNOCCourse/{ApplyNocID}/{DepartmentID}/{CollegeID}/{ActionType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetNOCCourse(int ApplyNocID, int DepartmentID, int CollegeID, string ActionType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.GetNOCCourse(ApplyNocID, DepartmentID, CollegeID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutinyController.GetNOCCourse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("UpdateNOCPDFData/{ApplyNocID}/{DepartmentID}/{CollegeID}/{ActionType}/{UserId}/{RoleID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> UpdateNOCPDFData(int ApplyNocID, int DepartmentID, int CollegeID, string ActionType, int UserId, int RoleID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(ApplyNocID, "UpdateNOCPDFData", DepartmentID, "AanimalController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                if (await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.SaveNOCIssueData(ApplyNocID, DepartmentID, CollegeID, ActionType)))
                {
                    string Path = GeneratePDF(ApplyNocID);
                    if (!string.IsNullOrEmpty(Path))
                    {
                        if (await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.FinalSavePDFPathandNOC(Path, ApplyNocID, DepartmentID, RoleID, UserId, "", "UpdateGeneratePDF")))
                        {
                            result.State = OperationState.Success;
                            result.SuccessMessage = "PDF Generate Successfully .!";
                        }
                        else
                        {
                            result.State = OperationState.Warning;
                            result.SuccessMessage = "There was an error Generate PDF!";
                        }
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "There was an error Generate PDF!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutiny.UpdateNOCPDFData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("FinalNOCRejectRelese")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> FinalNOCRejectRelese(GenerateNOC_DataModel request)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "FinalNOCRejectRelese", request.ApplyNOCID, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                bool success = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.FinalSavePDFPathandNOC("", request.ApplyNOCID, request.DepartmentID, 0, request.UserID, request.NOCIssuedRemark, request.Status));
                if (success)
                {
                    result.Data = new List<CommonDataModel_DataTable>();
                    result.State = OperationState.Success;
                    if (request.Status == "Release NOC")
                        result.SuccessMessage = "NOC Relesed Successfully .!";
                    else
                        result.SuccessMessage = "NOC Rejected Successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "There was an error Generate PDF!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AnimalDocumentScrutiny.FinalNOCRejectRelese", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        private string GeneratePDF(int ApplyNOCID)
        {
            StringBuilder sb = new StringBuilder();
            List<CommonDataModel_DataTable> dt = UtilityHelper.AnimalDocumentScrutinyUtility.GetGeneratePDFData(ApplyNOCID, 0, 0, "GetDataForPDF");

            var fileName = Guid.NewGuid().ToString().Replace("/", "").Replace("-", "").ToUpper() + ".pdf";
            StringBuilder sbhtml = new StringBuilder();
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);
            var path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\AHNOC_Print.rdlc";
            if (dt[0].data.Rows.Count > 0)
            {
                dt[0].data.Rows[0]["NocQRCode"] = CommonHelper.GenerateQrCode(dt[0].data.Rows[0]["NocQRCodeLink"].ToString());
                if (dt[0].data.Rows[0]["CollegeLevel"].ToString() == "Diploma" && dt[0].data.Rows[0]["CollegeType"].ToString() == "New")
                {
                    path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\AHNOC_DiplomaNew_Print.rdlc";
                }
            }
            string mimetype = "";
            int extension = 1;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("test", "");
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("AHNOCPrint", dt[0].data);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            System.IO.File.WriteAllBytes(filepath, result.MainStream);

            //string CollegeName = dt[0].data.Rows[0]["CollegeName"].ToString();
            //string CollegeMobileNo = dt[0].data.Rows[0]["CollegeMobileNo"].ToString();
            //string CollegeEmail = dt[0].data.Rows[0]["CollegeEmail"].ToString();
            //string ApplicationTypeName = dt[0].data.Rows[0]["ApplicationTypeName"].ToString();
            //string TotalFeeAmount = dt[0].data.Rows[0]["TotalFeeAmount"].ToString();
            //string ApplicationStatus = dt[0].data.Rows[0]["ApplicationStatus"].ToString();
            //string DepartmentName = dt[0].data.Rows[0]["DepartmentName"].ToString();
            //string ApplicationNo = dt[0].data.Rows[0]["ApplicationNo"].ToString();
            //DateTime now = DateTime.Now.Date;
            //var Date = now.ToString("dd-MM-yyyy");

            //{
            //    sb.Clear();
            //    sb.Append("<table style='width:100%;'>");
            //    sb.Append("<tr><td style='text-align:center'><h1 style='margin-bottom:0px;'>" + DepartmentName + "</h1></td></tr>");
            //    sb.Append("<tr><td style='text-align:center'><h4 style='margin-bottom:0px;'>No Objection Certificate</h4></td></tr>");
            //    sb.Append("<tr><td style='text-align:center'><h6 style='margin-bottom:0px;'>" + CollegeName + " Apply For " + ApplicationTypeName + "</h6></td></tr>");
            //    sb.Append("<tr><td height='30px;'></td></tr>");
            //    sb.Append("<tr><td style='text-align:right'><b>Application No. : </b> " + ApplicationNo + "</td></tr>");
            //    sb.Append("<tr><td style='text-align:right'><b>Contact No. : </b>" + CollegeMobileNo + "</td></tr>");
            //    sb.Append("<tr><td style='text-align:right'><b>Email : </b>" + CollegeEmail + "</td></tr>");
            //    sb.Append("<tr><td style='text-align:right'><b>Date : </b>" + Date + "</td></tr>");
            //    sb.Append("<tr><td height='30px;'></td></tr>");
            //    sb.Append("<tr><td><b>Total Fee Amount : </b>" + TotalFeeAmount + "</td></tr>");
            //    sb.Append("<tr><td height='30px;'></td></tr>");
            //    sb.Append("<tr><td><p>NOC has been issued to "+ CollegeName + " College of Animal Husbandry Department. I have no objection to this, I am marking it with my seal.</p></td></tr>");
            //    //sb.Append("<tr><td><p></p></td></tr>");
            //    //sb.Append("<tr><td><p>sdgfomsdfgomdsfg osdgmf fsogm dsfgom dsfgomd fsgmofg mdsfgm dsg</p></td></tr>");
            //    sb.Append("<tr><td height='30px;'></td></tr>");
            //    sb.Append("<tr><td height='30px;'></td></tr>");
            //    sb.Append("<tr><td height='30px;'></td></tr>");
            //    sb.Append("<tr><td style='text-align:right'><b>Signature</b></td></tr>");
            //    sb.Append("</table>");
            //}
            //}

            //sbhtml.Append(UnicodeToKrutidev.FindAndReplaceKrutidev(sb.ToString().Replace("<br>", "<br/>"), true, "15px"));
            //string filepath = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile/" + fileName);
            //Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 50f, 50f, 50f, 70f);
            //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filepath, FileMode.Create));
            //try
            //{
            //    pdfDoc.Open();
            //    var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
            //    tagProcessors.RemoveProcessor(HTML.Tag.IMG);
            //    tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor());
            //    var cssFiles = new CssFilesImpl();
            //    cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
            //    var cssResolver = new StyleAttrCSSResolver(cssFiles);
            //    var charset = System.Text.Encoding.UTF8;
            //    var context = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
            //    context.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors);
            //    var htmlPipeline = new HtmlPipeline(context, new PdfWriterPipeline(pdfDoc, writer));
            //    var cssPipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
            //    var worker = new XMLWorker(cssPipeline, true);
            //    var xmlParser = new XMLParser(true, worker, charset);
            //    using (var sr = new StringReader(sbhtml.ToString()))
            //    {
            //        xmlParser.Parse(sr);
            //        pdfDoc.Close();
            //        writer.Close();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    pdfDoc.Close();
            //    writer.Close();
            //    throw ex;
            //}

            return fileName;

        }
    }
}
