using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IDCEStaffReportsRepository
    {


        List<DCEStaffReportsDataModel_list> DCEStaffDetailsList(DCEStaffReportsDataModel request);
        List<DCEStaffReports_SubjectList> GetSubjectList();
        List<DCEStaffReports_SubjectList> GetStaffDuplicateAdharList(int DepartmentID);


    }
}
