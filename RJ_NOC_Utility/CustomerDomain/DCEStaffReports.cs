using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DCEStaffReports : UtilityBase, IDCEStaffReports
    {
        private CommonDataAccessHelper _commonHelper;

        public DCEStaffReports(IRepositories unitOfWork) : base(unitOfWork)
        {

        }
        public List<DCEStaffReportsDataModel_list> DCEStaffDetailsList(DCEStaffReportsDataModel request)
        {
            return UnitOfWork.DCEStaffReportsRepository.DCEStaffDetailsList(request);
        }

        public List<DCEStaffReports_SubjectList> GetSubjectList()
        {
            return UnitOfWork.DCEStaffReportsRepository.GetSubjectList();
        }

        public List<DCEStaffReports_SubjectList> GetStaffDuplicateAdharList()
        {
            return UnitOfWork.DCEStaffReportsRepository.GetStaffDuplicateAdharList();
        }

    }
}
