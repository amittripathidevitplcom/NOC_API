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
        public List<CommonDataModel_AssembelyAreaDDL> GetAssembelyAreaByDistrictId(int districtId)
        {
            string SqlQuery = $"exec USP_AssembelyAreaMaster @Action='GetAssembelyAreaByDistrictId', @DistrictID={districtId}";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetAssembelyAreaByDistrictId");

            List<CommonDataModel_AssembelyAreaDDL> dataModels = new List<CommonDataModel_AssembelyAreaDDL>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_AssembelyAreaDDL>>(JsonDataTable_Data);
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
    }
}
