using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class RNCCheckListMaster : UtilityBase, IRNCCheckListMaster
    {
        public RNCCheckListMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }       
        public List<CommonDataModel_DataTable> GetRNCCheckListData()
        {
            return UnitOfWork.RNCCheckListMasterRepository.GetRNCCheckListData();
        }
        public List<RNCCheckListMasterDataModel> GetByID(int RNCCheckListID)
        {
            return UnitOfWork.RNCCheckListMasterRepository.GetByID(RNCCheckListID);
        }
        public bool SaveData(RNCCheckListMasterDataModel request)
        {
            return UnitOfWork.RNCCheckListMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int RNCCheckListID)
        {
            return UnitOfWork.RNCCheckListMasterRepository.DeleteData(RNCCheckListID);
        }
        
        public bool IfExists(int RNCCheckListID, int DepartmentID, string Name)
        {
            return UnitOfWork.RNCCheckListMasterRepository.IfExists(RNCCheckListID, DepartmentID, Name);
        }

       
    }
}
