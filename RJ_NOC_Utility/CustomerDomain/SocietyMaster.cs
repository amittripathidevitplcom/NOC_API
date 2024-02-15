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
    public class SocietyMaster : UtilityBase, ISocietyMaster
    {
        public SocietyMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<SocietyMasterDataModels> GetSocietyAllList(int CollegeID, int ApplyNOCID)
        {
            return UnitOfWork.SocietyMasterRepository.GetSocietyAllList(CollegeID, ApplyNOCID);
        }
        public List<SocietyMasterDataModel> GetSocietyByID(int SocietyID)
        {
            return UnitOfWork.SocietyMasterRepository.GetSocietyByID(SocietyID);
        }
        public bool SaveData(SocietyMasterDataModel request)
        {
            return UnitOfWork.SocietyMasterRepository.SaveData(request);
        }
        public bool UpdateData(SocietyMasterDataModel request)
        {
            return UnitOfWork.SocietyMasterRepository.UpdateData(request);
        }
        public bool DeleteData(int SocietyID)
        {
            return UnitOfWork.SocietyMasterRepository.DeleteData(SocietyID);
        }

        public bool IfExists(int SocietyID, string PersonName)
        {
            return UnitOfWork.SocietyMasterRepository.IfExists(SocietyID, PersonName);
        }

        public List<CommonDataModel_DataTable> Check30Female(int CollegeID)
        {
            return UnitOfWork.SocietyMasterRepository.Check30Female(CollegeID);
        }
    }
}
