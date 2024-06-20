using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ClinicalFacility : UtilityBase, IClinicalFacility
    {
        public ClinicalFacility(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetCourseClinicalFacilityList(int CollegeID){
            return UnitOfWork.ClinicalFacilityRepository.GetCourseClinicalFacilityList(CollegeID);
        }
        public bool SaveData(ClinicalFacilityModel clinicalFacility)
        {
            return UnitOfWork.ClinicalFacilityRepository.SaveData(clinicalFacility);
        }
        public List<CommonDataModel_DataTable> GetCollegeClinicalFacilityList(int CollegeID)
        {
            return UnitOfWork.ClinicalFacilityRepository.GetCollegeClinicalFacilityList(CollegeID);
        }
    }
}
