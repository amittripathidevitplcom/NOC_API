using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using static RJ_NOC_Model.BuildingDetailsDataModel;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IBuildingDetailsMasterRepository
    {
        List<BuildingDetailsDataModelList> GetAllBuildingDetailsList(int CollegeID);
        List<BuildingDetailsDataModelList> GetBuildingDetailsIDWise(int SchoolBuildingDetailsID);
        bool SaveData(BuildingDetailsDataModel request);
        bool DeleteData(int SchoolBuildingDetailsID);
        bool StatusUpdate(int SchoolBuildingDetailsID, bool ActiveStatus);
        bool IfExists(int SchoolBuildingDetailsID, string OwnerName);
      

    }

}

