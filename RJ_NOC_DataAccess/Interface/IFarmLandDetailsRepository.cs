using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IFarmLandDetailsRepository
    {
        List<CommonDataModel_DataTable> GetAllFarmLandDetails();
        bool IfExists(int FarmLandDetailsID);
        bool SaveData(FarmLandDetailsModel request);
        List<FarmLandDetailsListModel> GetFarmLandDetailsList(int collegeId,int ApplyNOCID);
        FarmLandDetailsModel ViewFarmLandDetailsListByID(int FarmLandDetailsID);
        bool DeleteData(int FarmLandDetailsID);
    }
}

