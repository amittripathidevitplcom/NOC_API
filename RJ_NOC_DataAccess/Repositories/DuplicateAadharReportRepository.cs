using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace RJ_NOC_DataAccess.Repository
{
    public class DuplicateAadharReportRepository : IDuplicateAadharReportRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DuplicateAadharReportRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetDuplicateAadhaarReportDatail(DuplicateAadharReportDataModel request)
        {
            string SqlQuery = "exec USP_Get_Data_For_DuplicateAadharReport @AadhaarNo='" + request.AadhaarNo + "', @CollegeTypeID='" + request.CollegeTypeID + "',@DateOfAppointment='" + request.DateOfAppointment + "',@DateOfJoining='" + request.DateOfJoining + "',@StaffTypeID='" + request.StaffTypeID + "',@DesignationID='" + request.DesignationID + "',@FaculityFatherName='" + request.FaculityFatherName + "',@FaculityMobileNo='" + request.FaculityMobileNo + "',@FaculityName='" + request.FaculityName + "',@Gender='" + request.Gender + "',@MonthlySalary='" + request.MonthlySalary + "',@ResearchGuide='" + request.ResearchGuide + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DuplicateAadharReport.GetDuplicateAadhaarReportDatail");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

    }
}
