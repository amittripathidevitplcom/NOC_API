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
        public async Task<OperationResult<List<ApplyNOCDataModel>>> GetApplyNOCApplicationListByRole(int RoleID, int UserID,int DepartmentID)
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
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetApplyNOCRejectedReport(int UserID, string ActionName, int RoleID,int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetApplyNOCRejectedReport", 0, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCRejectedReport(UserID, ActionName,  RoleID,  DepartmentID));
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
        [HttpGet("GeneratePDFForJointSecretary/{ApplyNOCID}/{DepartmentID}/{RoleID}/{UserID}/{NOCIssuedRemark}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GeneratePDFForJointSecretary(int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GeneratePDFForJointSecretary", ApplyNOCID, "ApplyNOCController");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GeneratePDFForJointSecretary(ApplyNOCID));
                string Path=GeneratePDF(result.Data);

                if (!string.IsNullOrEmpty(Path))
                {
                    if (await Task.Run(() => UtilityHelper.ApplyNOCUtility.SavePDFPath(Path, ApplyNOCID, DepartmentID, RoleID, UserID, NOCIssuedRemark)))
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
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile/"+ fileName);
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
                if (result.Data!=null)
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

    }

}
