using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class OtherInformation : UtilityBase, IOtherInformation
    {
        public OtherInformation(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<OtherInformationDataModels> GetOtherInformationAllList(int CollegeID)
        {
            return UnitOfWork.OtherInformationRepository.GetOtherInformationAllList(CollegeID);
        }
        public List<OtherInformationDataModel> GetOtherInformationByID(int CollegeWiseOtherInfoID, int CollegeID)
        {
            return UnitOfWork.OtherInformationRepository.GetOtherInformationByID(CollegeWiseOtherInfoID, CollegeID);
        }
        public bool SaveData(OtherInformationDataModel request)
        {
            return UnitOfWork.OtherInformationRepository.SaveData(request);
        }

        public bool DeleteData(int CollegeWiseOtherInfoID)
        {
            return UnitOfWork.OtherInformationRepository.DeleteData(CollegeWiseOtherInfoID);
        }
        public List<CollegeLabInformationDataModel> GetCollegeLabInformationList(int CollegeID, string key)
        {
            return UnitOfWork.OtherInformationRepository.GetCollegeLabInformationList(CollegeID, key);
        }
        public bool SaveLabData(PostCollegeLabInformation request)
        {
            return UnitOfWork.OtherInformationRepository.SaveLabData(request);
        }
    }
}
