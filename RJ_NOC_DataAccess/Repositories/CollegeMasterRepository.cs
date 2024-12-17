using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace RJ_NOC_DataAccess.Repository
{
    public class CollegeMasterRepository : ICollegeMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CollegeMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool SaveData(CollegeMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            if (request.AnnualIntakeStudents == null)
            {
                request.AnnualIntakeStudents = 0;
            }
            if (request.SocietyCapitalAssets == null)
            {
                request.SocietyCapitalAssets = 0;
            }
            if (request.SocietyIncome == null)
            {
                request.SocietyIncome = 0;
            }
            if (request.TotalProjectCost == null)
            {
                request.TotalProjectCost = 0;
            }



            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
            sb.AppendFormat("@DepartmentID='{0}',", request.DepartmentID);
            sb.AppendFormat("@TypeofCollege='{0}',", request.TypeofCollege);
            sb.AppendFormat("@CollegeStatusID='{0}',", request.CollegeStatusID);
            sb.AppendFormat("@CollegeLogo='{0}',", request.CollegeLogo);
            sb.AppendFormat("@PresentCollegeStatusID='{0}',", request.PresentCollegeStatusID);
            sb.AppendFormat("@CollegeTypeID='{0}',", request.CollegeTypeID);
            sb.AppendFormat("@CollegeLevelID='{0}',", request.CollegeLevelID);
            sb.AppendFormat("@CollegeCode='{0}',", request.CollegeCode);
            sb.AppendFormat("@CollegeNameEn='{0}',", request.CollegeNameEn);
            sb.AppendFormat("@CollegeNameHi=N'{0}',", request.CollegeNameHi);
            sb.AppendFormat("@AISHECodeStatus='{0}',", request.AISHECodeStatus);
            sb.AppendFormat("@AISHECode='{0}',", request.AISHECode);
            sb.AppendFormat("@CollegeMedium='{0}',", request.CollegeMedium);
            sb.AppendFormat("@UniversityID='{0}',", request.UniversityID);
            sb.AppendFormat("@MobileNumber='{0}',", request.MobileNumber);
            sb.AppendFormat("@CollegeLandlineNumber='{0}',", request.CollegeLandlineNumber);
            sb.AppendFormat("@Email='{0}',", request.Email);
            sb.AppendFormat("@AddressLine1='{0}',", request.AddressLine1);
            sb.AppendFormat("@AddressLine2='{0}',", request.AddressLine2);
            sb.AppendFormat("@RuralUrban='{0}',", request.RuralUrban);
            sb.AppendFormat("@DivisionID='{0}',", request.DivisionID);
            sb.AppendFormat("@DistrictID='{0}',", request.DistrictID);
            sb.AppendFormat("@SubdivisionID='{0}',", request.SubdivisionID);
            sb.AppendFormat("@TehsilID='{0}',", request.TehsilID);
            sb.AppendFormat("@PanchayatSamitiID='{0}',", request.PanchayatSamitiID);
            sb.AppendFormat("@ParliamentAreaID='{0}',", request.ParliamentAreaID);
            sb.AppendFormat("@AssemblyAreaID='{0}',", request.AssemblyAreaID);
            sb.AppendFormat("@CityTownVillage='{0}',", request.CityTownVillage);
            sb.AppendFormat("@YearofEstablishment='{0}',", request.YearofEstablishment);
            sb.AppendFormat("@Pincode='{0}',", request.Pincode);
            sb.AppendFormat("@WebsiteLink='{0}',", request.WebsiteLink);
            sb.AppendFormat("@GCD_DesignationID='{0}',", request.GCD_DesignationID);
            sb.AppendFormat("@GCD_MobileNumber='{0}',", request.GCD_MobileNumber);
            sb.AppendFormat("@GCD_LandlineNumber='{0}',", request.GCD_LandlineNumber);
            sb.AppendFormat("@TGC_Latitude='{0}',", request.TGC_Latitude);
            sb.AppendFormat("@TGC_Longitude='{0}',", request.TGC_Longitude);
            sb.AppendFormat("@CreatedBy='{0}',", request.CreatedBy);
            sb.AppendFormat("@ModifyBy='{0}',", request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',", IPAddress);
            sb.AppendFormat("@MappingSSOID='{0}',", request.MappingSSOID);
            sb.AppendFormat("@ParentSSOID='{0}',", request.ParentSSOID);
            sb.AppendFormat("@DistanceFromCity='{0}',", request.DistanceFromCity);
            sb.AppendFormat("@CollegeNAACAccredited='{0}',", request.CollegeNAACAccredited);
            sb.AppendFormat("@NAACAccreditedCertificate='{0}',", request.NAACAccreditedCertificate);
            sb.AppendFormat("@NACCValidityDate='{0}',", request.NACCValidityDate);
            sb.AppendFormat("@CityID='{0}',", request.CityID);
            sb.AppendFormat("@ManagementType='{0}',", request.ManagementTypeID);
            sb.AppendFormat("@OtherUniversityName='{0}',", request.OtherUniversityName);

            sb.AppendFormat("@AnnualIntakeStudents='{0}',", request.AnnualIntakeStudents);
            sb.AppendFormat("@SocietyCapitalAssets='{0}',", request.SocietyCapitalAssets);
            sb.AppendFormat("@SocietyIncome='{0}',", request.SocietyIncome);
            sb.AppendFormat("@TotalProjectCost='{0}',", request.TotalProjectCost);
            sb.AppendFormat("@FundingSources='{0}',", request.FundingSources);

            sb.AppendFormat("@AppliedICAR='{0}',", request.AppliedICAR);
            sb.AppendFormat("@ApprovedICAR='{0}',", request.ApprovedICAR);
            sb.AppendFormat("@ICARDocument='{0}',", request.ICARDocument);
            sb.AppendFormat("@AffiliationUniversityDoc='{0}',", request.AffiliationUniversityDoc);
            sb.AppendFormat("@UniversityApproveTeachingFacultyDoc='{0}',", request.UniversityApproveTeachingFacultyDoc);            
            sb.AppendFormat("@IsAbbreviation='{0}',", request.IsAbbreviation);
            sb.AppendFormat("@AbbreviationName='{0}',", request.AbbreviationName);

            sb.AppendFormat("@FaxNo='{0}',", request.FaxNo);
            sb.AppendFormat("@LiveStockFarmAddress='{0}',", request.LiveStockFarmAddress);
            sb.AppendFormat("@VeternaryClinicalAddress='{0}',", request.VeternaryClinicalAddress);
            // child
            sb.AppendFormat("@ContactDetailsList='{0}',", CommonHelper.GetDetailsTableQry(request.ContactDetailsList, "ContactDetailsList"));
            if (request.NearestGovernmentHospitalsList.Count > 0)
            {
                sb.AppendFormat("@NearestGovernmentHospitalsList='{0}',", CommonHelper.GetDetailsTableQry(request.NearestGovernmentHospitalsList, "NearestGovernmentHospitalsList"));
            }
            if (request.CollegeLevelDetails.Count > 0)
            {
                sb.AppendFormat("@DTECollegeLevel_College='{0}',", CommonHelper.GetDetailsTableQry(request.CollegeLevelDetails, "Temp_DTECollegeLevel_College"));
            }
            sb.AppendFormat("@AffiliationDocument='{0}',", request.AffiliationDocument);
            sb.AppendFormat("@WebsiteImage='{0}',", request.WebsiteImage);
            // action
            sb.AppendFormat("@Action='{0}'", "SaveCollegeData");

            string SqlQuery = $" exec USP_CollegeMaster  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID, int SessionYear)
        {
            string SqlQuery = "exec USP_DraftApplicationList @LoginSSOID='" + LoginSSOID + "',@SessionYear='" + SessionYear + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.DraftApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> StatisticsCollegeList(string LoginSSOID, int SessionYear)
        {
            string SqlQuery = "exec USP_StatisticsCollegeList @LoginSSOID='" + LoginSSOID + "',@SessionYear='" + SessionYear + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.DraftApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> CollegeDetails(string LoginSSOID, string Type, int SessionYear)
        {
            string SqlQuery = "exec USP_CollegeDetailsList @LoginSSOID='" + LoginSSOID + "',@Type='" + Type + "',@SessionYear='" + SessionYear + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.CollegeDetails");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public CollegeMasterDataModel GetCollegeById(int collegeId)
        {
            string SqlQuery = $"exec USP_CollegeMaster @CollegeID={collegeId},@Action='GetCollegeById'";
            var ds = _commonHelper.Fill_DataSet(SqlQuery, "CollegeMaster.GetCollegeById");

            CollegeMasterDataModel collegeMasterDataModel = new CollegeMasterDataModel();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    collegeMasterDataModel = CommonHelper.ConvertDataTable<CollegeMasterDataModel>(ds.Tables[0]);
                }
                if (ds.Tables.Count > 1)
                {
                    collegeMasterDataModel.ContactDetailsList = CommonHelper.ConvertDataTable<List<ContactDetailsDataModel>>(ds.Tables[1]);
                }
                if (ds.Tables.Count > 2)
                {
                    collegeMasterDataModel.NearestGovernmentHospitalsList = CommonHelper.ConvertDataTable<List<NearestGovernmentHospitalsDataModel>>(ds.Tables[2]);
                }
                if (ds.Tables.Count > 3)
                {
                    collegeMasterDataModel.CollegeLevelDetails = CommonHelper.ConvertDataTable<List<CollegeLevelDetailsDataModel>>(ds.Tables[3]);
                }
            }

            return collegeMasterDataModel;
        }

        public bool DeleteData(int CollegeId, int modifiedBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_CollegeMaster @Action='DeleteCollegeById',@ModifyBy={modifiedBy},@CollegeID={CollegeId},@IPAddress='{IPAddress}'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeMaster.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool MapSSOIDInCollege(int CollegeId, int modifiedBy, string ssoId)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_CollegeMaster @Action='MapSSOIDInCollegeById',@ModifyBy={modifiedBy},@CollegeID={CollegeId},@IPAddress='{IPAddress}',@MappingSSOID='{ssoId}'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeMaster.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataSet> ViewTotalCollegeDataByID(int CollegeID)
        {
            string SqlQuery = " exec USP_GetCollegeData_Preview @CollegeID = '" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "CollegeMaster.GetAllData");

            List<CommonDataModel_DataSet> dataModels = new List<CommonDataModel_DataSet>();
            CommonDataModel_DataSet dataModel = new CommonDataModel_DataSet();
            dataModel.data = dataSet;
            for (int i = 0; i < dataModel.data.Tables[0].Rows.Count; i++)
            {
                dataModel.data.Tables[0].Rows[i]["CollegeLogo"] = _commonHelper.ConvertTobase64(dataModel.data.Tables[0].Rows[i]["CollegeLogo"].ToString());
            }
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> RevertedApplicationList(string LoginSSOID, int SessionYear)
        {
            string SqlQuery = "exec USP_DceCollegeRevertedApplicationList @LoginSSOID='" + LoginSSOID + "',@SessionYear='" + SessionYear + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.RevertApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> RejectedApplicationList(string LoginSSOID, int SessionYear)
        {
            string SqlQuery = "exec USP_GetCollegeApplyNOCRejected @SsoID='" + LoginSSOID + "',@SessionYear='" + SessionYear + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.RejectedApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> LOIApplicationList(string LoginSSOID)
        {
            string SqlQuery = "exec USP_LOIApplicationList @LoginSSOID='" + LoginSSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.LOIApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool LOIFinalSubmit_OTPVerification(int CollegeID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = "exec USP_LOIFinalSubmit_OTPVerification @CollegeID='" + CollegeID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeMaster.LOIFinalSubmit_OTPVerification");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int DepartmentID, int CollegeID, string MobileNo, string Email)
        {
            string SqlQuery = " USP_IfExistsCollegeDetail @DepartmentID='" + DepartmentID + "', @Email='" + Email + "',@CollegeID='" + CollegeID + "',@MobileNo='" + MobileNo + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool SaveLOIWorkFlow(DocumentScrutinySave_DataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ApplyLOI_WorkFlow  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNOCID + "',@RoleID='" + request.RoleID + "',@NextRoleID='" + request.NextRoleID + "',@UserID='" + request.UserID + "',@NextUserID='" + request.NextUserID + "',@ActionID='" + request.ActionID + "',@DepartmentID='" + request.DepartmentID + "',@Remark='" + request.Remark + "',@NextActionID='" + request.NextActionID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeMaster.SaveLOIWorkFlow");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<DataTable> GetCollegesByDepartmentID(int DepartmentID)
        {
            string SqlQuery = "exec USP_GetCollegesByDepartmentID @DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.GetCollegesByDepartmentID");

            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> TotalCollegeDetailsByDepartment(TotalCollegeReportSearchFilter request)
        {
            string SqlQuery = "exec USP_TotalCollegeDetailsByDepartment @DepartmentID='" + request.DepartmentID + "', @UniversityID='" + request.UniversityID + "',@DivisionID='" + request.DivisionID + "',@DistrictID='" + request.DistrictID + "',@CollegeName='"+ request.CollegeName + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.TotalCollegeDetailsByDepartment");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> CollegesReport(DCECollegesReportSearchFilter request)
        {
            string SqlQuery = @"exec USP_CollegesReportDCE @DepartmentID='" + request.DepartmentID + "',@CollegeName='" + request.CollegeName + "',@NOCStatusID='" + request.NOCStatusID + "',@ApplicationStatusID = '" + request.ApplicationStatusID + "',@FromSubmittedDate = '" + request.FromSubmittedDate + "',@ToSubmittedDate = '" + request.ToSubmittedDate + "',";
            SqlQuery += "@CollegeTypeID = '" + request.CollegeTypeID + "',@CollegeMobileNo = '" + request.CollegeMobileNo + "',@CollegeEmail = '" + request.CollegeEmail + "',@StatusOfCollegeID = '" + request.StatusOfCollegeID + "',@CollegeLevelID = '" + request.CollegeLevelID + "',@DivisionID = '" + request.DivisionID + "',";
            SqlQuery += "@DistrictID = '" + request.DistrictID + "',@SubDivisionID = '" + request.SubDivisionID + "',@TehsilID = '" + request.TehsilID + "',@ParliamentID = '" + request.ParliamentID + "',@AssemblyID = '" + request.AssemblyID + "',@PermanentAddress = '" + request.PermanentAddress + "',";
            SqlQuery += "@CityTownVillage = '" + request.CityTownVillage + "',@PinCode = '" + request.PinCode + "',@LandlineNo = '" + request.LandlineNo + "',@AdditionalMobileNo = '" + request.AdditionalMobileNo + "',@FaxNo = '" + request.FaxNo + "',@Website = '" + request.Website + "',";
            SqlQuery += "@NodalOfficerID = '" + request.NodalOfficerID + "',@EstablishmentYearID = '" + request.EstablishmentYearID + "',@ApplicationTypeID = '" + request.ApplicationTypeID + "',@LandAreaID = '" + request.LandAreaID + "',@LandDocumentID = '" + request.LandDocumentID + "',@LandConversionID = '" + request.LandConversionID + "',@AgricultureLandArea = '" + request.AgricultureLandArea + "',";
            SqlQuery += "@CommercialLandArea = '" + request.CommercialLandArea + "',@InstitutionalLandArea = '" + request.InstitutionalLandArea + "',@ResidentialLandArea = '" + request.ResidentialLandArea + "',@AgricultureKhasraNo = '" + request.AgricultureKhasraNo + "',@CommercialKhasraNo = '" + request.CommercialKhasraNo + "',";
            SqlQuery += "@InstitutionalKhasraNo = '" + request.InstitutionalKhasraNo + "',@ResidentialKhasraNo = '" + request.ResidentialKhasraNo + "',@FromAffidavitDate = '" + request.FromAffidavitDate + "',@ToAffidavitDate = '" + request.ToAffidavitDate + "',@UniversityID = '" + request.UniversityID + "',@CourseID = '" + request.CourseID + "',@SubjectID = '" + request.SubjectID + "',";
            SqlQuery += "@UrbanRuralID = '" + request.UrbanRuralID + "',@CollegeNAACID = '" + request.CollegeNAACID + "',@AISHECode = '" + request.AISHECode + "',@ApplicationId = '" + request.ApplicationId + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.CollegesReport");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool IfExistsDefaulterCollege(int DepartmentID,int CollegeID, string SSOID)
        {
            string SqlQuery = " USP_IfExistsDefaulterCollege @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "', @SSOID='" + SSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.IfExistsDefaulterCollege");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }        
        public bool IfExistsDefaulterCollegePenalty(int DepartmentID,int CollegeID, string SSOID)
        {
            string SqlQuery = " USP_IfExistsDefaulterCollegePenalty @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "', @SSOID='" + SSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.IfExistsDefaulterCollegePenalty");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool CompareDefaulterCollegeName(int DepartmentID, string CurrentCollegeName, string SSOID, int DivisionID, int DistrictID)
        {
            string SqlQuery = " USP_CompareDefaulterRequestCollegeName @DepartmentID='" + DepartmentID + "',@CurrentCollegeName='" + CurrentCollegeName + "', @SSOID='" + SSOID + "', @DivisionID='" + DivisionID + "', @DistrictID='" + DistrictID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.CompareDefaulterCollegeName");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
