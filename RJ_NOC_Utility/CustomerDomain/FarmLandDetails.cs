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
    internal class FarmLandDetails : UtilityBase, IFarmLandDetails
    {
        public FarmLandDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool DeleteData(int FarmLandDetailsID)
        {
            return UnitOfWork.FarmLandDetailsRepository.DeleteData(FarmLandDetailsID);
        }

        public List<CommonDataModel_DataTable> GetAllFarmLandDetails()
        {
            throw new NotImplementedException();
        }

        
        public List<FarmLandDetailsListModel> GetFarmLandDetailsList(int collegeId, int ApplyNOCID)
        {
            return UnitOfWork.FarmLandDetailsRepository.GetFarmLandDetailsList(collegeId, ApplyNOCID);
        }

        public bool IfExists(int FarmLandDetailsID)
        {
            throw new NotImplementedException();
        }

        public bool SaveData(FarmLandDetailsModel request)
        {
            return UnitOfWork.FarmLandDetailsRepository.SaveData(request);
        }

        public FarmLandDetailsModel ViewFarmLandDetailsListByID(int FarmLandDetailsID)
        {
            return UnitOfWork.FarmLandDetailsRepository.ViewFarmLandDetailsListByID(FarmLandDetailsID);
        }
    }
}
