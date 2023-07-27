using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class LandAreaSituatedMaster : UtilityBase, ILandAreaSituatedMaster
    {
        public LandAreaSituatedMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<LandAreaSituated_DistrictList> GetDistrictList()
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.GetDistrictList();
        }
        public List<LandAreaSituatedModel_StateList> GetStateList()
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.GetStateList();
        }
        public List<LandAreaSituatedMasterDataModel_list> GetAllLandAreaSituatedList(int DepartmentID)
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.GetAllLandAreaSituatedList(DepartmentID);
        }
        public List<LandAreaSituatedMasterDataModel> GetLandAreaSituatedIDWise(int LandAreaID)
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.GetLandAreaSituatedIDWise(LandAreaID);
        }
        public bool SaveData(LandAreaSituatedMasterDataModel request)
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int LandAreaID)
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.DeleteData(LandAreaID);
        }
        
        public bool IfExists(int LandAreaID, string LandAreaName)
        {
            return UnitOfWork.LandAreaSituatedMasterRepository.IfExists(LandAreaID, LandAreaName);
        }

       
    }
}
