using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICreateUser
    {

        List<CommonDataModel_DataTable> GetUserList(int DepartmentID);
        List<CreateUserDataModel> GetUserByIDWise(int UId);
        bool SaveData(CreateUserDataModel request);
        bool DeleteData(int UId);

        bool IfExists(int UId, string SSOID,int DepartmentID, int RoleID);
    }
}

