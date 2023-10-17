using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IPaymentRepository
    {
        PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL,string ApplyNocApplicationID, PaymentGatewayDataModel Model);
        PaymentResponse GetResponse(string STATUS, string ENCDATA, PaymentGatewayDataModel Model);
        bool SaveData(PaymentResponse request);
        bool CreatePaymentRequest(PaymentRequest request);
        bool UpdateRefundStatus(PaymentResponse request);
        bool UpdateRefundTransactionStatus(RefundTransactionDataModel request);
        List<CommonDataModel_DataTable> GetRPPTransactionList(TransactionSearchFilterModel model);

        List<ResponseParameters> GetPaymentListIDWise(string TransactionID);

        //payment gaeway
        PaymentGatewayDataModel GetpaymentGatewayDetails(PaymentGatewayDataModel Model);

        List<ResponseParameters> GetPreviewPaymentDetails(int ApplyNocApplicationID);


        //Emitra Section
        EmitraRequstParameters GetEmitraServiceDetails(EmitraRequestDetails Model);
        EmitraRequestDetails EmitraSendPaymentRequest(EmitraRequestDetails Model);
        EmitraTransactions CreateAddEmitraTransation(EmitraTransactions request);
        bool UpdateEmitraPaymentStatus(EmitraResponseParameters request);
        List<CommonDataModel_DataTable> GetEmitraTransactionDetails(string TransactionID);
        

    }
}
