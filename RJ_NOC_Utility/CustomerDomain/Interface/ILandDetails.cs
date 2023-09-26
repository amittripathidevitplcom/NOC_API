using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ILandDetails
    {
        List<CommonDataModel_DataSet> GetLandDetailsListForPDF(int SelectedCollageID);
        List<CommonDataModel_DataSet> GetLandDetailsList(int SelectedCollageID,int LandDetailID);
        List<LandDetailsDataModel> GetLandDetailsIDWise(int LandDetailID, int CollageID);
        bool SaveData(LandDetailsDataModel request);
        bool DeleteData(int LandDetailID);

        bool IfExists(int LandDetailID, int LandAreaID, int CollegeID);
    }
}

