using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility;

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

        [HttpGet("CheckDocumentScrutinyTabsData/{ApplyNOCID}/{RoleID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID));
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

        [HttpPost("FinalSubmitPreVerification/{ApplyNOCID}/{DepartmentID}/{UserID}/{ActionName}")]
        public async Task<OperationResult<bool>> FinalSubmitPreVerification(int ApplyNOCID, int DepartmentID, int UserID, string ActionName)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AnimalDocumentScrutinyUtility.FinalSubmitPreVerification(ApplyNOCID, DepartmentID, UserID, ActionName));
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
    }
}
