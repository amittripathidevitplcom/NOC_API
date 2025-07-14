using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace RJ_NOC_DataAccess.Repository
{
    public class GrievanceRepository : IGrievanceRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public GrievanceRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllGrievance()
        {
            string SqlQuery = " select * from Trn_Grievance ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Grievance.GetAllGrievance");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<DataTable> GetGrievance_AddedSSOIDWise(string SSOID)
        {
            string SqlQuery = "exec USP_Grievance_SSOIDWise @SSOID='" + SSOID + "'";
            
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Grievance.GetGrievance_AddedSSOIDWise");
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<GrievanceDataModel> GetByID(int GrievanceID)
        {
            string SqlQuery = "select * from  Trn_Grievance Where GrievanceID='" + GrievanceID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Grievance.GetByID");

            List<GrievanceDataModel> dataModels = new List<GrievanceDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<GrievanceDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        //public bool SaveData(GrievanceDataModel request)
        //{
        //    string IPAddress = CommonHelper.GetVisitorIPAddress();
        //    string SqlQuery = " exec Trn_GrievanceSave  ";
        //    SqlQuery += " @SSOID = '" + request.SSOID + "',  ";
        //    SqlQuery += " @MobileNo = '" + request.MobileNo + "',  ";
        //    SqlQuery += " @BugFrom = '" + request.BugFrom + "',  ";
        //    SqlQuery += " @DepartmentID ='" + request.DepartmentID + "',  ";
        //    SqlQuery += " @CollegeID = '" + request.CollegeID + "',  ";
        //    SqlQuery += " @Subject ='" + request.Subject + "',  ";
        //    SqlQuery += " @Description = '" + request.Description + "',  ";
        //    SqlQuery += " @AttachmentFile = '" + request.AttachmentFile + "'  ";
        //    int Rows = _commonHelper.NonQuerry(SqlQuery, "Grievance.SaveData");
        //    if (Rows > 0)
        //        return true;
        //    else
        //        return false;
        //}
        //public bool SaveData(GrievanceDataModel request)
        //{
        //    string IPAddress = CommonHelper.GetVisitorIPAddress();
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //    sb.AppendFormat("@SSOID='{0}',", request.SSOID);
        //    sb.AppendFormat("@MobileNo='{0}',", request.MobileNo);
        //    sb.AppendFormat("@BugFrom='{0}',", request.BugFrom);
        //    sb.AppendFormat("@DepartmentID='{0}',", request.DepartmentID);
        //    sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
        //    sb.AppendFormat("@Subject='{0}',", request.Subject);
        //    sb.AppendFormat("@Description=N'{0}',", request.Description);
        //    sb.AppendFormat("@AttachmentFile='{0}'", request.AttachmentFile);
        //    string SqlQuery = $" exec Trn_GrievanceSave {sb.ToString()} ";
        //    int Rows = _commonHelper.NonQuerry(SqlQuery, "Grievance.SaveData");
        //    if (Rows > 0)
        //        return true;
        //    else
        //        return false;
        //}
        public bool DeleteData(int GrievanceID)
        {
            string SqlQuery = "delete Trn_Grievance Where GrievanceID='" + GrievanceID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "Grievance.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int GrievanceID, int DepartmentID, string AnimalName)
        {
            string SqlQuery = " USP_IfExistsGrievance @GrievanceID='" + GrievanceID + "',@DepartmentID = '" + DepartmentID + "',@AnimalName='" + AnimalName + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Grievance.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public List<DataTable> Get_GrievanceTrail(int GrievanceID, string Action)
        {
            string SqlQuery = "exec USP_Grievance_SSOIDWise @GrievanceID='" + GrievanceID + "',@Action='" + Action + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Grievance.Get_GrievanceTrail");
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }






        public bool SaveData(GrievanceDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendFormat("@Action='{0}',", request.Action);
            sb.AppendFormat("@GrievanceID='{0}',", request.GrievanceID);
            sb.AppendFormat("@SSOID='{0}',", request.SSOID);
            sb.AppendFormat("@MobileNo='{0}',", request.MobileNo);
            sb.AppendFormat("@BugFrom='{0}',", request.BugFrom);
            sb.AppendFormat("@DepartmentID='{0}',", request.DepartmentID);
            sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
            sb.AppendFormat("@Subject='{0}',", request.Subject);
            sb.AppendFormat("@Description=N'{0}',", request.Description);
            sb.AppendFormat("@AttachmentFile='{0}',", request.AttachmentFile);
            sb.AppendFormat("@AttachmentImage='{0}',", request.AttachmentImage);
            sb.AppendFormat("@GrievanceRemark='{0}'", request.GrievanceRemark);
            string SqlQuery = $" exec Trn_GrievanceSave {sb.ToString()} ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "Grievance.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

    }
}
