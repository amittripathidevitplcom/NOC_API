using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class UserMasterDataModel
    {
        public int UserID { get; set; }
        public string LoginID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}