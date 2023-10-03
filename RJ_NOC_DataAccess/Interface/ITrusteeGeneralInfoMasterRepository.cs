using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ITrusteeGeneralInfoMasterRepository
    {
        bool DeleteData(int TrusteeGeneralInfoId, int modifiedBy);
        TrusteeGeneralInfoMasterDataModel GetData(int TrusteeGeneralInfoId);
        List<TrusteeGeneralInfoMasterDataModel> GetDataList(int legalEntityID);
        List<TrusteeGeneralInfoMasterDataModel> GetDataListForPDF(int legalEntityID);
        public LegalEntityDataModel GetDataOfLegalEntity(string ssoId);
        bool SaveData(TrusteeGeneralInfoMasterDataModel request);
    }
}