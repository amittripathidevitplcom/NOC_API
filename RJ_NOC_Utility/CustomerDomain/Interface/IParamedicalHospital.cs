using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IParamedicalHospital
    {
        List<HospitalAreaValidation> GetHospitalAreaValidation();
        bool SaveData(ParamedicalHospitalDataModel request);
        ParamedicalHospitalDataModel GetData(int hospitalId);
        List<ParamedicalHospitalDataModel> GetDataList(int collegeId);
        bool DeleteData(int hospitalId, int modifiedBy);
        List<ParamedicalHospitalBedValidation> GetParamedicalHospitalBedValidation(int CollegeID, int HospitalID);
    }
}