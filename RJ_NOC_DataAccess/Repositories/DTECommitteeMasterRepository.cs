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
            string SqlQuery = " exec USP_GetDTECommitteeMasterList @CommitteeMasterID='" + DTECommitteeMasterID + "'";
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
                    dataModels.DTECommitteeMasterID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CommitteeMasterID"]);
                    dataModels.CommitteeType = Convert.ToString(dataSet.Tables[0].Rows[0]["CommitteeType"]);
                    dataModels.CommitteeName = Convert.ToString(dataSet.Tables[0].Rows[0]["CommitteeName"]);
                    dataModels.ActiveStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ActiveStatus"]);
                    dataModels.DeleteStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["DeleteStatus"]);

                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<DETCommitteeMemberDetail> CommitteeMemberDetailDataModel_Item = JsonConvert.DeserializeObject<List<DETCommitteeMemberDetail>>(JsonDataTable_Data);
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

        

    }
}
