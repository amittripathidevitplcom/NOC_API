using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class LegalEntityRepository : ILegalEntityRepoSitory
    {
        private CommonDataAccessHelper _commonHelper;
        public LegalEntityRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<CommonDataModel_DataTable> GetAllProject()
        {
            string SqlQuery = " exec USP_LegalEntity_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LegalEntity.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool SaveData(LegalEntityModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_LegalEntity_IU  ";
            //SqlQuery += " @EmpanelmentType='" + request.EmpanelmentType + "',@ProjectID='" + request.ProjectID + "',@ProjectName='" + request.ProjectName + "',@DepartmentName='" + request.DepartmentName + "',@NumberofResources='" + request.NumberofResources + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = 1;//_commonHelper.NonQuerry(SqlQuery, "LegalEntity.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
