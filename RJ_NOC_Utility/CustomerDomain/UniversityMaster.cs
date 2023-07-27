using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class UniversityMaster : UtilityBase, IUniversityMaster
    {
        public UniversityMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }       
        public List<UniversityasterDataModel_list> GetAllUniversityList(int DepartmentID)
        {
            return UnitOfWork.UniversityMasterRepository.GetAllUniversityList(DepartmentID);
        }
        public List<UniversityasterDataModel> GetUniversityIDWise(int UniversityID)
        {
            return UnitOfWork.UniversityMasterRepository.GetUniversityIDWise(UniversityID);
        }
        public bool SaveData(UniversityasterDataModel request)
        {
            return UnitOfWork.UniversityMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int UniversityID)
        {
            return UnitOfWork.UniversityMasterRepository.DeleteData(UniversityID);
        }
        
        public bool IfExists(int UniversityID, string Name)
        {
            return UnitOfWork.UniversityMasterRepository.IfExists(UniversityID, Name);
        }

       
    }
}
