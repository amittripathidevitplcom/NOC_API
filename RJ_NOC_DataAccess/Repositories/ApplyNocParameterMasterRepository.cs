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
        public DataTable GetApplyNoc_FDRMasterByCollegeID(int CollegeID)
        {
            string SqlQuery = $"exec USP_ApplyNocFDRMaster @action='GetApplyNocFDRMasterByCollegeID',@CollegeID={CollegeID}";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ApplyNocParameterMaster.GetApplyNoc_FDRMasterByCollegeID");
            return dt;
        }
        public bool SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplyNoc_FDRMasterDetail @ApplyNocFDRID='" + request.ApplyNocFDRID + "',@ApplyNocID='" + request.ApplyNocID + "',";
            SqlQuery += "@CollegeID = '" + request.CollegeID + "',@BankName = '" + request.BankName + "',@BranchName = '" + request.BranchName + "',@IFSCCode = '" + request.IFSCCode + "',";
            SqlQuery += "@FDRNumber = '" + request.FDRNumber + "',@FDRAmount = '" + request.FDRAmount + "',@FDRDate = '" + request.FDRDate + "',@PeriodOfFDR = '" + request.PeriodOfFDR + "',"; 
           SqlQuery += "@IsFDRSubmited = '" + request.IsFDRSubmited + "',@FDRDocument = '" + request.FDRDocument + "',@IPAddress = '" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public DataTable GetApplyNocFDRDetails(int ApplyNocFDRID, int ApplyNocID)
        {
            string SqlQuery = $"exec USP_GetApplyNocFDRDetails @ApplyNocFDRID={ApplyNocFDRID} ,@ApplyNocID='{ApplyNocID}'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ApplyNocParameterMaster.GetApplyNocFDRDetails");
            return dt;
        }
        

        public DataTable GetApplyNocApplicationList()
        {
            string SqlQuery = "exec USP_Trn_ApplyNocApplication @action='GetApplyNocApplicationList'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ApplyNocParameterMaster.GetApplyNocApplicationList");
            return dt;
        }

        public DataSet GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID)
        {
            string SqlQuery = $"exec USP_Trn_ApplyNocApplication @action='GetApplyNocApplicationTrnByApplicationID',@ApplyNocApplicationID={ApplyNocApplicationID}";
            var ds = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNocParameterMaster.GetApplyNocApplicationList");
            return ds;
        }

        public bool DeleteApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy, string IpAddress)
        {
            string SqlQuery = $"exec USP_Trn_ApplyNocApplication @action='DeleteApplyNocApplicationTrnByApplicationID',@ApplyNocApplicationID={ApplyNocApplicationID},@IPAddress='{IpAddress}',@ModifyBy={ModifyBy}";
            var rows = _commonHelper.NonQuerry(SqlQuery, "ApplyNocParameterMaster.DeleteApplyNocApplicationByApplicationID");
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
