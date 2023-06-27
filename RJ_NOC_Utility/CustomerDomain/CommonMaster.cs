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
    public class CommonMaster : UtilityBase, ICommonMaster
    {
        public CommonMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetCommonMasterList()
        {
            return UnitOfWork.CommonMasterRepository.GetCommonMasterList();
        }
        public List<CommonMasterDataModel> GetCommonMasterIDWise(int ID)
        {
            return UnitOfWork.CommonMasterRepository.GetCommonMasterIDWise(ID);
        }
        public bool SaveData(CommonMasterDataModel request)
        {
            return UnitOfWork.CommonMasterRepository.SaveData(request);
        }

        public bool DeleteData(int ID)
        {
            return UnitOfWork.CommonMasterRepository.DeleteData(ID);
        }

        public bool IfExists(int ID, int DistrictID,string Type, string Name)
        {
            return UnitOfWork.CommonMasterRepository.IfExists(ID,DistrictID, Type, Name);
        }

    }
}

