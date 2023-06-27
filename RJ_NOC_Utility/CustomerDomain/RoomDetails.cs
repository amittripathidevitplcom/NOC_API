using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class RoomDetails : UtilityBase, IRoomDetails
    {
        public RoomDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<RoomDetailsDataModels> GetRoomDetailAllList(int CollageID)
        {
            return UnitOfWork.RoomDetailsRepository.GetRoomDetailAllList(CollageID);
        }
        public List<RoomDetailsDataModel> GetRoomDetailsByID(int CollegeWiseRoomID)
        {
            return UnitOfWork.RoomDetailsRepository.GetRoomDetailsByID(CollegeWiseRoomID);
        }
        public bool SaveData(RoomDetailsDataModel request)
        {
            return UnitOfWork.RoomDetailsRepository.SaveData(request);
        }

        public bool DeleteData(int CollegeWiseRoomID)
        {
            return UnitOfWork.RoomDetailsRepository.DeleteData(CollegeWiseRoomID);
        }
    }
}
