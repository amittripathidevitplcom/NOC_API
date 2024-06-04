using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class BEdRoomDetailDataModel
    {
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public int BEdRoomDetailID { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public string IPAddress { get; set; }
        public int UserID { get; set; }
        public int NoOfClasses { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
    public class BEdRoomDetailDetailsDataModel
    {
        public DataTable data { get; set; }
    }

}