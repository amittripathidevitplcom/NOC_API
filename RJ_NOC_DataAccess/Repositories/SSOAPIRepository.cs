using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class SSOAPIRepository : ISSOAPIRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public SSOAPIRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> Check_SSOIDWise_LegalEntity(string SSOID)
        {
            string SqlQuery = " exec USP_Check_SSOIDWise_LegalEntity @SSOID='"+ SSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SubjectMasterService.GetDepartmentByCourse");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DataTable>>(JsonDataTable_Data);
            return dataModels;
        }

    }
}
