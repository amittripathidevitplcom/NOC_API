using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;
using Azure.Core;
using Azure;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;
using System.Configuration;
using SSOService;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class FireQuery : UtilityBase, IFireQuery
    {
        public FireQuery(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<DataSet> DataFill(FireQueryDataModel fireQueryDataModel)
        {
            return UnitOfWork.FireQueryRepository.DataFill(fireQueryDataModel);
        }
        public bool DataExecuteNonQuery(FireQueryDataModel fireQueryDataModel)
        {
            return UnitOfWork.FireQueryRepository.DataExecuteNonQuery(fireQueryDataModel);
        }
    }

}
