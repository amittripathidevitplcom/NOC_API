using Newtonsoft.Json;
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
    public class MGOneNOCRepository : IMGOneNOCRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public MGOneNOCRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<CommonDataModel_DataTable> GetNOCApplicationList(int RoleID, int UserID, string Status)
        {
            string SqlQuery = " exec USP_GetMGOneApplyNOCApplicationList @RoleID='" + RoleID + "',@UserID='" + UserID + "',@Status='" + Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MGOneNOC.GetNOCApplicationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveNOCWorkFlow(DocumentScrutinySave_DataModel_MGOne request)
        {
            request.Remark= request.Remark.Replace("'","");
            string SqlQuery = " exec USP_ApplyNOC_IU_MGOne  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNOCID + "',@RoleID='" + request.RoleID + "',@NextRoleID='" + request.NextRoleID + "',@UserID='" + request.UserID + "',@NextUserID='" + request.NextUserID + "',@ActionID='" + request.ActionID + "',@DepartmentID='" + request.DepartmentID + "',@Remark=N'" + request.Remark + "',@NextActionID='" + request.NextActionID + "',@UploadDocument='" + request.UploadDocument + "',@MOMDocument='" + request.MOMDocument + "'";
            
            int Rows = _commonHelper.NonQuerry(SqlQuery, "MGOneNOC.SaveNOCWorkFlow");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool SaveNOCWorkFlowDock(DocumentSave_DataModel_MGOne request)
        {
            string SqlQuery = " exec USP_SaveNOCWorkFlowDock_IU_MGOne  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNOCID + "',@MeetingScheduleDate='" + request.MeetingScheduleDate + "',@UserID='" + request.UserID + "',@DepartmentID='" + request.DepartmentID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "MGOneNOC.SaveNOCWorkFlowDock");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_DataTable> GetNOCWorkFlowDock(int ApplyNOCID)
        {
            string SqlQuery = " exec USP_GetNOCWorkFlowDock_MGOne @ApplyNocApplicationID='" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MGOneNOC.GetNOCWorkFlowDock");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveInspectionReport(InspectionReport_DataModel_MGOne request)
        {
            string SqlQuery = " exec USP_SaveInspectionReport_MGOne  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNOCID + "',@DepartmentID='" + request.DepartmentID + "',@CollegeID='" + request.CollegeID + "',@UserID='" + request.UserID + "',@InspectionReport='" + request.UploadDocument + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "MGOneNOC.SaveInspectionReport");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool GenerateOrderForInspectionReport(InspectionReport_DataModel_MGOne request)
        {
            string SqlQuery = " exec USP_SaveInspectionReport_MGOne  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNOCID + "',@DepartmentID='" + request.DepartmentID + "',@CollegeID='" + request.CollegeID + "',@UserID='" + request.UserID + "',@GenerateOrder='" + request.UploadDocument + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "MGOneNOC.GenerateOrderForInspectionReport");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            string SqlQuery = " exec USP_GetNOCDetails_MGOne @ApplyNocID='" + ApplyNocID + "',@departmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ActionType='" + Action + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MGOneNOC.GetGeneratePDFData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action,int ActionID = 0,int NextRoleID = 0, int NextUserID = 0)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_UpdateNOCDetails_MGOne @ActionType='{Action}',@NOCFilePath='{Path}',@ApplyNocID={ApplyNOCID},@departmentID={DepartmentID},@RoleID={RoleID},@userID={UserID},@Remarks='{NOCIssuedRemark}',@IPAddress='{IPAddress}',@ActionID='{ActionID}',@NextRoleID='{NextRoleID}',@NextUserID='{NextUserID}'";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "MGOneNOC.FinalSavePDFPathandNOC");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool SaveNOCIssueData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_GetNOCDetails_MGOne @ActionType='{Action}',@ApplyNocID={ApplyNocID},@departmentID={DepartmentID},@CollegeID={@CollegeID}";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "MGOneNOC.FinalSavePDFPathandNOC");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
