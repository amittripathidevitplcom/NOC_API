using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICreateUserRepository
    {
        List<CommonDataModel_DataTable> GetUserList(int DepartmentID);
        List<CreateUserDataModel> GetUserByIDWise(int UId);
        bool SaveData(CreateUserDataModel request);
        bool DeleteData(int UId);
        bool IfExists(int UId, string SSOID,int DepartmentID, int RoleID);
    }

}