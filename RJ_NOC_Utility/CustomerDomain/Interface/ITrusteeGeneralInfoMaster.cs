using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ITrusteeGeneralInfoMaster
    {
        bool DeleteData(int TrusteeGeneralInfoId, int modifiedBy);
        TrusteeGeneralInfoMasterDataModel GetData(int TrusteeGeneralInfoId);
        List<TrusteeGeneralInfoMasterDataModel> GetDataList(int legalEntityID);
        public LegalEntityDataModel GetDataOfLegalEntity(string ssoId);
        bool SaveData(TrusteeGeneralInfoMasterDataModel request);
    }
}