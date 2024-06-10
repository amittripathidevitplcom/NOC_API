using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using System.Text;


namespace RJ_NOC_DataAccess.Repository
{
    public class DefaulterCollegeRequestRepository : IDefaulterCollegeRequestRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DefaulterCollegeRequestRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData()
        {
            string SqlQuery = " exec USP_GetDefaulterCollegeRequestData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.GetRNCCheckListData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<DefaulterCollegeRequestDataModel> GetByID(int RNCCheckListID)
        {
            string SqlQuery = " exec USP_GetDefaulterCollegeRequestData @RNCCheckListID='" + RNCCheckListID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.GetByRNCCheckListID");

            List<DefaulterCollegeRequestDataModel> dataModels = new List<DefaulterCollegeRequestDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DefaulterCollegeRequestDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(DefaulterCollegeRequestDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@RequestID='{0}',", request.RequestID);
            sb.AppendFormat("@SSOID='{0}',", request.SSOID);
            sb.AppendFormat("@DepartmentID='{0}',", request.DepartmentID);
            sb.AppendFormat("@EverAppliedNOC='{0}',", request.EverAppliedNOC);
            sb.AppendFormat("@IsPNOC='{0}',", request.IsPNOC);
            sb.AppendFormat("@FirstNOCDoc='{0}',", request.FirstNOCDoc);
            sb.AppendFormat("@LastNOCDoc='{0}',", request.LastNOCDoc);
            sb.AppendFormat("@LatestAffiliationDoc='{0}',", request.LatestAffiliationDoc);
            sb.AppendFormat("@ResultLastSessionDoc='{0}',", request.ResultLastSessionDoc);
            sb.AppendFormat("@LastSessionProofOfExaminationDoc='{0}',", request.LastSessionProofOfExaminationDoc);
            sb.AppendFormat("@LastApplicationNo='{0}',", request.LastApplicationNo);
            sb.AppendFormat("@LastApplicationSubmittedDate='{0}',", request.LastApplicationSubmittedDate);
            sb.AppendFormat("@CollegeName='{0}',", request.CollegeName);
            sb.AppendFormat("@CollegeNameHi=N'{0}',", request.CollegeNameHi);
            sb.AppendFormat("@CollegeEmail='{0}',", request.CollegeEmail);
            sb.AppendFormat("@CollegeMobileNo='{0}',", request.CollegeMobileNo);
            sb.AppendFormat("@DivisionID='{0}',", request.DivisionID);
            sb.AppendFormat("@DistrictID='{0}',", request.DistrictID);
            sb.AppendFormat("@UniversityID='{0}',", request.UniversityID);
            sb.AppendFormat("@CollegeTypeID='{0}',", request.CollegeTypeID);
            sb.AppendFormat("@CollegeLevelID='{0}',", request.CollegeLevelID);
            sb.AppendFormat("@EstablishmentYearID='{0}',", request.EstablishmentYearID);
            sb.AppendFormat("@CollegePresentStatusID='{0}',", request.CollegePresentStatusID);
            sb.AppendFormat("@CaseOperatedTNOCLevel='{0}',", request.CaseOperatedTNOCLevel);
            sb.AppendFormat("@LastSessionOfTNOCID='{0}',", request.LastSessionOfTNOCID);
            sb.AppendFormat("@ActiveStatus='{0}',", request.ActiveStatus);
            sb.AppendFormat("@DeleteStatus='{0}',", request.DeleteStatus);
            sb.AppendFormat("@UserID='{0}',", request.UserID);
            sb.AppendFormat("@IPAddress='{0}'", IPAddress);

            string SqlQuery = $" exec USP_Trn_College_DefaulterRequest_IU  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollegeRequest.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }


    }
}
