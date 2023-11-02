using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface ISeatInformationMasterRepository
    {
        List<CommonDataModel_DataTable> GetSeatInformationList();
        List<SeatInformationMasterDataModel> GetSeatByID(int ID);
        bool SaveData(SeatInformationMasterDataModel request);       
        bool DeleteData(int ID);
        bool IfExists(int ID, int DepartmentID, int CourseID);
      

    }

}

