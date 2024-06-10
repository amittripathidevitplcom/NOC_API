using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;

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

    }
}
