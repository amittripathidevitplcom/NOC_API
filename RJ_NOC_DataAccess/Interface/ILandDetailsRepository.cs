using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ILandDetailsRepository
    {
        List<CommonDataModel_DataTable> GetLandDetailsList(int SelectedCollageID,int  LandDetailID);
        List<LandDetailsDataModel> GetLandDetailsIDWise(int LandDetailID);
        bool SaveData(LandDetailsDataModel request);
        bool DeleteData(int LandDetailID);
        bool IfExists(int LandDetailID, int LandAreaID, int CollegeID);
    }

}