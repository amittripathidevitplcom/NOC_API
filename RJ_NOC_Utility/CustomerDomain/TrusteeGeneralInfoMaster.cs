using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class TrusteeGeneralInfoMaster : UtilityBase, ITrusteeGeneralInfoMaster
    {
        public TrusteeGeneralInfoMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public bool SaveData(TrusteeGeneralInfoMasterDataModel request)
        {
            return UnitOfWork.TrusteeGeneralInfoMasterRepository.SaveData(request);
        }
        public bool DeleteData(int TrusteeGeneralInfoId, int modifiedBy)
        {
            return UnitOfWork.TrusteeGeneralInfoMasterRepository.DeleteData(TrusteeGeneralInfoId, modifiedBy);
        }
        public TrusteeGeneralInfoMasterDataModel GetData(int TrusteeGeneralInfoId)
        {
            return UnitOfWork.TrusteeGeneralInfoMasterRepository.GetData(TrusteeGeneralInfoId);
        }
        public List<TrusteeGeneralInfoMasterDataModel> GetDataList(int legalEntityID)
        {
            return UnitOfWork.TrusteeGeneralInfoMasterRepository.GetDataList(legalEntityID);
        }
        public LegalEntityDataModel GetDataOfLegalEntity(string ssoId)
        {
            return UnitOfWork.TrusteeGeneralInfoMasterRepository.GetDataOfLegalEntity(ssoId);
        }
    }
}
