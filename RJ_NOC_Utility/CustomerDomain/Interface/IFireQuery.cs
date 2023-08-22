using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IFireQuery
    {
        List<DataSet> DataFill(FireQueryDataModel fireQueryDataModel);
        bool DataExecuteNonQuery(FireQueryDataModel fireQueryDataModel);
    }
}