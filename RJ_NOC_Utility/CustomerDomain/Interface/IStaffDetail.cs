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
       // bool IfExists(int HostelDetailID, int CollegeID, string HostelName);
        bool SaveData(StaffDetailDataModel request);
        List<StaffDetailDataModel> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int StaffDetailID);
        bool DeleteStaffDetail(int StaffDetailID);

        List<CommonDataModel_DataSet> GetStaffDetailListForPDF(int DepartmentID, int CollegeID);
    }
}
