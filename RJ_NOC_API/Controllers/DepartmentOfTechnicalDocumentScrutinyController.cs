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
using AspNetCore.Reporting;

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

        [HttpPost("DocumentScrutiny_LandDetails/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID, VerificationStep));
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
        [HttpPost("DocumentScrutiny_CollegeDocument/{DepartmentID}/{CollageID}/{RoleID}/{ApplyNOCID}/{Type}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type, VerificationStep));
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

        [HttpPost("DocumentScrutiny_OtherInformation/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID, VerificationStep));
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

        [HttpPost("DocumentScrutiny_HostelDetail/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>>> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_HostelDetail(CollageID, RoleID, ApplyNOCID, VerificationStep));
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
        [HttpPost("DocumentScrutiny_FacilityDetail/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail>>> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID, VerificationStep));
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


        [HttpPost("DocumentScrutiny_AcademicInformation/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID, VerificationStep));
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

        [HttpPost("DocumentScrutiny_CollegeManagementSociety/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID, VerificationStep));
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

        [HttpPost("DocumentScrutiny_LegalEntity/{CollegeID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID, VerificationStep));
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

        [HttpPost("DocumentScrutiny_CollegeDetail/{CollegeID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID, VerificationStep));
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

        [HttpPost("DocumentScrutiny_RoomDetail/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails>>> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID, VerificationStep));
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
        [HttpPost("DocumentScrutiny_BuildingDetails/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails>>> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID, VerificationStep));
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
        [HttpPost("DocumentScrutiny_StaffDetails/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails>>> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID, VerificationStep));
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
        [HttpPost("DocumentScrutiny_OldNOCDetails/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails>>> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID, VerificationStep));
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

        [HttpPost("DocumentScrutiny_CourseDetails/{CollageID}/{RoleID}/{ApplyNOCID}/{VerificationStep}")]
        public async Task<OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCourseDetail>>> DocumentScrutiny_CourseDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            var result = new OperationResult<List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCourseDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.DocumentScrutiny_CourseDetails(CollageID, RoleID, ApplyNOCID, VerificationStep));
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
        [HttpGet("CheckDocumentScrutinyTabsData/{ApplyNOCID}/{RoleID}/{CollegeID}/{VerificationStep}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID, string VerificationStep)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID, CollegeID, VerificationStep));
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
        public async Task<OperationResult<List<DataTable>>> GetApplyNOCApplicationList(int RoleID, int UserID, string Status, string ActionName)
        {
            var result = new OperationResult<List<DataTable>>();
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
                    result.ErrorMessage = "There was an error in application";
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

        [HttpPost("GeneratePDF_DTENOC")]
        public async Task<OperationResult<bool>> GeneratePDF_DTENOC(GenerateDTENOCPDFDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {

                LocalReport localReport = null;
                List<DCENOCPDFPathDataModel> PdfPathList = new List<DCENOCPDFPathDataModel>();
                DataSet dataset = new DataSet();

                StringBuilder sb = new StringBuilder();
                var fileName = request.IsNOCIssued == 1 ? "DTENOC_" + System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff") + ".pdf" : "";
                int IsIssuedLOI = request.IsNOCIssued == null ? 0 : request.IsNOCIssued.Value;
                if (await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.SavePDFPath(fileName, request.ApplyNOCID, request.UserID, request.Remark, IsIssuedLOI)))
                {
                    if (request.IsNOCIssued == 1)
                    {
                        dataset = UtilityHelper.DepartmentOfTechnicalScrutinyUtility.GeneratePDF_DTENOCData(request);
                        string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);
                        string mimetype = "";
                        int extension = 1;
                        string ReportPath = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports"));

                        //dataset.Tables[0].Rows[0]["LOIQRCode"] = CommonHelper.GenerateQrCode(dataset.Tables[0].Rows[0]["LOIQRCodeLink"].ToString());
                        ReportPath += "\\HTENOC_Print.rdlc";
                        localReport = new LocalReport(ReportPath);
                        //localReport.AddDataSource("MedicalGroupLOI", dataset.Tables[0]);


                        //Dictionary<string, string> parameters = new Dictionary<string, string>();
                        //string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
                        //parameters.Add("test", "");
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                        var pdfResult = localReport.Execute(RenderType.Pdf, extension, null, mimetype);
                        System.IO.File.WriteAllBytes(filepath, pdfResult.MainStream);
                        result.State = OperationState.Success;
                        result.SuccessMessage = "NOC PDF Generated Successfully .!";
                    }
                    else
                    {
                        result.State = OperationState.Success;
                        result.SuccessMessage = "NOC Reject Successfully .!";
                    }
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.GeneratePDF_DTENOC", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("PdfEsign/{ApplyNOCID}/{CreatedBy}")]
        public async Task<OperationResult<bool>> PdfEsign(int ApplyNOCID, int CreatedBy)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.PdfEsign(ApplyNOCID, CreatedBy));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Esign successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "error in data save.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.PdfEsign", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("GenerateReceipt")]
        public async Task<OperationResult<bool>> GenerateReceipt(GenerateDocument_DTE request)
        {
            var result = new OperationResult<bool>();
            try
            {

                LocalReport localReport = null;
                List<DCENOCPDFPathDataModel> PdfPathList = new List<DCENOCPDFPathDataModel>();
                DataSet ds = new DataSet();

                StringBuilder sb = new StringBuilder();
                var fileName = "DTENOCRECEIPT_" + System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff") + ".pdf";

                ds = UtilityHelper.DepartmentOfTechnicalScrutinyUtility.GenerateReceipt(request);
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);
                string mimetype = "";
                int extension = 1;
                string ReportPath = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports"));

                //dataset.Tables[0].Rows[0]["LOIQRCode"] = CommonHelper.GenerateQrCode(dataset.Tables[0].Rows[0]["LOIQRCodeLink"].ToString());
                ReportPath += "\\GenerateReceipt_DTE.rdlc";
                localReport = new LocalReport(ReportPath);
                ds.Tables[0].Rows[0]["ApplicationNoAndSubmitDate"]=ds.Tables[0].Rows[0]["ApplicationNoAndSubmitDate"].ToString().Replace("||", System.Environment.NewLine).Replace("#","    ");
                ds.Tables[0].Rows[0]["AppliedNOC"] = ds.Tables[0].Rows[0]["AppliedNOC"].ToString().Replace("||", System.Environment.NewLine).Replace("#", "    ");
                ds.Tables[0].Rows[0]["NameAddressEmailPhone"] = ds.Tables[0].Rows[0]["NameAddressEmailPhone"].ToString().Replace("||", System.Environment.NewLine).Replace("#", "    ");

                localReport.AddDataSource("GenerateReceiptDataSet", ds.Tables[0]);
                localReport.AddDataSource("GeneralDetails_DTE", ds.Tables[1]);


                //Dictionary<string, string> parameters = new Dictionary<string, string>();
                //string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
                //parameters.Add("test", "");
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                var pdfResult = localReport.Execute(RenderType.Pdf, extension, null, mimetype);
                System.IO.File.WriteAllBytes(filepath, pdfResult.MainStream);
                request.DocumentName = fileName;
                if (await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.SaveGenerateReceiptPDFPath(request)))
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Receipt Generated Successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error In Receipt Generation .!";
                }



            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.GenerateReceipt", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("ReceiptPdfEsign/{ApplyNOCID}/{CreatedBy}")]
        public async Task<OperationResult<bool>> ReceiptPdfEsign(int ApplyNOCID, int CreatedBy)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.ReceiptPdfEsign(ApplyNOCID, CreatedBy));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Esign successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "error in data save.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.ReceiptPdfEsign", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("GenerateConsolidatedReport")]
        public async Task<OperationResult<bool>> GenerateConsolidatedReport(GenerateDocument_DTE request)
        {
            var result = new OperationResult<bool>();
            try
            {

                LocalReport localReport = null;
                DataSet ds = new DataSet();

                StringBuilder sb = new StringBuilder();
                var fileName = "DTEConsolidatedReport_" + System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff") + ".pdf";

                ds = UtilityHelper.DepartmentOfTechnicalScrutinyUtility.GetConsolidatedReportData(request);
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);
                string mimetype = "";
                int extension = 1;
                string ReportPath = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports"));

                //dataset.Tables[0].Rows[0]["LOIQRCode"] = CommonHelper.GenerateQrCode(dataset.Tables[0].Rows[0]["LOIQRCodeLink"].ToString());
                ReportPath += "\\ConsolidatedReport_DTE.rdlc";
                localReport = new LocalReport(ReportPath);
                ds.Tables[0].Rows[0]["ApplicationNoAndSubmitDate"] = ds.Tables[0].Rows[0]["ApplicationNoAndSubmitDate"].ToString().Replace("||", System.Environment.NewLine).Replace("#", "    ");
                ds.Tables[0].Rows[0]["AppliedNOC"] = ds.Tables[0].Rows[0]["AppliedNOC"].ToString().Replace("||", System.Environment.NewLine).Replace("#", "    ");
                ds.Tables[0].Rows[0]["NameAddressEmailPhone"] = ds.Tables[0].Rows[0]["NameAddressEmailPhone"].ToString().Replace("||", System.Environment.NewLine).Replace("#", "    ");

                localReport.AddDataSource("GenerateReceiptDataSet", ds.Tables[0]);
                localReport.AddDataSource("GeneralDetails_DTE", ds.Tables[1]);


                //Dictionary<string, string> parameters = new Dictionary<string, string>();
                //string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
                //parameters.Add("test", "");
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                var pdfResult = localReport.Execute(RenderType.Pdf, extension, null, mimetype);
                System.IO.File.WriteAllBytes(filepath, pdfResult.MainStream);
                request.DocumentName = fileName;
                if (await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.SaveConsolidatedReportPDFPath(request)))
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Consolidated Report Generated Successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Error In Consolidated Report Generation .!";
                }



            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.GenerateReceipt", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetConsolidatedReportByApplyNOCID/{ApplyNOCID}")]
        public async Task<OperationResult<List<DataTable>>> GetConsolidatedReportByApplyNOCID(int ApplyNOCID)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "AcademicInformationDetails");
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.GetConsolidatedReportByApplyNOCID( ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.GetConsolidatedReportByApplyNOCID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("UploadConsolidatedReport")]
        public async Task<OperationResult<bool>> UploadConsolidatedReport(GenerateDocument_DTE request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.UploadConsolidatedReport(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "upload successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "error in upload Consolidated Report.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.UploadConsolidatedReport", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("UploadInspectionReport")]
        public async Task<OperationResult<bool>> UploadInspectionReport(GenerateDocument_DTE request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentOfTechnicalScrutinyUtility.UploadInspectionReport(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "upload successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "error in upload Inspection Report.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentOfTechnicalDocumentScrutinyController.UploadInspectionReport", e.ToString());
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

