using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IClassWiseStudentDetails
    {
        List<ClassWiseStudentDetailsDataModel> GetCollegeWiseStudenetDetails(int CollegeID);
        bool SaveData(PostClassWiseStudentDetailsDataModel request);
        //Save
        List<SubjectWiseStatisticsDetailsDataModel> GetSubjectWiseStudenetDetails(int CollegeID);
        bool SaveDataSubjectWise(PostSubjectWiseStatisticsDetailsDataModel model);

    }
}
