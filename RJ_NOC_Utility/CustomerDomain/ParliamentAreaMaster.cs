using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ParliamentAreaMaster : UtilityBase, IParliamentAreaMaster
    {
        public ParliamentAreaMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetParliamentAreaList()
        {
            return UnitOfWork.ParliamentAreaMasterRepository.GetParliamentAreaList();
        }
        public List<ParliamentAreaMasterDataModel> GetParliamentAreaIDWise(int ParliamentAreaID)
        {
            return UnitOfWork.ParliamentAreaMasterRepository.GetParliamentAreaIDWise(ParliamentAreaID);
        }
        public bool SaveData(ParliamentAreaMasterDataModel request)
        {
            return UnitOfWork.ParliamentAreaMasterRepository.SaveData(request);
        }
        
        public bool DeleteData(int ParliamentAreaID)
        {
            return UnitOfWork.ParliamentAreaMasterRepository.DeleteData(ParliamentAreaID);
        }

        public bool IfExists(int ParliamentAreaID, int DistrictID, string ParliamentAreaName)
        {
            return UnitOfWork.ParliamentAreaMasterRepository.IfExists( ParliamentAreaID,DistrictID, ParliamentAreaName);
        }

    }
}
