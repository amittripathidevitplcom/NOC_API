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
        PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL,string ApplyNocApplicationID,PaymentGatewayDataModel model);
        PaymentResponse GetResponse(string STATUS, string ENCDATA, PaymentGatewayDataModel model);
        bool SaveData(PaymentResponse request);
        bool CreatePaymentRequest(PaymentRequest request);
        bool UpdateRefundStatus(PaymentResponse request);
        bool UpdateRefundTransactionStatus(RefundTransactionDataModel request);

        List<ResponseParameters> GetPaymentListIDWise(string TransactionID);

        //payment PaymentGatewayDataModel
        PaymentGatewayDataModel GetpaymentGatewayDetails(PaymentGatewayDataModel Model);

        List<ResponseParameters> GetPreviewPaymentDetails(int ApplyNocApplicationID);
        List<CommonDataModel_DataTable> GetRPPTransactionList(TransactionSearchFilterModel Model);

        //Emitra Section
        EmitraRequstParameters GetEmitraServiceDetails(EmitraRequestDetails Model);
        EmitraRequestDetails EmitraSendPaymentRequest(EmitraRequestDetails Model);
        EmitraTransactions CreateAddEmitraTransation(EmitraTransactions request);
        bool UpdateEmitraPaymentStatus(EmitraResponseParameters request);
        List<CommonDataModel_DataTable> GetEmitraTransactionDetails(string TransactionID);

    
    }
}
