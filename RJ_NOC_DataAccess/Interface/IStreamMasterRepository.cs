using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IStreamMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllStreamList(int DepartmentID);
        List<StreamMasterDataModel> GetByID(int StreamMappingID);
        bool SaveData(StreamMasterDataModel request);       
        bool DeleteData(int StreamMappingID);
        bool IfExists(int StreamMappingID, int CourseLevelID, int CourseID, int DepartmentID, int StreamID);
      

    }

}

