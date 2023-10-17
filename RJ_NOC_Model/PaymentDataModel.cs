using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RJ_NOC_Model
{
    public class RequestParameters
    {
        public string MERCHANTCODE { get; set; }
        public string PRN { get; set; }
        public string REQTIMESTAMP { get; set; }
        public string PURPOSE { get; set; }
        public string AMOUNT { get; set; }
        public string SUCCESSURL { get; set; }
        public string FAILUREURL { get; set; }
        public string CANCELURL { get; set; }
        public string CALLBACKURL { get; set; }
        public string USERNAME { get; set; }
        public string USERMOBILE { get; set; }
        public string USEREMAIL { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public string OFFICECODE { get; set; }
        public string REVENUEHEAD { get; set; }
        public string CHECKSUM { get; set; }
        public string CreatedDate { get; set; }
        public int RequestType { get; set; }
        public string RPPTXNID { get; set; }
    }



    public class ResponseParameters
    {
        public string MERCHANTCODE { get; set; }
        public string REQTIMESTAMP { get; set; }
        public string PRN { get; set; }
        public decimal? AMOUNT { get; set; }
        public string RPPTXNID { get; set; }
        public string RPPTIMESTAMP { get; set; }
        public string PAYMENTAMOUNT { get; set; }
        public string STATUS { get; set; }
        public string PAYMENTMODE { get; set; }
        public string PAYMENTMODEBID { get; set; }
        public string PAYMENTMODETIMESTAMP { get; set; }
        public string RESPONSECODE { get; set; }
        public string RESPONSEMESSAGE { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public string CHECKSUM { get; set; }
        public string CreatedDate { get; set; }

        public string REFUNDID { get; set; }
        public string REFUNDSTATUS { get; set; }
        public string REFUNDTIMESTAMP { get; set; }
        public string REMARKS { get; set; }


    }




    public class PaymentRequest
    {
        public string MERCHANTCODE { get; set; }
        public RequestParameters REQUESTPARAMETERS { get; set; }
        public string REQUESTJSON { get; set; }
        public string ENCDATA { get; set; }
        public string PaymentRequestURL { get; set; }
    }



    public class PaymentResponse
    {public ResponseParameters RESPONSEPARAMETERS { get; set; }
        public string RESPONSEJSON { get; set; }
        public string STATUS { get; set; }
        public string ENCDATA { get; set; }
        public bool CHECKSUMVALID { get; set; }
        public string PaymentRequestURL { get; set; }

    }

    public class RequestDetails
    {
        public string AMOUNT { get; set; }
        public string PURPOSE { get; set; }
        public string USERNAME { get; set; }
        public string USERMOBILE { get; set; }
        public string USEREMAIL { get; set; }
        public string ApplyNocApplicationID { get; set; }
        public int DepartmentID { get; set; }

    }

    public class TransactionStatusDataModel
    {
        public string ApplyNocApplicationID { get; set; }
        public string AMOUNT { get; set; }
        public string PRN { get; set; }
        public int DepartmentID { get; set; }
        public string? RPPTXNID { get; set; }
        public string? SubOrderID { get; set; }
        public string? REFUNDID { get; set; }
     
    }

    #region "EMITRA MODEL"
    public class EmitraRequstParameters
    {
        public string MERCHANTCODE { get; set; }
        public string REQUESTID { get; set; }
        public string REQTIMESTAMP { get; set; }
        public string SERVICEID { get; set; }
        public string SUBSERVICEID { get; set; }
        public string REVENUEHEAD { get; set; }
        public string CONSUMERKEY { get; set; }
        public string CONSUMERNAME { get; set; }
        public string COMMTYPE { get; set; }
        public string SSOID { get; set; }
        public string OFFICECODE { get; set; }
        public string SSOTOKEN { get; set; }
        public string CHECKSUM { get; set; }
        public bool IsKiosk { get; set; }
        public string ServiceName { get; set; }

        public string CHECKSUMKEY { get; set; }
        public string REDIRECTURL { get; set; }
        public string EncryptionKey { get; set; }
        public string ServiceURL { get; set; }

        public string AMOUNT { get; set; }

        public string PRN { get; set; }

        public string SUCCESSURL { get; set; }
        public string FAILUREURL { get; set; }
        public string USERNAME { get; set; }
        public string USERMOBILE { get; set; }

        public string USEREMAIL { get; set; }


        public string UDF1 { get; set; }
        public string UDF2 { get; set; }

        public string WebServiceURL { get; set; }
        public string SuccessFailedURL { get; set; }
    }

    [Serializable()]
    public class PGRequest
    {
        public string MERCHANTCODE { get; set; }
        public string PRN { get; set; }
        public string REQTIMESTAMP { get; set; }
        public string AMOUNT { get; set; }
        public string SUCCESSURL { get; set; }
        public string FAILUREURL { get; set; }
        public string USERNAME { get; set; }
        public string USERMOBILE { get; set; }
        public string USEREMAIL { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string SERVICEID { get; set; }
        public string OFFICECODE { get; set; }
        public string REVENUEHEAD { get; set; }
        public string COMMTYPE { get; set; }
        public string CHECKSUM { get; set; }
        public string ApplicationIdEnc { get; set; }
        public string UniquerequestId { get; set; }




    }




    public class EmitraResponseParameters
    {
        public string MERCHANTCODE { get; set; }
        public string REQTIMESTAMP { get; set; }
        public string PRN { get; set; }
        public string AMOUNT { get; set; }
        public string PAIDAMOUNT { get; set; }
        public string SERVICEID { get; set; }
        public string TRANSACTIONID { get; set; }
        public string RECEIPTNO { get; set; }
        public string EMITRATIMESTAMP { get; set; }
        public string STATUS { get; set; }
        public string PAYMENTMODE { get; set; }
        public string PAYMENTMODEBID { get; set; }
        public string PAYMENTMODETIMESTAMP { get; set; }
        public string RESPONSECODE { get; set; }
        public string RESPONSEMESSAGE { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string CHECKSUM { get; set; }

        public string ApplicationIdEnc { get; set; }
        public string UniquerequestId { get; set; }

        public string ResponseString { get; set; }
    }

    public class EmitraRequestDetails
    {

        public string AppRequestID { get; set; }
        public string ServiceID { get; set; }
        public string ApplicationIdEnc { get; set; }
        public decimal Amount { get; set; }

        public string UserName { get; set; }
        public string MobileNo { get; set; }

        public string RegistrationNo { get; set; }

        public string SsoID { get; set; }

        public string RESPONSEJSON { get; set; }
        public string STATUS { get; set; }
        public string ENCDATA { get; set; }
        public string PaymentRequestURL { get; set; }
        public string MERCHANTCODE { get; set; }
        public bool IsKiosk { get; set; }
        public bool IsSucccess { get; set; }


    }

    public class EmitraTransactions
    {
        public int TransactionId { get; set; }
        public string ApplicationIdEnc { get; set; }

        public string ApplicationNo { get; set; }

        public string KioskID { get; set; }

        public string ReceiptNo { get; set; }

        public string TokenNo { get; set; }
        public string RequestStatus { get; set; }

        public string StatusMsg { get; set; }

        public string RequestString { get; set; }

        public string ResponseString { get; set; }

        public int ActId { get; set; }
        public string SSOID { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIP { get; set; }
        public string ServiceID { get; set; }
        public decimal Amount { get; set; }
        public string key { get; set; }

        public string PRN { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RefundTransactionDataModel
    {
        public string RPPTXNID { get; set; }
        public string PRN { get; set; }
        public string REFUNDEDAMOUNT { get; set; }
        public string REMAININGAMOUNT { get; set; }
        public string STATUS { get; set; }

        public string RESPONSEMESSAGE { get; set; }


        public string RESPONSEJSON { get; set; }
        public string RESPONSECODE { get; set; }
        public int ApplyNocApplicationID { get; set; }
        public List<TRANSACTIONDetails> TRANSACTIONS { get; set; }
    }

    public class TRANSACTIONDetails
    {
        public int REFUNDID { get; set; }
        public string SUBORDERID { get; set; }
        public string REFUNDAMOUNT { get; set; }
        public string REFUNDACKNOWLEDGEMENTNUMBER { get; set; }
        public string REFUNDSTATUS { get; set; }
        public string REFUNDTIMESTAMP { get; set; }
        public string REFUNDCOMPLETIONTIMESTAMP { get; set; }
        public string REMARKS { get; set; }
    }


    public class TransactionSearchFilterModel
    {
        public int DepartmentID { get; set; }
        public int? CollegeID { get; set; }
        public int? TransactionID { get; set; }
        public string? PRN  { get; set; }
        public string? RPPTranID { get; set; }
        public string Key { get; set; }
        public string? RefundID { get; set; }
        public int? ApplyNocApplicationID { get; set; }
    }

    public enum enmPaymetRequest
    {
        PaymentRequest = 1,
        RefundRequest = 2
    }

    #endregion
}
