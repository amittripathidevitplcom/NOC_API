using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RJ_NOC_Model;
using System.Threading.Tasks;
using RJ_NOC_DataAccess.Interface;
using System.Data.SqlClient;
using System.Data;
using RJ_NOC_DataAccess.Common;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Net;

namespace RJ_NOC_DataAccess.Repository
{
    public class CommitteeMasterRepository : ICommitteeMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CommitteeMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }


        #region "COomitteMaster Section"

        public bool SaveData(CommitteeMasterDataModel request)
        {
            string CommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.CommitteeMemberDetailList, "Temp_CommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveCommitteeMaster @CommitteeMasterID='" + request.CommitteeMasterID + "',@CommitteeType='" + request.CommitteeType + "',";
            SqlQuery += "@CommitteeName = '" + request.CommitteeName + "',@ContactNumber = '" + request.ContactNumber + "',@IPAddress = '" + IPAddress + "',@CommitteeMasterDetail_Str='" + CommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int CommitteeMasterID, string CommitteeType, string CommitteeName)
        {
            string SqlQuery = " select CommitteeName from M_CommitteeMaster Where CommitteeType='" + CommitteeType.Trim() + "' and CommitteeName='" + CommitteeName.Trim() + "'  and CommitteeMasterID !='" + CommitteeMasterID + "'  and DeleteStatus=0";
            //string SqlQuery = " USP_IfExistsCommitteeMaster @CommitteeType = '" + CommitteeType + "',@CommitteeMasterID='" + CommitteeMasterID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommitteeMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public List<CommitteeMasterDataModel> GetCommitteeMasterList(int CommitteeMasterID)
        {
            string SqlQuery = " exec USP_GetCommitteeMasterList @CommitteeMasterID='" + CommitteeMasterID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "CommitteeMaster.GetCommitteeMasterList");
            List<CommitteeMasterDataModel> listdataModels = new List<CommitteeMasterDataModel>();
            CommitteeMasterDataModel dataModels = new CommitteeMasterDataModel();
            if (CommitteeMasterID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<CommitteeMasterDataModel>>(JsonDataTable_Data);
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.CommitteeMasterID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CommitteeMasterID"]);
                    dataModels.CommitteeType = Convert.ToString(dataSet.Tables[0].Rows[0]["CommitteeType"]);
                    dataModels.CommitteeName = Convert.ToString(dataSet.Tables[0].Rows[0]["CommitteeName"]);
                    dataModels.ContactNumber = Convert.ToString(dataSet.Tables[0].Rows[0]["ContactNumber"]);
                    dataModels.ActiveStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ActiveStatus"]);
                    dataModels.DeleteStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["DeleteStatus"]);

                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<CommitteeMemberDetail> CommitteeMemberDetailDataModel_Item = JsonConvert.DeserializeObject<List<CommitteeMemberDetail>>(JsonDataTable_Data);
                    dataModels.CommitteeMemberDetailList = CommitteeMemberDetailDataModel_Item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }
        public bool DeleteCommitteeData(int CommitteeMasterID)
        {
            string SqlQuery = " exec USP_DeleteCommitteeMasterList @CommitteeMasterID='" + CommitteeMasterID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.DeleteCommitteeData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        #endregion


        #region "Application (Committee)"
        public bool SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel request)
        {
            string CommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.ApplicationCommitteeList, "Temp_CommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplicationCommitteeMember @UserID='" + request.UserID + "', @ApplyNocApplicationID='" + request.ApplyNocApplicationID + "',@CommitteeMasterDetail_Str='" + CommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.SaveApplicationCommitteeData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel request)
        {
            string CommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.ApplicationCommitteeList, "Temp_CommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplicationCommitteeMember_AH @UserID='" + request.UserID + "', @ApplyNocApplicationID='" + request.ApplyNocApplicationID + "',@CommitteeMasterDetail_Str='" + CommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.SaveApplicationCommitteeData_AH");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool SaveApplicationCommitteeData_Agri(PostApplicationCommitteeMemberdataModel request)
        {
            string CommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.ApplicationCommitteeList, "Temp_CommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplicationCommitteeMember_Agri @UserID='" + request.UserID + "', @ApplyNocApplicationID='" + request.ApplyNocApplicationID + "',@CommitteeMasterDetail_Str='" + CommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.SaveApplicationCommitteeData_Agri");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteApplicationCommittee(int CommitteeMemberID)
        {
            string SqlQuery = " exec USP_DeleteCommitteeMasterList @CommitteeMemberID='" + CommitteeMemberID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommitteeMaster.DeleteCommitteeData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList(int ApplyNocApplicationID)
        {
            string SqlQuery = " exec USP_GetApplicationCommitteeList @ApplyNocApplicationID='" + ApplyNocApplicationID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "CommitteeMaster.GetApplicationCommitteeMasterList");
            List<ApplicationCommitteeMemberdataModel> listdataModels = new List<ApplicationCommitteeMemberdataModel>();
            ApplicationCommitteeMemberdataModel dataModels = new ApplicationCommitteeMemberdataModel();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<ApplicationCommitteeMemberdataModel>>(JsonDataTable_Data);

            return listdataModels;
        }
        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList_AH(int ApplyNocApplicationID, string ActionType)
        {
            string SqlQuery = " exec USP_GetApplicationCommitteeList_AH @ApplyNocApplicationID='" + ApplyNocApplicationID + "',@ActionType='" + ActionType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "CommitteeMaster.GetApplicationCommitteeMasterList");
            List<ApplicationCommitteeMemberdataModel> listdataModels = new List<ApplicationCommitteeMemberdataModel>();
            ApplicationCommitteeMemberdataModel dataModels = new ApplicationCommitteeMemberdataModel();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<ApplicationCommitteeMemberdataModel>>(JsonDataTable_Data);

            return listdataModels;
        }

        public NodelOfficerDetails_DCE GetApplicationNodelOfficer(int ApplyNocApplicationID)
        {
            string SqlQuery = " exec USP_GetApplicationNodelOfficer @ApplyNocApplicationID='" + ApplyNocApplicationID + "'";
            DataTable datatable = new DataTable();
            datatable = _commonHelper.Fill_DataTable(SqlQuery, "CommitteeMaster.GetApplicationNodelOfficer");
            NodelOfficerDetails_DCE dataModels = new NodelOfficerDetails_DCE();
            dataModels = CommonHelper.ConvertDataTable<NodelOfficerDetails_DCE>(datatable); 
            return dataModels;
        }

        #endregion

    }
}
