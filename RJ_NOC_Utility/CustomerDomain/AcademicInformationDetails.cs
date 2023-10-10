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
    public class AcademicInformationDetails : UtilityBase, IAcademicInformationDetails
    {
        public AcademicInformationDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<AcademicInformationDetailsDataModels> GetAcademicInformationDetailAllList(int CollegeID, int ApplyNOCID)
        {
            return UnitOfWork.AcademicInformationDetailsRepository.GetAcademicInformationDetailAllList(CollegeID, ApplyNOCID);
        }
        public List<AcademicInformationDetailsDataModel> GetAcademicInformationDetailByID(int AcademicInformationID, int CollegeID)
        {
            return UnitOfWork.AcademicInformationDetailsRepository.GetAcademicInformationDetailByID(AcademicInformationID, CollegeID);
        }
        public bool SaveData(AcademicInformationDetailsDataModel request)
        {
            return UnitOfWork.AcademicInformationDetailsRepository.SaveData(request);
        }

        public bool DeleteData(int AcademicInformationID)
        {
            return UnitOfWork.AcademicInformationDetailsRepository.DeleteData(AcademicInformationID);
        }
    }
}
