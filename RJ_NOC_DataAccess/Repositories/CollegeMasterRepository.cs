using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;

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

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@DepartmentID='{0}',",   request.DepartmentID);
            sb.AppendFormat("@CollegeStatus='{0}',",   request.CollegeStatus);
            sb.AppendFormat("@CollegeLogo='{0}',",   request.CollegeLogo);
            sb.AppendFormat("@PresentCollegeStatus='{0}',",   request.PresentCollegeStatus);
            sb.AppendFormat("@CollegeTypeID='{0}',",   request.CollegeTypeID);
            sb.AppendFormat("@CollegeLevelID='{0}',",   request.CollegeLevelID);
            sb.AppendFormat("@CollegeNameEn='{0}',",   request.CollegeNameEn);
            sb.AppendFormat("@CollegeNameHi='{0}',",   request.CollegeNameHi);
            sb.AppendFormat("@AISHECodeStatus='{0}',",   request.AISHECodeStatus);
            sb.AppendFormat("@AISHECode='{0}',",   request.AISHECode);
            sb.AppendFormat("@CollegeMedium='{0}',",   request.CollegeMedium);
            sb.AppendFormat("@UniversityID='{0}',",   request.UniversityID);
            sb.AppendFormat("@MobileNumber='{0}',",   request.MobileNumber);
            sb.AppendFormat("@Email='{0}',",   request.Email);
            sb.AppendFormat("@AddressLine1='{0}',",   request.AddressLine1);
            sb.AppendFormat("@AddressLine2='{0}',",   request.AddressLine2);
            sb.AppendFormat("@RuralUrban='{0}',",   request.RuralUrban);
            sb.AppendFormat("@DivisionID='{0}',",   request.DivisionID);
            sb.AppendFormat("@DistrictID='{0}',",   request.DistrictID);
            sb.AppendFormat("@SubdivisionID='{0}',",   request.SubdivisionID);
            sb.AppendFormat("@TehsilID='{0}',",   request.TehsilID);
            sb.AppendFormat("@PanchayatSamitiID='{0}',",   request.PanchayatSamitiID);
            sb.AppendFormat("@ParliamentAreaID='{0}',",   request.ParliamentAreaID);
            sb.AppendFormat("@AssemblyAreaID='{0}',",   request.AssemblyAreaID);
            sb.AppendFormat("@CityTownVillage='{0}',",   request.CityTownVillage);
            sb.AppendFormat("@YearofEstablishment='{0}',",   request.YearofEstablishment);
            sb.AppendFormat("@Pincode='{0}',",   request.Pincode);
            sb.AppendFormat("@WebsiteLink='{0}',",   request.WebsiteLink);
            sb.AppendFormat("@GCD_Designation='{0}',",   request.GCD_Designation);
            sb.AppendFormat("@GCD_MobileNumber='{0}',",   request.GCD_MobileNumber);
            sb.AppendFormat("@GCD_LandlineNumber='{0}',",   request.GCD_LandlineNumber);
            sb.AppendFormat("@TGC_Latitude='{0}',",   request.TGC_Latitude);
            sb.AppendFormat("@TGC_Longitude='{0}',",   request.TGC_Longitude);
            sb.AppendFormat("@CreatedBy='{0}',",   request.CreatedBy);
            sb.AppendFormat("@ModifyBy='{0}',",   request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',",   IPAddress);            
            sb.AppendFormat("@ContactDetailsList='{0}',", CommonHelper.GetDetailsTableQry(request.ContactDetailsList, "ContactDetailsList"));
            sb.AppendFormat("@Action='{0}'", "InsCollegeData");

            string SqlQuery = $" exec USP_CollegeMaster  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }


        public List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID)
        {
            string SqlQuery = "exec USP_DraftApplicationList @LoginSSOID='"+ LoginSSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeMaster.DraftApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
