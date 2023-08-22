using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class FireQueryRepository : IFireQueryRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public FireQueryRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool DataExecuteNonQuery(FireQueryDataModel fireQueryDataModel)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            int Rows = _commonHelper.NonQuerry(fireQueryDataModel.SqlQuery, "FireQueryRepository.DataExecuteNonQuery");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<DataSet> DataFill(FireQueryDataModel fireQueryDataModel)
        {
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(fireQueryDataModel.SqlQuery, "FireQuery.DataFill");
            List<DataSet> dataModels = new List<DataSet>();
            DataSet dataModel = new DataSet();
            dataModel = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }

    }
}
