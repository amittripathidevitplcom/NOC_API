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
using System.Xml.Linq;

namespace RJ_NOC_DataAccess.Repository
{
    public class CommonFuncationRepository : ICommonFuncationRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CommonFuncationRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public string UploadFilePath()
        {
            string uploadFilePath = "";
            string SqlQuery = " select * from V#ImagePath ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery);
            if (dataTable.Rows.Count > 0)
            {
                uploadFilePath = dataTable.Rows[0]["ImagePath"].ToString();
            }
            return uploadFilePath;
        }
        public int Client_FolderWiseImages(string SqlQry)
        {
            return _commonHelper.NonQuerry(SqlQry, "CommonFuncation.Client_FolderWiseImages"); ;
        }


        public List<CommonDataModel_DepartmentMasterList> GetDepartmentList()
        {
            string SqlQuery = "exec USP_GetDepartmentList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDepartmentList");

            List<CommonDataModel_DepartmentMasterList> dataModels = new List<CommonDataModel_DepartmentMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DepartmentMasterList>>(JsonDataTable_Data);
            return dataModels;

        }
        public List<CommonDataModel_SchemeListByDepartment> GetSchemeListByDepartment(int DepatmentID)
        {
            string SqlQuery = "exec USP_GetSchemeListByDepartment @DepatmentID=" + DepatmentID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSchemeListByDepartment");

            List<CommonDataModel_SchemeListByDepartment> dataModels = new List<CommonDataModel_SchemeListByDepartment>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SchemeListByDepartment>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_ModuleMasterList> GetModuleList()
        {
            string SqlQuery = "exec USP_GetModuleList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetModuleList");

            List<CommonDataModel_ModuleMasterList> dataModels = new List<CommonDataModel_ModuleMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ModuleMasterList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_SubModuleListByModule> GetSubModuleListByModule(int ModuleID)
        {
            string SqlQuery = "exec USP_GetSubmoduleListByModule @ModuleID=" + ModuleID;
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSubModuleListByModule");
            List<CommonDataModel_SubModuleListByModule> dataModels = new List<CommonDataModel_SubModuleListByModule>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SubModuleListByModule>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_LevelMasterList> GetLevelList()
        {
            string SqlQuery = "exec USP_GetLevelList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLevelList");

            List<CommonDataModel_LevelMasterList> dataModels = new List<CommonDataModel_LevelMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LevelMasterList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleListByLevel(int LevelID)
        {
            string SqlQuery = "exec USP_GetRoleListByLevel @LevelID=" + LevelID;
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRoleListByLevel");
            List<CommonDataModel_RoleListByLevel> dataModels = new List<CommonDataModel_RoleListByLevel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RoleListByLevel>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_ActionHeadList> GetActionHeadList()
        {
            string SqlQuery = "exec USP_GetActionHeadList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionHeadList");

            List<CommonDataModel_ActionHeadList> dataModels = new List<CommonDataModel_ActionHeadList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ActionHeadList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_ActionListByActionHead> GetActionListByActionHead(int ActionHeadID)
        {
            string SqlQuery = "exec USP_GetActionListByActionHead @ActionHeadID=" + ActionHeadID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_ActionListByActionHead> dataModels = new List<CommonDataModel_ActionListByActionHead>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ActionListByActionHead>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DepartmentMaster> GetDepartmentMaster()
        {
            string SqlQuery = " Exec USP_DepartmentMaster";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_DepartmentMaster> dataModels = new List<CommonDataModel_DepartmentMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DepartmentMaster>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster> GetCollageList_DepartmentAndSSOIDWise(int DepartmentID, string LoginSSOID, string Type)
        {
            string SqlQuery = "exec USP_CollageList_DepartmentAndSSOIDWise @DepartmentID='" + DepartmentID + "',@LoginSSOID='" + LoginSSOID + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster> dataModels = new List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_CourseMaster> GetCourseList_DepartmentIDWise(int DepartmentID)
        {
            string SqlQuery = "exec USP_CourseList_DepartmentIDWise @DepartmentID=" + DepartmentID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_CourseMaster> dataModels = new List<CommonDataModel_CourseMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CourseMaster>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_CourseMaster> GetAddCourseList_DepartmentIDWise(int DepartmentID, int CourseLevelID)
        {
            string SqlQuery = "exec USP_CourseList_DepartmentIDWise @DepartmentID='" + DepartmentID + "',@CourseLevelID='" + CourseLevelID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAddActionListByActionHead");


            List<CommonDataModel_CourseMaster> dataModels = new List<CommonDataModel_CourseMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CourseMaster>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_SubjectMaster> GetSubjectList_CourseIDWise(int CourseID)
        {
            string SqlQuery = "exec USP_SubjectList_CourseIDWise @CourseID=" + CourseID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_SubjectMaster> dataModels = new List<CommonDataModel_SubjectMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SubjectMaster>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_SeatInformationMaster> GetSeatInformation_CourseIDWise(int CourseID)
        {
            string SqlQuery = "exec USP_SeatInformationList_CourseIDWise @CourseID=" + CourseID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_SeatInformationMaster> dataModels = new List<CommonDataModel_SeatInformationMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SeatInformationMaster>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            string SqlQuery = " Exec USP_CommonMasterList_DepartmentAndTypeWise @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSchemeListByDepartment");

            List<CommonDataModel_CommonMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_CommonMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DTEManagementType(int DepartmentID, string Type,string SSOID)
        {
            string SqlQuery = " Exec USP_CommonMasterList_DTEManagementType @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "',@SSOID='" + SSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSchemeListByDepartment");

            List<CommonDataModel_CommonMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_CommonMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DistrictList> GetDistrictList()
        {
            string SqlQuery = "exec USP_GetDistrictList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDistrictList");

            List<CommonDataModel_DistrictList> dataModels = new List<CommonDataModel_DistrictList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DistrictList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_StateList> GetStateList()
        {
            string SqlQuery = "exec USP_GetState";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetStateList");

            List<CommonDataModel_StateList> dataModels = new List<CommonDataModel_StateList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_StateList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DistrictList> GetDistrictListByStateID(int StateID)
        {
            string SqlQuery = "exec USP_GetDistrictListByStateID @StateID=" + StateID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDistrictListByStateID");

            List<CommonDataModel_DistrictList> dataModels = new List<CommonDataModel_DistrictList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DistrictList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DivisionDDL> GetAllDivision()
        {
            string SqlQuery = $"exec USP_DivisionMaster @Action='GetAllDivision'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAllDivision");

            List<CommonDataModel_DivisionDDL> dataModels = new List<CommonDataModel_DivisionDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DivisionDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_DistrictList> GetDistrictByDivsionId(int divisionId)
        {
            string SqlQuery = $"exec USP_DivisionMaster @Action='GetDistrictByDivisionId', @DivisionID={divisionId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDistrictByDivsionId");

            List<CommonDataModel_DistrictList> dataModels = new List<CommonDataModel_DistrictList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DistrictList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_UniversityDDL> GetUniversityByDepartmentId(int departmentId, int IsLaw)
        {
            string SqlQuery = $"exec USP_UniversityMaster @Action='GetUniversityByDepartmentId', @DepartmentID={departmentId},@IsLaw={IsLaw}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetUniversityByDepartmentId");

            List<CommonDataModel_UniversityDDL> dataModels = new List<CommonDataModel_UniversityDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_UniversityDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_SuvdivisionDDL> GetSuvdivisionByDistrictId(int districtId)
        {
            string SqlQuery = $"exec USP_SuvdivisionMaster @Action='GetSubdivisionByDistrictId', @DistrictID={districtId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSuvdivisionByDistrictId");

            List<CommonDataModel_SuvdivisionDDL> dataModels = new List<CommonDataModel_SuvdivisionDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SuvdivisionDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_TehsilDDL> GetTehsilByDistrictId(int districtId)
        {
            string SqlQuery = $"exec USP_TehsilMaster @Action='GetTehsilByDistrictId', @DistrictID={districtId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetTehsilByDistrictId");

            List<CommonDataModel_TehsilDDL> dataModels = new List<CommonDataModel_TehsilDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_TehsilDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_PanchyatSamitiDDL> GetPanchyatSamitiByDistrictId(int districtId)
        {
            string SqlQuery = $"exec USP_PanchyatSamitiMaster @Action='GetPanchyatSamitiByDistrictId', @DistrictID={districtId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetPanchyatSamitiByDistrictId");

            List<CommonDataModel_PanchyatSamitiDDL> dataModels = new List<CommonDataModel_PanchyatSamitiDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_PanchyatSamitiDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_ParliamentAreaDDL> GetParliamentAreaByDistrictId(int districtId)
        {
            string SqlQuery = $"exec USP_ParliamentAreaMaster @Action='GetParliamentAreaByDistrictId', @DistrictID={districtId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetParliamentAreaByDistrictId");

            List<CommonDataModel_ParliamentAreaDDL> dataModels = new List<CommonDataModel_ParliamentAreaDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ParliamentAreaDDL>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear()
        {
            string SqlQuery = "exec USP_FinancialYearMaster @Action='GetAllFinancialYear'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAllFinancialYear");

            List<CommonDataModel_FinancialYearDDL> dataModels = new List<CommonDataModel_FinancialYearDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_FinancialYearDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear_AcademicInformation()
        {
            string SqlQuery = "exec USP_FinancialYearMaster_AcademicInformation ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAllFinancialYear_AcademicInformation");

            List<CommonDataModel_FinancialYearDDL> dataModels = new List<CommonDataModel_FinancialYearDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_FinancialYearDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear_OldNOC(int CollegeID)
        {
            string SqlQuery = "exec USP_FinancialYearMaster_OldNOC @CollegeID='" + CollegeID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAllFinancialYear_OldNOC");

            List<CommonDataModel_FinancialYearDDL> dataModels = new List<CommonDataModel_FinancialYearDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_FinancialYearDDL>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DocumentMasterDepartmentAndTypeWise> GetDocumentMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            string SqlQuery = " Exec USP_DocumentMasterList_DepartmentAndTypeWise @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDocumentMasterList_DepartmentAndTypeWise");

            List<CommonDataModel_DocumentMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_DocumentMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DocumentMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID)
        {
            string SqlQuery = " Exec USP_LandAreaMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandAreaMasterList_DepartmentWise");

            List<CommonDataModel_LandAreaMasterList_DepartmentWise> dataModels = new List<CommonDataModel_LandAreaMasterList_DepartmentWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LandAreaMasterList_DepartmentWise>>(JsonDataTable_Data);
            return dataModels;
        }

        //public List<CommonDataModel_LandTypeMasterList_DepartmentWise> GetLandTypeMasterList_DepartmentWise(int DepartmentID)
        //{
        //    string SqlQuery = " Exec USP_LandTypeMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "'";
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandTypeMasterList_DepartmentWise");

        //    List<CommonDataModel_LandTypeMasterList_DepartmentWise> dataModels = new List<CommonDataModel_LandTypeMasterList_DepartmentWise>();
        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
        //    dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LandTypeMasterList_DepartmentWise>>(JsonDataTable_Data);
        //    return dataModels;
        //}
        public List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise> GetLandDoucmentTypeMasterList_DepartmentWise(int DepartmentID)
        {
            string SqlQuery = " Exec USP_LandDoucmentTypeMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandDoucmentTypeMasterList_DepartmentWise");

            List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise> dataModels = new List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_CollegeWiseCourseList> GetCourseList_CollegeWise(int CollegID, string CourseType)
        {
            string SqlQuery = $" Exec Get_CollegeWiseCourse @CollegeID={CollegID},@CourseType='" + CourseType + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandDoucmentTypeMasterList_DepartmentWise");

            List<CommonDataModel_CollegeWiseCourseList> dataModels = new List<CommonDataModel_CollegeWiseCourseList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CollegeWiseCourseList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<DataTable> Get_CollegeWiseCourse_Subject_OldNOC(int CollegeID, string Type, int CourseID, int OldNocID)
        {
            string SqlQuery = $" Exec Get_CollegeWiseCourse_Subject_OldNOC @CollegeID={CollegeID}, @Type='" + Type + "',@CourseID='" + CourseID + "',@OldNocID='" + OldNocID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandDoucmentTypeMasterList_DepartmentWise");


            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<DataTable> GetCollegeWise_SubjectList_StaffDetails(int CollegeID, string Type, int CourseID)
        {
            string SqlQuery = $" Exec GetCollegeWise_SubjectList_StaffDetails @CollegeID={CollegeID}, @Type='" + Type + "',@CourseID='" + CourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetCollegeWise_SubjectList_StaffDetails");


            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<DataTable> GetCollegeWise_CourseList_AcademicInformation(int CollegeID, string Type, int CourseID)
        {
            string SqlQuery = $" Exec GetCollegeWise_CourseList_AcademicInformation @CollegeID={CollegeID}, @Type='" + Type + "',@CourseID='" + CourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetCollegeWise_CourseList_AcademicInformation");


            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_CourseRoomSize> GetCourseRoomSize(int CourseID, int CollegeID)
        {
            string SqlQuery = " exec USP_CourseRoomSize @CourseID='" + CourseID + "',@CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandDoucmentTypeMasterList_DepartmentWise");

            List<CommonDataModel_CourseRoomSize> dataModels = new List<CommonDataModel_CourseRoomSize>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CourseRoomSize>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            string SqlQuery = " Exec USP_OtherInformationList_DepartmentAndTypeWise @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.OtherInformationList_DepartmentAndTypeWise");

            List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> dataModels = new List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentCollegeAndTypeWise(int DepartmentID,int CollegeID,int OtherInformationID, string Type)
        {
            string SqlQuery = " Exec USP_OtherInformationList_DepartmentCollegeAndTypeWise @DepartmentID='" + DepartmentID.ToString() + "',@CollegeID='" + CollegeID.ToString() + "',@OtherInformationID='" + OtherInformationID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.OtherInformationList_DepartmentCollegeAndTypeWise");

            List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> dataModels = new List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_OtherInformationSize> OtherInformationSize(int OtherInformationID)
        {
            string SqlQuery = " exec USP_OtherInformationSize @OtherInformationID='" + OtherInformationID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.OtherInformationSize");

            List<CommonDataModel_OtherInformationSize> dataModels = new List<CommonDataModel_OtherInformationSize>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_OtherInformationSize>>(JsonDataTable_Data);
            return dataModels;
        }


        //public List<CommonDataModel_QualificationMasterDepartmentAndTypeWise> GetQualificationMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        //{
        //    string SqlQuery = " Exec USP_QualificationMasterList_DepartmentAndTypeWise @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "'";
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetQualificationMasterList_DepartmentAndTypeWise");

        //    List<CommonDataModel_QualificationMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_QualificationMasterDepartmentAndTypeWise>();
        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
        //    dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_QualificationMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
        //    return dataModels;
        //}


        public List<CommonDataModel_BuildingType> GetBuildingTypeCheck(int SelectedDepartmentID)
        {
            string SqlQuery = "exec USP_BuildingDetails @ActionType='GetBuildingtype',@DepartmentID='" + SelectedDepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetBuildingTypeCheck");

            List<CommonDataModel_BuildingType> dataModels = new List<CommonDataModel_BuildingType>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_BuildingType>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_BuildingUploadDoc> GetBuildingUploadDetails(int DepartmentId)
        {
            string SqlQuery = "exec USP_BuildingDetails @ActionType='GetBuildingDoctype',@DepartmentID='" + DepartmentId + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetBuildingUploadDetails");

            List<CommonDataModel_BuildingUploadDoc> dataModels = new List<CommonDataModel_BuildingUploadDoc>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_BuildingUploadDoc>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID, int CollageID)
        {
            string SqlQuery = " Exec USP_LandAreaMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "',@CollageID='" + CollageID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandAreaMasterList_DepartmentWise");

            List<CommonDataModel_LandAreaMasterList_DepartmentWise> dataModels = new List<CommonDataModel_LandAreaMasterList_DepartmentWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LandAreaMasterList_DepartmentWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_TermAndCondition> GetTermAndConditionList_DepartmentWise(int departmentId)
        {
            string SqlQuery = $"exec USP_TermAndConditionList_DepartmentWiseMaster @DepartmentID={departmentId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetTermAndConditionList_DepartmentWise");

            List<CommonDataModel_TermAndCondition> dataModels = new List<CommonDataModel_TermAndCondition>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_TermAndCondition>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_Annexure> GetAnnexureDataList_DepartmentWise(int DepartmentID, int LandDocumentTypeID, int LandConvertedID)
        {
            string SqlQuery = $"exec USP_AnnexureList_DepartmentWiseMaster  @DepartmentID='" + DepartmentID.ToString() + "',@LandDocumentTypeID='" + LandDocumentTypeID.ToString() + "',@LandConvertedID='" + LandConvertedID.ToString() + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAnnexureDataList_DepartmentWise");

            List<CommonDataModel_Annexure> dataModels = new List<CommonDataModel_Annexure>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_Annexure>>(JsonDataTable_Data);
            return dataModels;
        }


        public List<CommonDataModel_QualificationMasterDepartmentWise> GetQualificationMasterList_DepartmentWise(int DepartmentID, int IsTeaching, string Type)
        {
            string SqlQuery = " Exec USP_QualificationMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "',@IsTeaching='" + IsTeaching + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetQualificationMasterList_DepartmentWise");

            List<CommonDataModel_QualificationMasterDepartmentWise> dataModels = new List<CommonDataModel_QualificationMasterDepartmentWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_QualificationMasterDepartmentWise>>(JsonDataTable_Data);
            return dataModels;
        }



        public List<CommonDataModel_CollegeWiseSubject> GetCollegeWiseSubjectList(int CollegeID)
        {
            string SqlQuery = " Exec USP_CollegeWiseSubject @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetCollegeWiseSubjectList");

            List<CommonDataModel_CollegeWiseSubject> dataModels = new List<CommonDataModel_CollegeWiseSubject>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CollegeWiseSubject>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitiesMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            string SqlQuery = " Exec USP_FacilitiesMaster_GetList @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetFacilitiesMasterList_DepartmentAndTypeWise");

            List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }     
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitiesMasterList_DepartmentCollegeAndTypeWise(int DepartmentID,int CollegeID, int FacilitieID, string Type)
        {
            string SqlQuery = " Exec USP_FacilitiesMaster_GetList_DepartmentCollegeWise @DepartmentID='" + DepartmentID.ToString() + "',@CollegeID='" + CollegeID.ToString() + "',@FacilitieID='" + FacilitieID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetFacilitiesMasterList_DepartmentCollegeAndTypeWise");

            List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitesMinSize(int FacilitieID)
        {
            string SqlQuery = " Exec USP_FacilitiesMaster_GetList @FacilitieID='" + FacilitieID.ToString() + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetFacilitesMinSize");

            List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }


        public List<CommonDataModel_LandTypeMasterList_DepartmentWise> GetLandTypeMasterList_DepartmentAndLandConvertWise(int DepartmentID, string Type)
        {
            string SqlQuery = " Exec USP_LandTypeMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandTypeMasterList_DepartmentAndLandConvertWise");



            List<CommonDataModel_LandTypeMasterList_DepartmentWise> dataModels = new List<CommonDataModel_LandTypeMasterList_DepartmentWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LandTypeMasterList_DepartmentWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_AssemblyAreaDDL> GetAssembelyAreaByDistrictId(int districtId)
        {
            string SqlQuery = $"exec USP_AssemblyAreaMaster @Action='GetAssembelyAreaByDistrictId', @DistrictID={districtId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAssembelyAreaByDistrictId");

            List<CommonDataModel_AssemblyAreaDDL> dataModels = new List<CommonDataModel_AssemblyAreaDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_AssemblyAreaDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_DashBoard> GetDashboardDataSSOWise(string SSOID, int DepartmentID, int RoleID, int UserID)
        {
            string SqlQuery = " Exec USP_GetDashboardData_SSOWise @LoginSSOID='" + SSOID + "',@DepartmentID='" + DepartmentID + "',@RoleID='" + RoleID + "',@UserID='" + UserID + "'";
            List<CommonDataModel_DashBoard> dataModels = new List<CommonDataModel_DashBoard>();
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDashboardDataSSOWise");
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DashBoard>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DesignationDDL> GetAllDesignation()
        {
            string SqlQuery = "Exec USP_DesignationMaster @Action='GetAllDesignation'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAllDesignation");

            var JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            var dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DesignationDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_OccupationDDL> GetAllOccupation()
        {
            string SqlQuery = "Exec USP_OccupationMaster @Action='GetAllOccupation'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAllOccupation");

            var JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            var dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_OccupationDDL>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetCollegeBasicDetails(int CollegID)
        {
            string SqlQuery = " exec USP_GetCollegeBasicDetails @CollegeID='" + CollegID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetCollegeBasicDetails");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleList()
        {
            string SqlQuery = "exec USP_GetRoleList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRoleList");

            List<CommonDataModel_RoleListByLevel> dataModels = new List<CommonDataModel_RoleListByLevel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RoleListByLevel>>(JsonDataTable_Data);
            return dataModels;

        }
        public List<CommonDataModel_DistrictList> Load_StateWise_DistrictMaster(int StateID)
        {
            string SqlQuery = " exec USP_GetDistrictByStateID @StateID='" + StateID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.Load_StateWise_DistrictMaster");

            List<CommonDataModel_DistrictList> dataModels = new List<CommonDataModel_DistrictList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DistrictList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_TabField> GetTabFieldByTabName(string TabName)
        {
            string SqlQuery = " Exec USP_GetTabFieldByTabName @TabName='" + TabName + "'";
            List<CommonDataModel_TabField> dataModels = new List<CommonDataModel_TabField>();
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetTabFieldByTabName");
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_TabField>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> CheckTabsEntry(int CollegID)
        {
            string SqlQuery = " exec USP_CheckTabsEntry @CollegeID='" + CollegID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.CheckTabsEntry");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool DraftFinalSubmit(int CollegeID, int IsDraftSubmited)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_DraftFinalSubmit";
            SqlQuery += " @CollegeID='" + CollegeID + "',@IsDraftSubmited='" + IsDraftSubmited + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommonFunction.DraftFinalSubmit");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool LOIFinalSubmit(int CollegeID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_LOIFinalSubmit";
            SqlQuery += " @CollegeID='" + CollegeID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommonFunction.LOIFinalSubmit");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleListByLevelID(int LevelID)
        {
            string SqlQuery = "exec USP_GetRoleListByLevelID @LevelID=" + LevelID;
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRoleListByLevelID");
            List<CommonDataModel_RoleListByLevel> dataModels = new List<CommonDataModel_RoleListByLevel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RoleListByLevel>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_CommitteeList> GetCommitteeList()
        {
            string SqlQuery = "exec USP_GetCommitteeList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetCommitteeList");

            List<CommonDataModel_CommitteeList> dataModels = new List<CommonDataModel_CommitteeList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CommitteeList>>(JsonDataTable_Data);
            return dataModels;

        }

        public List<CommonDataModel_GetConnectionString> GetConnectionString()
        {

            string ConnectionString1 = "";
            string ConnectionString2 = "";
            string ConnectionString3 = "";

            _commonHelper.GetConnectionstr(ref ConnectionString1, ref ConnectionString2, ref ConnectionString3);
            List<CommonDataModel_GetConnectionString> dataModels = new List<CommonDataModel_GetConnectionString>();
            CommonDataModel_GetConnectionString common = new CommonDataModel_GetConnectionString();
            common.ConnectionString1 = ConnectionString1;
            common.ConnectionString2 = ConnectionString2;
            common.ConnectionString3 = ConnectionString3;
            dataModels.Add(common);
            return dataModels;
        }

        public List<CommonDataModel_RoleListByLevel> GetRoleListForApporval(int RoleID, int DepartmentID)
        {
            string SqlQuery = "exec USP_ActionDataList @RoleID='" + RoleID + "',@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRoleListForApporval");
            List<CommonDataModel_RoleListByLevel> dataModels = new List<CommonDataModel_RoleListByLevel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RoleListByLevel>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CreateUserDataModel> GetUserDetailsByRoleID(int RoleID, int DepartmentID)
        {
            string SqlQuery = "exec USP_CommonDataList @Key='GetUserDetailsByRoleID',@RoleID='" + RoleID + "',@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetUserDetailsByRoleID");
            List<CreateUserDataModel> dataModels = new List<CreateUserDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CreateUserDataModel>>(JsonDataTable_Data);
            return dataModels;
        }


        public List<CommonDataModel_WorkFlowActionsByRole> GetWorkFlowActionListByRole(int RoleID, string Type, int DepartmentID)
        {
            string SqlQuery = "exec USP_GetWorkFlowActionListByRole @RoleID='" + RoleID + "',@Type='" + Type + "',@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.USP_GetWorkFlowActionListByRole");
            List<CommonDataModel_WorkFlowActionsByRole> dataModels = new List<CommonDataModel_WorkFlowActionsByRole>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_WorkFlowActionsByRole>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_RNCCheckListData> GetRNCCheckListByTypeDepartment(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            string SqlQuery = "exec USP_GetRNCCheckListByTypeDepartment @Type='" + Type + "' ,@DepartmentID='" + DepartmentID + "',@ApplyNOCID='" + ApplyNOCID + "',@CreatedBy='" + CreatedBy + "',@RoleID='" + RoleID + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRNCCheckListByTypeDepartment");
            List<CommonDataModel_RNCCheckListData> dataModels = new List<CommonDataModel_RNCCheckListData>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RNCCheckListData>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_ApplicationTrail> GetApplicationTrail_DepartmentApplicationWise(int ApplicationID, int DepartmentID)
        {
            string SqlQuery = "exec USP_GetApplicationTrail_DepartmentApplicationWise @ApplicationID='" + ApplicationID + "' ,@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetApplicationTrail_DepartmentApplicationWise");
            List<CommonDataModel_ApplicationTrail> dataModels = new List<CommonDataModel_ApplicationTrail>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ApplicationTrail>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_CourseMaster> GetCourseList_ByCourseLevelIDWise(int CourseLevelID, int DepartmentID)
        {
            string SqlQuery = "exec USP_CourseList_ByCourseLevelIDWise @CourseLevelID='" + CourseLevelID + "' ,@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");


            List<CommonDataModel_CourseMaster> dataModels = new List<CommonDataModel_CourseMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CourseMaster>>(JsonDataTable_Data);
            return dataModels;
        }


        public List<CommonDataModel_Stream> GetStreamList_CourseIDWise(int DepartmentID, int CourseLevelID, int CourseID)
        {
            string SqlQuery = "exec USP_CommonDataList @Key='GetStreamListCourseIDWise',@DepartmentID='" + DepartmentID + "',@CourseLevelID='" + CourseLevelID + "',@CourseID='" + CourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetStreamList_CourseIDWise");
            List<CommonDataModel_Stream> dataModels = new List<CommonDataModel_Stream>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_Stream>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_SubjectMaster> GetSubjectList_StreamIDWise(int StreamID, int DepartmentID, int CourseLevelID, int CourseID)
        {
            string SqlQuery = "exec USP_GetSubjectList_StreamIDWise @StreamID='" + StreamID + "', @DepartmentID = '" + DepartmentID + "', @CourseLevelID = '" + CourseLevelID + "', @CourseID = '" + CourseID + "'"; ;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSubjectList_StreamIDWise");
            List<CommonDataModel_SubjectMaster> dataModels = new List<CommonDataModel_SubjectMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SubjectMaster>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetCollegeWiseCourseList(int CollegID)
        {
            string SqlQuery = " exec USP_CollegeWiseCourseSubjectGet @ViewMode='GetCollegeWiseCourseList', @CollegeID='" + CollegID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetCollegeWiseCourseList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetCollegeWiseCourseIDSubjectList(int CollegeID, int CollegeWiseCourseID, string ViewMode)
        {
            string SqlQuery = " exec USP_CollegeWiseCourseSubjectGet @CollegeID='" + CollegeID + "',@ViewMode='" + ViewMode + "',@CollegeWiseCourseID='" + CollegeWiseCourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetCollegeWiseCourseIDSubjectList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetStreamMasterList(int DepartmentID)
        {
            string SqlQuery = "exec USP_CommonDataList @Key='GetStreamMasterList',@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetStreamMaster");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetMappedStreamListByID(int DepartmentID)
        {
            string SqlQuery = "exec USP_CommonDataList @Key='GetMappedStreamListByID',@DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetStreamMaster");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetCourseByStreamID(int StreamID, int DepartmentID, int CourseLevelID, int UniversityID)
        {
            string SqlQuery = "exec USP_CommonDataList  @Key='GetCourseByStreamID',@StreamID='" + StreamID + "', @DepartmentID = '" + DepartmentID + "', @CourseLevelID = '" + CourseLevelID + "',@UniversityID='" + UniversityID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetStreamMaster");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise> GetLandSqureMeterMappingDetails_DepartmentWise(int DepartmentID, int CollageID, int LandAreaId)
        {
            string SqlQuery = "exec USP_GetLandSqureMeterMappingDetails  @DepartmentID='" + DepartmentID + "', @CollegeID = '" + CollageID + "', @LandAreaID = '" + LandAreaId + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandSqureMeterMappingDetails_DepartmentWise");

            List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise> dataModels = new List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetDocumentScritintyTaril(int ID, int NOCApplyID, int CollageID, int DepartmentID, string ActionType)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_Trail @ActionType='" + ActionType + "', @CollegeID='" + CollageID + "',@DepartmentID='" + DepartmentID + "',@ApplyNOCID='" + NOCApplyID + "',@ID='" + ID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetDocumentScritintyTaril");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetStaffDesignation(int IsTeaching, int DepartmentID)
        {
            string SqlQuery = " exec USP_GetStaffDesignation @IsTeaching='" + IsTeaching + "',@departmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetStaffDesignation");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CollegeLandTypeDetailsDataModel> GetLandTypeDetails_CollegeWise(int DepartmentID, string Type, int LandDetailID)
        {
            string SqlQuery = " Exec USP_LandTypeDetails_CollegeWise @DepartmentID='" + DepartmentID.ToString() + "',@Type='" + Type + "',@LandDetailID='" + LandDetailID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandTypeDetails_CollegeWise");
            List<CollegeLandTypeDetailsDataModel> dataModels = new List<CollegeLandTypeDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CollegeLandTypeDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_UniversityDDL> GetUniversityDepartmentWise(int DepartmentID)
        {
            string SqlQuery = $"exec USP_UniversityMaster @Action='GetUniversityDepartmentWise', @DepartmentID={DepartmentID}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetUniversityDepartmentWise");

            List<CommonDataModel_UniversityDDL> dataModels = new List<CommonDataModel_UniversityDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_UniversityDDL>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_SubjectMaster> GetSubjectDepartmentWise(int DepartmentID)
        {
            string SqlQuery = $"exec USP_GetSubjectDepartmentWise  @DepartmentID={DepartmentID}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSubjectDepartmentWise");

            List<CommonDataModel_SubjectMaster> dataModels = new List<CommonDataModel_SubjectMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SubjectMaster>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetCollegeInspectionFee(int CollegID, int DepartmentId)
        {
            string SqlQuery = " exec USP_CollegeInspectionFee_GetData @CollegeID='" + CollegID + "',@DepartmentId='" + DepartmentId + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetCollegeInspectionFee");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CollegeLandConversionDetailsDataModel> GetCollegeLandConversionDetail(int DepartmentID, int LandDetailID, string Type)
        {
            string SqlQuery = " Exec USP_CollegeLandConversionDetail_GetData @DepartmentID='" + DepartmentID.ToString() + "',@LandDetailID='" + LandDetailID + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetCollegeLandConversionDetail");
            List<CollegeLandConversionDetailsDataModel> dataModels = new List<CollegeLandConversionDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CollegeLandConversionDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DepartmentAndTypeWises(int DepartmentID, int CollageID, string Type)
        {
            string SqlQuery = " Exec USP_CommonMasterList_DepartmentAndTypeWise @DepartmentID='" + DepartmentID.ToString() + "',@CollageID='" + CollageID + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSchemeListByDepartment");

            List<CommonDataModel_CommonMasterDepartmentAndTypeWise> dataModels = new List<CommonDataModel_CommonMasterDepartmentAndTypeWise>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CommonMasterDepartmentAndTypeWise>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetCityByDistrict(int DistrictID)
        {
            string SqlQuery = " exec USP_GetCityByDistrict @DistrictID='" + DistrictID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetCityByDistrict");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetNOCApplicationStepList(int ApplyNocID, int CurrentActionID, int DepartmentID, string ActionType)
        {
            string SqlQuery = " exec USP_ShowApplicationStep @ApplyNocID='" + ApplyNocID + "',@CurrentActionID='" + CurrentActionID + "',@DeptID='" + DepartmentID + "',@actionType='" + ActionType + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetNOCApplicationStepList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetDownloadPdfDetails(int DepartmentID, int CollageID)
        {
            string SqlQuery = " exec USP_GetDownloadPDfDetails @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollageID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetDownloadPdfDetails");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                dataModel.data.Rows[0]["MemberSignature2"] = _commonHelper.ConvertTobase64(dataModel.data.Rows[0]["MemberSignature2"].ToString());
            }
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetPaymentMode()
        {
            string SqlQuery = " exec USP_GetPaymentMode";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetPaymentMode");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool SaveExcelData(List<MemberDataModel> request, int StaticsFileID, int DeptId, int collegeID, int courseID, string FinYear, string FileName, string SSOID)
        {

            string SqlQuery = "";
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string ImportStaticsFileDetails_Str = CommonHelper.GetDetailsTableQry(request, "Temp_ImportStaticsFileDetails");
            SqlQuery = " exec USP_ImportExcelStatics_AddUpdate";

            SqlQuery += " @StaticsFileID='" + StaticsFileID + "',";
            SqlQuery += " @CollegeID='" + collegeID + "',";
            SqlQuery += " @DepartmentID='" + DeptId + "',";
            SqlQuery += " @CourseID='" + courseID + "',";
            SqlQuery += " @FinYear='" + FinYear + "',";
            SqlQuery += " @FileName='" + FileName.Replace("C:\\fakepath\\", "") + "',";
            SqlQuery += " @TotalCount='" + request.Count() + "',";
            SqlQuery += " @SSOID='" + SSOID + "',";
            SqlQuery += " @ImportStaticsFileDetails_Str='" + ImportStaticsFileDetails_Str + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "Commomfunction.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetImportExcelData(string SSOID, int DeptId, int collegeID, int StaticsFileID, string ActionType)
        {
            string SqlQuery = " exec USP_ImportExcelStaticsDetails @SSOID='" + SSOID + "',@DepartmentID='" + DeptId + "',@CollegeID='" + collegeID + "',@StaticsFileID='" + StaticsFileID + "',@ActionType='" + @ActionType + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetImportExcelData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool UpdateSingleRow(MemberDataModel request, int DeptId, int collegeID, string SSOID)
        {
           // string IPAddress = CommonHelper.GetVisitorIPAddress();

            var query=new StringBuilder();
            query.Append("exec USP_ImportExcelStatics_UpdateSingleRow ");
            query.AppendFormat("@StaticsFileDetailsID={0},", request.StaticsFileDetailsID);
            query.AppendFormat("@StaticsFileID={0},", request.StaticsFileID);
            query.AppendFormat("@ApplicationID='{0}',", request.ApplicationID);
            query.AppendFormat("@District='{0}',", request.District);
            query.AppendFormat("@CollegeName='{0}',", request.CollegeName);
            query.AppendFormat("@AISHECode='{0}',", request.AISHECode);
            query.AppendFormat("@StudentName='{0}',", request.StudentName);
            query.AppendFormat("@FatherName='{0}',", request.FatherName);
            query.AppendFormat("@Gender='{0}',", request.Gender);
            query.AppendFormat("@Course='{0}',", request.Course);
            query.AppendFormat("@Subject='{0}',", request.Subject);
            query.AppendFormat("@Class='{0}',", request.Class);
            query.AppendFormat("@Cast='{0}',", request.Cast);
            query.AppendFormat("@PH='{0}',", request.PH);
            query.AppendFormat("@Minorty='{0}',", request.Minorty);
            query.AppendFormat("@HasScholarship='{0}',", request.HasScholarship);
            query.AppendFormat("@ScholarshipName='{0}',", request.ScholarshipName);
            query.AppendFormat("@DOB='{0}',", request.DOB);
            query.AppendFormat("@StudentMobileNo='{0}',", request.StudentMobileNo);
            query.AppendFormat("@StudentEmailId='{0}',", request.StudentEmailId);
            query.AppendFormat("@PrincipalName='{0}',", request.PrincipalName);
            query.AppendFormat("@PrincipalMobileNo='{0}',", request.PrincipalMobileNo);
            query.AppendFormat("@CollegeEmailId='{0}'", request.CollegeEmailId);

            int Rows = _commonHelper.NonQuerry(query.ToString(), "Commomfunction.UpdateSingleRow");
            if (Rows > 0)
                return true;
            else
                return false;
        }


        public List<CommonDataModel_CollegeWiseCourseList> GetOldNOCCourseList_CollegeWise(int CollegID)
        {
            string SqlQuery = $" Exec Get_CollegeWiseOldNOCCourse @CollegeID={CollegID}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetOldNOCCourseList_CollegeWise");

            List<CommonDataModel_CollegeWiseCourseList> dataModels = new List<CommonDataModel_CollegeWiseCourseList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CollegeWiseCourseList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<DataTable> CheckExistsDETGovernmentCollege(string SSOID)
        {
            string SqlQuery = "exec USP_CheckExistsDETGovernmentCollege @SSOID='"+ SSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.CheckExistsDETGovernmentCollege");


            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<DataTable> Get_LOIFeeMaster(int DepartmentID)
        {
            string SqlQuery = " exec USP_LOIFeeMaster @DepartmentID='"+ DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.Get_LOIFeeMaster");
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public CommonDataModel_DataTable GetAppliedNocInformation(string SSOID)
        {
            string SqlQuery = $"exec USP_GetAppliedNocInformation @SSOID='{SSOID}',@action='GetLastAppliedNocInformation'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAppliedNocInformation");
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            return dataModel;
        }

        public CommonDataModel_CollegeID_SearchRecordIDWise GetCollegeID_SearchRecordIDWise(string SearchRecordID)
        {
            string SqlQuery = "select CollegeID from M_CollegeMaster where SearchRecordID='"+ SearchRecordID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetCollegeID_SearchRecordIDWise");

            CommonDataModel_CollegeID_SearchRecordIDWise dataModels = new CommonDataModel_CollegeID_SearchRecordIDWise();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<CommonDataModel_CollegeID_SearchRecordIDWise>(JsonDataTable_Data.Replace("[","").Replace("]", ""));
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetUsersByRoleDepartment(int DepartmentID, int RoleID)
        {
            string SqlQuery = $" Exec USP_GetUsersByRoleDepartment @DepartmentID={DepartmentID}, @RoleID={ RoleID}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetUsersByRoleDepartment");


            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }        
        public List<CommonDataModel_DataTable> GetWorkFlowStatusbyDepartment(int DepartmentID)
        {
            string SqlQuery = $" Exec USP_GetWorkFlowStatusbyDepartment @DepartmentID={DepartmentID}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetWorkFlowStatusbyDepartment");


            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}

