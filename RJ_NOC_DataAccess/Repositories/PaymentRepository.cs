using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Data;

namespace RJ_NOC_DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public PaymentRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        //const string MERCHANTCODE = "testMerchant2";
        //const string CHECKSUMKEY = "WFsdaY28Pf";
        //const string ENCRYPTIONKEY = "9759E1886FB5766DA58FF17FF8DD4";
        //const string SUCCESSURL = "http://localhost:62778/api/Payment/PaymentResponse";
        ////const string FAILUREURL = "http://localhost:4200/paymentsuccess";

        //const string FAILUREURL = "http://localhost:62778/api/Payment/PaymentResponse";
        //const string CANCELURL = "http://localhost:62778/api/Payment/PaymentResponse";


        #region "RPP PAYMENT SECTION"
        public PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL,string ApplyNocApplicationID, PaymentGatewayDataModel Model)
        {
            string REQTIMESTAMP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string CHECKSUM = MD5HASHING(MERCHANTCODE + "|" + PRN + "|" + AMOUNT + "|" + CHECKSUMKEY);
            string CHECKSUM = MD5HASHING(Model.MerchantCode + "|" + PRN + "|" + AMOUNT + "|" + Model.CheckSumKey);
            //JavaScriptSerializer serializer = new JavaScriptSerializer();



            RequestParameters REQUESTPARAMS = new RequestParameters
            {
                MERCHANTCODE = Model.MerchantCode, //MERCHANTCODE,
                PRN = PRN,
                REQTIMESTAMP = REQTIMESTAMP,
                PURPOSE = PURPOSE,
                AMOUNT = AMOUNT,
                SUCCESSURL = Model.SuccessURL,// SUCCESSURL,
                FAILUREURL = Model.SuccessURL, //FAILUREURL,
                CANCELURL = Model.CencelURL, //CANCELURL,
                USERNAME = USERNAME,
                USERMOBILE = USERMOBILE,
                USEREMAIL = USEREMAIL,
                UDF1 = ApplyNocApplicationID,
                UDF2 = "PARAM2",
                UDF3 = "PARAM3",
                OFFICECODE = "",
                REVENUEHEAD = "AMOUNT=" + AMOUNT.ToString(),
                CHECKSUM = CHECKSUM
            };



            string REQUESTJSON = JsonConvert.SerializeObject(REQUESTPARAMS);
            string ENCDATA = AESEncrypt(REQUESTJSON, Model.ENCRYPTIONKEY);
            PaymentRequest PAYMENTREQUEST = new PaymentRequest
            {
                MERCHANTCODE = Model.MerchantCode,
                REQUESTJSON = REQUESTJSON,
                REQUESTPARAMETERS = REQUESTPARAMS,
                ENCDATA = ENCDATA,
                PaymentRequestURL=Model.PaymentRequestURL
               
            };



            return PAYMENTREQUEST;
        }
        private static readonly Encoding encoding = Encoding.UTF8;
        public PaymentResponse GetResponse(string STATUS, string ENCDATA, PaymentGatewayDataModel Model)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            string RESPONSEJSON = AESDecrypt(ENCDATA, Model.ENCRYPTIONKEY);
            ResponseParameters RESPONSEPARAMS = JsonConvert.DeserializeObject<ResponseParameters>(RESPONSEJSON);
            string CHECKSUM = MD5HASHING(Model.MerchantCode + "|" + RESPONSEPARAMS.PRN + "|" + RESPONSEPARAMS.RPPTXNID + "|" + RESPONSEPARAMS.PAYMENTAMOUNT + "|" + Model.CheckSumKey);



            PaymentResponse PAYMENTRESPONSE = new PaymentResponse();
            if (CHECKSUM == RESPONSEPARAMS.CHECKSUM.ToUpper())
            {
                PAYMENTRESPONSE = new PaymentResponse
                {
                    RESPONSEJSON = RESPONSEJSON,
                    ENCDATA = ENCDATA,
                    RESPONSEPARAMETERS = RESPONSEPARAMS,
                    STATUS = STATUS,
                    CHECKSUMVALID = true
                };
            }
            else
            {
                PAYMENTRESPONSE = new PaymentResponse
                {
                    RESPONSEJSON = RESPONSEJSON,
                    ENCDATA = ENCDATA,
                    RESPONSEPARAMETERS = RESPONSEPARAMS,
                    STATUS = STATUS,
                    CHECKSUMVALID = false
                };
            }



            return PAYMENTRESPONSE;
        }
        public static string AESEncrypt(string textToEncrypt, string encryptionKey)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.Key = SHA256.Create().ComputeHash(encoding.GetBytes(encryptionKey));
                aes.IV = MD5.Create().ComputeHash(encoding.GetBytes(encryptionKey));
                ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] buffer = encoding.GetBytes(textToEncrypt);
                return Convert.ToBase64String(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                throw new Exception("Error encrypting: " + e.Message);
            }
        }
        public static string AESDecrypt(string textToDecrypt, string encryptionKey)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.Key = SHA256.Create().ComputeHash(encoding.GetBytes(encryptionKey));
                aes.IV = MD5.Create().ComputeHash(encoding.GetBytes(encryptionKey));
                ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] buffer = Convert.FromBase64String(textToDecrypt);
                return encoding.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                throw new Exception("Error decrypting: " + e.Message);
            }
        }
        public static string MD5HASHING(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        #endregion


        public bool SaveData(PaymentResponse request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CreatePaymentTransation";
            SqlQuery += " @PaymentStatus='" + request.STATUS + "',@CheckSumValid='" + request.CHECKSUMVALID + "',@PRNNO='" + request.RESPONSEPARAMETERS.PRN + "',@CheckSum='" + request.RESPONSEPARAMETERS.CHECKSUM + "'," +
                "@Amount='" + request.RESPONSEPARAMETERS.AMOUNT + "',@MerchantCode='" + request.RESPONSEPARAMETERS.MERCHANTCODE + "',@PaymentAmount='" + request.RESPONSEPARAMETERS.PAYMENTAMOUNT + "'," +
                "@PaymentMode='" + request.RESPONSEPARAMETERS.PAYMENTMODE + "'" + ",@PaymentModeBID='" + request.RESPONSEPARAMETERS.PAYMENTMODEBID + "'" + ",@PaymentModeTimeStamp='" + request.RESPONSEPARAMETERS.PAYMENTMODETIMESTAMP + "'" +
                ",@ReqTimeStamp='" + request.RESPONSEPARAMETERS.REQTIMESTAMP + "',@ResponseCode='" + request.RESPONSEPARAMETERS.RESPONSECODE + "',@RPPTXNID='" + request.RESPONSEPARAMETERS.RPPTXNID + "'," +
                "@STATUS='" + request.RESPONSEPARAMETERS.STATUS + "',@UDF1='" + request.RESPONSEPARAMETERS.UDF1 + "',@UDF2='" + request.RESPONSEPARAMETERS.UDF2 + "',@RESPONSEJSON='" + request.RESPONSEJSON+ "'"; 
            int Rows = _commonHelper.NonQuerry(SqlQuery, "PaymentRepository.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
      
        public List<ResponseParameters> GetPaymentListIDWise(string TransactionID)
        {
            string SqlQuery = " exec USP_PaymentTransaction_GetData @PRNNO='" + TransactionID + "' ,@Key= 'ViewRecord' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetPaymentListIDWise");

            List<ResponseParameters> dataModels = new List<ResponseParameters>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ResponseParameters>>(JsonDataTable_Data);
            return dataModels;
        }

        //gete payment gateway details
        public PaymentGatewayDataModel GetpaymentGatewayDetails(PaymentGatewayDataModel model)
        {
            string SqlQuery = " exec USP_PaymentGateway_GetData @PaymentGateway='" + model.PaymentGateway + "' ,@Key= 'GetRecord' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetPaymentListIDWise");

           List< PaymentGatewayDataModel> dataModels = new List<PaymentGatewayDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<PaymentGatewayDataModel>>(JsonDataTable_Data);

            if (dataModels.Count > 0)
            {
                var record = dataModels.FirstOrDefault();
                if (record != null)
                {
                    model = record;
                }
            }

            return model;
        }
    }
}
