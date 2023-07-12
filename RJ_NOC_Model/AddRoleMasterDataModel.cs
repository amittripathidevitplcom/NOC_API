using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class AddRoleMasterDataModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }

    public class UserRoleRightsDataModel
    {
        public int MenuID { get; set; }
        public string? MenuName { get; set; }
        public int RoleID { get; set; }
        public int? LevelNo { get; set; }
        public int? ParentId { get; set; }
        public string U_View { get; set; }
        public string U_Add { get; set; }
        public string U_Update { get; set; }
        public string U_Delete { get; set; }
        public string U_Print { get; set; }


        public bool NG_U_View { get; set; }
        public bool NG_U_Add { get; set; }
        public bool NG_U_Update { get; set; }
        public bool NG_U_Delete { get; set; }
        public bool NG_U_Print { get; set; }


    }

}
