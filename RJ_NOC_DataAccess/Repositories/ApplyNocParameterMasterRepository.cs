using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;

namespace RJ_NOC_DataAccess.Repository
{
    public class ApplyNocParameterMasterRepository : IApplyNocParameterMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ApplyNocParameterMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DataTable GetApplyNocParameterMaster(int CollegeID)
        {
            string SqlQuery = $"exec USP_ApplyNocParameterMaster @action='GetApplyNocParameterMaster',@CollegeID={CollegeID}";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ApplyNocParameterMaster.GetApplyNocParameterMaster");
            return dt;
        }
        public DataSet GetApplyNocForByParameter(int CollegeID, string ApplyNocFor)
        {
            string SqlQuery = $"exec USP_ApplyNocParameterMaster @action='GetApplyNocForByParameter',@CollegeID={CollegeID} ,@ApplyNocFor='{ApplyNocFor}'";
            var ds = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNocParameterMaster.GetApplyNocForByParameter");
            return ds;
        }

        public bool SaveApplyNocApplication(string query)
        {
            string SqlQuery = $" exec USP_Trn_ApplyNocApplication  {query}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ApplyNocParameterMaster.SaveApplyNocApplication");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        
        public DataTable GetApplyNocApplicationList()
        {
            string SqlQuery = "exec USP_Trn_ApplyNocApplication @action='GetApplyNocApplicationList'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ApplyNocParameterMaster.GetApplyNocApplicationList");
            return dt;
        }
    }
}
