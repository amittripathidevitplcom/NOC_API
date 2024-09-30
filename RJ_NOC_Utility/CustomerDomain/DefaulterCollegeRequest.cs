using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DefaulterCollegeRequest : UtilityBase, IDefaulterCollegeRequest
    {
        public DefaulterCollegeRequest(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData(DefaulterCollegeSearchFilterDataModel request)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.GetDefaulterCollegeRequestData(request);
        }
        public bool SaveData(DefaulterCollegeRequestDataModel request)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.SaveData(request);
        }
        public bool DeleteData(int RequestID)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.DeleteData(RequestID);
        }
        public bool SaveDefaulterCollegePenalty(ApplicationPenaltyDataModel request)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.SaveDefaulterCollegePenalty(request);
        }
        public List<CommonDataModel_DataTable> GetDefaulterCollegePenalty(int RequestID, int PenaltyID)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.GetDefaulterCollegePenalty(RequestID, PenaltyID);
        }
        public bool DeleteDefaulterCollegePenalty(int PenaltyID)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.DeleteDefaulterCollegePenalty(PenaltyID);
        }
        public bool IfExists(string ApplicationNo, string SubmittedDate)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.IfExists(ApplicationNo, SubmittedDate);
        }
        public List<DataTable> GetDefaulterRequestCount(int DepartmentID, int UserID)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.GetDefaulterRequestCount(DepartmentID, UserID);
        }
        public bool CompareCollegeName(string SSOID, string CollegeName)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.CompareCollegeName(SSOID, CollegeName);
        }

    }
}
