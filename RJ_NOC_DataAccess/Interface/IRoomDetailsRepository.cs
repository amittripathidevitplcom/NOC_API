using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IRoomDetailsRepository
    {
        List<RoomDetailsDataModels> GetRoomDetailAllList(int CollageID);
        List<RoomDetailsDataModel> GetRoomDetailsByID(int CollegeWiseRoomID);
        bool SaveData(RoomDetailsDataModel request);
        bool DeleteData(int CollegeWiseRoomID);
    }
}
