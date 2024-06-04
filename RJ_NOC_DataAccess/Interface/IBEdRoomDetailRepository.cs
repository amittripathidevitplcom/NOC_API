using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IBEdRoomDetailRepository
    {

        List<BEdRoomDetailDetailsDataModel> GetBEdRoomDetailList(int DepartmentID, int CollegeID);
        bool SaveData(BEdRoomDetailDataModel request);
        bool Delete(int BEdRoomDetailID);
    }

}

