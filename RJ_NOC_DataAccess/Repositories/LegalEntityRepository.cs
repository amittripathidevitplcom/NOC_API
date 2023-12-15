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
    public class LegalEntityRepository : ILegalEntityRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public LegalEntityRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<CommonDataModel_DataTable> GetAllProject()
        {
            string SqlQuery = " exec USP_LegalEntity_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LegalEntity.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool IfExists(int LegalEntityID, string RegistrationNo, string AadhaarNo)
        {
            string SqlQuery = " USP_IfExistsLegalEntity @RegistrationNo='" + RegistrationNo + "',@LegalEntityID='" + LegalEntityID + "',@AadhaarNo='" + AadhaarNo + "'";
            DataSet dataset = new DataSet();
            dataset = _commonHelper.Fill_DataSet(SqlQuery, "LegalEntity.IfExists");
            if (dataset != null)
            {
                if (dataset.Tables[0].Rows.Count > 0 || dataset.Tables[1].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            else
            { return false; }
        }
        public bool SaveData(LegalEntityModel request)
        {
            string MemberDetail_Str = request.MemberDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.MemberDetails, "Temp_MemberDetail_LegalEntity") : "";
            string InstituteDetail_Str = request.InstituteDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.InstituteDetails, "Temp_InstituteDetail_LegalEntity") : "";
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveLegalEntity_IU  ";
            SqlQuery += "@LegalEntityID='" + request.LegalEntityID + "',@IsLegalEntity='" + request.IsLegalEntity + "',@SSOID='" + request.SSOID + "',@RegistrationNo='" + request.RegistrationNo + "',@PresidentMobileNo='" + request.PresidentMobileNo + "',@PresidentEmail='" + request.PresidentEmail + "',@SocietyName='" + request.SocietyName + "',";
            SqlQuery += "@SocietyPresentStatus='" + request.SocietyPresentStatus + "',@StateID='" + request.StateID + "',@DistrictID='" + request.DistrictID + "',@RegisteredActID='" + request.RegisteredActID + "',@SocietyRegistrationDate='" + request.SocietyRegistrationDate + "',@ElectionPresentManagementCommitteeDate='" + request.ElectionPresentManagementCommitteeDate + "',@SocietyRegisteredAddress='" + request.SocietyRegisteredAddress + "',@Pincode='" + request.Pincode + "',@IsOtherInstitution='" + request.IsOtherInstitution + "',";
            SqlQuery += "@IsWomenMembers='" + request.IsWomenMembers + "',@IsDateOfElection='" + request.IsDateOfElection + "',@ManagementCommitteeCertified='" + request.ManagementCommitteeCertified + "',@SocietyPANNumber='" + request.SocietyPANNumber + "',@TrustLogoDoc='" + request.TrustLogoDoc + "',@TrusteeMemberProofDoc='" + request.TrusteeMemberProofDoc + "',@SocietyPanProofDoc='" + request.SocietyPanProofDoc + "',@RegisteredActName='" + request.RegisteredActName + "',@RegistrationDoc='" + request.RegistrationDoc + "',";
            SqlQuery += "@MemberDetail_Str='" + MemberDetail_Str + "',@InstituteDetail_Str='" + InstituteDetail_Str + "',@ProcessDepartmentID='" + request.ProcessDepartmentID + "',@ManagementType='" + request.ManagementType + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LegalEntity.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<LegalEntityListModel> GetLegalEntityList(string SSOID)
        {
            string SqlQuery = " exec USP_GetLegalEntity_Preview @SSOID='" + SSOID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LegalEntity.GetAllData");

            List<LegalEntityListModel> dataModels = new List<LegalEntityListModel>();

            LegalEntityListModel dataModel = new LegalEntityListModel();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LegalEntityListModel> ViewlegalEntityDataByID(int LegalEntityID, string SSOID)
        {
            string SqlQuery = " exec USP_GetLegalEntity_Preview @LegalEntityID = '" + LegalEntityID + "',@SSOID='" + SSOID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LegalEntity.GetAllData");

            List<LegalEntityListModel> dataModels = new List<LegalEntityListModel>();
            LegalEntityListModel dataModel = new LegalEntityListModel();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LegalEntityListModel> GetLegalEntityBySSOID(string SSOID)
        {
            string SqlQuery = " exec USP_GetLegalEntityBySSOID @SSOID = '" + SSOID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LegalEntity.GetAllData");

            List<LegalEntityListModel> dataModels = new List<LegalEntityListModel>();
            LegalEntityListModel dataModel = new LegalEntityListModel();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LegalEntityListModel> GetLegalEntityBySSOIDFForPDF(string SSOID)
        {
            string SqlQuery = " exec USP_GetLegalEntityBySSOID @SSOID = '" + SSOID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LegalEntity.GetAllData");

            List<LegalEntityListModel> dataModels = new List<LegalEntityListModel>();
            LegalEntityListModel dataModel = new LegalEntityListModel();
            dataModel.data = dataSet;
            if (dataModel.data.Tables.Count > 0)
            {
                if (dataModel.data.Tables[0].Rows.Count > 0)
                { 
                dataModel.data.Tables[0].Rows[0]["TrustLogoDoc"] = _commonHelper.ConvertTobase64(dataModel.data.Tables[0].Rows[0]["TrustLogoDoc"].ToString());
            }
            }
            for (int i = 0; i < dataModel.data.Tables[2].Rows.Count; i++)
            {
              dataModel.data.Tables[2].Rows[i]["MemberPhoto"] = _commonHelper.ConvertTobase64(dataModel.data.Tables[2].Rows[i]["MemberPhoto"].ToString());
              dataModel.data.Tables[2].Rows[i]["MemberSignature"] = _commonHelper.ConvertTobase64(dataModel.data.Tables[2].Rows[i]["MemberSignature"].ToString());
            }
            dataModels.Add(dataModel);

            return dataModels;
        }

        public bool CheckExistsLegalEntity(string SSOID, int RoleID)
        {
            string SqlQuery = " USP_CheckExistsLegalEntity @SSOID='" + SSOID + "',@RoleID='" + RoleID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LegalEntity.CheckExistsLegalEntity");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
