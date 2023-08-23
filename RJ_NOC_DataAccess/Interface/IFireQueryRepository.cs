using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IFireQueryRepository
    {
        List<DataSet> DataFill(FireQueryDataModel fireQueryDataModel);
        bool DataExecuteNonQuery(FireQueryDataModel fireQueryDataModel);
    }

}

