using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IAcademicInformationDetailsRepository
    {
        List<AcademicInformationDetailsDataModels> GetAcademicInformationDetailAllList(int CollegeID,int ApplyNOCID);
        List<AcademicInformationDetailsDataModel> GetAcademicInformationDetailByID(int AcademicInformationID, int CollegeID);
        bool SaveData(AcademicInformationDetailsDataModel request);
        bool DeleteData(int AcademicInformationID);
    }
}
