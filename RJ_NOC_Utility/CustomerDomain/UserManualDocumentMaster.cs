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
    public class UserManualDocumentMaster : UtilityBase, IUserManualDocumentMaster
    {
        
        public UserManualDocumentMaster(IRepositories unitOfWork) : base(unitOfWork)
    {

    }

        public List<UserManualDocumentMasterDataModel_List> GetUserManualDocumentMasterList(int DepartmentID)
        {
            return UnitOfWork.UserManualDocumentMasterRepository.GetUserManualDocumentMasterList(DepartmentID);
        }

        public List<UserManualDocumentMasterDataModel> GetUserManualDocumentMasterIDWise(int ID)
        {
            return UnitOfWork.UserManualDocumentMasterRepository.GetUserManualDocumentMasterIDWise(ID);
        }

        public bool SaveData(UserManualDocumentMasterDataModel request)
        {
            return UnitOfWork.UserManualDocumentMasterRepository.SaveData(request);
        }

        public bool DeleteData(int ID)
        {
            return UnitOfWork.UserManualDocumentMasterRepository.DeleteData(ID);
        }

        //public bool IfExists(int ID, string TitleEnglish)
        //{
        //    return UnitOfWork.UserManualDocumentMasterRepository.IfExists(ID, TitleEnglish);
        //}


    }
}
