using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IStreamMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllStreamList();
        List<StreamMasterDataModel> GetByID(int StreamMasterID);
        bool SaveData(StreamMasterDataModel request);       
        bool DeleteData(int StreamMasterID);
        bool IfExists(int StreamMasterID, int DepartmentID, string StreamName);
      

    }

}

