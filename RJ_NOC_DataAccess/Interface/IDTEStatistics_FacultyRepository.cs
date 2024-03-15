using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_FacultyRepository
    {
        DTEStatistics_FacultyDataModel GetByID(int RoleID);
        bool SaveData(DTEStatistics_FacultyDataModel request);
    }

}

