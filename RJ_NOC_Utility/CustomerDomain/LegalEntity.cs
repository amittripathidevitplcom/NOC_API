using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class LegalEntity : UtilityBase, ILegalEntity
    {
        public LegalEntity(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<CommonDataModel_DataTable> GetAllLegalEntity()
        {
            throw new NotImplementedException();
        }
        public bool IfExists(int LegalEntityID, string RegistrationNo, string AadhaarNo)
        {
            return UnitOfWork.LegalEntityRepository.IfExists(LegalEntityID, RegistrationNo,AadhaarNo);
        }
        public bool SaveData(LegalEntityModel request)
        {
            return UnitOfWork.LegalEntityRepository.SaveData(request);
        }
        public List<LegalEntityListModel> GetLegalEntityList(string SSOID)
        {
            return UnitOfWork.LegalEntityRepository.GetLegalEntityList(SSOID);
        }
        public List<LegalEntityListModel> ViewlegalEntityDataByID(int LegalEntityID,string SSOID)
        {
            return UnitOfWork.LegalEntityRepository.ViewlegalEntityDataByID(LegalEntityID, SSOID);
        }
        public List<LegalEntityListModel> GetLegalEntityBySSOID(string SSOID)
        {
            return UnitOfWork.LegalEntityRepository.GetLegalEntityBySSOID(SSOID);
        }
        public bool CheckExistsLegalEntity(string SSOID, int RoleID)
        {
            return UnitOfWork.LegalEntityRepository.CheckExistsLegalEntity(SSOID,RoleID);
        }
    }
}
