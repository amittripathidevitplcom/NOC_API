using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using static RJ_NOC_Model.BuildingDetailsDataModel;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IBuildingDetailsMaster
    {
        List<BuildingDetailsDataModelList> GetAllBuildingDetailsList(int CollegeID, int ApplyNOCID);
        List<BuildingDetailsDataModelList> GetBuildingDetailsIDWise(int SchoolBuildingDetailsID);
        bool SaveData(BuildingDetailsDataModel buildingdetails);
        bool DeleteData(int SchoolBuildingDetailsID);
        bool StatusUpdate(int SchoolBuildingDetailsID, bool ActiveStatus);
        bool IfExists(int SchoolBuildingDetailsID, string OwnerName);


    }
}