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
    public class AssemblyAreaMaster : UtilityBase, IAssemblyAreaMaster
    {
        public AssemblyAreaMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAssemblyAreaList()
        {
            return UnitOfWork.AssemblyAreaMasterRepository.GetAssemblyAreaList();
        }
        public List<AssemblyAreaMasterDataModel> GetAssemblyAreaIDWise(int AssemblyAreaID)
        {
            return UnitOfWork.AssemblyAreaMasterRepository.GetAssemblyAreaIDWise(AssemblyAreaID);
        }
        public bool SaveData(AssemblyAreaMasterDataModel request)
        {
            return UnitOfWork.AssemblyAreaMasterRepository.SaveData(request);
        }

        public bool DeleteData(int AssemblyAreaID)
        {
            return UnitOfWork.AssemblyAreaMasterRepository.DeleteData(AssemblyAreaID);
        }

        public bool IfExists(int AssemblyAreaID, int DistrictID, string AssemblyAreaName)
        {
            return UnitOfWork.AssemblyAreaMasterRepository.IfExists(AssemblyAreaID,DistrictID, AssemblyAreaName);
        }

    }
}
