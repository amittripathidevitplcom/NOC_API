using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_Staff : UtilityBase, IDTEStatistics_Staff
    {
        public DTEStatistics_Staff(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public  DTEStatistics_NonTeachingDataModel NonTeaching_GetByID(int CollegID, int UserID, string EntryType)
        {
            return UnitOfWork.DTEStatistics_StaffRepository.NonTeaching_GetByID(CollegID, UserID, EntryType);
        }

        public bool SaveData(DTEStatistics_NonTeachingDataModel request)
        {
            return UnitOfWork.DTEStatistics_StaffRepository.SaveData(request);
        }

        public List<DTEStatistics_StaffDataModels> TeachingStaff(int CollegeID, string EntryType)
        {
            return UnitOfWork.DTEStatistics_StaffRepository.TeachingStaff(CollegeID, EntryType);
        }
    }
}
