using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class ClinicalFacilityRepository: IClinicalFacilityRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ClinicalFacilityRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetCourseClinicalFacilityList(int CollegeID)
        {
            string SqlQuery = "exec [USP_GetCourseClinicalFacilityList] @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ClinicalFacility.GetCourseClinicalFacilityList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveData(ClinicalFacilityModel clinicalFacility)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string clinicalFacility_Str = CommonHelper.GetDetailsTableQry(clinicalFacility.FacilityList, "Temp_School_Facility");
            string SqlQuery = " exec USP_Trn_ClinicalFacilityDetails_IU";

            SqlQuery += " @CollegeID='" + clinicalFacility.CollegeID + "',";
            SqlQuery += " @UserId='" + clinicalFacility.UserId + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @BuildingDetail_Document_Str='" + clinicalFacility_Str + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "ClinicalFacility.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
