using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_RegularForeignStudentEnrolmentRepository
    {
        DTEStatistics_RegularForeignStudentEnrolmentDataModel GetByID(int RoleID, string EntryType);
        bool SaveData(DTEStatistics_RegularForeignStudentEnrolmentDataModel request);
    }

}

