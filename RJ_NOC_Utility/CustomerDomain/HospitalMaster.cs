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
    }
}
