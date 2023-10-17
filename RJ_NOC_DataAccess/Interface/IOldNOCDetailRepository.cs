using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IOldNOCDetailRepository
    {
        //bool IfExists(int HostelDetailID, int CollegeID, string HostelName);
        bool SaveData(OldNocDetailsDataModel request);
        List<OldNocDetailsDataModel> GetOldNOCDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int OldNocID,int ApplyNOCID);
        bool DeleteOldNocDetail(int OldNocID);
        bool IfExists(int OldNocID, string NOCNumber);
        List<CommonDataModel_DataSet> GetOldNOCDetailListForPDF(int DepartmentID, int CollegeID);
    }
}
