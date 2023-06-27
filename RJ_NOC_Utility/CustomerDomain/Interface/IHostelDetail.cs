using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IHostelDetail
    {
        bool IfExists(int HostelDetailID, int CollegeID, string HostelName);
        bool SaveData(HostelDataModel request);
        List<HostelDataModel> GetHostelDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int HostelDetailID);
        bool DeleteHostelDetail(int HostelDetailID);
    }
}
