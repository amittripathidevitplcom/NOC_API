using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using static RJ_NOC_Model.BuildingDetailsDataModel;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class BuildingDetailsMaster : UtilityBase, IBuildingDetailsMaster
    {
        public BuildingDetailsMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<BuildingDetailsDataModelList> GetAllBuildingDetailsList(int CollegeID, int ApplyNOCID)
        {
            return UnitOfWork.BuildingDetailsMasterRepository.GetAllBuildingDetailsList(CollegeID, ApplyNOCID);
        }
        public List<BuildingDetailsDataModelList> GetBuildingDetailsIDWise(int SchoolBuildingDetailsID)
        {
            return UnitOfWork.BuildingDetailsMasterRepository.GetBuildingDetailsIDWise(SchoolBuildingDetailsID);
        }
        public bool SaveData(BuildingDetailsDataModel request)
        {
            return UnitOfWork.BuildingDetailsMasterRepository.SaveData(request);
        }
        public bool DeleteData(int SchoolBuildingDetailsID)
        {
            return UnitOfWork.BuildingDetailsMasterRepository.DeleteData(SchoolBuildingDetailsID);
        }
        public bool StatusUpdate(int SchoolBuildingDetailsID, bool ActiveStatus)
        {
            return UnitOfWork.BuildingDetailsMasterRepository.StatusUpdate(SchoolBuildingDetailsID, ActiveStatus);
        }
        public bool IfExists(int SchoolBuildingDetailsID, string OwnerName)
        {
            return UnitOfWork.BuildingDetailsMasterRepository.IfExists(SchoolBuildingDetailsID, OwnerName);
        }

       
    }
}
