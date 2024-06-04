using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DuplicateAadharReport : UtilityBase, IDuplicateAadharReport
    {
        public DuplicateAadharReport(IRepositories unitOfWork) : base(unitOfWork)
        {

        } 
        public List<CommonDataModel_DataTable> GetDuplicateAadhaarReportDatail(DuplicateAadharReportDataModel request)
        {
            return UnitOfWork.DuplicateAadharReportRepository.GetDuplicateAadhaarReportDatail(request);
        }
       
    }
}
