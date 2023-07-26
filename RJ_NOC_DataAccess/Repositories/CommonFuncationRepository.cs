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
        public List<CommonDataModel_UniversityDDL> GetUniversityByDepartmentId(int departmentId)
        {
            string SqlQuery = $"exec USP_UniversityMaster @Action='GetUniversityByDepartmentId', @DepartmentID={departmentId}";
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

        public List<CommonDataModel_CollegeWiseCourseList> GetCourseList_CollegeWise(int CollegID, int CourseType)
        {
            string SqlQuery = $" Exec Get_CollegeWiseCourse @CollegeID={CollegID},@CourseType={CourseType}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLandDoucmentTypeMasterList_DepartmentWise");

            List<CommonDataModel_CollegeWiseCourseList> dataModels = new List<CommonDataModel_CollegeWiseCourseList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_CollegeWiseCourseList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_CourseRoomSize> GetCourseRoomSize(int CourseID)
        {
            string SqlQuery = " exec USP_CourseRoomSize @CourseID='" + CourseID + "'";
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


        public List<CommonDataModel_BuildingType> GetBuildingTypeCheck()
        {
            string SqlQuery = "exec USP_BuildingDetails @ActionType='GetBuildingtype'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetBuildingTypeCheck");

            List<CommonDataModel_BuildingType> dataModels = new List<CommonDataModel_BuildingType>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_BuildingType>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_BuildingUploadDoc> GetBuildingUploadDetails()
        {
            string SqlQuery = "exec USP_BuildingDetails @ActionType='GetBuildingDoctype'";
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
            string SqlQuery = $"exec GetTermAndConditionList_DepartmentWise @DepartmentID={departmentId}";
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


        public List<CommonDataModel_QualificationMasterDepartmentWise> GetQualificationMasterList_DepartmentWise(int DepartmentID)
        {
            string SqlQuery = " Exec USP_QualificationMasterList_DepartmentWise @DepartmentID='" + DepartmentID.ToString() + "'";
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

        public List<CommonDataModel_RoleListByLevel> GetRoleListForApporval(int RoleID)
        {
            string SqlQuery = "exec USP_ActionDataList @RoleID='" + RoleID + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRoleListForApporval");
            List<CommonDataModel_RoleListByLevel> dataModels = new List<CommonDataModel_RoleListByLevel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RoleListByLevel>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CreateUserDataModel> GetUserDetailsByRoleID(int RoleID)
        {
            string SqlQuery = "exec USP_CommonDataList @Key='GetUserDetailsByRoleID',@RoleID='" + RoleID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetUserDetailsByRoleID");
            List<CreateUserDataModel> dataModels = new List<CreateUserDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CreateUserDataModel>>(JsonDataTable_Data);
            return dataModels;
        }


        public List<CommonDataModel_WorkFlowActionsByRole> GetWorkFlowActionListByRole(int RoleID,string Type)
        {
            string SqlQuery = "exec USP_GetWorkFlowActionListByRole @RoleID='" + RoleID + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.USP_GetWorkFlowActionListByRole");
            List<CommonDataModel_WorkFlowActionsByRole> dataModels = new List<CommonDataModel_WorkFlowActionsByRole>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_WorkFlowActionsByRole>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_RNCCheckListData> GetRNCCheckListByTypeDepartment(string Type, int DepartmentID)
        {
            string SqlQuery = "exec USP_GetRNCCheckListByTypeDepartment @Type='"+Type+ "' ,@DepartmentID='" + DepartmentID + "'";
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
        public List<CommonDataModel_CourseMaster> GetCourseList_ByCourseLevelIDWise(int CourseLevelID,int DepartmentID)
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

        public List<CommonDataModel_SubjectMaster> GetSubjectList_StreamIDWise(int StreamID)
        {
            string SqlQuery = "exec USP_GetSubjectList_StreamIDWise @StreamID=" + StreamID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSubjectList_StreamIDWise");

            List<CommonDataModel_SubjectMaster> dataModels = new List<CommonDataModel_SubjectMaster>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SubjectMaster>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}

