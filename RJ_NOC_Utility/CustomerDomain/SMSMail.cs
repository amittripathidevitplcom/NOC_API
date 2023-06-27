using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Reflection;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class SMSMail : UtilityBase, ISMSMail
    {
        public SMSMail(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public string SendMessage(string MobileNo, string MessageType)
        {
            return UnitOfWork.SMSMailRepository.SendMessage(MobileNo, MessageType);
        }

    }
}
