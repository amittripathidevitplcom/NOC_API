using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class QualificationMaster : UtilityBase, IQualificationMaster
    {
        public QualificationMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetQualificationMasterList(int DepartmentID)
        {
            return UnitOfWork.QualificationMasterRepository.GetQualificationMasterList(DepartmentID);
        }
        public List<QualificationMasterDataModel> GetQualificationMasterIDWise(int QualificationID)
        {
            return UnitOfWork.QualificationMasterRepository.GetQualificationMasterIDWise(QualificationID);
        }
        public bool SaveData(QualificationMasterDataModel request)
        {
            return UnitOfWork.QualificationMasterRepository.SaveData(request);
        }

        public bool DeleteData(int QualificationID)
        {
            return UnitOfWork.QualificationMasterRepository.DeleteData(QualificationID);
        }

        public bool IfExists(int QualificationID, int DistrictID, string QualificationName, string Type)
        {
            return UnitOfWork.QualificationMasterRepository.IfExists(QualificationID, DistrictID, QualificationName,Type);
        }

    }
}

