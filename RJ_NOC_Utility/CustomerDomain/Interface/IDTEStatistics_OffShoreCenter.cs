using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_OffShoreCenter
    {
       DTEStatistics_OffShoreCenterDataModel GetByID(int RoleID);
        bool SaveData(DTEStatistics_OffShoreCenterDataModel request);
    }
}