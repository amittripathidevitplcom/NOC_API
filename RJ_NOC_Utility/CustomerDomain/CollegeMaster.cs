using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class CollegeMaster : UtilityBase, ICollegeMaster
    {
        public CollegeMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        } 
        public bool SaveData(CollegeMasterDataModel request)
        {
            return UnitOfWork.CollegeMasterRepository.SaveData(request);
        }

        public List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID)
        {
            return UnitOfWork.CollegeMasterRepository.DraftApplicationList(LoginSSOID);
        }
    }
}
