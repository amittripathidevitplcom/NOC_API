using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_Faculty : UtilityBase, IDTEStatistics_Faculty
    {
        public DTEStatistics_Faculty(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_FacultyDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_FacultyRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_FacultyDataModel request)
        {
            return UnitOfWork.DTEStatistics_FacultyRepository.SaveData(request);
        }
    }
}
