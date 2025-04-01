using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Transactions;
using Azure.Core;

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
        public PaymentRequest SendRequest(string PRN, string AMOUNT, string PURPOSE, string USERNAME, string USERMOBILE, string USEREMAIL, string ApplyNocApplicationID,string DTEAffiliationID, PaymentGatewayDataModel Model)
        {
            string REQTIMESTAMP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string CHECKSUM = MD5HASHING(MERCHANTCODE + "|" + PRN + "|" + AMOUNT + "|" + CHECKSUMKEY);
            string CHECKSUM = MD5HASHING(Model.MerchantCode + "|" + PRN + "|" + AMOUNT + "|" + Model.CheckSumKey);
            //JavaScriptSerializer serializer = new JavaScriptSerializer();


            if (PURPOSE== "BTER Payment")
            {
                
                RequestParameters REQUESTPARAMS = new RequestParameters
                {
                    MERCHANTCODE = Model.MerchantCode, //MERCHANTCODE,
                    PRN = PRN,
                    REQTIMESTAMP = REQTIMESTAMP,
                    PURPOSE = PURPOSE,
                    AMOUNT = AMOUNT,
                    SUCCESSURL = Model.SuccessURL+ "?DepartmentID=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(Model.DepartmentID)),// SUCCESSURL,
                    FAILUREURL = Model.SuccessURL + "?DepartmentID=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(Model.DepartmentID)),// SUCCESSURL,, //FAILUREURL,
                    CANCELURL = Model.CencelURL + "?DepartmentID=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(Model.DepartmentID)),// SUCCESSURL,, //CANCELURL,
                    CALLBACKURL = Model.CallBackURL,
                    USERNAME = USERNAME,
                    USERMOBILE = USERMOBILE,
                    USEREMAIL = USEREMAIL,
                    UDF1 = DTEAffiliationID,
                    UDF2 = PURPOSE,
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
                    PaymentRequestURL = Model.PaymentRequestURL
                };
                return PAYMENTREQUEST;
            }
            else
            {
                RequestParameters REQUESTPARAMS = new RequestParameters
                {
                    MERCHANTCODE = Model.MerchantCode, //MERCHANTCODE,
                    PRN = PRN,
                    REQTIMESTAMP = REQTIMESTAMP,
                    PURPOSE = PURPOSE,
                    AMOUNT = AMOUNT,
                    SUCCESSURL = Model.SuccessURL + "?DepartmentID=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(Model.DepartmentID)),// SUCCESSURL,
                    FAILUREURL = Model.SuccessURL + "?DepartmentID=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(Model.DepartmentID)),// SUCCESSURL,, //FAILUREURL,
                    CANCELURL = Model.CencelURL + "?DepartmentID=" + PaymentEncriptionDec.EmitraEncrypt(Convert.ToString(Model.DepartmentID)),// SUCCESSURL,, //CANCELURL,
                    CALLBACKURL = Model.CallBackURL,
                    USERNAME = USERNAME,
                    USERMOBILE = USERMOBILE,
                    USEREMAIL = USEREMAIL,
                    UDF1 = ApplyNocApplicationID,
                    UDF2 = PURPOSE,
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
                    PaymentRequestURL = Model.PaymentRequestURL
                };
                return PAYMENTREQUEST;
            }
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
            SqlQuery += " @PaymentStatus='" + request.STATUS + "'" +
                ",@CheckSumValid='" + request.CHECKSUMVALID + "'" +
                ",@ResponseMessage='" + request.RESPONSEPARAMETERS.RESPONSEMESSAGE + "'" +
                ",@PRNNO='" + request.RESPONSEPARAMETERS.PRN + "'" +
                ",@CheckSum='" + request.RESPONSEPARAMETERS.CHECKSUM + "'" +
                "," + "@Amount='" + request.RESPONSEPARAMETERS.AMOUNT + "',@MerchantCode='" + request.RESPONSEPARAMETERS.MERCHANTCODE + "',@PaymentAmount='" + request.RESPONSEPARAMETERS.PAYMENTAMOUNT + "'," +
                "@PaymentMode='" + request.RESPONSEPARAMETERS.PAYMENTMODE + "'" + ",@PaymentModeBID='" + request.RESPONSEPARAMETERS.PAYMENTMODEBID + "'" + ",@PaymentModeTimeStamp='" + request.RESPONSEPARAMETERS.PAYMENTMODETIMESTAMP + "'" +
                ",@ReqTimeStamp='" + request.RESPONSEPARAMETERS.REQTIMESTAMP + "',@ResponseCode='" + request.RESPONSEPARAMETERS.RESPONSECODE + "',@RPPTXNID='" + request.RESPONSEPARAMETERS.RPPTXNID + "'," +
                "@STATUS='" + request.RESPONSEPARAMETERS.STATUS + "',@UDF1='" + request.RESPONSEPARAMETERS.UDF1 + "',@UDF2='" + request.RESPONSEPARAMETERS.UDF2 + "',@RESPONSEJSON='" + request.RESPONSEJSON + "'," + "@key='UpdatePaymentStatus'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "PaymentRepository.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool CreatePaymentRequest(PaymentRequest request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CreatePaymentTransation";

            string strPaymentStatus = "";
            if (request.REQUESTPARAMETERS.RequestType == (int)enmPaymetRequest.PaymentRequest)
              strPaymentStatus = "PaymentRequest";
            else if (request.REQUESTPARAMETERS.RequestType == (int)enmPaymetRequest.RefundRequest)
                strPaymentStatus = "RefundRequest";
            else
                strPaymentStatus = "PaymentRequest";

            SqlQuery += " @PaymentStatus='"+strPaymentStatus+"',@PRNNO='" + request.REQUESTPARAMETERS.PRN + "',@CheckSum='" + request.REQUESTPARAMETERS.CHECKSUM + "'," +
                "@Amount='" + request.REQUESTPARAMETERS.AMOUNT + "',@MerchantCode='" + request.REQUESTPARAMETERS.MERCHANTCODE + "',@PaymentAmount='" + request.REQUESTPARAMETERS.AMOUNT +
                "',@UDF1='" + request.REQUESTPARAMETERS.UDF1 + "',@UDF2='" + request.REQUESTPARAMETERS.UDF2 + "',@REQUESTJSON='" + request.REQUESTJSON + "',@ENCDATA='" + request.ENCDATA + "'," + "@key='CreatePaymentRequest',@RequestType='"+request.REQUESTPARAMETERS.RequestType+ "',@RPPTXNID='" + request.REQUESTPARAMETERS.RPPTXNID+"',@CreatedBy='"+ request.CreatedBy+ "',@IPAddress='"+ IPAddress + "',@SSOID='"+request.SSOID+"'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "PaymentRepository.CreatePaymentRequest");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool UpdateRefundStatus(PaymentResponse request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CreatePaymentTransation";
            SqlQuery += " @PRNNO='" + request.RESPONSEPARAMETERS.PRN + "',";
            SqlQuery += " @ResponseMessage='" + request.RESPONSEPARAMETERS.RESPONSEMESSAGE + "',";
            SqlQuery += " @ResponseJson='" + request.RESPONSEJSON + "',";
            SqlQuery += " @UDF1='" + request.RESPONSEPARAMETERS.UDF1 + "',";
            SqlQuery += " @ResponseCode='" + request.RESPONSEPARAMETERS.RESPONSECODE + "',";
            SqlQuery += " @STATUS='" + request.RESPONSEPARAMETERS.STATUS + "',";
            SqlQuery += " @RefundID='" + request.RESPONSEPARAMETERS.REFUNDID + "',";
            SqlQuery += " @RPPTimeStamp='" + request.RESPONSEPARAMETERS.REFUNDTIMESTAMP + "',";
            SqlQuery += " @REMARKS='" + request.RESPONSEPARAMETERS.REMARKS + "',";
            SqlQuery += " @RPPTXNID='" + request.RESPONSEPARAMETERS.RPPTXNID + "',";
            SqlQuery += " @key='UpdateRefundStatus'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "PaymentRepository.UpdateRefundStatus");
            if (Rows > 0)
                return true;
            else
                return false;
        }



        public bool UpdateRefundTransactionStatus(RefundTransactionDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CreatePaymentTransation";
            SqlQuery += " @PRNNO='" + request.PRN + "',";
            SqlQuery += " @ResponseMessage='" + request.RESPONSEMESSAGE + "',";
            SqlQuery += " @ResponseJson='" + request.RESPONSEJSON + "',";
            SqlQuery += " @UDF1='" + request.ApplyNocApplicationID + "',";
            SqlQuery += " @ResponseCode='" + request.RESPONSECODE + "',";
            SqlQuery += " @STATUS='" + request.STATUS + "',";
            SqlQuery += " @RPPTXNID='" + request.RPPTXNID + "',";
            if (request.TRANSACTIONS != null)
            {
                if (request.TRANSACTIONS.Count > 0)
                {
                    string strRefundID = request.TRANSACTIONS.FirstOrDefault() != null ? Convert.ToString(request.TRANSACTIONS.FirstOrDefault().REFUNDID) : string.Empty;
                    string RPPTimeStamp = request.TRANSACTIONS.FirstOrDefault() != null ? request.TRANSACTIONS.FirstOrDefault().REFUNDTIMESTAMP : string.Empty;
                    string REMARKS = request.TRANSACTIONS.FirstOrDefault() != null ? request.TRANSACTIONS.FirstOrDefault().REMARKS : string.Empty;
                    
                    SqlQuery += " @RefundID='" + strRefundID + "',";
                    SqlQuery += " @RPPTimeStamp='" + RPPTimeStamp + "',";
                    SqlQuery += " @REMARKS='" + REMARKS + "',";
                 
                }
            }
            SqlQuery += " @key='UpdateRefundStatus'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "PaymentRepository.UpdateRefundTransactionStatus");
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
            string SqlQuery = " exec USP_PaymentGateway_GetData @PaymentGateway='" + model.PaymentGateway + "' ,@Key= 'GetRecord',@DepartmentID='" + model.DepartmentID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetPaymentListIDWise");

            List<PaymentGatewayDataModel> dataModels = new List<PaymentGatewayDataModel>();
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

        public List<ResponseParameters> GetPreviewPaymentDetails(int CollegeID, int SessionYear)
        {
            string SqlQuery = " exec USP_PaymentTransaction_GetData @CollegeID='" + CollegeID + "'  ,@SessionYear='" + SessionYear + "' ,@Key= 'GetPreviewPaymentDetails' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetPaymentListIDWise");

            List<ResponseParameters> dataModels = new List<ResponseParameters>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ResponseParameters>>(JsonDataTable_Data);
            return dataModels;
        }
        
        

        #region "Emitra Payment Section"
        public EmitraRequestDetails EmitraSendPaymentRequest(EmitraRequestDetails Model)
        {
            return Model;
        }

        public EmitraRequstParameters GetEmitraServiceDetails(EmitraRequestDetails model)
        {
            EmitraRequstParameters objData = new EmitraRequstParameters();
            string SqlQuery = " exec USP_GetEmitraServiceDetails @ServiceId='" + model.ServiceID + "',@IsKiosk='" + model.IsKiosk + "' , @Key= 'GetServiceDetails' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetEmitraServiceDetails");

            List<EmitraRequstParameters> dataModels = new List<EmitraRequstParameters>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<EmitraRequstParameters>>(JsonDataTable_Data);
            if (dataModels.Count > 0)
            {
                var record = dataModels.FirstOrDefault();
                if (record != null)
                {
                    objData = record;
                }
            }
            return objData;
        }


        public EmitraTransactions CreateAddEmitraTransation(EmitraTransactions request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_InsertEmitraTransactions";
            SqlQuery += " @ApplicationIdEnc='" + request.ApplicationIdEnc + "',@ApplicationNo='" + request.ApplicationNo + "',@KioskID='" + request.KioskID + "',@ReceiptNo='" + request.ReceiptNo + "'," +
                "@TokenNo='" + request.TokenNo + "',@RequestStatus='" + request.RequestStatus + "',@StatusMsg='" + request.StatusMsg + "'," +
                "@RequestString='" + request.RequestString + "'" + ",@ResponseString='" + request.ResponseString + "'" + ",@ActId='" + request.ActId + "'" + ",@TransactionId='" + request.TransactionId + "'" + ",@PRN='" + request.PRN + "'" +
                ",@SSOID='" + request.SSOID + "',@CreatedIP='" + IPAddress + "',@ServiceID='" + request.ServiceID + "',@Amount='" + request.Amount + "'," +
                "@key='" + request.key + "'";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "PaymentRepository.CreateAddEmitraTransation");
            if (Rows > 0)
                request.TransactionId = Rows;
            else
                request.TransactionId = 0;
            return request;
        }

        public bool UpdateEmitraPaymentStatus(EmitraResponseParameters request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_InsertEmitraTransactions";
            SqlQuery += " @ApplicationIdEnc='" + request.ApplicationIdEnc + "',@TransactionId='" + request.TRANSACTIONID + "',@PRN='" + request.PRN + "',@PaidAmount='" + request.PAIDAMOUNT + "',@TokenNo='" + request.RECEIPTNO + "',@StatusMsg='" + request.RESPONSEMESSAGE + "',@ResponseString='" + JsonConvert.SerializeObject(request) + "',@ReceiptNo='" + request.RECEIPTNO + "'," + "@RequestStatus='" + request.STATUS + "'," +
                "@key='UpdateEmitraPaymentStatus'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "PaymentRepository.UpdateEmitraPaymentStatus");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetEmitraTransactionDetails(string PRN)
        {
            string SqlQuery = " exec USP_GetEmitraTransactionDetails @Key='GetServiceDetails',@PRN='" + PRN + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetEmitraTransactionDetails");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetRPPTransactionList(TransactionSearchFilterModel Model )
        {
            string SqlQuery = " exec USP_PaymentTransaction_GetData";
            SqlQuery += " @DepartmentID='" + Model.DepartmentID + "',";
            SqlQuery += " @TransactionID='" + Model.TransactionID + "',";
            SqlQuery += " @RPPTranID='" + Model.RPPTranID + "',";
            SqlQuery += " @CollegeID='" + Model.CollegeID + "',";
            SqlQuery += " @RefundID='" + Model.RefundID + "',";
            SqlQuery += " @PRNNO='" + Model.PRN + "',";
            SqlQuery += " @ApplyNocApplicationID='" + Model.ApplyNocApplicationID + "',";
            SqlQuery += " @Key='" + Model.Key + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetRPPTransactionList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }


        #endregion

        public List<CommonDataModel_DataTable> GetOfflinePaymentDetails(int CollegeID, int SessionYear)
        {
            string SqlQuery = " exec USP_GetOfflinePaymentDetails @CollegeID='" + CollegeID + "',@SessionYear='" + SessionYear + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetOfflinePaymentDetails");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        
        public List<ResponseParameters> GetBterPaymentListIDWise(string TransactionID)
        {
            string SqlQuery = " exec USP_PaymentTransaction_GetData @PRNNO='" + TransactionID + "' ,@Key= 'ViewBTERRecord' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetBterPaymentListIDWise");

            List<ResponseParameters> dataModels = new List<ResponseParameters>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ResponseParameters>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<ResponseParameters> GetBTERPreviewPaymentDetails(int AffiliationRegID, int SessionYear)
        {
            string SqlQuery = " exec USP_PaymentTransaction_GetData @AffiliationRegID='" + AffiliationRegID + "'  ,@SessionYear='" + SessionYear + "' ,@Key= 'GetBTERRPPTransactionList' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentRepository.GetBTERPreviewPaymentDetails");

            List<ResponseParameters> dataModels = new List<ResponseParameters>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ResponseParameters>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
