using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IRoomDetails
    {
        List<RoomDetailsDataModels> GetRoomDetailAllList(int CollageID);
        List<RoomDetailsDataModel> GetRoomDetailsByID(int CollegeWiseRoomID);
        bool SaveData(RoomDetailsDataModel request);
        bool DeleteData(int CollegeWiseRoomID);
    }
}
