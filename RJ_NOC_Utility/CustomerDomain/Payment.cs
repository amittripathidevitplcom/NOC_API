using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using System.Reflection;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class Payment : UtilityBase, IPayment
    {
        public Payment(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL, string ApplyNocApplicationID,PaymentGatewayDataModel Model)
        {
            return UnitOfWork.PaymentRepository.SendRequest(PRN,AMOUNT,PURPOSE,USERNAME,USERMOBILE,USEREMAIL, ApplyNocApplicationID,Model);
        }
        public PaymentResponse GetResponse(string STATUS, string ENCDATA, PaymentGatewayDataModel Model)
        {
            return UnitOfWork.PaymentRepository.GetResponse(STATUS, ENCDATA, Model);
        }

        public bool SaveData(PaymentResponse response)
        {
            return UnitOfWork.PaymentRepository.SaveData(response);
        }

        public List<ResponseParameters> GetPaymentListIDWise(string TransactionID)
        {
            return UnitOfWork.PaymentRepository.GetPaymentListIDWise(TransactionID);
        }

        public PaymentGatewayDataModel GetpaymentGatewayDetails(PaymentGatewayDataModel model)
        {
            return UnitOfWork.PaymentRepository.GetpaymentGatewayDetails(model);
        }


    }
}
