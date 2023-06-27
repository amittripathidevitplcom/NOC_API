using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class LandDetails : UtilityBase, ILandDetails
    {
        public LandDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetLandDetailsList(int SelectedCollageID, int LandDetailID)
        {
            return UnitOfWork.LandDetailsRepository.GetLandDetailsList(SelectedCollageID, LandDetailID);
        }
        public List<LandDetailsDataModel> GetLandDetailsIDWise(int LandDetailID)
        {
            return UnitOfWork.LandDetailsRepository.GetLandDetailsIDWise(LandDetailID);
        }
        public bool SaveData(LandDetailsDataModel request)
        {
            return UnitOfWork.LandDetailsRepository.SaveData(request);
        }

        public bool DeleteData(int LandDetailID)
        {
            return UnitOfWork.LandDetailsRepository.DeleteData(LandDetailID);
        }

        public bool IfExists(int LandDetailID, int LandAreaID, int CollegeID)
        {
            return UnitOfWork.LandDetailsRepository.IfExists(LandDetailID, LandAreaID, CollegeID);
        }

    }
}

