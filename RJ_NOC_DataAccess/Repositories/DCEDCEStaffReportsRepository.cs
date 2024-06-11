using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class DCEStaffReportsRepository : IDCEStaffReportsRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public DCEStaffReportsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

       

        public List<DCEStaffReportsDataModel_list> DCEStaffDetailsList(DCEStaffReportsDataModel request)
        {
            string SqlQuery = $" exec USP_Get_Data_For_StaffReport";
            SqlQuery += " @FaculityName='" + request.FaculityName + "',";
            SqlQuery += " @MobileNo='" + request.MobileNo + "',";
            SqlQuery += " @DesignationID='" + request.DesignationID + "',";

            SqlQuery += " @Gender='" + request.Gender + "',";
            SqlQuery += " @StaffStatus='" + request.TempPermanentID + "',";
            SqlQuery += " @ResearchGuide='" + request.IsReserachGuideID + "',";
            SqlQuery += " @AadhaarNo='" + request.AadhaarNo + "',";
            SqlQuery += " @NOCStatus='" + request.NOCStatus + "',";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @SubjectID='" + request.SubjectID + "',";
            SqlQuery += " @MonthlySalary='" + request.MonthlySalary + "',";
            SqlQuery += " @PFDeductionID='" + request.PFDeductionID + "',";
            SqlQuery += " @PresentCollegeStatusID='" + request.PresentCollegeStatusID + "',";
            SqlQuery += " @DateOfAppointment='" + request.DateOfAppointment + "',";
            SqlQuery += " @DuplicateAdharID='" + request.DuplicateAdharID + "',";
            SqlQuery += " @DateOfJoining='" + request.DateOfJoining + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DCEDCEStaffReports.DCEStaffDetailsList");
            List<DCEStaffReportsDataModel_list> dataModels = new List<DCEStaffReportsDataModel_list>();
            DCEStaffReportsDataModel_list dataModel = new DCEStaffReportsDataModel_list();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }



        public List<DCEStaffReports_SubjectList> GetSubjectList()
        {
            string SqlQuery = "exec USP_GetSubjectList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DCEDCEStaffReports.GetSubjectList");

            List<DCEStaffReports_SubjectList> dataModels = new List<DCEStaffReports_SubjectList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DCEStaffReports_SubjectList>>(JsonDataTable_Data);
            return dataModels;

        }

        public List<DCEStaffReports_SubjectList> GetStaffDuplicateAdharList()
        {
            string SqlQuery = "exec USP_StaffDuplicateAdharList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GetStaffDuplicateAdharList.GetStaffPFStatusList");

            List<DCEStaffReports_SubjectList> dataModels = new List<DCEStaffReports_SubjectList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DCEStaffReports_SubjectList>>(JsonDataTable_Data);
            return dataModels;

        }


    }
}
