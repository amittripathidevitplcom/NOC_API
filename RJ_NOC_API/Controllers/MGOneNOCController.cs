using AspNetCore.Reporting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Repository;
using RJ_NOC_Model;
using System.Text;

namespace RJ_NOC_API.Controllers
{
    [Route("api/MGOneNOC")]
    [ApiController]
    public class MGOneNOCController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public MGOneNOCController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetNOCApplicationList/{UserID}/{RoleID}/{Status}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetNOCApplicationList(int UserID, int RoleID, string Status)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetNOCApplicationList", 0, "MGOneNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data =  UtilityHelper.MGOneNOC.GetNOCApplicationList(RoleID, UserID, Status);
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
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOCController.GetNOCApplicationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveNOCWorkFlow")]
        public async Task<OperationResult<bool>> SaveNOCWorkFlow(DocumentScrutinySave_DataModel_MGOne request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneNOC.SaveNOCWorkFlow(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "SaveNOCWorkFlow", request.ApplyNOCID, "MGOneNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOC.SaveNOCWorkFlow", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveNOCWorkFlowDock")]
        public async Task<OperationResult<bool>> SaveNOCWorkFlowDock(DocumentSave_DataModel_MGOne request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneNOC.SaveNOCWorkFlowDock(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "SaveNOCWorkFlowDock", request.ApplyNOCID, "MGOneNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOC.SaveNOCWorkFlowDock", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetNOCWorkFlowDock/{ApplyNOCID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetNOCWorkFlowDock(int ApplyNOCID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetNOCWorkFlowDock", 0, "MGOneNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneNOC.GetNOCWorkFlowDock(ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOCController.GetNOCWorkFlowDock", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveInspectionReport")]
        public async Task<OperationResult<bool>> SaveInspectionReport(InspectionReport_DataModel_MGOne request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneNOC.SaveInspectionReport(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "SaveInspectionReport", request.ApplyNOCID, "MGOneNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOC.SaveInspectionReport", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("GenerateOrderForInspectionReport")]
        public async Task<OperationResult<bool>> GenerateOrderForInspectionReport(InspectionReport_DataModel_MGOne request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MGOneNOC.GenerateOrderForInspectionReport(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "GenerateOrderForInspectionReport", request.ApplyNOCID, "MGOneNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOC.GenerateOrderForInspectionReport", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("FinalNOCRejectRelese")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> FinalNOCRejectRelese(GenerateNOC_DataModel_MGOne request)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "FinalNOCRejectRelese", request.ApplyNOCID, "MGOneNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                bool success = await Task.Run(() => UtilityHelper.MGOneNOC.FinalSavePDFPathandNOC("", request.ApplyNOCID, request.DepartmentID, 0, request.UserID, request.NOCIssuedRemark,request.Status,request.ActionID,request.NextRoleID,request.NextUserID));
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
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOCController.FinalNOCRejectRelese", ex.ToString());
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
            CommonDataAccessHelper.Insert_TrnUserLog(ApplyNocID, "UpdateNOCPDFData", DepartmentID, "MGOneNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                if (await Task.Run(() => UtilityHelper.MGOneNOC.SaveNOCIssueData(ApplyNocID, DepartmentID, CollegeID, ActionType)))
                {
                    string Path = GeneratePDF(ApplyNocID);
                    if (!string.IsNullOrEmpty(Path))
                    {
                        if (await Task.Run(() => UtilityHelper.MGOneNOC.FinalSavePDFPathandNOC(Path, ApplyNocID, DepartmentID, RoleID, UserId, "", "UpdateGeneratePDF")))
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
                CommonDataAccessHelper.Insert_ErrorLog("MGOneNOCController.UpdateNOCPDFData", ex.ToString());
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
            List<CommonDataModel_DataTable> dt = UtilityHelper.MGOneNOC.GetGeneratePDFData(ApplyNOCID, 0, 0, "GetDataForPDF");

            var fileName = Guid.NewGuid().ToString().Replace("/", "").Replace("-", "").ToUpper() + ".pdf";
            StringBuilder sbhtml = new StringBuilder();
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);
            var path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\MGOneNOC_Print.rdlc";
            if (dt[0].data.Rows.Count > 0)
            {
                dt[0].data.Rows[0]["NocQRCode"] = CommonHelper.GenerateQrCode(dt[0].data.Rows[0]["NocQRCodeLink"].ToString());
            }
            string mimetype = "";
            int extension = 1;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("test", "");
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("MGOneNOCPrint", dt[0].data);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            System.IO.File.WriteAllBytes(filepath, result.MainStream);

            return fileName;

        }
    }
}

