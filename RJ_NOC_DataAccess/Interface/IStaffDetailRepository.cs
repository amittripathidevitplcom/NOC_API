using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IStaffDetailRepository
    {
        bool IfExistsPrincipal(int StaffDetailID, int CollegeID,int DesignationID);
        bool SaveData(StaffDetailDataModel request);
        bool SaveData_ExcelData(StaffDetailDataModel_Excel request);
        List<StaffDetailDataModel> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID,int CollegeID,int StaffDetailID,int ApplyNOCID);
        bool DeleteStaffDetail(int StaffDetailID);
        List<CommonDataModel_DataSet> GetStaffDetailListForPDF(int DepartmentID, int CollegeID);
    }
}
