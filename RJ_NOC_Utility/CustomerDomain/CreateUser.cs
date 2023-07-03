using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;
using System.Security.Cryptography;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class CreateUser : UtilityBase, ICreateUser
    {
        public CreateUser(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetUserList()
        {
            return UnitOfWork.CreateUserRepository.GetUserList();
        }
        public List<CreateUserDataModel> GetUserByIDWise(int UId)
        {
            return UnitOfWork.CreateUserRepository.GetUserByIDWise(UId);
        }
        public bool SaveData(CreateUserDataModel request)
        {
            return UnitOfWork.CreateUserRepository.SaveData(request);
        }

        public bool DeleteData(int UId)
        {
            return UnitOfWork.CreateUserRepository.DeleteData(UId);
        }

        public bool IfExists(int UId, string SSOID, string Name)
        {
            return UnitOfWork.CreateUserRepository.IfExists(UId, SSOID, Name);
        }

    }
}

