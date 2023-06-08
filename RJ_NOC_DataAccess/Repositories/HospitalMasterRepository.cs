using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;

namespace RJ_NOC_DataAccess.Repository
{
    public class HospitalMasterRepository : IHospitalMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public HospitalMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<HospitalAreaValidation> GetHospitalAreaValidation()
        {
            string SqlQuery = "exec USP_HospitalMaster @Action='GetAllHospitalAreaValidation'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HospitalMasterRepository.GetHospitalAreaValidation");
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            var dataModels = JsonConvert.DeserializeObject<List<HospitalAreaValidation>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
