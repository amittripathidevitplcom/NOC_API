using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;

namespace RJ_NOC_DataAccess.Repository
{
    public class TrusteeGeneralInfoMasterRepository : ITrusteeGeneralInfoMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public TrusteeGeneralInfoMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool SaveData(TrusteeGeneralInfoMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("@TrusteeGeneralInfoID='{0}',", request.TrusteeGeneralInfoID);
            sb.AppendFormat("@LegalEntityID='{0}',", request.LegalEntityID);
            sb.AppendFormat("@SocietyRegistrationDocument='{0}',", request.SocietyRegistrationDocument);
            sb.AppendFormat("@SocietyLogo='{0}',", request.SocietyLogo);
            sb.AppendFormat("@DateOfElectionOfPresentManagementCommittee='{0}',", request.DateOfElectionOfPresentManagementCommittee);
            sb.AppendFormat("@WomenMembersOfManagementCommitteeID={0},", request.WomenMembersOfManagementCommitteeID);
            sb.AppendFormat("@DateOfElectionOfManagementCommitteeID={0},", request.DateOfElectionOfManagementCommitteeID);
            sb.AppendFormat("@OtherInstitutionRunByTheSocietyID={0},", request.OtherInstitutionRunByTheSocietyID);

            sb.AppendFormat("@CreatedBy={0},", request.CreatedBy);
            sb.AppendFormat("@ModifyBy={0},", request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',", IPAddress);

            // action
            sb.AppendFormat("@Action='{0}'", "SaveTrusteeGeneralInfoData");

            string SqlQuery = $" exec USP_TrusteeGeneralInfoMaster  {sb.ToString()}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "TrusteeGeneralInfoMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int TrusteeGeneralInfoId, int modifiedBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_TrusteeGeneralInfoMaster @Action='DeleteTrusteeGeneralInfoById',@ModifyBy={modifiedBy},@TrusteeGeneralInfoID={TrusteeGeneralInfoId},@IPAddress='{IPAddress}'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "TrusteeGeneralInfoMaster.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public TrusteeGeneralInfoMasterDataModel GetData(int TrusteeGeneralInfoId)
        {
            string SqlQuery = $"exec USP_TrusteeGeneralInfoMaster @TrusteeGeneralInfoID={TrusteeGeneralInfoId},@Action='GetTrusteeGeneralInfoById'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "TrusteeGeneralInfoMaster.GetData");

            TrusteeGeneralInfoMasterDataModel trusteeGeneralInfoMasterDataModel = new TrusteeGeneralInfoMasterDataModel();
            if (dt != null)
            {
                trusteeGeneralInfoMasterDataModel = CommonHelper.ConvertDataTable<TrusteeGeneralInfoMasterDataModel>(dt);
            }
            return trusteeGeneralInfoMasterDataModel;
        }
        public List<TrusteeGeneralInfoMasterDataModel> GetDataList(int legalEntityID)
        {
            string SqlQuery = $"exec USP_TrusteeGeneralInfoMaster @LegalEntityID={legalEntityID},@Action='GetTrusteeGeneralInfoListByLegalEntityId'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "TrusteeGeneralInfoMaster.GetDataList");

            List<TrusteeGeneralInfoMasterDataModel> trusteeGeneralInfoMasterDataModel = new List<TrusteeGeneralInfoMasterDataModel>();
            if (dt != null)
            {
                trusteeGeneralInfoMasterDataModel = CommonHelper.ConvertDataTable<List<TrusteeGeneralInfoMasterDataModel>>(dt);
            }
            return trusteeGeneralInfoMasterDataModel;
        }
        public LegalEntityDataModel GetDataOfLegalEntity(string ssoId)
        {
            string SqlQuery = $"exec USP_TrusteeGeneralInfoMaster @SSOID='" + ssoId + "',@Action='GetLegalEntityBySsoId'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "TrusteeGeneralInfoMaster.GetDataOfLegalEntity");

            List<LegalEntityDataModel> legalEntityDataModel1 = new List<LegalEntityDataModel>();
            LegalEntityDataModel legalEntityDataModel = new LegalEntityDataModel();
            if (dt != null)
            {
                legalEntityDataModel1 = CommonHelper.ConvertDataTable<List<LegalEntityDataModel>>(dt);
                legalEntityDataModel = legalEntityDataModel1.FirstOrDefault();
            }
            return legalEntityDataModel;
        }

        public List<TrusteeGeneralInfoMasterDataModel> GetDataListForPDF(int legalEntityID)
        {
            string SqlQuery = $"exec USP_TrusteeGeneralInfoMaster @LegalEntityID={legalEntityID},@Action='GetTrusteeGeneralInfoListByLegalEntityId'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "TrusteeGeneralInfoMaster.GetDataList");

            List<TrusteeGeneralInfoMasterDataModel> trusteeGeneralInfoMasterDataModel = new List<TrusteeGeneralInfoMasterDataModel>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SocietyLogo"] = _commonHelper.ConvertTobase64(dt.Rows[i]["SocietyLogo"].ToString());
                }
                trusteeGeneralInfoMasterDataModel = CommonHelper.ConvertDataTable<List<TrusteeGeneralInfoMasterDataModel>>(dt);
            }
            return trusteeGeneralInfoMasterDataModel;
        }
    }
}
