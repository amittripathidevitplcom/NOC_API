using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IStaffDetail
    {
        bool IfExistsPrincipal(int StaffDetailID,int CollegeID, int DesignationID);
        bool IfExistsAadhar(int DepartmentID,int StaffDetailID, int CollegeID,string AadharCard);
        bool SaveData(StaffDetailDataModel request);
        List<StaffDetailDataModel> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int StaffDetailID, int ApplyNOCID);
        bool DeleteStaffDetail(int StaffDetailID);
        bool SaveData_ExcelData(StaffDetailDataModel_Excel request);
        List<CommonDataModel_DataSet> GetStaffDetailListForPDF(int DepartmentID, int CollegeID);
    }
}
