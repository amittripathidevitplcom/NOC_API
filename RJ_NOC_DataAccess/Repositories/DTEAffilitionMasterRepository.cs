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
            string BTERAffiliationfeesDetailsList = CommonHelper.GetDetailsTableQry(request.BTERAffiliationfeesDetails, "Temp_BTERAffiliationfeesDetailsList");           
            string SqlQuery = " exec USP_M_DTEAffilitionCourse @BTERCourseID='" + request.BTERCourseID + "',@CourseStatusId='" + request.CourseStatusId + "',@CourseTypeId='" + request.CourseTypeId + "',@CourseId='" + request.CourseId + "',@CourseIntakeAsPerAICTELOA='" + request.CourseIntakeAsPerAICTELOA + "',";
              SqlQuery += "@ShiftID = '" + request.ShiftID + "',@Yearofstarting='" + request.Yearofstarting + "',@BterBranchTypeId = '" + request.BterBranchTypeId + "',@FirstYearRegularStudent='" +request.FirstYearRegularStudent + "',@FirstYearExStudent='" + request.FirstYearExStudent + "',@FirstYearTotal='" + request.FirstYearTotal+ "',@SecondYearRegularStudent='" + request.SecondYearRegularStudent + "',@SecondYearExStudent='" + request.SecondYearExStudent+ "',@SecondYearTotal='" + request.SecondYearTotal + "',@ThirdYearRegularStudent='" + request.ThirdYearRegularStudent + "',@ThirdYearExStudent='" + request.ThirdYearExStudent + "',@ThirdYearTotal='" + request.ThirdYearTotal + "',@GovtNOCAvailableforclosure='" + request.GovtNOCAvailableforclosure + "',@NOCNumber='" + request.NOCNumber + "',@NOCDate='" + request.NOCDate + "',@NOCClosingYearId='" + request.NOCClosingYearId + "',@NOCCUploadDocument='" + request.NOCCUploadDocument + "',@LegalEntityManagementType='" + request.LegalEntityManagementType + "',@DepartmentID='" + request.DepartmentID + "',@BTERRegID='" + request.BTERRegID + "',@RegAffiliationStatusId='" + request.RegAffiliationStatusId + "',@UserID='" + request.UserID + "',@BTERAffiliationfeesDetailsList='"+ BTERAffiliationfeesDetailsList + "' ";
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
            SqlQuery += "@UploadNocApproval = '" + request.UploadNocApproval + "',@AICTE_EOA_LOA='" + request.AICTE_EOA_LOA + "',@AICTELAO_No='" + request.AICTELAO_No + "',@EOA_LOA_Date='" + request.EOA_LOA_Date + "',@UploadLOAApproval='" + request.UploadLOAApproval + "',@UploadApplicationForm='" + request.UploadApplicationForm + "',@FYID = '" + request.FYID + "',@UserID = '" + request.UserID + "',@BTERRegID = '" + request.BTERRegID + "',@RegAffiliationStatusId = '" + request.RegAffiliationStatusId + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.DTEAffilitionOtherDetailsSaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        
        public bool IfExists(int BTERRegID, int BTERCourseID, int CourseTypeId, int CourseId,int ShiftID)
        {
            string SqlQuery = "exec USP_IfExistsBTERCourse @BTERRegID='" + BTERRegID + "' ,@BTERCourseID='" + BTERCourseID + "', @CourseTypeId='" + CourseTypeId + "',@CourseId='" + CourseId + "',@ShiftID='"+ ShiftID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.IfExists");
            if (dataTable.Rows.Count > 0)
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
        public List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int BTERRegID)
        {
            string SqlQuery = "exec USP_GETDTEAffiliationOtherDetailsPreview @BTERRegID=" + BTERRegID;
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

        public List<DTEAffiliationCommonDataModel_DataTable> GetAllDTEAffiliationCourseList(int BTERRegID)
        {
            string SqlQuery = " exec USP_GetAffiliationCourseList @BTERRegID='" + BTERRegID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetAllDTEAffiliationCourseList");

            List<DTEAffiliationCommonDataModel_DataTable> dataModels = new List<DTEAffiliationCommonDataModel_DataTable>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DTEAffiliationCommonDataModel_DataTable>>(JsonDataTable_Data);
            return dataModels;


        }
        public List<BTERCourseAffiliationDataModel> GetDTEAffiliationWiseCourseIDWise(int BTERCourseID, string LoginSSOID)
        {
            string SqlQuery = " exec USP_GetByIdAffiliationCourseList @BTERCourseID ='" + BTERCourseID + "',@LoginSSOID='" + LoginSSOID + "'";
            DataSet dataTable = new DataSet();
            dataTable = _commonHelper.Fill_DataSet(SqlQuery, "DTEAffilitionMaster.GetDTEAffiliationWiseCourseIDWise");

            List<BTERCourseAffiliationDataModel> dataModels = new List<BTERCourseAffiliationDataModel>();
            BTERCourseAffiliationDataModel dataModel = new BTERCourseAffiliationDataModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        
        public bool DeleteData(int AffiliationCourseID)
        {
            string SqlQuery = " Update Trn_CourseMaster_DTEAffiliation set ActiveStatus=0 , DeleteStatus=1  WHERE BTERCourseID='" + AffiliationCourseID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<BTERAffiliationfeesdeposited> generateYears(int YearofstartingID)
        {
            string SqlQuery = "exec USP_GetAffiliationfeesdepositedYear @YearofstartingID=" + YearofstartingID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.generateYears");

            List<BTERAffiliationfeesdeposited> dataModels = new List<BTERAffiliationfeesdeposited>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<BTERAffiliationfeesdeposited>>(JsonDataTable_Data);
            return dataModels;
        }
       
        public List<BTEROtherDetailsDataModel> GetOtherinformation(int BTERRegID)
        {
            string SqlQuery = "exec USP_GetOtherDetailsList @BTERRegID=" + BTERRegID;            
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetOtherinformation");

            List<BTEROtherDetailsDataModel> dataModels = new List<BTEROtherDetailsDataModel>();
            BTEROtherDetailsDataModel dataModel = new BTEROtherDetailsDataModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
               
        
        public List<BTERFeeDetailsDataModel> GetAllBTERAffiliationCourseFeeList(int BTERRegID)
        {
            //USP_GetBTERApplicationFeeCalculation            
            string SqlQuery = "exec USP_GetBTERApplicationFeeCalculation_one @BTERRegID=" + BTERRegID;            
            DataSet dataTable = new DataSet();
            dataTable = _commonHelper.Fill_DataSet(SqlQuery, "DTEAffilitionMaster.GetAllBTERAffiliationCourseFeeList");
            List<BTERFeeDetailsDataModel> dataModels = new List<BTERFeeDetailsDataModel>();
            BTERFeeDetailsDataModel dataModel = new BTERFeeDetailsDataModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<BTERFeeDetailsDataModel> GetDeficiencyHistoryApplicationID(int BTERRegID,string ApplicationStatus)
        {
            //USP_GetBTERApplicationFeeCalculation            
            string SqlQuery = "exec USP_BTERDocumentforDeficiencemarklist @BTERRegID='" + BTERRegID+"',@ApplicationStatus='"+ ApplicationStatus + "'";            
            DataSet dataTable = new DataSet();
            dataTable = _commonHelper.Fill_DataSet(SqlQuery, "DTEAffilitionMaster.GetDeficiencyHistoryApplicationID");
            List<BTERFeeDetailsDataModel> dataModels = new List<BTERFeeDetailsDataModel>();
            BTERFeeDetailsDataModel dataModel = new BTERFeeDetailsDataModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }        
        public bool RevertnocSaveData(NOCRevertOtherDetailsDataModel request, string ActionName)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ResubmitBTERApplication @OtherDetailsID='" + request.OtherDetailsID + "',@DepartmentID='" + request.DepartmentID + "',@NocIssued='" + request.NocIssued + "',@NocNumber='" + request.NocNumber + "',@NocIssueDate='" + request.NocIssueDate + "',";
            SqlQuery += "@UploadNocApproval = '" + request.UploadNocApproval + "',@FYID = '" + request.FYID + "',@UserID = '" + request.UserID + "',@BTERRegID = '" + request.BTERRegID + "',@RegAffiliationStatusId = '" + request.RegAffiliationStatusId + "',@Action='"+ ActionName + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.RevertnocSaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        } 
        public bool RevertEOALOASaveData(EOALOARevertOtherDetailsDataModel request, string ActionName)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ResubmitBTERApplication @OtherDetailsID='" + request.OtherDetailsID + "',@DepartmentID='" + request.DepartmentID + "',@AICTE_EOA_LOA='" + request.AICTE_EOA_LOA + "',@AICTELAO_No='" + request.AICTELAO_No + "',@EOA_LOA_Date='" + request.EOA_LOA_Date + "',";
            SqlQuery += "@UploadLOAApproval = '" + request.UploadLOAApproval + "',@FYID = '" + request.FYID + "',@UserID = '" + request.UserID + "',@BTERRegID = '" + request.BTERRegID + "',@RegAffiliationStatusId = '" + request.RegAffiliationStatusId + "',@Action='"+ ActionName + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.RevertEOALOASaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        
        public bool RevertApplicationSaveData(ApplicationRevertOtherDetailsDataModel request, string ActionName)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ResubmitBTERApplication @OtherDetailsID='" + request.OtherDetailsID + "',@DepartmentID='" + request.DepartmentID +"',";
            SqlQuery += "@UploadApplicationForm = '" + request.UploadApplicationForm + "',@FYID = '" + request.FYID + "',@UserID = '" + request.UserID + "',@BTERRegID = '" + request.BTERRegID + "',@RegAffiliationStatusId = '" + request.RegAffiliationStatusId + "',@Action='"+ ActionName + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.ApplicationRevertOtherDetailsDataModel");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<BTEROtherDetailsDataModel> ApplicationSubmit(int BTERRegID, string ActionName, decimal AMOUNT)
        {
            string SqlQuery = "exec USP_BTERRegFinalSubmit @BTERRegID='"+ BTERRegID + "',@ActionName='"+ ActionName + "',@AMOUNT='"+ AMOUNT + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.ApplicationSubmit");

            List<BTEROtherDetailsDataModel> dataModels = new List<BTEROtherDetailsDataModel>();
            BTEROtherDetailsDataModel dataModel = new BTEROtherDetailsDataModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool Generateorder_SaveData(Generateorderforbter request)
        {

            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string BTERApprovedList = CommonHelper.GetDetailsTableQry(request.TotalBTERreceivedApplicationList, "Temp_BTERApprovedList");
            string SqlQuery = " exec USP_BTERApprovedOrderList @BterApprovedOrderId='" + request.DTEAffiliationID + "',@SessionID='" + request.SessionID + "',@UserID='" + request.UserID + "',@RoleID='" + request.RoleID + "',@SessionName='" + request.SessionName + "',@BTERApprovedList='" + BTERApprovedList + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.Generateorder_SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetAllBTERFeeList()
        {
            string SqlQuery = " exec USP_GetBTERFeeMasterData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetAllBTERFeeList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<BTERFeeMasterDataModel> GetBTERFeeByID(int FeeID)
        {
            string SqlQuery = " exec USP_GetBTERFeeMasterData @FeeID='" + FeeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetLOIFeeByID");

            List<BTERFeeMasterDataModel> dataModels = new List<BTERFeeMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<BTERFeeMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveDataBTERFee(BTERFeeMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec BTERFeeMaster_AddUpdate";
            SqlQuery += " @FeeID='" + request.FeeID + "',@DepartmentID='" + request.DepartmentID + "',@FeeType='" + request.FeeType + "',@Amount='" + request.Amount + "', @ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.SaveDataBTERFee");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteDataBter(int FeeID)
        {
            string SqlQuery = " Update DTE_AffiliationApplyFees set ActiveStatus=0 , DeleteStatus=1  WHERE FeeID='" + FeeID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.DeleteDataBter");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int FeeID, int DepartmentID, string FeeType)
        {
            string SqlQuery = " select FeeType from DTE_AffiliationApplyFees Where Department = '" + DepartmentID + "' and FeeType='" + FeeType.Trim() + "'  and FeeID !='" + FeeID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool SaveDataBTERApplicationOpenSession(BTERApplicationOpensessionDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string formattedStartDate = request.StartDate.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedEndDate = request.EndDate.ToString("yyyy-MM-dd HH:mm:ss");
            string SqlQuery = " exec BTEROpenApplicationSessionMaster_AddUpdate";
            SqlQuery += " @ID='" + request.ID + "',@DepartmentID='" + request.DepartmentID + "',@ApplicationSession='" + request.ApplicationSession + "',@StartDate='" + formattedStartDate + "',@EndDate='" + formattedEndDate + "', @ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.SaveDataBTERApplicationOpenSession");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<BTERApplicationOpensessionDataModel> GetAllOpenSessionApplicationList()
        {
            string SqlQuery = "exec USP_BTERAllOpenSessionApplicationList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetAllOpenSessionApplicationList");

            List<BTERApplicationOpensessionDataModel> dataModels = new List<BTERApplicationOpensessionDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<BTERApplicationOpensessionDataModel>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<BTERApplicationOpensessionDataModel> GetByIDOpenSessionApplicationList(int ID)
        {
            string SqlQuery = "exec USP_BTERAllOpenSessionApplicationList @ID='" + ID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetByIDOpenSessionApplicationList");

            List<BTERApplicationOpensessionDataModel> dataModels = new List<BTERApplicationOpensessionDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<BTERApplicationOpensessionDataModel>>(JsonDataTable_Data);
            return dataModels;
        }


        public bool DeleteDataOpenSessionApplicationList(int ID)
        {
            string SqlQuery = " Update M_ApplicationMaster_DTEAffiliation set ActiveStatus=0 , DeleteStatus=1  WHERE ID='" + ID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEAffilitionMaster.DeleteDataOpenSessionApplicationList");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<BTERPaymentHistoryeMitraDataModel_List> GetPaymenthistoryList(BTERPaymentHistoryeMitraDataModel request, int DepartmentID)
        {
            string SqlQuery = "exec USP_GetBTER_PaymentHistoryeMitra @DepartmentID='" + request.DepartmentID + "', @CollegeID='" + request.CollegeID + "',@PRN='" + request.PRNNO + "',@TokenNo='" + request.TokenNo + "',@TransctionStatus='" + request.TransctionStatus + "',@TransctionDate='" + request.TransctionDate + "',@TransctionToDate='"+request.TransctionToDate+"'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetPaymenthistoryList");
            List<BTERPaymentHistoryeMitraDataModel_List> dataModels = new List<BTERPaymentHistoryeMitraDataModel_List>();
            BTERPaymentHistoryeMitraDataModel_List dataModel = new BTERPaymentHistoryeMitraDataModel_List();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }      
        public List<BTERPaymentHistoryeMitraDataModel_List> GetAllCollegeList()
        {
            string SqlQuery = "exec USP_GetBTERCollegeList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEAffilitionMaster.GetAllCollegeList");
            List<BTERPaymentHistoryeMitraDataModel_List> dataModels = new List<BTERPaymentHistoryeMitraDataModel_List>();
            BTERPaymentHistoryeMitraDataModel_List dataModel = new BTERPaymentHistoryeMitraDataModel_List();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
