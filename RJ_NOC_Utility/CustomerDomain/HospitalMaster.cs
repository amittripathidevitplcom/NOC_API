using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class HospitalMaster : UtilityBase, IHospitalMaster
    {
        public HospitalMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public List<HospitalAreaValidation> GetHospitalAreaValidation()
        {
            return UnitOfWork.HospitalMasterRepository.GetHospitalAreaValidation();
        }
        public bool SaveData(HospitalMasterDataModel request)
        {
            return UnitOfWork.HospitalMasterRepository.SaveData(request);
        }
        public bool IsSuperSpecialtyHospital(int collegeId)
        {
            return UnitOfWork.HospitalMasterRepository.IsSuperSpecialtyHospital(collegeId);
        }
        public bool DeleteData(int hospitalId, int modifiedBy)
        {
            return UnitOfWork.HospitalMasterRepository.DeleteData(hospitalId, modifiedBy);
        }
        public HospitalMasterDataModel GetData(int hospitalId)
        {
            return UnitOfWork.HospitalMasterRepository.GetData(hospitalId);
        }
        public List<HospitalMasterDataModel> GetDataList(int collegeId)
        {
            return UnitOfWork.HospitalMasterRepository.GetDataList(collegeId);
        }
    }
}
