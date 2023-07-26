using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class FacilitiesMaster : UtilityBase, IFacilitiesMaster
    {
        public FacilitiesMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }       
        public List<FacilitiesMasterDataModel_list> GetAllFacilitiesList()
        {
            return UnitOfWork.FacilitiesMasterRepository.GetAllFacilitiesList();
        }
        public List<FacilitiesMasterDataModel> GetFacilitiesIDWise(int UniversityID)
        {
            return UnitOfWork.FacilitiesMasterRepository.GetFacilitiesIDWise(UniversityID);
        }
        public bool SaveData(FacilitiesMasterDataModel request)
        {
            return UnitOfWork.FacilitiesMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int FID)
        {
            return UnitOfWork.FacilitiesMasterRepository.DeleteData(FID);
        }
        
        public bool IfExists(int FID,int DepartmentID, string FacilitiesName)
        {
            return UnitOfWork.FacilitiesMasterRepository.IfExists(FID, DepartmentID, FacilitiesName);
        }

       
    }
}
