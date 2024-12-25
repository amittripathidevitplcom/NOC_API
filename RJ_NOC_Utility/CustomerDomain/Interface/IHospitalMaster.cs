using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IHospitalMaster
    {
        bool DeleteData(int hospitalId, int modifiedBy);
        HospitalMasterDataModel GetData(int hospitalId);
        List<HospitalMasterDataModel> GetDataList(int collegeId); 
        List<HospitalAreaValidation> GetHospitalAreaValidation();
        bool IsSuperSpecialtyHospital(int collegeId);
        bool SaveData(HospitalMasterDataModel request);
        List<HospitalMasterDataModel> GetHospitalDataListforPDF(int CollegeID);
        bool SaveMGThreeHospitalData(MGThreeHospitalDataModel request);
    }
}