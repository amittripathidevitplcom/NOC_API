using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_RegularForeignStudentEnrolment : UtilityBase, IDTEStatistics_RegularForeignStudentEnrolment
    {
        public DTEStatistics_RegularForeignStudentEnrolment(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_RegularForeignStudentEnrolmentDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_RegularForeignStudentEnrolmentRepository.GetByID(RoleID, EntryType);
        }
        public bool SaveData(DTEStatistics_RegularForeignStudentEnrolmentDataModel request)
        {
            return UnitOfWork.DTEStatistics_RegularForeignStudentEnrolmentRepository.SaveData(request);
        }
    }
}
