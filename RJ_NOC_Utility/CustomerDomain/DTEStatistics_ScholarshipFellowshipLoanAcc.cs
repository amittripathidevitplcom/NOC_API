using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_ScholarshipFellowshipLoanAcc : UtilityBase, IDTEStatistics_ScholarshipFellowshipLoanAcc
    {
        public DTEStatistics_ScholarshipFellowshipLoanAcc(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_ScholarshipFellowshipLoanAccDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_ScholarshipFellowshipLoanAccRepository.GetByID(RoleID, EntryType);
        }
        public DTEStatistics_ScholarshipFellowshipLoanAccDataModel ScholarshipFellowshipLoanAccItem(int CollegeID)
        {
            return UnitOfWork.DTEStatistics_ScholarshipFellowshipLoanAccRepository.ScholarshipFellowshipLoanAccItem(CollegeID);
        }
        public bool SaveData(DTEStatistics_ScholarshipFellowshipLoanAccDataModel request)
        {
            return UnitOfWork.DTEStatistics_ScholarshipFellowshipLoanAccRepository.SaveData(request);
        }
    }
}
