using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICollegeDocument
    {
        List<CommonDataModel_DataTable> GetAllData(int DepartmentID, int CollegeID, string Type, int ApplyNOCID);
        List<CommonDataModel_DataTable> GetOtherDocumentByID(int OtherDocumentID);
        bool SaveData(CollegeDocumentDataModel request);
        bool Delete(int AID);
    }
}