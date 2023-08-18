using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/AgricultureDocumentScrutiny")]
    [ApiController]
    public class AgricultureDocumentScrutinyController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public AgricultureDocumentScrutinyController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("DocumentScrutiny_LegalEntity/{CollegeID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity>>> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_LegalEntity", e.ToString());
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
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_CollegeDetail", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_CollegeManagementSociety", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_LandDetails", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail>>> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_FacilityDetail", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocuemntScrutinyCommonModel>>> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            var result = new OperationResult<List<AgricultureDocuemntScrutinyCommonModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_CollegeDocument", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails>>> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_RoomDetail", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails>>> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_BuildingDetails", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails>>> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_StaffDetails", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails>>> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_OldNOCDetails", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_AcademicInformation", e.ToString());
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
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_OtherInformation", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DocumentScrutiny_FarmLandDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails>>> DocumentScrutiny_FarmLandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.DocumentScrutiny_FarmLandDetails(CollageID, RoleID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.DocumentScrutiny_FarmLandDetails", e.ToString());
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
                result.Data = await Task.Run(() => UtilityHelper.AgricultureDocumentScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("AgricultureDocumentScrutinyController.CheckDocumentScrutinyTabsData", ex.ToString());
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
