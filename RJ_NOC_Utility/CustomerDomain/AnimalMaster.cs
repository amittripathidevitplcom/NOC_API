using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class AnimalMaster : UtilityBase, IAnimalMaster
    {
        public AnimalMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllAnimalList()
        {
            return UnitOfWork.AnimalMasterRepository.GetAllAnimalList();
        }
        public List<AnimalMasterDataModel> GetByID(int AnimalMasterID)
        {
            return UnitOfWork.AnimalMasterRepository.GetByID(AnimalMasterID);
        }
        public bool SaveData(AnimalMasterDataModel request)
        {
            return UnitOfWork.AnimalMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int AnimalMasterID)
        {
            return UnitOfWork.AnimalMasterRepository.DeleteData(AnimalMasterID);
        }
        
        public bool IfExists(int AnimalMasterID, int DepartmentID, string AnimalName)
        {
            return UnitOfWork.AnimalMasterRepository.IfExists(AnimalMasterID, DepartmentID, AnimalName);
        }

       
    }
}
