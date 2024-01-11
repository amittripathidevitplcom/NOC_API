using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IClassWiseStudentDetails
    {
        List<ClassWiseStudentDetailsDataModel> GetCollegeWiseStudenetDetails(int CollegeID, int ApplyNOCID);
        bool SaveData(PostClassWiseStudentDetailsDataModel request);
        //Save
        List<SubjectWiseStatisticsDetailsDataModel> GetSubjectWiseStudenetDetails(int CollegeID, int ApplyNOCID);
        bool SaveDataSubjectWise(PostSubjectWiseStatisticsDetailsDataModel model);
        bool StatisticsFinalSubmit_Save(StatisticsFinalSubmitDataModel model);
        List<DataTable> CollegeList_StatisticsFinalSubmited(CollegeList_StatisticsFinalSubmitedDataModel_Filter request);
        List<DataTable> CollegeList_StatisticsDraftSubmited(CollegeList_StatisticsDraftSubmitedDataModel_Filter request);


        List<DataTable> CollegeList_StatisticsNotFilledReport(TotalNotFilledStatics_DataModel_Filter request);



    }
}
