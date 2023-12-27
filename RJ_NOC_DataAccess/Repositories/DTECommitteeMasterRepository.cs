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
    public class DTECommitteeMasterRepository : IDTECommitteeMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTECommitteeMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }


        #region "COomitteMaster Section"

        public bool SaveData(DTECommitteeMasterDataModel request)
        {
            string DTECommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.CommitteeMemberDetailList, "Temp_DTECommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveDTECommitteeMaster @DTECommitteeMasterID='" + request.DTECommitteeMasterID + "',@CommitteeType='" + request.CommitteeType + "',";
            SqlQuery += "@CommitteeName = '" + request.CommitteeName + "',@ContactNumber = '" + request.ContactNumber + "',@IPAddress = '" + IPAddress + "',@DTECommitteeMasterDetail_Str='" + DTECommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTECommitteeMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int DTECommitteeMasterID, string CommitteeType, string CommitteeName)
        {
            string SqlQuery = " select CommitteeName from M_DTECommitteeMaster Where CommitteeType='" + CommitteeType.Trim() + "' and CommitteeName='" + CommitteeName.Trim() + "'  and DTECommitteeMasterID !='" + DTECommitteeMasterID + "'  and DeleteStatus=0";
            //string SqlQuery = " USP_IfExistsDTECommitteeMaster @CommitteeType = '" + CommitteeType + "',@DTECommitteeMasterID='" + DTECommitteeMasterID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTECommitteeMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public List<DTECommitteeMasterDataModel> GetDTECommitteeMasterList(int DTECommitteeMasterID)
        {
            string SqlQuery = " exec USP_GetDTECommitteeMasterList @DTECommitteeMasterID='" + DTECommitteeMasterID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTECommitteeMaster.GetDTECommitteeMasterList");
            List<DTECommitteeMasterDataModel> listdataModels = new List<DTECommitteeMasterDataModel>();
            DTECommitteeMasterDataModel dataModels = new DTECommitteeMasterDataModel();
            if (DTECommitteeMasterID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<DTECommitteeMasterDataModel>>(JsonDataTable_Data);
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.DTECommitteeMasterID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DTECommitteeMasterID"]);
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
        public bool DeleteCommitteeData(int DTECommitteeMasterID)
        {
            string SqlQuery = " exec USP_DeleteDTECommitteeMasterList @DTECommitteeMasterID='" + DTECommitteeMasterID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTECommitteeMaster.DeleteCommitteeData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        #endregion


        #region "Application (Committee)"
        public bool SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel request)
        {
            string DTECommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.ApplicationCommitteeList, "Temp_DTECommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplicationCommitteeMember @UserID='" + request.UserID + "', @ApplyNocApplicationID='" + request.ApplyNocApplicationID + "',@DTECommitteeMasterDetail_Str='" + DTECommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTECommitteeMaster.SaveApplicationCommitteeData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel request)
        {
            string DTECommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.ApplicationCommitteeList, "Temp_DTECommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplicationCommitteeMember_AH @UserID='" + request.UserID + "', @ApplyNocApplicationID='" + request.ApplyNocApplicationID + "',@DTECommitteeMasterDetail_Str='" + DTECommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTECommitteeMaster.SaveApplicationCommitteeData_AH");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool SaveApplicationCommitteeData_Agri(PostApplicationCommitteeMemberdataModel request)
        {
            string DTECommitteeMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.ApplicationCommitteeList, "Temp_DTECommitteeMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveApplicationCommitteeMember_Agri @UserID='" + request.UserID + "', @ApplyNocApplicationID='" + request.ApplyNocApplicationID + "',@DTECommitteeMasterDetail_Str='" + DTECommitteeMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTECommitteeMaster.SaveApplicationCommitteeData_Agri");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteApplicationCommittee(int CommitteeMemberID)
        {
            string SqlQuery = " exec USP_DeleteDTECommitteeMasterList @CommitteeMemberID='" + CommitteeMemberID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTECommitteeMaster.DeleteCommitteeData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<ApplicationCommitteeMemberdataModel> GetApplicationCommitteeList(int ApplyNocApplicationID)
        {
            string SqlQuery = " exec USP_GetApplicationCommitteeList @ApplyNocApplicationID='" + ApplyNocApplicationID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTECommitteeMaster.GetApplicationDTECommitteeMasterList");
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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTECommitteeMaster.GetApplicationDTECommitteeMasterList");
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
            datatable = _commonHelper.Fill_DataTable(SqlQuery, "DTECommitteeMaster.GetApplicationNodelOfficer");
            NodelOfficerDetails_DCE dataModels = new NodelOfficerDetails_DCE();
            dataModels = CommonHelper.ConvertDataTable<NodelOfficerDetails_DCE>(datatable); 
            return dataModels;
        }

        #endregion

    }
}
