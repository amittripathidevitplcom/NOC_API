using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IPayment
    {
        PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL,string ApplyNocApplicationID);
        PaymentResponse GetResponse(string STATUS, string ENCDATA);
        bool SaveData(PaymentResponse request);
        List<ResponseParameters> GetPaymentListIDWise(int TransactionID);


    }
}
