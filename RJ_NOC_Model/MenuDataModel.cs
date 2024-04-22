using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

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


    public class MenuModel
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public List<MenuModel> sub { get; set; }

    }
}
