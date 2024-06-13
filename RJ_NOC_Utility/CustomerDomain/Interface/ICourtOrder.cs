using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICourtOrder
    {
        public List<CommonDataModel_DataTable> GetCourtOrderData(CourtOrderSearchFilterDataModel request);
        public bool SaveData(CourtOrderModel request);
        public bool DeleteData(int CourtOrderID);
    }
}
