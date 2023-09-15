using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IStreamMaster
    {
        List<CommonDataModel_DataTable> GetAllStreamList(int DepartmentID);
        List<StreamMasterDataModel> GetByID(int StreamMappingID);
        bool SaveData(StreamMasterDataModel request);       
        bool DeleteData(int StreamMappingID);
        bool IfExists(int StreamMappingID, int CourseLevelID, int CourseID, int DepartmentID, int StreamID);


    }
}