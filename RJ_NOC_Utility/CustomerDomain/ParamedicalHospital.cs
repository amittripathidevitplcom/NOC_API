using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ParamedicalHospital : UtilityBase, IParamedicalHospital
    {
        public ParamedicalHospital(IRepositories unitOfWork) : base(unitOfWork)
        {

        }
        public List<HospitalAreaValidation> GetHospitalAreaValidation()
        {
            return UnitOfWork.ParamedicalHospitalRepository.GetHospitalAreaValidation();
        }    
        public bool SaveData(ParamedicalHospitalDataModel request)
        {
            return UnitOfWork.ParamedicalHospitalRepository.SaveData(request);
        }
        public ParamedicalHospitalDataModel GetData(int hospitalId)
        {
            return UnitOfWork.ParamedicalHospitalRepository.GetData(hospitalId);
        }
        public List<ParamedicalHospitalDataModel> GetDataList(int collegeId)
        {
            return UnitOfWork.ParamedicalHospitalRepository.GetDataList(collegeId);
        }
        public bool DeleteData(int hospitalId, int modifiedBy)
        {
            return UnitOfWork.ParamedicalHospitalRepository.DeleteData(hospitalId, modifiedBy);
        }
        public List<ParamedicalHospitalBedValidation> GetParamedicalHospitalBedValidation(int CollegeID, int HospitalID)
        {
            return UnitOfWork.ParamedicalHospitalRepository.GetParamedicalHospitalBedValidation(CollegeID, HospitalID);
        }
       
    }
}
