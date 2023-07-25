using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IStreamMaster
    {
        List<CommonDataModel_DataTable> GetAllStreamList();
        List<StreamMasterDataModel> GetByID(int StreamMasterID);
        bool SaveData(StreamMasterDataModel request);       
        bool DeleteData(int StreamMasterID);
        bool IfExists(int StreamMasterID, int CourseLevelID, int CourseID, int DepartmentID, string StreamName);


    }
}