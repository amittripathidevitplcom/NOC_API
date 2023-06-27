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
    public class FacilityDetails : UtilityBase, IFacilityDetails
    {
        public FacilityDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<FacilityDetailsDataModels> GetFacilityDetailAllList()
        {
            return UnitOfWork.FacilityDetailsRepository.GetFacilityDetailAllList();
        }
        public List<FacilityDetailsDataModel> GetfacilityDetailsByID(int FacilityDetailID)
        {
            return UnitOfWork.FacilityDetailsRepository.GetfacilityDetailsByID(FacilityDetailID);
        }
        public bool SaveData(FacilityDetailsDataModel request)
        {
            return UnitOfWork.FacilityDetailsRepository.SaveData(request);
        }

        public bool DeleteData(int FacilityDetailID)
        {
            return UnitOfWork.FacilityDetailsRepository.DeleteData(FacilityDetailID);
        }
    }
}
