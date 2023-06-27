using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class UniversityasterDataModel
    {
       public int DepartmentID { get; set; }
       public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
   public class UniversityasterDataModel_list
    {
        public DataTable data { get; set; }
    }


}
