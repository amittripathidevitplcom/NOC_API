using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IQualificationMaster
    {

        List<CommonDataModel_DataTable> GetQualificationMasterList(int DepartmentID);
        List<QualificationMasterDataModel> GetQualificationMasterIDWise(int QualificationID);
        bool SaveData(QualificationMasterDataModel request);
        bool DeleteData(int QualificationID);

        bool IfExists(int QualificationID, int DepartmentID, string QualificationName);
    }
}

