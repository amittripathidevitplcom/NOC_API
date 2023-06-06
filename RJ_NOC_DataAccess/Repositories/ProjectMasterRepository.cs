using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_DataAccess.Repository
{
    public class ProjectMasterRepository : IProjectMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ProjectMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllProject()
        {
            string SqlQuery = " exec USP_ProjectMaster_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID)
        {
            string SqlQuery = " exec USP_ProjectMaster_GetData @ProjectID='" + ProjectID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetDataIDWise");

            List<ProjectMasterDataModel> dataModels = new List<ProjectMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ProjectMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool SaveData(ProjectMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ProjectMaster_IU  ";
            SqlQuery += " @EmpanelmentType='" + request.EmpanelmentType + "',@ProjectID='" + request.ProjectID + "',@ProjectName='" + request.ProjectName + "',@DepartmentName='" + request.DepartmentName + "',@NumberofResources='" + request.NumberofResources + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ProjectMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool UpdateData(ProjectMasterDataModel request)
        {

            //string IPAddress = CommonHelper.GetVisitorIPAddress();
            //string SqlQuery = " exec USP_ProjectMaster_IU  ";
            //SqlQuery = " @ProjectID='" + request.ProjectID + "',@ProjectName='" + request.ProjectID + "',@DepartmentName='" + request.ProjectID + "',@NumberofResources='" + request.ProjectID + "',@UserID='" + request.ProjectID + "',@IPAddress='" + IPAddress + "'";
            //int Rows = _commonHelper.NonQuerry(SqlQuery, "ProjectMaster.SaveData");
            //if (Rows > 0)
            //    return true;
            //else
            return false;
        }

        public bool DeleteData(int ProjectID)
        {
            string SqlQuery = " Update M_ProjectMaster set ActiveStatus=0 , DeleteStatus=1  WHERE ProjectID='" + ProjectID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ProjectMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int ProjectID, string ProjectName)
        {
            string SqlQuery = " select ProjectName from M_ProjectMaster Where ProjectName='" + ProjectName.Trim() + "'  and ProjectID !='" + ProjectID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public List<ProjectMasterDataModel_CandidateInfo> GetProjectCandidateInfo(int ProjectID)
        {
            string SqlQuery = " exec USP_GetProjectCandidateInfo @ProjectID='" + ProjectID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetProjectCandidateInfo");

            List<ProjectMasterDataModel_CandidateInfo> dataModels = new List<ProjectMasterDataModel_CandidateInfo>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ProjectMasterDataModel_CandidateInfo>>(JsonDataTable_Data);
            return dataModels;
        }

        public bool SaveProjectCandidateInfo(CandidateDocumentDataModel request)
        {
            string CandidateInfo_Str = CommonHelper.GetDetailsTableQry(request.CandidateInfo, "Temp_CandidateInfo");
            string Document_Str = CommonHelper.GetDetailsTableQry(request.DocumentDataList, "Temp_Document");
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = " exec USP_SaveProjectCandidateInfo @ProjectID='" + request.ProjectID + "',@CandidateInfo_Str='" + CandidateInfo_Str + "',@CandidateDocument_Str='" + Document_Str + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ProjectMaster.SaveProjectCandidateInfo");
            if (Rows > 0)
                return true;
            else
                return false;
        }


        //Document Scrutiny
        public List<DataTable> GetDocumentScrutiny_ProjectCandidateInfo(int ProjectID)
        {
            string SqlQuery = " exec USP_GetDocumentScrutiny_ProjectCandidateInfo @ProjectID='" + ProjectID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetProjectCandidateInfo");

            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;

        }

        public bool DocumentScrutiny_ApprovedReject(ProjectMaster_DocumentScrutiny_ApprovedReject request)
        {
            string EmployeeDocument_Str = CommonHelper.GetDetailsTableQry(request.DocumentScrutiny_ApprovedRejectList, "EmployeeDocumentScrutiny");
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = " exec USP_EmployeeDocumentScrutiny  @EmployeeDocument_Str='" + EmployeeDocument_Str + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ProjectMaster.DocumentScrutiny_ApprovedReject");
            if (Rows > 0)
                return true;
            else
                return false;
        }


        public bool Save_ProjectIPDetails(ProjectMasterDataModel_ProjectIPDetails request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Save_ProjectIPDetails  ";
            SqlQuery += " @PIID='" + request.PIID + "',@ProjectID='" + request.ProjectID + "',@PINo='" + request.PINo + "',@TenderNo='" + request.TenderNo + "',@TenderValidUpTo='" + request.TenderValidUpTo + "',@InvoiceNo='" + request.InvoiceNo + "',@RefID='" + request.RefID + "',@PIRecievedDate='" + request.PIRecievedDate + "',@PIGrossAmount='" + request.PIGrossAmount + "', ";
            SqlQuery += " @Name='" + request.Name + "',@GSTINNo='" + request.GSTINNo + "',@ContactNo='" + request.ContactNo + "',@Email='" + request.Email + "',@StateID='" + request.StateID + "',@DistrictID='" + request.DistrictID + "',@CityName='" + request.CityName + "',@PinCode='" + request.PinCode + "',@Address='" + request.Address + "', ";
            SqlQuery += " @DocumentName='" + request.DocumentName + "',@AssignTo='" + request.AssignTo + "',@CreatedBy ='" + request.UserID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ProjectMaster.Save_ProjectIPDetails");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<ProjectMasterDataModel_ProjectIPDetails> GetProjectIPDetails(int ProjectID)
        {
            string SqlQuery = " exec USP_GetProjectIPDetails @ProjectID='" + ProjectID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetProjectIPDetails");

            List<ProjectMasterDataModel_ProjectIPDetails> dataModels = new List<ProjectMasterDataModel_ProjectIPDetails>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ProjectMasterDataModel_ProjectIPDetails>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
