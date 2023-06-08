using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICollegeMasterRepository
    {
        bool SaveData(CollegeMasterDataModel request);
        List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID);
    }
}