using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_StaffRepository
    {
        List<DTEStatistics_StaffDataModels> TeachingStaff(int CollegeID, string EntryType);
        DTEStatistics_NonTeachingDataModel NonTeaching_GetByID(int CollegID, int UserID, string EntryType);
        bool SaveData(DTEStatistics_NonTeachingDataModel request);
    }

}
