using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface ISSOAPIRepository
    {
        List<CommonDataModel_DataTable> Check_SSOIDWise_LegalEntity(string SSOID);
        List<CommonDataModel_DataTable> GetUserRoleList(string SSOID, bool IsWeb);
    }

}

