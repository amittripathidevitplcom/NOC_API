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
    public class DTEAffilitionMasterRepository : IDTEAffilitionMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEAffilitionMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(DTEAffiliationRegistrationDataModel request)
        {

            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_DTEAffilitionRegistration @DTE_ARId='" + request.DTE_ARId + "',@DepartmentID='" + request.DepartmentID + "',@College_Name='" + request.College_Name + "',@Mobile_Number='" + request.Mobile_Number + "',@Email_Address='" + request.Email_Address + "',";
            SqlQuery += "@CollegeStatusId = '" + request.CollegeStatusId + "',@FYID = '" + request.OpenSessionFY + "',@AffiliationTypeID='"+request.AffiliationTypeID+ "',@SSOID='"+request.SSOID+"'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DTEAffilitionCourseSaveData(DTEAffiliationCourseDataModel request)
        {

            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_M_DTEAffilitionCourse @AffiliationCourseID='" + request.AffiliationCourseID + "',@DepartmentID='" + request.DepartmentID + "',@AffiliationCourseTypeID='" + request.AffiliationCourseTypeID + "',@CourseIntakeAsPerAICTELOA='" + request.CourseIntakeAsPerAICTELOA + "',@CourseID='" + request.CourseID + "',";
            SqlQuery += "@AffiliationShiftID = '" + request.AffiliationShiftID + "',@AffiliationBranchID='" + request.AffiliationBranchID + "',@FYID = '" + request.FYID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.DTEAffilitionCourseSaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request)
        {

            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_M_DTEAffilitionOtherDetails @OtherDetailsID='" + request.OtherDetailsID + "',@DepartmentID='" + request.DepartmentID + "',@NocIssued='" + request.NocIssued + "',@NocNumber='" + request.NocNumber + "',@NocIssueDate='" + request.NocIssueDate + "',";
            SqlQuery += "@UploadNocApproval = '" + request.UploadNocApproval + "',@AICTE_EOA_LOA='" + request.AICTE_EOA_LOA + "',@AICTELAO_No='" + request.AICTELAO_No + "',@EOA_LOA_Date='" + request.EOA_LOA_Date + "',@UploadLOAApproval='" + request.UploadLOAApproval + "',@UploadApplicationForm='" + request.UploadApplicationForm + "',@FYID = '" + request.FYID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.DTEAffilitionOtherDetailsSaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }     
        public List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID)
        {
            string SqlQuery = "exec USP_GETDTEAffiliationCoursePreview @DepatmentID=" + DepatmentID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetDTEAffiliationCoursePreviewData");

            List<DTEAffiliationAddCoursePreviewDataModel> dataModels = new List<DTEAffiliationAddCoursePreviewDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DTEAffiliationAddCoursePreviewDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int DepatmentID)
        {
            string SqlQuery = "exec USP_GETDTEAffiliationOtherDetailsPreview @DepatmentID=" + DepatmentID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetDTEAffiliationCoursePreviewData");

            List<DTEAffiliationAddOtherDetailsPreviewDataModel> dataModels = new List<DTEAffiliationAddOtherDetailsPreviewDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DTEAffiliationAddOtherDetailsPreviewDataModel>>(JsonDataTable_Data);
            return dataModels;
        }       
        public List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId)
        {
            string SqlQuery = "exec USP_GetRegistration_DTEAffiliation @DTE_ARId=" + DTE_ARId;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.Edit_OnClick");

            List<DTEAffiliationRegistrationDataModel> dataModels = new List<DTEAffiliationRegistrationDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DTEAffiliationRegistrationDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
