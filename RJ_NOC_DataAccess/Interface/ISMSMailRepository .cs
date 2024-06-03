using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ISMSMailRepository
    {
        string SendMessage(string MobileNo,string MessageType, int ID);
        DataSet GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID);
    }

}

