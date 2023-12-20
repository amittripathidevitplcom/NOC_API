using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IGrievance
    {
        List<CommonDataModel_DataTable> GetAllGrievance();
        List<GrievanceDataModel> GetByID(int GrievanceID);
        List<DataTable> GetGrievance_AddedSSOIDWise(string SSOID);
        bool SaveData(GrievanceDataModel request);
        bool DeleteData(int GrievanceID);
        bool IfExists(int GrievanceID, int DepartmentID, string AnimalName);

    }
}