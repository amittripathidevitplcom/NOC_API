using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class RoomDetailsDataModels
    {
        public DataTable data { get; set; }
    }
    public class RoomDetailsDataModel
    {
        public int CollegeWiseRoomID { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public int StudentCapacity { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFilePath { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int UserID { get; set; }
    }
}
