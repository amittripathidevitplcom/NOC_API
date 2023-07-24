using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static RJ_NOC_Model.VeterinaryHospitalDataModel;
using System.Text;

namespace RJ_NOC_DataAccess.Repository
{
    public class VeterinaryHospitalRepository : IVeterinaryHospitalRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public VeterinaryHospitalRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;   
        }
        public List<AnimalDataModel_AnimalList> GetAnimalMasterList()
        {
            string SqlQuery = "exec USP_GetAnimalMasterList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "VeterinaryHospital.GetAnimalMasterList");

            List<AnimalDataModel_AnimalList> dataModels = new List<AnimalDataModel_AnimalList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<AnimalDataModel_AnimalList>>(JsonDataTable_Data);
            return dataModels;
        }

        public bool SaveData(VeterinaryHospitalDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string AnimalDetails_Str = request.AnimalDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.AnimalDetails, "Temp_AnimalDetails_VeterinaryHospital") : "";
            string SqlQuery = " exec USP_Trn_VeterinaryHospital_IU";

            SqlQuery += " @ActionType='UI',";
            SqlQuery += " @VeterinaryHospitalID='" + request.VeterinaryHospitalID + "',";
            SqlQuery += " @AddressLine1='" + request.AddressLine1 + "',";
            SqlQuery += " @AddressLine2='" + request.AddressLine2 + "',";
            SqlQuery += " @RuralUrban='" + request.RuralUrban + "',";
            SqlQuery += " @DivisionID='" + request.DivisionID + "',";
            SqlQuery += " @DistrictID='" + request.DistrictID + "',";
            SqlQuery += " @TehsilID='" + request.TehsilID + "',";
            SqlQuery += " @PanchayatSamitiID='" + request.PanchayatSamitiID + "',";
            SqlQuery += " @CityTownVillage='" + request.CityTownVillage + "',";
            SqlQuery += " @Pincode='" + request.Pincode + "',";
            SqlQuery += " @HospitalName='" + request.HospitalName + "',";
            SqlQuery += " @DistanceFromInstitute='" + request.DistanceFromInstitute + "',";
            SqlQuery += " @AuthorizedPerson='" + request.AuthorizedPerson + "',";
            SqlQuery += " @EmailAddress='" + request.EmailAddress + "',";
            SqlQuery += " @PersonField='" + request.PersonField + "',";
            SqlQuery += " @Relation='" + request.Relation + "',";
            SqlQuery += " @Remark='" + request.Remark + "',";
            SqlQuery += " @FileUpload='" + request.FileUpload + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @DeleteStatus='" + request.DeleteStatus + "',";
            SqlQuery += " @MobileNo='" + request.MobileNo + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @SSOID='" + request.SSOID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += "@AnimalDetails_Str='" + AnimalDetails_Str + "'";



            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "VeterinaryHospital.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<VeterinaryHospitalDataModelList> GetAllVeterinaryHospitalList(int CollegeID)
        {
            string SqlQuery = $" exec USP_Trn_VeterinaryHospital_IU @CollegeID='" +CollegeID+ "',@ActionType='GetAllData'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "VeterinaryHospital.GetAllVeterinaryHospitalList");

            List<VeterinaryHospitalDataModelList> dataModels = new List<VeterinaryHospitalDataModelList>();
            VeterinaryHospitalDataModelList dataModel = new VeterinaryHospitalDataModelList();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;



        }
        public VeterinaryHospitalDataModel GetVeterinaryHospitalByIDWise(int VeterinaryHospitalID)
        {
            string SqlQuery = $"exec USP_Trn_VeterinaryHospital_IU @VeterinaryHospitalID='" + VeterinaryHospitalID + "',@ActionType='GetDataByID'";
            var ds = _commonHelper.Fill_DataSet(SqlQuery, "VeterinaryHospital.GetVeterinaryHospitalByIDWise");

            VeterinaryHospitalDataModel veterinaryHospitalDataModel = new VeterinaryHospitalDataModel();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    veterinaryHospitalDataModel = CommonHelper.ConvertDataTable<VeterinaryHospitalDataModel>(ds.Tables[0]);
                }
                if (ds.Tables.Count > 1)
                {
                    veterinaryHospitalDataModel.AnimalDetails = CommonHelper.ConvertDataTable<List<AnimalDataModel>>(ds.Tables[1]);
                }                
            }

            return veterinaryHospitalDataModel;
        }
        public bool DeleteData(int VeterinaryHospitalID)
        {
            string SqlQuery = $"exec USP_Trn_VeterinaryHospital_IU @VeterinaryHospitalID='" + VeterinaryHospitalID + "',@ActionType='DeleteByID'";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "VeterinaryHospital.Delete");
            if (Rows == 0)
                return true;
            else
                return false;
        }
    }
}
