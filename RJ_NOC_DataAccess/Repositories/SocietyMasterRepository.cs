using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_DataAccess.Repositories
{
    public class SocietyMasterRepository : ISocietyMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public SocietyMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(SocietyMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SocietyMaster_IU  ";
            SqlQuery += " @SocietyID='" + request.SocietyID + "',@CollegeID='" + request.CollegeID + "',@DesignationID='" + request.DesignationID + "',@OccupationID='" + request.OccupationID + "',@Educationists='" + request.Educationists + "',@PersonName='" + request.PersonName + "',@FatherName='" + request.FatherName + "',@MobileNo='" + request.MobileNo + "',@Email='" + request.Email + "',@Gender='" + request.Gender + "',@PANNo='" + request.PANNo + "',@PANCard='" + request.PANCard + "',@AadhaarNo='" + request.AadhaarNo + "',@AadhaarCard='" + request.AadhaarCard + "',@SignatureDoc='" + request.SignatureDoc + "',@ProfilePhoto='" + request.ProfilePhoto + "',@AuthorizedDocument='" + request.AuthorizedDocument + "',@IsPrimary='" + request.IsPrimary + "',@IsAuthorized='" + request.IsAuthorized + "',@ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@EducationProof='" + request.EducationProof + "',@ConsentLetter='" + request.ConsentLetter + "',@OtherOccupation='" + request.OtherOccupation + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "SocietyMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<SocietyMasterDataModels> GetSocietyAllList(int CollegeID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_SocietyMaster_GetData @CollegeID='"+CollegeID+ "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SocietyMaster.GetSocietyAllList");

            List<SocietyMasterDataModels> dataModels = new List<SocietyMasterDataModels>();
            SocietyMasterDataModels dataModel = new SocietyMasterDataModels();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<SocietyMasterDataModel> GetSocietyByID(int SocietyID)
        {
            string SqlQuery = " exec USP_SocietyMaster_GetData @SocietyID='" + SocietyID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SocietyMaster.GetSocietyByID");

            List<SocietyMasterDataModel> dataModels = new List<SocietyMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<SocietyMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool UpdateData(SocietyMasterDataModel request)
        {

            //string IPAddress = CommonHelper.GetVisitorIPAddress();
            //string SqlQuery = " exec USP_DocumentMaster_IU  ";
            //SqlQuery += " @DepartmentID='" + request.DepartmentID + "',@DocumentTypeID='" + request.DocumentTypeID + "',@DocumentName='" + request.DocumentName + "',@MinSize='" + request.MinSize + "',@MaxSize='" + request.MaxSize + "',@IsCompulsory='" + request.IsCompulsory + "',@IsActiveStatus='" + request.IsActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            //int Rows = _commonHelper.NonQuerry(SqlQuery, "DocumentMaster.SaveData");
            //if (Rows > 0)
            //    return true;
            //else
            return false;
        }

        public bool DeleteData(int SocietyID)
        {
            string SqlQuery = " Update M_SocietyMaster set ActiveStatus=0 , DeleteStatus=1  WHERE SocietyID='" + SocietyID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "SocietyMaster.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int SocietyID, string PersonName)
        {
            string SqlQuery = " select PersonName from M_SocietyMaster Where PersonName='" + PersonName.Trim() + "'  and SocietyID !='" + SocietyID + "'  and DeleteStatus=0 and ActiveStatus=1";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SocietyMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }




     
        public List<CommonDataModel_DataTable> Check30Female(int CollegeID)
        {
            string SqlQuery = " exec USP_Check30Female @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SocietyMaster.Check30Female");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
