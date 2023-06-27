using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IHospitalMasterRepository
    {
        bool DeleteData(int hospitalId, int modifiedBy);
        bool IsSuperSpecialtyHospital(int collegeId);
        HospitalMasterDataModel GetData(int hospitalId);
        List<HospitalMasterDataModel> GetDataList(int collegeId);
        List<HospitalAreaValidation> GetHospitalAreaValidation();
        bool SaveData(HospitalMasterDataModel request);
    }
}