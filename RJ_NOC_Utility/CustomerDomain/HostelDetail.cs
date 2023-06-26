using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class HostelDetail : UtilityBase, IHostelDetail
    {
        public HostelDetail(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool IfExists(int HostelDetailID, int CollegeID, string HostelName)
        {
            return UnitOfWork.HostelDetailRepository.IfExists(HostelDetailID, CollegeID, HostelName);
        }

        public bool SaveData(HostelDataModel request)
        {
            return UnitOfWork.HostelDetailRepository.SaveData(request);
        }
        public List<HostelDataModel> GetHostelDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int HostelDetailID)
        {
            return UnitOfWork.HostelDetailRepository.GetHostelDetailList_DepartmentCollegeWise(DepartmentID, CollegeID, HostelDetailID);
        }
        public bool DeleteHostelDetail(int HostelDetailID)
        {
            return UnitOfWork.HostelDetailRepository.DeleteHostelDetail(HostelDetailID);
        }
    }
}
