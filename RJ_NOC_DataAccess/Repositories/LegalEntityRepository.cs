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
            string SqlQuery = " exec USP_ProjectMaster_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool SaveData(LegalEntityModel request)
        {
            throw new NotImplementedException();
        }
    }
}
