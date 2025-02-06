using ikvm.@internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using System.Data;
using System.Net;
using System.Xml;
using AspNetCore.Reporting;
using System.IO;
using AspNetCore.Reporting.ReportExecutionService;
using org.omg.PortableServer;

namespace RJ_NOC_API.Controllers
{
    [Route("api/RDLCReport")]
    [ApiController]
    public class RDLC_ReportController : RJ_NOC_ControllerBase
    {

        private IConfiguration _configuration;
        public RDLC_ReportController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

         [HttpPost("DECNOC")]
        public IActionResult DECNOC_Print()
        {
             
            DataSet dataset = new DataSet();
            dataset = CollegeDetails();

            string mimetype = "";
            int extension = 1;
            var path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\DECNOC_Print.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
            parameters.Add("test", "");
            LocalReport lr = new LocalReport(path);
            lr.AddDataSource("DataSet_CollegeDetails", dataset.Tables[0]);
            lr.AddDataSource("DataSet_CourseAndSubjectDetails", dataset.Tables[1]);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }
        [HttpPost("DECNOCSavePDF")]
        public string DECNOC_SavePDF()
        {
            DataSet dataset = new DataSet();
            dataset = CollegeDetails();
            string mimetype = "";
            int extension = 1;
            var path = (System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports")) + "\\DECNOC_Print.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string imagePath = new Uri((System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images") + @"\logo.png")).AbsoluteUri;
            parameters.Add("test", "");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet_CollegeDetails", dataset.Tables[0]);
            localReport.AddDataSource("DataSet_CourseAndSubjectDetails", dataset.Tables[1]);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            //return File(result.MainStream, "application/pdf");
            String file_name_pdf = "\\Test.pdf";
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Reports") + file_name_pdf, result.MainStream);
            return "";

        }
        private DataSet CollegeDetails()
        {
            var dataSet = new DataSet(); 
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables[0].Columns.Add("NOCIssueNo");
            dataSet.Tables[0].Columns.Add("Date");
            dataSet.Tables[0].Columns.Add("NOCIssueFinancialYear");
            dataSet.Tables[0].Columns.Add("Img");
            DataRow row;
            row = dataSet.Tables[0].NewRow();
            row["NOCIssueNo"] = "2023-2024/30";
            row["Date"] = "05-09-2023";
            row["NOCIssueFinancialYear"] = "2023-2024";
            row["Img"] = "http://172.22.33.75:81/assets/images/logoLarge.png";
            dataSet.Tables[0].Rows.Add(row); 
            ////
            dataSet.Tables.Add(new DataTable());
            dataSet.Tables[1].Columns.Add("LegalEntityName");
            dataSet.Tables[1].Columns.Add("CollegeName");
            dataSet.Tables[1].Columns.Add("UniversityName");
            dataSet.Tables[1].Columns.Add("StreamName");
            DataRow row1;
            row1 = dataSet.Tables[1].NewRow();
            row1["LegalEntityName"] = "श्री कॉम्प कंप्यूटर शिक्षण संस्थान, सोजत सिटी, जिला पाली|";
            row1["CollegeName"] = "श्री विनायक महाविद्यालय मेला चौक, सोजत सिटी, जिला पाली|";
            row1["UniversityName"] = "जय नारायण व्यास विश्व विद्यालय, जोधपुर |";
            row1["StreamName"] = "अनिवार्य विषयो सहित सनातक स्टार प्र कला संकाय:- भुगोल, राजनीति विज्ञान, हिंदी साहित्य, इतिहास |";
            dataSet.Tables[1].Rows.Add(row1);

            return dataSet;
        }        
    }
}