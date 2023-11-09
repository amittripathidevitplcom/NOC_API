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
    public class StaffDetail : UtilityBase, IStaffDetail
    {
        public StaffDetail(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool IfExistsPrincipal(int StaffDetailID, int CollegeID, int DesignationID)
        {
            return UnitOfWork.StaffDetailRepository.IfExistsPrincipal(StaffDetailID, CollegeID, DesignationID);
        }

        public bool SaveData(StaffDetailDataModel request)
        {
            return UnitOfWork.StaffDetailRepository.SaveData(request);
        }
        public List<StaffDetailDataModel> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int StaffDetailID, int ApplyNOCID)
        {
            return UnitOfWork.StaffDetailRepository.GetStaffDetailList_DepartmentCollegeWise(DepartmentID,CollegeID,StaffDetailID, ApplyNOCID);
        }   
        public bool DeleteStaffDetail(int StaffDetailID)
        {
            return UnitOfWork.StaffDetailRepository.DeleteStaffDetail(StaffDetailID);
        }
        public List<CommonDataModel_DataSet> GetStaffDetailListForPDF(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.StaffDetailRepository.GetStaffDetailListForPDF(DepartmentID,  CollegeID);
        }
    }
}
