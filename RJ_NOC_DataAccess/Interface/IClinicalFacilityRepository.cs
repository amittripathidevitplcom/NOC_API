using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IClinicalFacilityRepository
    {
        public List<CommonDataModel_DataTable> GetCourseClinicalFacilityList(int CollegeID);
        public bool SaveData(ClinicalFacilityModel clinicalFacility);
        public List<CommonDataModel_DataTable> GetCollegeClinicalFacilityList(int CollegeID); 
    }
}
