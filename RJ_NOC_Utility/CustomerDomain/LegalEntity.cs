using RJ_NOC_Utility;
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
    public class LegalEntity : UtilityBase, ILegalEntity
    {
        public LegalEntity(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<CommonDataModel_DataTable> GetAllLegalEntity()
        {
            throw new NotImplementedException();
        }

        public bool SaveData(LegalEntityModel request)
        {
            return UnitOfWork.LegalEntityRepoSitory.SaveData(request);
        }
    }
}
