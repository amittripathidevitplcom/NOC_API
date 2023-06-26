using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IOtherInformation
    {
        List<OtherInformationDataModels> GetOtherInformationAllList();
        List<OtherInformationDataModel> GetOtherInformationByID(int CollegeWiseOtherInfoID);
        bool SaveData(OtherInformationDataModel request);
        bool DeleteData(int CollegeWiseOtherInfoID);
    }
}
