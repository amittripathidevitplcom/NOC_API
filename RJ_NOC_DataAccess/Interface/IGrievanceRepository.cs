using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IGrievanceRepository
    {
        List<CommonDataModel_DataTable> GetAllGrievance();
        List<GrievanceDataModel> GetByID(int GrievanceID);
        List<DataTable> GetGrievance_AddedSSOIDWise(string SSOID);
        bool SaveData(GrievanceDataModel request);       
        bool DeleteData(int GrievanceID);
        bool IfExists(int GrievanceID,int DepartmentID, string AnimalName);
      

    }

}

