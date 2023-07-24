using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using static RJ_NOC_Model.VeterinaryHospitalDataModel;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class VeterinaryHospital : UtilityBase, IVeterinaryHospital
    {
        public VeterinaryHospital(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<AnimalDataModel_AnimalList> GetAnimalMasterList()
        {
            return UnitOfWork.VeterinaryHospitalRepository.GetAnimalMasterList();
        }
        public List<VeterinaryHospitalDataModelList> GetAllVeterinaryHospitalList(int CollegeID)
        {
            return UnitOfWork.VeterinaryHospitalRepository.GetAllVeterinaryHospitalList(CollegeID);
        }
        public VeterinaryHospitalDataModel GetVeterinaryHospitalByIDWise(int VeterinaryHospitalID)
        {
            return UnitOfWork.VeterinaryHospitalRepository.GetVeterinaryHospitalByIDWise(VeterinaryHospitalID);
        }
        public bool SaveData(VeterinaryHospitalDataModel request)
        {
            return UnitOfWork.VeterinaryHospitalRepository.SaveData(request);
        }
        public bool DeleteData(int VeterinaryHospitalID)
        {
            return UnitOfWork.VeterinaryHospitalRepository.DeleteData(VeterinaryHospitalID);
        }
    }
}
