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
    public class StaffDetailRepository : IStaffDetailRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public StaffDetailRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool IfExistsPrincipal(int StaffDetailID, int CollegeID, int DesignationID)
        {
            string SqlQuery = " USP_IfExistsPrincipalStaffDetail @CollegeID='" + CollegeID + "',@StaffDetailID='" + StaffDetailID + "',@DesignationID='" + DesignationID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StaffDetail.IfExistsPrincipal");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool IfExistsAadhar(int StaffDetailID, int CollegeID, string AadharCard)
        {
            string SqlQuery = "select AadhaarNo from Trn_StaffDetail Where AadhaarNo='"+ AadharCard + "' and StaffDetailID != '"+ StaffDetailID + "' and ActiveStatus=1 and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StaffDetail.IfExistsAadhar");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool SaveData(StaffDetailDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string EducationalQualificationDetail_Str = request.EducationalQualificationDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.EducationalQualificationDetails, "Temp_EducationalQualificationDetail_StaffDetail") : "";
            string SqlQuery = " exec USP_SaveStaffDetail_IU  ";
            SqlQuery += "@StaffDetailID='" + request.StaffDetailID + "',@TeachingType='" + request.TeachingType + "',@SubjectID='" + request.SubjectID + "',@PersonName='" + request.PersonName + "',@RoleID='" + request.RoleID + "',@MobileNo='" + request.MobileNo + "',@Email='" + request.Email + "',";
            SqlQuery += "@HighestQualification='" + request.HighestQualification + "',@NumberofExperience='" + request.NumberofExperience + "',@AadhaarNo='" + request.AadhaarNo + "',@DateOfBirth='" + request.DateOfBirth + "',@DateOfAppointment='" + request.DateOfAppointment + "',@DateOfJoining='" + request.DateOfJoining + "',";
            SqlQuery += "@SpecializationSubject='" + request.SpecializationSubject + "',@RoleMapping='" + request.RoleMapping + "',@Salary='" + request.Salary + "',@StaffStatus='" + request.StaffStatus + "',@PFDeduction='" + request.PFDeduction + "',@UANNumber='" + request.UANNumber + "',@ResearchGuide='" + request.ResearchGuide + "',";
            SqlQuery += "@ProfilePhoto='" + request.ProfilePhoto + "',@AadhaarCard='" + request.AadhaarCard + "',@PANCard='" + request.PANCard + "',@ExperienceCertificate='" + request.ExperienceCertificate + "',@DepartmentID='" + request.DepartmentID + "',@CollegeID='" + request.CollegeID + "',@EducationalQualificationDetail_Str='" + EducationalQualificationDetail_Str + "',@ModifyBy='" + request.ModifyBy + "',@CreatedBy='" + request.CreatedBy + "',@IPAddress='" + IPAddress + "',@Gender='" + request.Gender + "',@ESINumber='" + request.ESINumber + "',@PANNo='" + request.PANNo + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StaffDetail.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<StaffDetailDataModel> GetStaffDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int StaffDetailID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_GetStaffDetailList_DepartmentCollegeWise @StaffDetailID='" + StaffDetailID + "',@DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "StaffDetail.GetStaffDetailList_DepartmentCollegeWise");
            List<StaffDetailDataModel> listdataModels = new List<StaffDetailDataModel>();
            StaffDetailDataModel dataModels = new StaffDetailDataModel();
            if (StaffDetailID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<StaffDetailDataModel>>(JsonDataTable_Data);
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.StaffDetailID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StaffDetailID"]);
                    dataModels.TeachingType = dataSet.Tables[0].Rows[0]["TeachingType"].ToString();
                    dataModels.SubjectID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["SubjectID"]);
                    dataModels.SubjectName = dataSet.Tables[0].Rows[0]["SubjectName"].ToString();
                    dataModels.PersonName = dataSet.Tables[0].Rows[0]["PersonName"].ToString();
                    dataModels.MobileNo = dataSet.Tables[0].Rows[0]["MobileNo"].ToString();
                    dataModels.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
                    dataModels.HighestQualification = Convert.ToInt32(dataSet.Tables[0].Rows[0]["HighestQualification"]);
                    dataModels.NumberofExperience = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NumberofExperience"]);
                    dataModels.AadhaarNo = dataSet.Tables[0].Rows[0]["AadhaarNo"].ToString();
                    dataModels.DateOfBirth = dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString();
                    dataModels.DateOfAppointment = dataSet.Tables[0].Rows[0]["DateOfAppointment"].ToString();
                    dataModels.DateOfJoining = dataSet.Tables[0].Rows[0]["DateOfJoining"].ToString();
                    dataModels.SpecializationSubject = dataSet.Tables[0].Rows[0]["SpecializationSubject"].ToString();
                    dataModels.RoleMapping = dataSet.Tables[0].Rows[0]["RoleMapping"].ToString();
                    dataModels.StaffStatus = dataSet.Tables[0].Rows[0]["StaffStatus"].ToString();
                    dataModels.PFDeduction = dataSet.Tables[0].Rows[0]["PFDeduction"].ToString();
                    dataModels.UANNumber = dataSet.Tables[0].Rows[0]["UANNumber"].ToString();
                    dataModels.ResearchGuide = dataSet.Tables[0].Rows[0]["ResearchGuide"].ToString();
                    dataModels.ProfilePhoto = dataSet.Tables[0].Rows[0]["ProfilePhoto"].ToString();
                    dataModels.ProfilePhotoPath = dataSet.Tables[0].Rows[0]["ProfilePhotoPath"].ToString();
                    dataModels.ProfilePhoto_Dis_FileName = dataSet.Tables[0].Rows[0]["ProfilePhoto_Dis_FileName"].ToString();
                    dataModels.AadhaarCard = dataSet.Tables[0].Rows[0]["AadhaarCard"].ToString();
                    dataModels.AadhaarCardPath = dataSet.Tables[0].Rows[0]["AadhaarCardPath"].ToString();
                    dataModels.AadhaarCard_Dis_FileName = dataSet.Tables[0].Rows[0]["AadhaarCard_Dis_FileName"].ToString();
                    dataModels.PANCard = dataSet.Tables[0].Rows[0]["PANCard"].ToString();
                    dataModels.PANCardPath = dataSet.Tables[0].Rows[0]["PANCardPath"].ToString();
                    dataModels.PANCard_Dis_FileName = dataSet.Tables[0].Rows[0]["PANCard_Dis_FileName"].ToString();
                    dataModels.ExperienceCertificate = dataSet.Tables[0].Rows[0]["ExperienceCertificate"].ToString();
                    dataModels.ExperienceCertificatePath = dataSet.Tables[0].Rows[0]["ExperienceCertificatePath"].ToString();
                    dataModels.ExperienceCertificate_Dis_FileName = dataSet.Tables[0].Rows[0]["ExperienceCertificate_Dis_FileName"].ToString();
                    dataModels.RoleID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RoleID"]);
                    dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                    dataModels.Salary = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["Salary"]);
                    dataModels.RoleName = dataSet.Tables[0].Rows[0]["RoleName"].ToString();
                    dataModels.CreatedBy = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CreatedBy"]);
                    dataModels.ModifyBy = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ModifyBy"]);
                    dataModels.IPAddress = dataSet.Tables[0].Rows[0]["IPAddress"].ToString();
                    dataModels.HighestQualificationName = dataSet.Tables[0].Rows[0]["HighestQualificationName"].ToString();
                    dataModels.Gender = dataSet.Tables[0].Rows[0]["Gender"].ToString();
                    dataModels.ESINumber = dataSet.Tables[0].Rows[0]["ESINumber"].ToString();
                    dataModels.PANNo = dataSet.Tables[0].Rows[0]["PANNo"].ToString();

                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<EducationalQualificationDetails_StaffDetail> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<EducationalQualificationDetails_StaffDetail>>(JsonDataTable_Data);
                    dataModels.EducationalQualificationDetails = EducationalQualificationDetails_StaffDetail_Item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }

        public bool DeleteStaffDetail(int StaffDetailID)
        {
            string SqlQuery = "exec USP_DeleteStaffDetail @StaffDetailID='" + StaffDetailID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StaffDetail.DeleteStaffDetail");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataSet> GetStaffDetailListForPDF(int DepartmentID, int CollegeID)
        {
            string SqlQuery = " exec USP_GetStaffDetailList_ForPDf @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LandDetails.GetStaffDetailListForPDF");

            List<CommonDataModel_DataSet> dataModels = new List<CommonDataModel_DataSet>();
            CommonDataModel_DataSet dataModel = new CommonDataModel_DataSet();
            dataModel.data = dataSet;
            for (int i = 0; i < dataModel.data.Tables[0].Rows.Count; i++)
            {
                dataModel.data.Tables[0].Rows[i]["ProfilePhoto"] = _commonHelper.ConvertTobase64(dataModel.data.Tables[0].Rows[i]["ProfilePhoto"].ToString());
            }
            dataModels.Add(dataModel);
            return dataModels;
        }



        public bool SaveData_ExcelData(StaffDetailDataModel_Excel request_Model)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "";
            foreach (var request in request_Model.AllStaffExcelData)
            {
                string EducationalQualificationDetail_Str = request.EducationalQualificationDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.EducationalQualificationDetails, "Temp_EducationalQualificationDetail_StaffDetail") : "";
                 
                SqlQuery += " exec USP_SaveStaffDetail_IU  ";
                SqlQuery += "@StaffDetailID='" + request.StaffDetailID + "',@TeachingType='" + request.TeachingType + "',@SubjectID='" + request.SubjectID + "',@PersonName='" + request.PersonName + "',@RoleID='" + request.RoleID + "',@MobileNo='" + request.MobileNo + "',@Email='" + request.Email + "',";
                SqlQuery += "@HighestQualification='" + request.HighestQualification + "',@NumberofExperience='" + request.NumberofExperience + "',@AadhaarNo='" + request.AadhaarNo + "',@DateOfBirth='" + request.DateOfBirth + "',@DateOfAppointment='" + request.DateOfAppointment + "',@DateOfJoining='" + request.DateOfJoining + "',";
                SqlQuery += "@SpecializationSubject='" + request.SpecializationSubject + "',@RoleMapping='" + request.RoleMapping + "',@Salary='" + request.Salary + "',@StaffStatus='" + request.StaffStatus + "',@PFDeduction='" + request.PFDeduction + "',@UANNumber='" + request.UANNumber + "',@ResearchGuide='" + request.ResearchGuide + "',";
                SqlQuery += "@ProfilePhoto='" + request.ProfilePhoto + "',@AadhaarCard='" + request.AadhaarCard + "',@PANCard='" + request.PANCard + "',@ExperienceCertificate='" + request.ExperienceCertificate + "',@DepartmentID='" + request.DepartmentID + "',@CollegeID='" + request.CollegeID + "',@EducationalQualificationDetail_Str='" + EducationalQualificationDetail_Str + "',@ModifyBy='" + request.ModifyBy + "',@CreatedBy='" + request.CreatedBy + "',@IPAddress='" + IPAddress + "',@Gender='" + request.Gender + "',@ESINumber='" + request.ESINumber + "',@PANNo='" + request.PANNo + "'";

            }

            int Rows = _commonHelper.NonQuerry(SqlQuery, "StaffDetail.SaveData_ExcelData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
