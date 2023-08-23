using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace RJ_NOC_Model
{
    public class FireQueryDataModel
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string SqlQuery { get; set; } 
    } 
}

 