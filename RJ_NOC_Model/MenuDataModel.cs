using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class MenuDataModel
    {
        public int AccountGroupId { get; set; }
        public int UnderGroupId { get; set; }
        public string GroupName { get; set; }
        public string ShortName { get; set; }
        public int ModifyBy { get; set; }

    }
    public class MenuDataModel_List
    {
        public DataTable data { get; set; }
    }
}
