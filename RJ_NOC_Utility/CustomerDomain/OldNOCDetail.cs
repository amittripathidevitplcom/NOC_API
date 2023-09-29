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
    public class OldNOCDetail : UtilityBase, IOldNOCDetail
    {
        public OldNOCDetail(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        //public bool IfExists(int HostelDetailID, int CollegeID, string HostelName)
        //{
        //    return UnitOfWork.HostelDetailRepository.IfExists(HostelDetailID, CollegeID, HostelName);
        //}

        public bool SaveData(OldNocDetailsDataModel request)
        {
            return UnitOfWork.OldNOCDetailRepository.SaveData(request);
        }
        public List<OldNocDetailsDataModel> GetOldNOCDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int OldNocID)
        {
            return UnitOfWork.OldNOCDetailRepository.GetOldNOCDetailList_DepartmentCollegeWise(DepartmentID,CollegeID,OldNocID);
        }
        public bool DeleteOldNocDetail(int OldNocID)
        {
            return UnitOfWork.OldNOCDetailRepository.DeleteOldNocDetail(OldNocID);
        }
        public bool IfExists (int OldNocID, string NOCNumber)
        {
            return UnitOfWork.OldNOCDetailRepository.IfExists(OldNocID, NOCNumber);
        }
        public List<CommonDataModel_DataSet> GetOldNOCDetailListForPDF(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.OldNOCDetailRepository.GetOldNOCDetailListForPDF(DepartmentID, CollegeID);
        }
    }
}
