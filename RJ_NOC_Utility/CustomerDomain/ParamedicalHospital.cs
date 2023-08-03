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
        public bool SaveData(ParamedicalHospitalDataModel request)
        {
            return UnitOfWork.ParamedicalHospitalRepository.SaveData(request);
        }
       
    }
}
