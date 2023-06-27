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
    public class CollegeDocument : UtilityBase, ICollegeDocument
    {
        public CollegeDocument(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllData(int DepartmentID, int CollegeID, string Type)
        {
            return UnitOfWork.CollegeDocumentRepository.GetAllData(DepartmentID, CollegeID, Type);
        } 
        public bool SaveData(CollegeDocumentDataModel request)
        {
            return UnitOfWork.CollegeDocumentRepository.SaveData(request);
        }
         
         
    }
}
