using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ISMSMail
    {
       string SendMessage(string MobileNo,string MessageType,int ID);
        string SendMessage_Local();

    }
}