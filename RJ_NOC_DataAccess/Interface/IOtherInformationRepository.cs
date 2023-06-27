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
        List<OtherInformationDataModels> GetOtherInformationAllList(int CollegeID);
        List<OtherInformationDataModel> GetOtherInformationByID(int CollegeWiseOtherInfoID, int CollegeID);
        bool SaveData(OtherInformationDataModel request);
        bool DeleteData(int CollegeWiseOtherInfoID);
    }
}
