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
        public bool IfExists(int LegalEntityID, string RegistrationNo)
        {
            string SqlQuery = " USP_IfExistsLegalEntity @RegistrationNo='" + RegistrationNo + "',@LegalEntityID='" + LegalEntityID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LegalEntity.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool SaveData(LegalEntityModel request)
        {
            string MemberDetail_Str = request.MemberDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.MemberDetails, "Temp_MemberDetail_LegalEntity") : "";
            string InstituteDetail_Str = request.InstituteDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.InstituteDetails, "Temp_InstituteDetail_LegalEntity") : "";
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveLegalEntity_IU  ";
            SqlQuery += "@LegalEntityID='" + request.LegalEntityID + "',@IsLegalEntity='" + request.IsLegalEntity + "',@SSOID='" + request.SSOID + "',@RegistrationNo='" + request.RegistrationNo + "',@PresidentMobileNo='" + request.PresidentMobileNo + "',@PresidentEmail='" + request.PresidentEmail + "',@SocietyName='" + request.SocietyName + "',";
            SqlQuery += "@SocietyPresentStatus='" + request.SocietyPresentStatus + "',@StateID='" + request.StateID + "',@DistrictID='" + request.DistrictID + "',@RegisteredActID='" + request.RegisteredActID + "',@SocietyRegistrationDate='" + request.SocietyRegistrationDate + "',@ElectionPresentManagementCommitteeDate='" + request.ElectionPresentManagementCommitteeDate + "',@SocietyRegisteredAddress='" + request.SocietyRegisteredAddress + "',@Pincode='" + request.Pincode + "',@IsOtherInstitution='" + request.IsOtherInstitution + "',";
            SqlQuery += "@IsWomenMembers='" + request.IsWomenMembers + "',@IsDateOfElection='" + request.IsDateOfElection + "',@ManagementCommitteeCertified='" + request.ManagementCommitteeCertified + "',@PresidentAadhaarNumber='" + request.PresidentAadhaarNumber + "',@SocietyPANNumber='" + request.SocietyPANNumber + "',@TrustLogoDoc='" + request.TrustLogoDoc + "',@TrusteeMemberProofDoc='" + request.TrusteeMemberProofDoc + "',@PresidentAadhaarProofDoc='" + request.PresidentAadhaarProofDoc + "',@SocietyPanProofDoc='" + request.SocietyPanProofDoc + "',";
            SqlQuery += "@MemberDetail_Str='" + MemberDetail_Str + "',@InstituteDetail_Str='" + InstituteDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LegalEntity.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<LegalEntityListModel> GetLegalEntityList()
        {
            string SqlQuery = " exec USP_GetLegalEntity_Preview";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LegalEntity.GetAllData");

            List<LegalEntityListModel> dataModels = new List<LegalEntityListModel>();
            LegalEntityListModel dataModel = new LegalEntityListModel();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LegalEntityListModel> ViewlegalEntityDataByID(int LegalEntityID)
        {
            string SqlQuery = " exec USP_GetLegalEntity_Preview @LegalEntityID = '" + LegalEntityID + "'";
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
    }
}
