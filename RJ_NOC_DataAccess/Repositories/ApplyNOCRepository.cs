using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class ApplyNOCRepository : IApplyNOCRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ApplyNOCRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool DocumentScrutiny(DocumentScrutinySave_DataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ApplyNOC_IU  ";
            SqlQuery += "@ApplyNOCID='" + request.ApplyNOCID + "',@RoleID='" + request.RoleID + "',@NextRoleID='" + request.NextRoleID + "',@UserID='" + request.UserID + "',@NextUserID='" + request.NextUserID + "',@ActionID='" + request.ActionID + "',@DepartmentID='" + request.DepartmentID + "',@Remark='"+ request.Remark +"'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ApplyNOC.DocumentScrutiny");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool SaveDocumentScrutiny(DocumentScrutinyDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string DocumentScrutiny_Detail_Str = request.DocumentScrutinyDetail.Count > 0 ? CommonHelper.GetDetailsTableQry(request.DocumentScrutinyDetail, "Temp_Trn_DocumentScrutiny_Details") : "";
            string SqlQuery = " exec USP_DocumentScrutiny_IU";

            SqlQuery += " @DocumentScrutinyID=0,";
            SqlQuery += " @ApplyNOCID='" + request.ApplyNOCID + "',";
            SqlQuery += " @TabName='" + request.TabName + "',";
            SqlQuery += " @Remark='" + request.FinalRemark + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @RoleID='" + request.RoleID + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @DocumentScrutiny_Detail_Str='" + DocumentScrutiny_Detail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ApplyNOC.SaveDocumentScrutiny");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID, int UserID)
        {
            string SqlQuery = " exec USP_ApplyNOCApplicationList @RoleID='" + RoleID + "',@UserID='" + UserID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNOC.GetApplyNOCApplicationListByRole");
            List<ApplyNOCDataModel> listdataModels = new List<ApplyNOCDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<ApplyNOCDataModel>>(JsonDataTable_Data);
            return listdataModels;
        }
        public List<DocumentScrutinyDataModel> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID, int RoleID)
        {
            string SqlQuery = " exec USP_GetDocumentScrutinyData_TabNameCollegeWise @TabName='" + TabName + "',@CollegeID='" + CollegeID + "',@RoleID='" + RoleID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNOC.GetDocumentScrutinyData_TabNameCollegeWise");
            List<DocumentScrutinyDataModel> listdataModels = new List<DocumentScrutinyDataModel>();
            DocumentScrutinyDataModel dataModels = new DocumentScrutinyDataModel();
            //if (dataSet != null)
            //{
            //    if (TabName == "All")
            //    {
            //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            //        {
            //            dataModels = new DocumentScrutinyDataModel();
            //            dataModels.DocumentScrutinyDetail = new List<DocumentScrutinyDetail_DocumentScrutinyDataModel>();
            //            dataModels.DocumentScrutinyID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DocumentScrutinyID"]);
            //            dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DepartmentID"]);
            //            dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CollegeID"]);
            //            dataModels.UserID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["UserID"]);
            //            dataModels.RoleID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["RoleID"]);
            //            dataModels.ActionID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ActionID"]);
            //            dataModels.TabName = dataSet.Tables[0].Rows[i]["TabName"].ToString();
            //            dataModels.Remark = dataSet.Tables[0].Rows[i]["Remark"].ToString();
            //            for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
            //            {
            //                if (Convert.ToInt32(dataSet.Tables[1].Rows[j]["DocumentScrutinyID"]) == Convert.ToInt32(dataSet.Tables[0].Rows[i]["DocumentScrutinyID"]))
            //                {
            //                    DocumentScrutinyDetail_DocumentScrutinyDataModel detailDataModel = new DocumentScrutinyDetail_DocumentScrutinyDataModel();
            //                    detailDataModel.DocumentScrutinyDetailID = Convert.ToInt32(dataSet.Tables[1].Rows[j]["DocumentScrutinyDetailID"]);
            //                    detailDataModel.DocumentScrutinyID = Convert.ToInt32(dataSet.Tables[1].Rows[j]["DocumentScrutinyID"]);
            //                    detailDataModel.TabFieldID = Convert.ToInt32(dataSet.Tables[1].Rows[j]["TabFieldID"]);
            //                    detailDataModel.TabFieldName = dataSet.Tables[1].Rows[j]["TabFieldName"].ToString();
            //                    dataModels.DocumentScrutinyDetail.Add(detailDataModel);
            //                }
            //            }
            //            listdataModels.Add(dataModels);
            //        }
            //    }
            //    else
            //    {
            //        if (dataSet.Tables[0].Rows.Count > 0)
            //        {
            //            dataModels.DocumentScrutinyDetail = new List<DocumentScrutinyDetail_DocumentScrutinyDataModel>();
            //            dataModels.DocumentScrutinyID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DocumentScrutinyID"]);
            //            dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
            //            dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
            //            dataModels.UserID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["UserID"]);
            //            dataModels.RoleID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RoleID"]);
            //            dataModels.ActionID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ActionID"]);
            //            dataModels.TabName = dataSet.Tables[0].Rows[0]["TabName"].ToString();
            //            dataModels.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();

            //            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
            //            List<DocumentScrutinyDetail_DocumentScrutinyDataModel> DocumentScrutinyDetail_DocumentScrutinyDataModel_Item = JsonConvert.DeserializeObject<List<DocumentScrutinyDetail_DocumentScrutinyDataModel>>(JsonDataTable_Data);
            //            dataModels.DocumentScrutinyDetail = DocumentScrutinyDetail_DocumentScrutinyDataModel_Item;
            //            listdataModels.Add(dataModels);
            //        }
            //    }
            //}
            return listdataModels;
        }
        public List<ApplyNocParameterDataModel> GetRevertApplyNOCApplicationDepartmentRoleWise(int DepartmentID, int RoleID)
        {
            string SqlQuery = " exec USP_GetRevertApplyNOCApplicationDepartmentRoleWise @RoleID='" + RoleID + "',@DepartmentID='" + DepartmentID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNOC.GetRevertApplyNOCApplicationDepartmentRoleWise");
            List<ApplyNocParameterDataModel> listdataModels = new List<ApplyNocParameterDataModel>();
            ApplyNocParameterDataModel dataModels = new ApplyNocParameterDataModel();
            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    dataModels = new ApplyNocParameterDataModel();
                    dataModels.ApplyNocParameterMasterListDataModel = new List<ApplyNocParameterMasterListDataModel>();

                    dataModels.ApplyNocID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ApplyNocApplicationID"]);
                    dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DepartmentID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CollegeID"]);
                    dataModels.ApplicationTypeID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ApplicationTypeID"]);
                    dataModels.TotalFeeAmount = Convert.ToDecimal(dataSet.Tables[0].Rows[i]["TotalFeeAmount"]);
                    dataModels.ApplicationStatus = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ApplicationStatus"]);
                    dataModels.ApplicationTypeName = dataSet.Tables[0].Rows[i]["ApplicationTypeName"].ToString();
                    for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dataSet.Tables[1].Rows[j]["ApplyNocApplicationID"]) == Convert.ToInt32(dataSet.Tables[0].Rows[i]["ApplyNocApplicationID"]))
                        {
                            ApplyNocParameterMasterListDataModel detailDataModel = new ApplyNocParameterMasterListDataModel();
                            detailDataModel.ApplyNocID = Convert.ToInt32(dataSet.Tables[1].Rows[j]["ApplyNocApplicationID"]);
                            detailDataModel.ApplyNocFor = dataSet.Tables[1].Rows[j]["ApplyNocFor"].ToString();
                            dataModels.ApplyNocParameterMasterListDataModel.Add(detailDataModel);
                        }
                    }
                    listdataModels.Add(dataModels);

                }
            }
            return listdataModels;
        }
    }
}
