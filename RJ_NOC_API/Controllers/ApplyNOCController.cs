using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
using javax.annotation;
using System.Text;
using RJ_NOC_Utility;
using iTextSharp.text.pdf;
using iTextSharp.text;

using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Primitives;
using java.util;
using System.Data;
using AspNetCore.Reporting;
using sun.security.util;
using System.Security.Permissions;
using System.Security;
using QRCoder;
using System.Drawing;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ApplyNOC")]
    [ApiController]
    public class ApplyNOCController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;

        public ApplyNOCController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("GetApplyNOCApplicationListByRole/{RoleID}/{UserID}/{DepartmentID}")]
        public async Task<OperationResult<List<ApplyNOCDataModel>>> GetApplyNOCApplicationListByRole(int RoleID, int UserID, int DepartmentID)
        {
            var result = new OperationResult<List<ApplyNOCDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCApplicationListByRole(RoleID, UserID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetApplyNOCApplicationListByRole", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("DocumentScrutiny")]
        public async Task<OperationResult<bool>> DocumentScrutiny(DocumentScrutinySave_DataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.DocumentScrutiny(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "DocumentScrutiny", request.ApplyNOCID, "ApplyNOC");
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.DocumentScrutiny", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveDocumentScrutiny")]
        public async Task<OperationResult<bool>> SaveDocumentScrutiny(DocumentScrutinyDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.SaveDocumentScrutiny(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.ApplyNOCID, "SaveDocumentScrutiny", 0, "ApplyNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save document scrutiny";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.SaveDocumentScrutiny", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDocumentScrutinyData_TabNameCollegeWise/{TabName}/{CollegeID}/{RoleID}")]
        public async Task<OperationResult<List<DocumentScrutinyDataModel>>> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID, int RoleID)
        {
            var result = new OperationResult<List<DocumentScrutinyDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetDocumentScrutinyData_TabNameCollegeWise(TabName, CollegeID, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetDocumentScrutinyData_TabNameCollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetRevertApplyNOCApplicationDepartmentRoleWise/{DepartmentID}/{RoleID}")]
        public async Task<OperationResult<List<ApplyNocParameterDataModel>>> GetRevertApplyNOCApplicationDepartmentRoleWise(int DepartmentID, int RoleID)
        {
            var result = new OperationResult<List<ApplyNocParameterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetRevertApplyNOCApplicationDepartmentRoleWise(DepartmentID, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetDocumentScrutinyData_TabNameCollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveCommiteeInspectionRNCCheckList")]
        public async Task<OperationResult<bool>> SaveCommiteeInspectionRNCCheckList(List<CommiteeInspection_RNCCheckList_DataModel> request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.SaveCommiteeInspectionRNCCheckList(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.FirstOrDefault().CreatedBy, "SaveCommiteeInspectionRNCCheckList", 0, "ApplyNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "save successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error save Commitee Inspection";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.SaveCommiteeInspectionRNCCheckList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetApplyNOCRejectedReport/{UserID}/{ActionName}/{RoleID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplyNOCRejectedReport(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetApplyNOCRejectedReport", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCRejectedReport(UserID, ActionName, RoleID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetApplyNOCRejectedReport", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetForwardCommiteeAHList/{UserID}/{ActionName}/{RoleID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetForwardCommiteeAHList(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetForwardCommiteeAHList", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetForwardCommiteeAHList(UserID, ActionName, RoleID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetForwardCommiteeAHList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpGet("GetPendingMedicalApplications/{RoleID}/{UserID}/{ActionName}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetPendingMedicalApplications(int RoleID, int UserID, string ActionName)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetPendingMedicalApplications", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetPendingMedicalApplications(RoleID, UserID, ActionName));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetPendingMedicalApplications", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }




        [HttpGet("GetApplyNOCApplicationType/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>> GetApplyNOCApplicationType(int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetApplyNOCApplicationType", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCApplicationType(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetApplyNOCApplicationType", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("GeneratePDFForJointSecretary/{ApplyNOCID}/{DepartmentID}/{RoleID}/{UserID}/{NOCIssuedRemark}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GeneratePDFForJointSecretary(GenerateNOC_DataModel request)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "GeneratePDFForJointSecretary", request.ApplyNOCID, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GeneratePDFForJointSecretary(request.ApplyNOCID));
                string Path = GeneratePDF(result.Data);

                if (!string.IsNullOrEmpty(Path))
                {
                    if (await Task.Run(() => UtilityHelper.ApplyNOCUtility.SavePDFPath(Path, request.ApplyNOCID, request.DepartmentID, request.RoleID, request.UserID, request.NOCIssuedRemark)))
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
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GeneratePDFForJointSecretary", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("GenerateNOCForDCE")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GenerateNOCForDCE(List<GenerateNOC_DataModel> request)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(request[0].UserID, "GenerateNOCForDCE", request[0].ApplyNOCID, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                //string Path = GeneratePDFDCE(request[0].ApplyNOCID,request);


                if (await Task.Run(() => UtilityHelper.ApplyNOCUtility.SaveDCENOCData(request)))
                {
                    string Path = GeneratePDFDCE(request[0].ApplyNOCID);
                    if (!string.IsNullOrEmpty(Path))
                    {
                        bool result1 = false;
                        result1 = UtilityHelper.ApplyNOCUtility.UpdateNOCPDFPath(request[0].ApplyNOCID, Path);
                        if (result1)
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
                    else
                    {
                        UtilityHelper.ApplyNOCUtility.DeleteNOCIssuedDetails(request[0].ApplyNOCID);
                        result.State = OperationState.Warning;
                        result.SuccessMessage = "There was an error Generate PDF!";
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GenerateNOCForDCE", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        public class CustomImageTagProcessor : iTextSharp.tool.xml.html.Image
        {
            public override IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
            {
                IDictionary<string, string> attributes = tag.Attributes;
                string src;
                if (!attributes.TryGetValue(HTML.Attribute.SRC, out src))
                    return new List<IElement>(1);

                if (string.IsNullOrEmpty(src))
                    return new List<IElement>(1);

                if (src.StartsWith("data:image/", StringComparison.InvariantCultureIgnoreCase))
                {
                    var base64Data = src.Substring(src.IndexOf(",") + 1);
                    var imagedata = Convert.FromBase64String(base64Data);
                    var image = iTextSharp.text.Image.GetInstance(imagedata);

                    var list = new List<IElement>();
                    var htmlPipelineContext = GetHtmlPipelineContext(ctx);
                    list.Add(GetCssAppliers().Apply(new Chunk((iTextSharp.text.Image)GetCssAppliers().Apply(image, tag, htmlPipelineContext), 0, 0, true), tag, htmlPipelineContext));
                    return list;
                }
                else
                {
                    return base.End(ctx, tag, currentContent);
                }
            }
        }
        [HttpGet]
        public string GeneratePDF(List<CommonDataModel_DataTable> dt)
        {
            StringBuilder sb = new StringBuilder();
            var fileName = Guid.NewGuid().ToString().Replace("/", "").Replace("-", "").ToUpper() + ".pdf";
            StringBuilder sbhtml = new StringBuilder();

            string CollegeName = dt[0].data.Rows[0]["CollegeName"].ToString();
            string CollegeMobileNo = dt[0].data.Rows[0]["CollegeMobileNo"].ToString();
            string CollegeEmail = dt[0].data.Rows[0]["CollegeEmail"].ToString();
            string ApplicationTypeName = dt[0].data.Rows[0]["ApplicationTypeName"].ToString();
            string TotalFeeAmount = dt[0].data.Rows[0]["TotalFeeAmount"].ToString();
            string ApplicationStatus = dt[0].data.Rows[0]["ApplicationStatus"].ToString();
            string DepartmentName = dt[0].data.Rows[0]["DepartmentName"].ToString();
            string ApplicationNo = dt[0].data.Rows[0]["ApplicationNo"].ToString();
            DateTime now = DateTime.Now.Date;
            var Date = now.ToString("dd-MM-yyyy");

            {
                sb.Clear();
                sb.Append("<table style='width:100%;'>");
                sb.Append("<tr><td style='text-align:center'><h1 style='margin-bottom:0px;'>" + DepartmentName + "</h1></td></tr>");
                sb.Append("<tr><td style='text-align:center'><h4 style='margin-bottom:0px;'>No Objection Certificate</h4></td></tr>");
                sb.Append("<tr><td style='text-align:center'><h6 style='margin-bottom:0px;'>" + CollegeName + " Apply For " + ApplicationTypeName + "</h6></td></tr>");
                sb.Append("<tr><td height='30px;'></td></tr>");
                sb.Append("<tr><td style='text-align:right'><b>Application No. : </b> " + ApplicationNo + "</td></tr>");
                sb.Append("<tr><td style='text-align:right'><b>Contact No. : </b>" + CollegeMobileNo + "</td></tr>");
                sb.Append("<tr><td style='text-align:right'><b>Email : </b>" + CollegeEmail + "</td></tr>");
                sb.Append("<tr><td style='text-align:right'><b>Date : </b>" + Date + "</td></tr>");
                sb.Append("<tr><td height='30px;'></td></tr>");
                sb.Append("<tr><td><b>Total Fee Amount : </b>" + TotalFeeAmount + "</td></tr>");
                sb.Append("<tr><td height='30px;'></td></tr>");
                sb.Append("<tr><td><p>sdgfomsdfgomdsfg osdgmf fsogm dsfgom dsfgomd fsgmofg mdsfgm dsg</p></td></tr>");
                sb.Append("<tr><td><p>sdgfomsdfgomdsfg osdgmf fsogm dsfgom dsfgomd fsgmofg mdsfgm dsg</p></td></tr>");
                sb.Append("<tr><td><p>sdgfomsdfgomdsfg osdgmf fsogm dsfgom dsfgomd fsgmofg mdsfgm dsg</p></td></tr>");
                sb.Append("<tr><td height='30px;'></td></tr>");
                sb.Append("<tr><td height='30px;'></td></tr>");
                sb.Append("<tr><td height='30px;'></td></tr>");
                sb.Append("<tr><td style='text-align:right'><b>Signature</b></td></tr>");
                sb.Append("</table>");
            }
            //}

            sbhtml.Append(UnicodeToKrutidev.FindAndReplaceKrutidev(sb.ToString().Replace("<br>", "<br/>"), true, "15px"));
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile/" + fileName);
            Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 50f, 50f, 50f, 70f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filepath, FileMode.Create));
            try
            {
                pdfDoc.Open();
                var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                tagProcessors.RemoveProcessor(HTML.Tag.IMG);
                tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor());
                var cssFiles = new CssFilesImpl();
                cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                var cssResolver = new StyleAttrCSSResolver(cssFiles);
                var charset = System.Text.Encoding.UTF8;
                var context = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                context.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors);
                var htmlPipeline = new HtmlPipeline(context, new PdfWriterPipeline(pdfDoc, writer));
                var cssPipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
                var worker = new XMLWorker(cssPipeline, true);
                var xmlParser = new XMLParser(true, worker, charset);
                using (var sr = new StringReader(sbhtml.ToString()))
                {
                    xmlParser.Parse(sr);
                    pdfDoc.Close();
                    writer.Close();
                }

            }
            catch (Exception ex)
            {
                pdfDoc.Close();
                writer.Close();
                throw ex;
            }

            return fileName;

        }



        [HttpGet("CheckAppliedNOCCollegeWise/{CollegeID}")]
        public async Task<OperationResult<int>> CheckAppliedNOCCollegeWise(int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "CheckAppliedNOCCollegeWise", 0, "ApplyNOCController");
            var result = new OperationResult<int>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.CheckAppliedNOCCollegeWise(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.CheckAppliedNOCCollegeWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetIssuedNOCReportList/{UserID}/{ActionName}/{RoleID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetIssuedNOCReportList(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetIssuedNOCReportList", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetIssuedNOCReportList(UserID, ActionName, RoleID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetIssuedNOCReportList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetApplyNOCCompletedReport/{UserID}/{ActionName}/{RoleID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplyNOCCompletedReport(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetApplyNOCCompletedReport", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCCompletedReport(UserID, ActionName, RoleID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetApplyNOCCompletedReport", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetApplyNOCRevertReport/{UserID}/{ActionName}/{RoleID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplyNOCRevertReport(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetApplyNOCRevertReport", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCRevertReport(UserID, ActionName, RoleID, DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetApplyNOCRevertReport", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetNocLateFees/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetNocLateFees(int DepartmentID)
        {

            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetNocLateFees(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetNocLateFees", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        private DataSet CollegeDetails(int ApplyNOCID)
        {
            var result = new DataSet();
            result = UtilityHelper.ApplyNOCUtility.GetNOCIssuedDetailsByNOCIID(ApplyNOCID);
            var dataSet = new DataSet();
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables[0].Columns.Add("NOCIssueNo");
            dataSet.Tables[0].Columns.Add("Date");
            dataSet.Tables[0].Columns.Add("NOCIssueFinancialYear");
            dataSet.Tables[0].Columns.Add("Img");
            dataSet.Tables[0].Columns.Add("NocQRCode", typeof(byte[]));
            DataRow row;
            row = dataSet.Tables[0].NewRow();
            row["NOCIssueNo"] = result.Tables[0].Rows[0]["NOCIssueNo"];//"2023-2024/30";
            row["Date"] = result.Tables[0].Rows[0]["Date"];//"05-09-2023";
            row["NOCIssueFinancialYear"] = result.Tables[0].Rows[0]["NOCIssueFinancialYear"];//"2023-2024";
            //row["Img"] = "http://172.22.33.75:81/assets/images/logoLarge.png";
            row["NocQRCode"] = CommonHelper.GenerateQrCode(result.Tables[0].Rows[0]["NocQRCode"].ToString());
            dataSet.Tables[0].Rows.Add(row);
            ////
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables[1].Columns.Add("LegalEntityName");
            dataSet.Tables[1].Columns.Add("CollegeName");
            dataSet.Tables[1].Columns.Add("UniversityName");
            dataSet.Tables[1].Columns.Add("StreamName");
            DataRow row1;
            row1 = dataSet.Tables[1].NewRow();
            row1["LegalEntityName"] = result.Tables[1].Rows[0]["LegalEntityName"];//"श्री कॉम्प कंप्यूटर शिक्षण संस्थान, सोजत सिटी, जिला पाली|";
            row1["CollegeName"] = result.Tables[1].Rows[0]["CollegeName"];//"श्री विनायक महाविद्यालय मेला चौक, सोजत सिटी, जिला पाली|";
            row1["UniversityName"] = result.Tables[1].Rows[0]["UniversityName"];    //"जय नारायण व्यास विश्व विद्यालय, जोधपुर |";
            string CourseSubject = "";
            for (int i = 0; i < result.Tables[1].Rows.Count; i++)
            {
                CourseSubject += i == 0 ? result.Tables[1].Rows[i]["StreamName"] + " - " + result.Tables[1].Rows[i]["SubjectName"] : " || " + result.Tables[1].Rows[i]["StreamName"] + " - " + result.Tables[1].Rows[i]["SubjectName"];
            }
            row1["StreamName"] = CourseSubject;//"अनिवार्य विषयो सहित सनातक स्टार प्र कला संकाय:- भुगोल, राजनीति विज्ञान, हिंदी साहित्य, इतिहास |";
            dataSet.Tables[1].Rows.Add(row1);

            return dataSet;
        }

        [HttpGet("GeneratePDFDCE")]
        // public string GeneratePDFDCE(int ApplyNOCID, List<GenerateNOC_DataModel> CourseSubjectData)
        public string GeneratePDFDCE(int ApplyNOCID)
        {
            StringBuilder sb = new StringBuilder();
            var fileName = System.DateTime.Now.ToString("ddMMMyyyyhhmmssffffff") + ".pdf";
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF/" + fileName);


            DataSet dataset = new DataSet();
            dataset = CollegeDetails(ApplyNOCID);
            string mimetype = "";
            int extension = 1;
            var path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\DECNOC_Print.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
            parameters.Add("test", "");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet_CollegeDetails", dataset.Tables[0]);
            localReport.AddDataSource("DataSet_CourseAndSubjectDetails", dataset.Tables[1]);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);



            //return File(result.MainStream, "application/pdf");
            System.IO.File.WriteAllBytes(filepath, result.MainStream);


            //StringBuilder sbhtml = new StringBuilder();

            //string CollegeLogo = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile/dce_logo.jpg");

            //List<CommonDataModel_DataTable> dt = new List<CommonDataModel_DataTable>();
            //dt = UtilityHelper.ApplyNOCUtility.GeneratePDFForJointSecretary(ApplyNOCID);
            //if (dt.Count > 0)
            //{
            //    sb.Clear();
            //    sb.Append("<table style='width:100%;line-height:1' cellpadding='0' cellspacing='0'>");
            //    sb.Append("<tr><td align='left' width='10%'><img  src='" + CollegeLogo + "' height='80' width='80' alt='logo'/></td>");
            //    sb.Append("<td align='center'><table style='width:100%;line-height:1' cellpadding='0' cellspacing='0'><tr><td align='center' valign='top'><h2 style='font-size:28px'>राजस्थान सरकार</h2></td></tr>");
            //    sb.Append("<tr><td align='center' valign='top'><p>आयुक्तालय, कालेज शिक्षा, राजस्थान, जयपुर</p></td></tr>");
            //    sb.Append("<tr><td align='center' valign='top'><p>Block-4, RKS Sankul, JLN Road, Jaipur- 302015, Rajasthan</p></td></tr>");
            //    sb.Append("<tr><td align='center' valign='top'><p>Website: http://hte.rajasthan.gov.in/dept/dce/</p></td></tr>");
            //    sb.Append("<tr><td align='center' valign='top'><p>e-mail: jdpi.cce@gmail.com Ph.: 0141-2706736(0);</p></td></tr>");
            //    sb.Append("<tr><td align='center' valign='top'><hr /></td></tr></table></td></tr>");
            //    sb.Append("<tr><td colspan='2' style='margin-top:10px'><table style='width:100%;line-height:1' cellpadding='0' cellspacing='0'><tr>");
            //    sb.Append("<td align='left' valign='top'>क्रमांक : एफ4 (40) आकाश / नि.सं./ 2018 /1154</td><td align='right' valign='top'>दिनांक - " + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr></table></td></tr>");
            //    sb.Append("<tr><td colspan='2' align='center' valign='top'><b>आदेश</b></td></tr>");
            //    sb.Append("<tr><td colspan='2' align='left' valign='top' style='font-size:16px'> &nbsp;&nbsp;&nbsp;&nbsp;राजस्थान गैर सरकारी शैक्षिक यम, 1989 तथा तत्संबंधी नियम 1993 एवं राजा सरकार द्वारा जारी अद्यतन निजी महाविद्यालय नीति के अन्तर्गत <b>सत्र  " + dt[0].data.Rows[0]["FinancialYearName"].ToString() + "</b> (एक सत्र) के लिए स्नातक स्तर पर पूर्व संचालित संकाय/ विषयों में अस्थाई अनापत्ति प्रमाण पत्र अभिवृद्धि निम्नलिखित शर्तों के साथ स्वीकृत की जाती है-<br/></td></tr>");
            //    sb.Append("<tr><td colspan='2' align='left' valign='top'><table style='width:100%;line-height:1;' cellpadding='0' cellspacing='0' border='1'>");
            //    sb.Append("<tr><td align='left' valign='top' style='margin:10px'>संचालक संस्था</td><td align='left' valign='top' style='margin:10px'>महाविद्यालय का नाम</td>");
            //    sb.Append("<td align='left' valign='top' style='margin:10px'>सम्बद्ध विश्वविद्यालय</td><td align='left' valign='top' style='margin:10px'>पूर्व संचालित संकाय/ विषय</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td align='left' valign='top' style='margin:10px'>" + dt[0].data.Rows[0]["SocietyName"].ToString() + "</td><td align='left' valign='top' style='padding:10px'>" + dt[0].data.Rows[0]["CollegeName"].ToString() + "</td>");
            //    sb.Append("<td align='left' valign='top' style='margin:10px'> " + dt[0].data.Rows[0]["UniversityName"].ToString() + "</td><td align='left' valign='top' style='margin:10px'>अनिवार्य विषयों सहित स्नातक स्तर पर</td></tr></table></td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>1. संस्था प्रत्येक सत्र में निरीक्षण करवाने हेतु नियमानुसार निर्धारित शुल्क जमा करवाकर ऑनलाइन प्रपत्र प्रस्तुत करेगी।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top' style='font-size:14px'>2. संस्था सत्र " + dt[0].data.Rows[0]["FinancialYearName"].ToString() + " में निर्धारित नियमानुसार स्थायी अनापत्ति प्रमाण पत्र हेतु आवेदन करेगी।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>3. संस्था द्वारा सावधि जमा राशि (एफडीआर) का प्रत्येक वर्ष में नवीनीकरण कराया जाना अनिवार्य होगा।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>4. आवश्यकतानुसार आयुक्तालय द्वारा अधिकृत अधिकारी द्वारा महाविद्यालय का निरीक्षण किया जा सकता अधिकृत अधिकारी द्वारा गया अभिलेख उपलब्ध करायेगी।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>5. संस्था को समय-समय पर यू.जी.सी. राज्य सरकार / आयुक्तालय कॉलेज शिक्षा द्वारा जारी निर्देशों की पालना अनिवार्य रूप से करनी होगी।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>6. संख्या संबंधित विद्यालय से संबद्धता प्राप्त करेगी तथा विधि महाविद्यालय के प्रकरण में बसे मान्यता व विश्वविद्यालय से समद्धता पर अनुमोदन प्राप्त करेगी। तत्पश्चात् ही विद्यार्थियों को प्रवेश दिया जाये।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>7. संस्था संकाय व विषयवार सीटों का आवंटन विश्वविद्यालय द्वारा प्राप्त कर आयुक्तालय कॉलेज शिक्षा विभाग को सूचित करेगी तथा महाविद्यालय तदनुसार तय संख्या सीमा में प्रवेश दिया जाना सुनिश्चित करेगा।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>8. संख्या महाविद्यालय में अध्यापन कार्य हेतु पूजीसी सामारी प्राचार्य एवं व्याख्यान मानदण्डानुसार कि स्टाफ की नियुक्ति के साथ-2 अन्य निर्धारित शर्मा को चलना करेगी।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top' style='font-size:14px'>9. राज्य सरकार की महाविद्यालय प्रवेश नीति " + dt[0].data.Rows[0]["FinancialYearName"].ToString() + " तथा बाद में जानी होने वाली नीतियों का पालन करना</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>10. संस्था प्रति वर्ष विभाग के NOC पोर्टल पर आवश्यक सांख्यिकी एवं महाविद्यालय की सूचनाएं निर्धारित अवधि मे भरकर अपलोड़ करेगी।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>11. मानव संसाधन विकास मंत्रालय, भारत सरकार के वेबपोर्टल www.aishe.nic.in पर महाविद्यालय को रजिस्टर DCF-II (Data Capture format-ii) भरवार अपलोड करना अनिवार्य होगा प्रमाण-पत्र की कॉपी आवश्यकतानुसार आयुक्तालय में प्रस्तुत करे।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='left' valign='top'>उपर्युक्त शतों की पालना नहीं करने पर अस्थाई अनापत्ति प्रमाण पत्र को निरस्त कर दिया जायेगा।</td></tr>");
            //    sb.Append("<tr style='font-size:14px'><td colspan='2' align='right' valign='top'><br/><br/>आयुक्त <br />कॉलेज शिक्षा राजस्थान जयपुर</td></tr>");
            //    sb.Append("<tr><td colspan='2' align='left' valign='top'><p>प्रतिलिपि निम्नलिखित को सूचनार्थ एवं आवश्यक कार्यवाही हेतु प्रेषित है-</p>");
            //    sb.Append("<p>1. विशिष्ट सहायक मा० उच्च शिक्षा मंत्री महोदय, राजस्थान जयपुर ।</p><p>2. निजी सचिव शासन सचिव उच्च शिक्षा विभाग, राजस्थान जयपुर ।</p><p>3. निजी सचिव आयुक्त आयुक्तालय कॉलेज शिक्षा राजस्थान जयपुर</p>");
            //    sb.Append("<p>4. जिला कलेक्टर पानी</p><p>5. कुल शहिद जय नारायणालय, जोधपुर।</p><p>6. सचिव सम्बन्धित महाविद्यालय ।</p><p>7. सध्या आयुक्तालय शिक्षा राजस्थान जयपुर</p><p>8. रक्षित पत्रावली </p></td></tr>");
            //    sb.Append(" <tr><td colspan='2' align='right' valign='top'><br/>संयुक्त निदेशक (नि०सं०) <br />कॉलेज शिक्षा राजस्थान जयपुर</td></tr>");
            //    sb.Append("</table>");
            //}

            //sbhtml.Append(UnicodeToKrutidev.FindAndReplaceKrutidev(sb.ToString().Replace("<br>", "<br/>"), true, "17px"));
            ////string filepath = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile/" + fileName);
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


        [HttpPost("SubmitRevertApplication")]
        public async Task<OperationResult<bool>> SubmitRevertApplication(SubmitRevertApplication request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.SubmitRevertApplication(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "SubmitRevertApplication", request.ApplyNOCID, "SubmitRevertApplication");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Re Submit Application successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error submit application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.SubmitRevertApplication", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("ParameterFeeMaster")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetParameterFeeMaster(ParameterFeeMaster request)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "CommonMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetParameterFeeMaster(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonMasterController.GetCommonMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetNocInformation/{SearchRecordID}")]
        public async Task<OperationResult<NocInformation>> GetNocInformation(Guid SearchRecordID)
        {
            var result = new OperationResult<NocInformation>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetNocInformation(SearchRecordID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetNocInformation", ex.ToString());
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
