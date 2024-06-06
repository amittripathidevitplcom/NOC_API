using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DefaulterCollegeRequest : UtilityBase, IDefaulterCollegeRequest
    {
        public DefaulterCollegeRequest(IRepositories unitOfWork) : base(unitOfWork)
        {
        }       
        public List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData()
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.GetDefaulterCollegeRequestData();
        }
        public List<DefaulterCollegeRequestDataModel> GetByID(int DefaulterCollegeRequestID)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.GetByID(DefaulterCollegeRequestID);
        }
        public bool SaveData(DefaulterCollegeRequestDataModel request)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.SaveData(request);
        }       
        public bool DeleteData(int DefaulterCollegeRequestID)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.DeleteData(DefaulterCollegeRequestID);
        }
        
        public bool IfExists(int DefaulterCollegeRequestID, int DepartmentID, string Name)
        {
            return UnitOfWork.DefaulterCollegeRequestRepository.IfExists(DefaulterCollegeRequestID, DepartmentID, Name);
        }

       
    }
}
