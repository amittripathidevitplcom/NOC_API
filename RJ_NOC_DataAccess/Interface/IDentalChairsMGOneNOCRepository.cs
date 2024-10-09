using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IDentalChairsMGOneNOCRepository
    {
        public bool SaveDentalChairs(DentalChairsMGOneNOCModel request);
        public List<CommonDataModel_DataTable> GetDentalChairsById(int applyNocId, int collegeId);
    }
}
