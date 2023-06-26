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
        public List<OtherInformationDataModels> GetOtherInformationAllList()
        {
            return UnitOfWork.OtherInformationRepository.GetOtherInformationAllList();
        }
        public List<OtherInformationDataModel> GetOtherInformationByID(int CollegeWiseOtherInfoID)
        {
            return UnitOfWork.OtherInformationRepository.GetOtherInformationByID(CollegeWiseOtherInfoID);
        }
        public bool SaveData(OtherInformationDataModel request)
        {
            return UnitOfWork.OtherInformationRepository.SaveData(request);
        }

        public bool DeleteData(int CollegeWiseOtherInfoID)
        {
            return UnitOfWork.OtherInformationRepository.DeleteData(CollegeWiseOtherInfoID);
        }
    }
}
