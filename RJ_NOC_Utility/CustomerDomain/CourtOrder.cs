using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class CourtOrder : UtilityBase, ICourtOrder
    {
        public CourtOrder(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetCourtOrderData(CourtOrderSearchFilterDataModel request)
        {
            return UnitOfWork.CourtOrderRepository.GetCourtOrderData(request);
        }
        public bool SaveData(CourtOrderModel request)
        {
            return UnitOfWork.CourtOrderRepository.SaveData(request);
        }
        public bool DeleteData(int CourtOrderID)
        {
            return UnitOfWork.CourtOrderRepository.DeleteData(CourtOrderID);
        }
    }
}
