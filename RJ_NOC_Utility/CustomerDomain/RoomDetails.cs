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
        public List<RoomDetailsDataModels> GetRoomDetailAllList(int CollegeID, int ApplyNOCID)
        {
            return UnitOfWork.RoomDetailsRepository.GetRoomDetailAllList(CollegeID, ApplyNOCID);
        }
        public List<RoomDetailsDataModel> GetRoomDetailsByID(int CollegeWiseRoomID, int CollegeID)
        {
            return UnitOfWork.RoomDetailsRepository.GetRoomDetailsByID(CollegeWiseRoomID, CollegeID);
        }
        public bool SaveData(RoomDetailsDataModel request)
        {
            return UnitOfWork.RoomDetailsRepository.SaveData(request);
        }

        public bool DeleteData(int CollegeWiseRoomID)
        {
            return UnitOfWork.RoomDetailsRepository.DeleteData(CollegeWiseRoomID);
        }

        public bool IfExists(int DepartmentID, int CollegeID, int CourseID,int CollegeWiseRoomID, int NoOfRooms)
        {
            return UnitOfWork.RoomDetailsRepository.IfExists(DepartmentID, CollegeID, CourseID, CollegeWiseRoomID, NoOfRooms);
        }
    }
}
