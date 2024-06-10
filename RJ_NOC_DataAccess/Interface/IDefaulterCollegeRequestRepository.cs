using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDefaulterCollegeRequestRepository
    {
        List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData();
        List<DefaulterCollegeRequestDataModel> GetByID(int RNCCheckListID);
        bool SaveData(DefaulterCollegeRequestDataModel request);       
      

    }

}

