using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICollegeDocumentRepository
    {

        List<CommonDataModel_DataTable> GetAllData(int DepartmentID,int CollegeID, string Type);
        bool SaveData(CollegeDocumentDataModel request);
    }

}

