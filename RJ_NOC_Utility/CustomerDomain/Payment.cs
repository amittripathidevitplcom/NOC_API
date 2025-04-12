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

        public PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL, string ApplyNocApplicationID,string DTEAffiliationID, PaymentGatewayDataModel Model)
        {
            return UnitOfWork.PaymentRepository.SendRequest(PRN,AMOUNT,PURPOSE,USERNAME,USERMOBILE,USEREMAIL, ApplyNocApplicationID, DTEAffiliationID, Model);
        }
        public PaymentResponse GetResponse(string STATUS, string ENCDATA, PaymentGatewayDataModel Model)
        {
            return UnitOfWork.PaymentRepository.GetResponse(STATUS, ENCDATA, Model);
        }

        public bool SaveData(PaymentResponse response)
        {
            return UnitOfWork.PaymentRepository.SaveData(response);
        }
        public bool CreatePaymentRequest(PaymentRequest request)
        {
            return UnitOfWork.PaymentRepository.CreatePaymentRequest(request);
        }
        public bool UpdateRefundStatus(PaymentResponse request)
        {
            return UnitOfWork.PaymentRepository.UpdateRefundStatus(request);
        }
        public bool UpdateRefundTransactionStatus(RefundTransactionDataModel request)
        {
            return UnitOfWork.PaymentRepository.UpdateRefundTransactionStatus(request);
        }

        public List<ResponseParameters> GetPaymentListIDWise(string TransactionID)
        {
            return UnitOfWork.PaymentRepository.GetPaymentListIDWise(TransactionID);
        }
        

        public PaymentGatewayDataModel GetpaymentGatewayDetails(PaymentGatewayDataModel model)
        {
            return UnitOfWork.PaymentRepository.GetpaymentGatewayDetails(model);
        }

        public List<ResponseParameters> GetPreviewPaymentDetails(int ApplyNocApplicationID,int SessionYear )
        {
            return UnitOfWork.PaymentRepository.GetPreviewPaymentDetails(ApplyNocApplicationID, SessionYear);
        }
        
        public List<CommonDataModel_DataTable> GetRPPTransactionList(TransactionSearchFilterModel Model)
        {
            return UnitOfWork.PaymentRepository.GetRPPTransactionList(Model);
        }
        public List<CommonDataModel_DataTable> GetOfflinePaymentDetails(int CollegeID, int SessionYear)
        {
            return UnitOfWork.PaymentRepository.GetOfflinePaymentDetails(CollegeID, SessionYear);
        }
       
        public List<ResponseParameters> GetBterPaymentListIDWise(string TransactionID)
        {
            return UnitOfWork.PaymentRepository.GetBterPaymentListIDWise(TransactionID);
        }
       
        public List<ResponseParameters> GetBTERPreviewPaymentDetails(int AffiliationRegID, int SessionYear)
        {
            return UnitOfWork.PaymentRepository.GetBTERPreviewPaymentDetails(AffiliationRegID, SessionYear);
        }

        #region "Emitra Section"
        public EmitraRequstParameters GetEmitraServiceDetails(EmitraRequestDetails model)
        {
            return UnitOfWork.PaymentRepository.GetEmitraServiceDetails(model);
        }

        public EmitraRequestDetails EmitraSendPaymentRequest(EmitraRequestDetails model)
        {
            return UnitOfWork.PaymentRepository.EmitraSendPaymentRequest(model);
        }

        public EmitraTransactions CreateAddEmitraTransation(EmitraTransactions request)
        {
            return UnitOfWork.PaymentRepository.CreateAddEmitraTransation(request);
        }

        public bool UpdateEmitraPaymentStatus(EmitraResponseParameters request)
        {
            return UnitOfWork.PaymentRepository.UpdateEmitraPaymentStatus(request);
        }

        public List<CommonDataModel_DataTable> GetEmitraTransactionDetails(string TransactionID)
        {
            return UnitOfWork.PaymentRepository.GetEmitraTransactionDetails(TransactionID);
        }
        #endregion



        public bool UpdateEmitraRecheckPaymentStatus(EmitraResponseParameters request)
        {
            return UnitOfWork.PaymentRepository.UpdateEmitraRecheckPaymentStatus(request);
        }

        public List<CAGetSignedPDFAPIRequestResponse> GetCAeSignTransactionDetails(string TransactionID)
        {
            return UnitOfWork.PaymentRepository.GetCAeSignTransactionDetails(TransactionID);
        }



    }
}
