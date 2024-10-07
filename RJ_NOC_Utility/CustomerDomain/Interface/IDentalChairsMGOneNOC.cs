using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDentalChairsMGOneNOC
    {
        public bool SaveDentalChairs(DentalChairsMGOneNOCModel request);
        public List<CommonDataModel_DataTable> GetDentalChairsById(int applyNocId, int collegeId);
    }
}
