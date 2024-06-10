using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDefaulterCollegeRequest
    {
        
        List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData(DefaulterCollegeSearchFilterDataModel request);
        bool SaveData(DefaulterCollegeRequestDataModel request);
        public bool DeleteData(int RequestID);


        bool SaveDefaulterCollegePenalty(ApplicationPenaltyDataModel request);
        List<CommonDataModel_DataTable> GetDefaulterCollegePenalty(int RequestID,int PenaltyID);
        public bool DeleteDefaulterCollegePenalty(int PenaltyID);
    }
}