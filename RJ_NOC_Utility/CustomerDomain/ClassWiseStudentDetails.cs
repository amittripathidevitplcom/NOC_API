using Azure.Core;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ClassWiseStudentDetails : UtilityBase, IClassWiseStudentDetails
    {
        public ClassWiseStudentDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<ClassWiseStudentDetailsDataModel> GetCollegeWiseStudenetDetails(int CollegeID)
        {
            return UnitOfWork.ClassWiseStudentDetailsRepository.GetCollegeWiseStudenetDetails(CollegeID);
        }

        public List<SubjectWiseStatisticsDetailsDataModel> GetSubjectWiseStudenetDetails(int CollegeID)
        {
            return UnitOfWork.ClassWiseStudentDetailsRepository.GetSubjectWiseStudenetDetails(CollegeID);
        }

        public bool SaveData(PostClassWiseStudentDetailsDataModel request)
        {
            return UnitOfWork.ClassWiseStudentDetailsRepository.SaveData(request);
        }

        public bool SaveDataSubjectWise(PostSubjectWiseStatisticsDetailsDataModel model)
        {
            return UnitOfWork.ClassWiseStudentDetailsRepository.SaveDataSubjectWise(model);
        }
    }
}
