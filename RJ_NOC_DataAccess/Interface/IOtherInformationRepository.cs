using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IOtherInformationRepository
    {
        List<OtherInformationDataModels> GetOtherInformationAllList();
        List<OtherInformationDataModel> GetOtherInformationByID(int CollegeWiseOtherInfoID);
        bool SaveData(OtherInformationDataModel request);
        bool DeleteData(int CollegeWiseOtherInfoID);
    }
}
