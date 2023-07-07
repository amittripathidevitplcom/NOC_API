using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class GeoTagging : UtilityBase, IGeoTagging
    {
        public GeoTagging(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        List<CommonDataModel_DataTable> IGeoTagging.AppCollegeSSOLogin(string LoginSSOID)
        {
            return UnitOfWork.GeoTaggingRepository.AppCollegeSSOLogin(LoginSSOID);
        }
        List<CommonDataModel_DataTable> IGeoTagging.GetAPPApplicationCollegeList(string LoginSSOID, string Type)
        {
            return UnitOfWork.GeoTaggingRepository.GetAPPApplicationCollegeList(LoginSSOID, Type);
        }
        List<CommonDataModel_DataTable> IGeoTagging.GetAPPApplicationCollege_DashboardCount(string LoginSSOID)
        {
            return UnitOfWork.GeoTaggingRepository.GetAPPApplicationCollege_DashboardCount(LoginSSOID);
        }
        public bool SaveData(GeoTaggingDataModel request)
        {
            return UnitOfWork.GeoTaggingRepository.SaveData(request);
        }
    }
}
