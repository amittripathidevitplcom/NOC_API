using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IQualificationMasterRepository
    {
        List<CommonDataModel_DataTable> GetQualificationMasterList(int DepratmentID);
        List<QualificationMasterDataModel> GetQualificationMasterIDWise(int QualificationID);
        bool SaveData(QualificationMasterDataModel request);
        bool DeleteData(int QualificationID);
        bool IfExists(int QualificationID, int DepartmentID, string QualificationName);
    }

}