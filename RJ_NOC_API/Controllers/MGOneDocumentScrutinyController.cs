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
    [Route("api/MGOneDocumentScrutiny")]
    [ApiController]
    public class MGOneDocumentScrutinyController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public MGOneDocumentScrutinyController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("DocumentScrutiny_LandDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID));
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
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type));
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


        [HttpPost("DocumentScrutiny_HospitalDetail/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>>> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_HospitalDetail(CollageID, RoleID, ApplyNOCID));
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


        [HttpPost("DocumentScrutiny_CollegeManagementSociety/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID));
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
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID));
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
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID));
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

        [HttpPost("DocumentScrutiny_BuildingDetails/{CollageID}/{RoleID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentBuildingDetails>>> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            var result = new OperationResult<List<MGOneDocumentScrutinyDataModel_DocumentBuildingDetails>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID));
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

        [HttpGet("CheckDocumentScrutinyTabsData/{ApplyNOCID}/{RoleID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID)
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID, CollegeID));
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

        [HttpGet("GetLOIApplicationList/{RoleID}/{UserID}/{Status}/{ActionName}")]
        public async Task<OperationResult<List<LOIApplicationDetails_DataModel>>> GetLOIApplicationList(int RoleID, int UserID, string Status, string ActionName)
        {
            var result = new OperationResult<List<LOIApplicationDetails_DataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.GetLOIApplicationList(RoleID, UserID, Status, ActionName));
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

        [HttpGet("GeneratePDF_MedicalGroupLOIC/{LOIFinalSubmitID}")]
        public async Task<OperationResult<bool>> GeneratePDF_MedicalGroupLOIC(int LOIFinalSubmitID)
        {
            var result = new OperationResult<bool>();
            try
            {

                LocalReport localReport = null;
                List<DCENOCPDFPathDataModel> PdfPathList = new List<DCENOCPDFPathDataModel>();
                DataSet dataset = new DataSet();
                dataset = UtilityHelper.MGOneScrutinyUtility.GeneratePDF_MedicalGroupLOICData(LOIFinalSubmitID);

                StringBuilder sb = new StringBuilder();
                var fileName = "MedicalGroupLOIC_" + System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff") + ".pdf";
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);
                string mimetype = "";
                int extension = 1;
                string ReportPath = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports"));

                dataset.Tables[0].Rows[0]["LOIQRCode"] = CommonHelper.GenerateQrCode(dataset.Tables[0].Rows[0]["LOIQRCodeLink"].ToString());
                ReportPath += "\\MedicalGroupLOI.rdlc";
                localReport = new LocalReport(ReportPath);
                localReport.AddDataSource("MedicalGroupLOI", dataset.Tables[0]);


                //Dictionary<string, string> parameters = new Dictionary<string, string>();
                //string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
                //parameters.Add("test", "");
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                var pdfResult = localReport.Execute(RenderType.Pdf, extension, null, mimetype);
                System.IO.File.WriteAllBytes(filepath, pdfResult.MainStream);

                result.State = OperationState.Success;
                result.SuccessMessage = "LOI PDF Generated Successfully .!";
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("MGOneDocumentScrutiny.GeneratePD_FMedicalGroupLOIC", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpGet("MedicalGroupLOIIssuedReport/{LoginUserID}/{RoleID}")]
        public async Task<OperationResult<List<DataTable>>> MedicalGroupLOIIssuedReport(int LoginUserID,int RoleID)
        {
            var result = new OperationResult<List<DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneScrutinyUtility.MedicalGroupLOIIssuedReport(LoginUserID,RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("MGOneDocumentScrutiny.MedicalGroupLOIIssuedReport", ex.ToString());
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

