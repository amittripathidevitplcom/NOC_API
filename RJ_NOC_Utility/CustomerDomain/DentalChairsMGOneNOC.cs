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
    public class DentalChairsMGOneNOC : UtilityBase, IDentalChairsMGOneNOC
    {
        public DentalChairsMGOneNOC(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public bool SaveDentalChairs(DentalChairsMGOneNOCModel request)
        {
            return UnitOfWork.DentalChairsMGOneNOCRepository.SaveDentalChairs(request);
        }
        public List<CommonDataModel_DataTable> GetDentalChairsById(int applyNocId, int collegeId)
        {
            return UnitOfWork.DentalChairsMGOneNOCRepository.GetDentalChairsById(applyNocId,collegeId);
        }
    }
}
