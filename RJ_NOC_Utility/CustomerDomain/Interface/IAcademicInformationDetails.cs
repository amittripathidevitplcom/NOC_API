using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAcademicInformationDetails
    {
        List<AcademicInformationDetailsDataModels> GetAcademicInformationDetailAllList(int CollegeID);
        List<AcademicInformationDetailsDataModel> GetAcademicInformationDetailByID(int AcademicInformationID, int CollegeID);
        bool SaveData(AcademicInformationDetailsDataModel request);
        bool DeleteData(int AcademicInformationID);
    }
}
