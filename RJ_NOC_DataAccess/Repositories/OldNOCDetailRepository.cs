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
    public class OldNOCDetailRepository : IOldNOCDetailRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public OldNOCDetailRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        //public bool IfExists(int HostelDetailID, int CollegeID, string HostelName)
        //{
        //    string SqlQuery = " USP_IfExistsHostelDetail @HostelName='" + HostelName + "',@CollegeID='" + CollegeID + "',@HostelDetailID='" + HostelDetailID + "' ";
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HostelDetail.IfExists");
        //    if (dataTable.Rows.Count > 0)
        //        return true;
        //    else
        //        return false;
        //}
        public bool SaveData(OldNocDetailsDataModel request)
        {
            string SubjectDetail_Str = request.SubjectData.Count > 0 ? CommonHelper.GetDetailsTableQry(request.SubjectData, "Temp_SubjectDetail_OldNOCDetail") : "";
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveOldNOCDetail_IU  ";
            SqlQuery += "@OldNocID='" + request.OldNocID + "',@CollegeID='" + request.CollegeID + "',@CourseID='" + request.CourseID + "',@NOCTypeID='" + request.NOCTypeID + "',@SessionYear='" + request.SessionYear + "',";
            SqlQuery += "@IssuedYear='" + request.IssuedYear + "',@NOCNumber='" + request.NOCNumber + "',@NOCReceivedDate='" + request.NOCReceivedDate + "',@NOCExpireDate='" + request.NOCExpireDate + "',";
            SqlQuery += "@UploadNOCDoc='" + request.UploadNOCDoc + "',@Remark='" + request.Remark + "',@DepartmentID='" + request.DepartmentID + "',@SubjectDetail_Str='" + SubjectDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "OldNOCDetail.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<OldNocDetailsDataModel> GetOldNOCDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int OldNocID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_GetOldNOCDetailList_DepartmentCollegeWise @OldNocID='" + OldNocID + "',@DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "OldNOCDetail.GetOlsNOCDetailList_DepartmentCollegeWise");
            List<OldNocDetailsDataModel> listdataModels = new List<OldNocDetailsDataModel>();
            OldNocDetailsDataModel dataModels = new OldNocDetailsDataModel();
            if (OldNocID == 0)
            {
                //string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                //listdataModels = JsonConvert.DeserializeObject<List<OldNocDetailsDataModel>>(JsonDataTable_Data);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    dataModels = new OldNocDetailsDataModel();
                    dataModels.SubjectData = new List<OldNocDetails_SubjectDataModel>();
                    //dataModels= JsonConvert.DeserializeObject<OldNocDetailsDataModel>(dataSet.Tables[0].Rows[i].ToString());
                    dataModels.OldNocID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["OldNocID"]);
                    dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DepartmentID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CollegeID"]);
                    dataModels.CourseID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CourseID"]);
                    dataModels.NOCTypeID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["NOCTypeID"]);
                    dataModels.SessionYear = Convert.ToInt32(dataSet.Tables[0].Rows[i]["SessionYear"]);
                    dataModels.IssuedYear = Convert.ToInt32(dataSet.Tables[0].Rows[i]["IssuedYear"]);
                    dataModels.IssuedYearName = dataSet.Tables[0].Rows[i]["IssuedYearName"].ToString();
                    dataModels.NOCNumber = dataSet.Tables[0].Rows[i]["NOCNumber"].ToString();
                    dataModels.NOCReceivedDate = dataSet.Tables[0].Rows[i]["NOCReceivedDate"].ToString();
                    dataModels.NOCExpireDate = dataSet.Tables[0].Rows[i]["NOCExpireDate"].ToString();
                    dataModels.UploadNOCDoc = dataSet.Tables[0].Rows[i]["UploadNOCDoc"].ToString();
                    dataModels.UploadNOCDocPath = dataSet.Tables[0].Rows[i]["UploadNOCDocPath"].ToString();
                    dataModels.Dis_FileName = dataSet.Tables[0].Rows[i]["Dis_FileName"].ToString();
                    dataModels.Remark = dataSet.Tables[0].Rows[i]["Remark"].ToString();
                    dataModels.CollegeName = dataSet.Tables[0].Rows[i]["CollegeName"].ToString();
                    dataModels.CourseName = dataSet.Tables[0].Rows[i]["CourseName"].ToString();
                    dataModels.NOCTypeName = dataSet.Tables[0].Rows[i]["NOCTypeName"].ToString();
                    dataModels.FinancialYearName = dataSet.Tables[0].Rows[i]["FinancialYearName"].ToString();
                    dataModels.Action = dataSet.Tables[0].Rows[i]["Action"].ToString();
                    for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dataSet.Tables[1].Rows[j]["OldNocID"]) == Convert.ToInt32(dataSet.Tables[0].Rows[i]["OldNocID"]))
                        {
                            OldNocDetails_SubjectDataModel subjectDataModel = new OldNocDetails_SubjectDataModel();
                            subjectDataModel.OldNOCSubjectID = Convert.ToInt32(dataSet.Tables[1].Rows[j]["OldNOCSubjectID"]);
                            subjectDataModel.SubjectID = Convert.ToInt32(dataSet.Tables[1].Rows[j]["SubjectID"]);
                            subjectDataModel.SubjectName = dataSet.Tables[1].Rows[j]["SubjectName"].ToString();
                            dataModels.SubjectData.Add(subjectDataModel);
                        }
                    }
                    listdataModels.Add(dataModels);
                }
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.OldNocID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["OldNocID"]);
                    dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                    dataModels.CourseID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CourseID"]);
                    dataModels.NOCTypeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NOCTypeID"]);
                    dataModels.SessionYear = Convert.ToInt32(dataSet.Tables[0].Rows[0]["SessionYear"]);
                    dataModels.IssuedYear = Convert.ToInt32(dataSet.Tables[0].Rows[0]["IssuedYear"]);
                    dataModels.IssuedYearName = dataSet.Tables[0].Rows[0]["IssuedYearName"].ToString();
                    dataModels.NOCNumber = dataSet.Tables[0].Rows[0]["NOCNumber"].ToString();
                    dataModels.NOCReceivedDate = dataSet.Tables[0].Rows[0]["NOCReceivedDate"].ToString();
                    dataModels.NOCExpireDate = dataSet.Tables[0].Rows[0]["NOCExpireDate"].ToString();
                    dataModels.UploadNOCDoc = dataSet.Tables[0].Rows[0]["UploadNOCDoc"].ToString();
                    dataModels.UploadNOCDocPath = dataSet.Tables[0].Rows[0]["UploadNOCDocPath"].ToString();
                    dataModels.Dis_FileName = dataSet.Tables[0].Rows[0]["Dis_FileName"].ToString();
                    dataModels.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
                    dataModels.CollegeName = dataSet.Tables[0].Rows[0]["CollegeName"].ToString();
                    dataModels.CourseName = dataSet.Tables[0].Rows[0]["CourseName"].ToString();
                    dataModels.NOCTypeName = dataSet.Tables[0].Rows[0]["NOCTypeName"].ToString();
                    dataModels.FinancialYearName = dataSet.Tables[0].Rows[0]["FinancialYearName"].ToString();
                    dataModels.Action = dataSet.Tables[0].Rows[0]["Action"].ToString();

                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<OldNocDetails_SubjectDataModel> OldNocDetails_SubjectDataModel_Item = JsonConvert.DeserializeObject<List<OldNocDetails_SubjectDataModel>>(JsonDataTable_Data);
                    dataModels.SubjectData = OldNocDetails_SubjectDataModel_Item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }
        public bool DeleteOldNocDetail(int OldNocID)
        {
            string SqlQuery = "exec USP_DeleteOldNocDetail @OldNocID='" + OldNocID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "OldNOCDetail.DeleteOldNocDetail");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int OldNocID, string NOCNumber)
        {
            string SqlQuery = " USP_IfExistsOldNocDetail @OldNocID='" + OldNocID + "',@NOCNumber='" + NOCNumber + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "OldNOCDetail.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataSet> GetOldNOCDetailListForPDF(int DepartmentID, int CollegeID)
        {
            string SqlQuery = " exec USP_GetOldNocList_ForPDf @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "OldNOCDetail.GetOldNOCDetailListForPDF");

            List<CommonDataModel_DataSet> dataModels = new List<CommonDataModel_DataSet>();
            CommonDataModel_DataSet dataModel = new CommonDataModel_DataSet();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
