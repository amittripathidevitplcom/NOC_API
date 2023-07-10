using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string USERNAME { get; set; }
        public string USERMOBILE { get; set; }
        public string USEREMAIL { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public string OFFICECODE { get; set; }
        public string REVENUEHEAD { get; set; }
        public string CHECKSUM { get; set; }
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
    }



    public class PaymentRequest
    {
        public string MERCHANTCODE { get; set; }
        public RequestParameters REQUESTPARAMETERS { get; set; }
        public string REQUESTJSON { get; set; }
        public string ENCDATA { get; set; }
    }



    public class PaymentResponse
    {
        public ResponseParameters RESPONSEPARAMETERS { get; set; }
        public string RESPONSEJSON { get; set; }
        public string STATUS { get; set; }
        public string ENCDATA { get; set; }
        public bool CHECKSUMVALID { get; set; }
    }

    public class RequestDetails
    {
        public string AMOUNT { get; set; }
        public string PURPOSE { get; set; }
        public string USERNAME { get; set; }
        public string USERMOBILE { get; set; }
        public string USEREMAIL { get; set; }
        public string ApplyNocApplicationID { get; set; }

    }
}
