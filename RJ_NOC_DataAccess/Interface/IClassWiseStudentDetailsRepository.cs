using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
   public interface IClassWiseStudentDetailsRepository
    {
        List<ClassWiseStudentDetailsDataModel> GetCollegeWiseStudenetDetails(int CollegeID, int ApplyNOCID);
        bool SaveData(PostClassWiseStudentDetailsDataModel model);

        //Save
        List<SubjectWiseStatisticsDetailsDataModel> GetSubjectWiseStudenetDetails(int CollegeID, int ApplyNOCID);
        bool SaveDataSubjectWise(PostSubjectWiseStatisticsDetailsDataModel model);
        bool StatisticsFinalSubmit_Save(StatisticsFinalSubmitDataModel model);


    }
}
