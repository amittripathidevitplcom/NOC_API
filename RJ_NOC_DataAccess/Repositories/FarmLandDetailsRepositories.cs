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
    public class FarmLandDetailsRepositories : IFarmLandDetailsRepository
    {

        private CommonDataAccessHelper _commonHelper;
        public FarmLandDetailsRepositories(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool DeleteData(int FarmLandDetailsID)
        {
            string SqlQuery = $" exec USP_Trn_FarmLandDetails @FarmLandDetailsID='" + FarmLandDetailsID + "',@ActionType='DeleteByID'";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "FarmLandDetails.Delete");
            if (Rows == 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetAllFarmLandDetails()
        {
            throw new NotImplementedException();
        }

        public List<FarmLandDetailsListModel> GetFarmLandDetailsList(int collegeId, int ApplyNOCID)
        {
            string SqlQuery = $" exec USP_Trn_FarmLandDetails @CollegeID='" + collegeId + "',@ActionType='GetAllDataByCollegeID',@ApplyNOCID='"+ApplyNOCID+"'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FarmLandDetails.GetFarmLandDetailsList");

            List<FarmLandDetailsListModel> dataModels = new List<FarmLandDetailsListModel>();
            FarmLandDetailsListModel dataModel = new FarmLandDetailsListModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool IfExists(int FarmLandDetailsID)
        {
            throw new NotImplementedException();
        }

        public bool SaveData(FarmLandDetailsModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_FarmLandDetails_IU";

            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @FarmLandDetailID='" + request.FarmLandDetailID + "',";
            SqlQuery += " @CertificatefOfTehsildarPath='" + request.CertificatefOfTehsildarPath + "',";
            SqlQuery += " @CertificatefOfTehsildarName='" + request.CertificatefOfTehsildarName + "',";
            SqlQuery += " @TotalFarmLandArea='" + request.TotalFarmLandArea + "',";
            SqlQuery += " @FarmLandIs='" + request.FarmLandIs + "',";
            SqlQuery += " @KhasraNumber='" + request.KhasraNumber + "',";
            SqlQuery += " @LandOwnerName='" + request.LandOwnerName + "',";
            SqlQuery += " @LandTitleCertificatePath='" + request.LandTitleCertificatePath + "',";
            SqlQuery += " @LandTitleCertificateName='" + request.LandTitleCertificateName + "',";
            SqlQuery += " @TotalLandArea='" + request.TotalLandArea + "',";
            SqlQuery += " @AddressLine1='" + request.AddressLine1 + "',";
            SqlQuery += " @AddressLine2='" + request.AddressLine2 + "',";
            SqlQuery += " @RuralUrban='" + request.RuralUrban + "',";
            SqlQuery += " @DivisionID='" + request.DivisionID + "',";
            SqlQuery += " @DistrictID='" + request.DistrictID + "',";
            SqlQuery += " @TehsilID='" + request.TehsilID + "',";
            SqlQuery += " @PanchayatSamitiID='" + request.PanchayatSamitiID + "',";
            SqlQuery += " @CityTownVillage='" + request.CityTownVillage + "',";
            SqlQuery += " @Pincode='" + request.Pincode + "',";
            SqlQuery += " @LandType='" + request.LandType + "',";
            SqlQuery += " @SourceIrrigation='" + request.SourceIrrigation + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @CityID='" + request.CityID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "FarmLandDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public FarmLandDetailsModel ViewFarmLandDetailsListByID(int FarmLandDetailsID)
        {
            string SqlQuery = $" exec USP_Trn_FarmLandDetails @FarmLandDetailsID='" + FarmLandDetailsID + "',@ActionType='GetDataByID'";
            var ds = _commonHelper.Fill_DataSet(SqlQuery, "FarmLandDetails.ViewFarmLandDetailsListByID");

            FarmLandDetailsModel farmLandDetailsModel = new FarmLandDetailsModel();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    farmLandDetailsModel = CommonHelper.ConvertDataTable<FarmLandDetailsModel>(ds.Tables[0]);
                }
            }
            return farmLandDetailsModel;
        }


    }
}
