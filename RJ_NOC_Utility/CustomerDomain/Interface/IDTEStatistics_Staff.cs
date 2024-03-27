using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_Staff
    {
        List<DTEStatistics_StaffDataModels> TeachingStaff(int CollegeID, string EntryType);
        DTEStatistics_NonTeachingDataModel NonTeaching_GetByID(int CollegID, int UserID, string EntryType);
        bool SaveData(DTEStatistics_NonTeachingDataModel request); 
    }

}
