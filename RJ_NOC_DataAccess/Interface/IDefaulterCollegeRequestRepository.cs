using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDefaulterCollegeRequestRepository
    {
        List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData(DefaulterCollegeSearchFilterDataModel request);
        bool SaveData(DefaulterCollegeRequestDataModel request);
        public bool DeleteData(int RequestID);

        bool SaveDefaulterCollegePenalty(ApplicationPenaltyDataModel request);
        List<CommonDataModel_DataTable> GetDefaulterCollegePenalty(int RequestID,int PenaltyID);
        public bool DeleteDefaulterCollegePenalty(int PenaltyID);
        bool IfExists(string ApplicationNo, string SubmittedDate);
    }

}

