using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class LOIFeeMaster : UtilityBase, ILOIFeeMaster
    {
        public LOIFeeMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllLOIFeeList()
        {
            return UnitOfWork.LOIFeeMasterRepository.GetAllLOIFeeList();
        }
        public List<LOIFeeMasterDataModel> GetLOIFeeByID(int FeeID)
        {
            return UnitOfWork.LOIFeeMasterRepository.GetLOIFeeByID(FeeID);
        }
        public bool SaveData(LOIFeeMasterDataModel request)
        {
            return UnitOfWork.LOIFeeMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int FeeID)
        {
            return UnitOfWork.LOIFeeMasterRepository.DeleteData(FeeID);
        }
        
        public bool IfExists(int FeeID, int DepartmentID, string FeeType)
        {
            return UnitOfWork.LOIFeeMasterRepository.IfExists(FeeID, DepartmentID, FeeType);
        }

       
    }
}
