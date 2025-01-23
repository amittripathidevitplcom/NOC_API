using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using System.Xml;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Security.Cryptography;
using RJ_NOC_DataAccess.Common;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using System.ServiceModel.Channels;
using System.Collections;
using Newtonsoft.Json;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class AadharService : UtilityBase, IAadharService
    {
        public AadharService(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DataTable SendOtpByAadharNo(CommonDataModel_AadharDataModel modal, IConfiguration _configuration)
        {
            return SendOtpByAadharNo(modal.AadharNo, "NOC", _configuration);

        }
        public DataTable SendOtpByAadharNo_Esign(CommonDataModel_AadharDataModel modal, IConfiguration _configuration)
        {
            return SendOtpByAadharNo_Esign(modal.AadharNo, "NOC", _configuration);

        }

        public DataTable ValidateAadhaarOTP(CommonDataModel_AadharDataModel modal, IConfiguration _configuration)
        {
            return ValidateOTP(modal.TransactionNo, modal.AadharNo, modal.OTP, _configuration);
        }
        public DataTable ValidateAadhaarOTP_Esign(CommonDataModel_AadharDataModel modal, IConfiguration _configuration)
        {
            return ValidateAadhaarOTP_Esign(modal.TransactionNo, modal.AadharNo, modal.OTP, _configuration);
        }

        public string GetAadharByVID(CommonDataModel_AadharDataModel modal, IConfiguration _configuration)
        {
            return GetAadharByVID(modal.AadharID, _configuration);
        }

        public string GetAadharByVID_Esgin(string _AadharNo, IConfiguration _configuration)
        {
            return GetAadharByVID(_AadharNo, _configuration);
        }



        #region "User Define Functiotion"
        public DataTable SendOtpByAadharNo_Esign(string _AadharNo, string modulename, IConfiguration _configuration)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("txn", typeof(string));
            string errormsg = string.Empty;
            string succmsg = string.Empty;
            string _txnid = string.Empty;
            string json = "";
            string ss = "";
            string status = "";
            string responseCode = "";
            if (_AadharNo.Trim().ToString() != "")
            {
                //
                if (!string.IsNullOrEmpty(_AadharNo) && Convert.ToString(_AadharNo).Length == 15)
                {

                    _AadharNo = GetAadharByVID_Esgin(_AadharNo, _configuration);
                }
                //
                json = "{\"aadharid\":\"" + _AadharNo.ToString() + "\", \"departmentname\" : \"Agriculture\"}";
                //json = "{\"aadharid\":\"800366997686\", \"departmentname\" : \"Agriculture\"}";
                try
                {
                    string auacode = _configuration["AadharServiceDetails:eSignOTP"].ToString();
                    string lickey = _configuration["AadharServiceDetails:AadhaarLicKey"].ToString();
                    ss = WebRequestinJson(auacode, json, "application/json");

                    CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.SendOtpByAadharNo_Esign", ss.ToString());
                    JObject root = (JObject)JObject.Parse(ss);
                    foreach (var item in root)
                    {
                        if (item.Key == "Status")
                            status = item.Value.ToString().Replace("\"", ""); ;
                        if (item.Key == "TransactionId")
                            _txnid = item.Value.ToString().Replace("\"", ""); ;
                    }
                    if (!status.Equals("1"))
                    {
                        errormsg = "status - " + status;
                        _txnid = "NO" + "#" + _txnid;
                    }
                    else if (status.Equals("1"))
                    {
                        _txnid.Replace("\"", "");

                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.SendOtpByAadharNo_Esign", ex.ToString());
                    _txnid = "NO" + "#" + ex.Message;
                }
            }
            else
            {
                errormsg = "Fill Aadhar ID!";
            }
            dt.Rows.Add(new Object[] { _txnid });
            return dt;
        }


        public DataTable SendOtpByAadharNo(string _AadharNo, string modulename, IConfiguration _configuration)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("txn", typeof(string));
            //_AadharNo = "428434778643";
            string txnid = string.Empty;
            string _txnid = string.Empty;
            //string txnid = "";
            string UID = string.Empty;
            string ip = GetIpAddress();
            string status = "";
            string results = "";
            string errorcode = "";
            String timeStamp = DateTime.Now.ToString();
            string auacode = _configuration["AadharServiceDetails:subaua"].ToString();
            string lickey = _configuration["AadharServiceDetails:AadhaarLicKey"].ToString();
            string XMLDATA = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?><authrequest uid='" + _AadharNo + "' subaua='" + auacode + "'  ip='" + ip + "' fdc='NA' idc='NA' bt='otp' macadd='78-2B-CB-8D-93-F1' lot='P' lov='110002' lk='" + lickey + "' rc='Y' ver='2.5'><otp/></authrequest>";


            XMLDATA.Replace('\'', '\"');
            string url = _configuration["AadharServiceDetails:ServiceURL"].ToString();
            System.Net.WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                if (!string.IsNullOrEmpty(_AadharNo) && _AadharNo.Length == 12)
                {
                    req = WebRequest.Create(url);
                    //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                    req.Method = "POST";        // Post method
                    req.ContentType = "application/xml";
                    req.Headers["appname"] = "Agriculture";
                    // content type
                    // Wrap the request stream with a text-based writer
                    StreamWriter writer = new StreamWriter(req.GetRequestStream());
                    // Write the XML text into the stream
                    writer.Write(XMLDATA);
                    writer.Close();
                    // Send the data to the webserver
                    rsp = req.GetResponse(); //I am getting error over here
                    StreamReader sr = new StreamReader(rsp.GetResponseStream());
                    results = sr.ReadToEnd();
                    sr.Close();
                    // UpdateIdentifyMessage(results, null);
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(results); // suppose that myXmlString contains "<Names>...</Names>"
                    XmlNodeList xnList = xml.SelectNodes("authresponse/auth");
                    string sa = "";
                    string Errormsg = "";
                    foreach (XmlNode xn in xnList)
                    {
                        sa = xn.Attributes["status"].Value;
                        if (sa.ToUpper() == "Y")
                        {
                            _txnid = xn.Attributes["txn"].Value;
                            txnid = xn.Attributes["txn"].Value;
                            status = sa.ToUpper();
                        }
                        else if (sa.ToUpper() == "N")
                        {
                            XmlNodeList errorcodelist = xml.SelectNodes("authresponse/error");
                            XmlNodeList messagelist = xml.SelectNodes("authresponse/message");
                            errorcode = errorcodelist[0].InnerText.ToString();
                            Errormsg = messagelist[0].InnerText.ToString();
                            _txnid = Errormsg;
                            txnid = xn.Attributes["txn"].Value;
                            status = sa.ToUpper();

                        }
                        else
                        {
                            _txnid = "Aadhar Service temporarily down Please Try After Some Time";
                            status = "N";
                        }
                    }
                    if (errorcode != "")
                    {
                        if (errorcode == "952")
                        {
                            Errormsg = "Please Wait for 10 Mintues and try again";
                        }
                        else if (errorcode == "953")
                        {
                            Errormsg = "Please Wait for 30 Mintues and try again";
                        }
                        else if (errorcode == "112")
                        {
                            Errormsg = "Aadhaar number does not have both email and mobile.";
                        }
                        else if (errorcode == "337")
                        {
                            Errormsg = "UIDAI server not responding,Try again after some time.";
                        }
                        else if (errorcode == "K-999")
                        {
                            Errormsg = "Unknown error by UIDAI server";
                        }
                        //_txnid = errorcode;
                        _txnid = Errormsg;

                    }
                    //if (sa.ToUpper() == "N")
                    //{

                    //    _txnid = "NO" + "#" + _txnid;
                    //    status = sa.ToUpper();
                    //}
                }
                else
                {
                    _txnid = "NO" + "#" + "AADHAR ID NOT UPDATED IN SSO PROFILE";
                }
            }
            catch (Exception ex)
            {
                _txnid = "NO" + "#SOME ERROR OCCURD IN AADHAAR SERVER. PLEASE TRY AFTER SOME TIME";
            }
            dt.Rows.Add(new Object[] { _txnid });
            return dt;
        }
        public static DataTable ValidateOTP(string txn, string adhar, string otp, IConfiguration _configuration)
        {

            DataTable dtb = new DataTable();
            string authXML = "";
            string results = "";
            string status = "";
            string Errormsg = "";
            string errorcode = "";
            try
            {

                string auacode = _configuration["AadharServiceDetails:subaua"].ToString();
                string Certificatename = "uidai_auth_prod.cer";
                string lickey = _configuration["AadharServiceDetails:AadhaarLicKey"].ToString();
                string url = _configuration["AadharServiceDetails:ValidateAadharServiceURL"].ToString();
                //string CertificatePath = context.Server.MapPath(Certificatename);
                string pathString = "~/Content/";
                //string CertificatePath = Path.GetFullPath("Content"); System.Web.  System.Web.HttpContext.Current.Server.MapPath(pathString + Certificatename);
                string CertificatePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", Certificatename);
                //Creating PID XML and Generate in UTF-8 Byte of that XML.
                var tts = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss");
                //V2.1
                //string msg = "<Pid ts=\"" + tts + "\" ver=\"2.0\" wadh=\"3rkK2t6Ro4XNVYNfXendn5h2UOMw2LTbHsGWQQ/QjcM=\"><Pv otp=\"" + otp + "\" /></Pid>";
                //2.5
                string msg = "<Pid ts=\"" + tts + "\" ver=\"2.0\" wadh=\"DEL9Vn2tNcxY/T3g9Jf6F/0Ne43ufdO6AaBClCWkCiQ=\"><Pv otp=\"" + otp + "\" /></Pid>";
                string expiryDate = string.Empty;
                string encSessionKey = string.Empty;
                string encryptedHmacBytes = string.Empty;
                string encXMLPIDDataNew = GetEncryptedPIDXmlNew(msg, CertificatePath, tts, ref expiryDate, ref encSessionKey, ref encryptedHmacBytes);

                //string authXML = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><authrequest uid=\"" + adhar + "\" tid=\"\" subaua=\"" + auacode + "\" bt=\"\" udc=\"15dfs13I846\" lk=\"" + lickey + "\" mec=\"Y\" ver=\"2.1\" txn=\"" + txn + "\" dpID=\"\" rdsID=\"\" rdsVer=\"\" dc=\"\" mi=\"\" mc=\"\" deviceSrNO=\"NA\" deviceError=\"NA\" ip=\"NA\" fdc=\"NA\" idc=\"NC\" macadd=\"NA\" lot=\"P\" ra=\"O\" rc=\"Y\" lr=\"Y\" de=\"N\" pfr=\"N\" lov=\"302005\"><deviceInfo fType=\"NA\" iCount=\"NA\" pCount=\"NA\" errCodeRDS=\"NA\" errInfoRDS=\"NA\" fCount=\"NA\" nmPoints=\"NA\" qScore=\"NA\" srno=\"NA\" deviceError=\"NA\" /><Skey ci=\"" + expiryDate + "\">" + encSessionKey + "</Skey><Hmac>" + encryptedHmacBytes + "</Hmac><Data type=\"X\">" + encXMLPIDDataNew + "</Data></authrequest>";

                authXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><authrequest uid=\"" + adhar + "\" tid=\"\" subaua=\"" + auacode + "\" bt=\"OTP\" lk=\"" + lickey + "\" rc=\"Y\" ra=\"O\" lr=\"Y\" de=\"N\" pfr=\"N\" mec=\"Y\" ver=\"2.5\" txn=\"" + txn + "\" dpID=\"\" rdsID=\"\" rdsVer=\"\" dc=\"\" mi=\"\" mc=\"\" deviceSrNO=\"NA\" deviceError=\"NA\" ip=\"NA\" fdc=\"NA\" idc=\"NC\" macadd=\"NA\" lot=\"P\" lov=\"302005\" ><deviceInfo fType=\"NA\" iCount=\"NA\" pCount=\"NA\" errCodeRDS=\"NA\" errInfoRDS=\"NA\" fCount=\"NA\" nmPoints=\"NA\" qScore=\"NA\" srno=\"NA\" deviceError=\"NA\" /><Skey ci=\"" + expiryDate + "\">" + encSessionKey + "</Skey><Hmac>" + encryptedHmacBytes + "</Hmac><Data type=\"X\">" + encXMLPIDDataNew + "</Data></authrequest>";


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(authXML);
                request.ContentType = "Application/xml";
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                request.Headers["appname"] = "Agriculture";

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    results = new StreamReader(responseStream).ReadToEnd();
                    // UpdateIdentifyMessage(results, null);
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(results); // suppose that myXmlString contains "<Names>...</Names>"
                    XmlNodeList xnList = xml.SelectNodes("//authresponse/auth");
                    string sa = "";
                    string txnid = "";
                    foreach (XmlNode xn in xnList)
                    {
                        sa = xn.Attributes["status"].Value;
                        txnid = xn.Attributes["txn"].Value;
                    }
                    if (sa.ToUpper() == "Y")
                    {
                        status = sa.ToUpper();
                        string SSOIDORAADHAREnc = PaymentEncriptionDec.EmitraEncrypt(adhar);
                        List<string[]> listx = new List<string[]>();
                        XmlNodeList xDataList = xml.SelectNodes("//authresponse/UidData/pi");
                        XmlNodeList xDataList1 = xml.SelectNodes("//authresponse/UidData/pht");
                        XmlNodeList xDataList2 = xml.SelectNodes("//authresponse/UidData/LData");
                        XmlNodeList xDataList3 = xml.SelectNodes("//authresponse/UidData/pa");
                        string address = "House : " + xDataList3[0].Attributes["house"].Value + " LandMark : " + xDataList3[0].Attributes["lm"].Value + " Street : " + xDataList3[0].Attributes["street"].Value + " District: " + xDataList3[0].Attributes["dist"].Value + " PIN: " + xDataList3[0].Attributes["pc"].Value + " State: " + xDataList3[0].Attributes["state"].Value;
                        listx.Add(new string[] { "Success", xDataList[0].Attributes["name"].Value, xDataList[0].Attributes["gender"].Value, xDataList[0].Attributes["dob"].Value, xDataList1[0].InnerText.ToString(), xDataList2[0].Attributes["name"].Value, SSOIDORAADHAREnc, xDataList3[0].Attributes["co"].Value, xDataList2[0].Attributes["co"].Value, address });
                        //listx.Add(new string[] { "Success", xDataList[0].Attributes["name"].Value, xDataList[0].Attributes["gender"].Value, xDataList[0].Attributes["dob"].Value, xDataList1[0].InnerText.ToString(), xDataList2[0].Attributes["name"].Value, SSOIDORAADHAREnc, xDataList3[0].Attributes["co"].Value.Split(':')[1], xDataList2[0].Attributes["co"].Value.Split(':')[1] });
                        dtb = ConvertListToDataTable(listx);
                    }
                    else if (sa.ToUpper() == "N")
                    {
                        XmlNodeList errorcodelist = xml.SelectNodes("authresponse/error");
                        XmlNodeList messagelist = xml.SelectNodes("authresponse/message");
                        errorcode = errorcodelist[0].InnerText.ToString();
                        if (errorcodelist[0].InnerText.ToString() == "K-100")
                        {
                            Errormsg = "Invalid OTP";
                        }
                        else if (errorcodelist[0].InnerText.ToString() == "952")
                        {
                            Errormsg = "Please Wait for 10 Mintues and try again";
                        }
                        else if (errorcodelist[0].InnerText.ToString() == "953")
                        {
                            Errormsg = "Please Wait for 30 Mintues and try again";
                        }
                        else if (errorcodelist[0].InnerText.ToString() == "112")
                        {
                            Errormsg = "Aadhaar number does not have both email and mobile.";
                        }
                        else if (errorcodelist[0].InnerText.ToString() == "337")
                        {
                            Errormsg = "UIDAI server not responding,Try again after some time.";
                        }
                        else if (errorcodelist[0].InnerText.ToString() == "K-999")
                        {
                            Errormsg = "Unknown error by UIDAI server";
                        }
                        else
                        {
                            Errormsg = messagelist[0].InnerText.ToString();
                        }
                        //errorcode = errorcodelist[0].InnerText.ToString();
                        //Errormsg = messagelist[0].InnerText.ToString();
                        //_txnid = Errormsg;
                        List<string[]> listx = new List<string[]>();
                        XmlNodeList xDataList = xml.SelectNodes("//authresponse/message");
                        listx.Add(new string[] { Errormsg, xDataList[0].InnerText });
                        dtb = ConvertListToDataTable(listx);
                    }
                    else
                    {
                        status = sa.ToUpper();
                        List<string[]> listx = new List<string[]>();
                        XmlNodeList xDataList = xml.SelectNodes("//authresponse/message");
                        listx.Add(new string[] { "Failed", xDataList[0].InnerText });
                        dtb = ConvertListToDataTable(listx);
                    }
                }
            }
            catch (Exception ex)
            {
                List<string[]> listx = new List<string[]>();
                listx.Add(new string[] { "Failed", ex.ToString() });
                dtb = ConvertListToDataTable(listx);
            }
            //string logid = new csCommon().InsertAadhaarServiceLogs(adhar, "VALIDATEOTP", authXML, results, txn, status, errorcode, "validate");
            return dtb;
        }
        public DataTable ValidateAadhaarOTP_Esign(string txn, string adhar, string otp, IConfiguration _configuration)
        {
            List<string[]> listx = new List<string[]>();
            DataTable dtb = new DataTable();
            string message = string.Empty;
            string status = "";
            string TransactionId = "";
            string ss = "";
            var decryOTP = otp;
            var decryTXN = txn;
            if (otp == "123456") // BYPAss "123456" with your test OTP value
            {
                // OTP Bypass Logic
                message = "Success (OTP Bypassed)";
                listx.Add(new string[] { "success", message });
                return ConvertListToDataTable(listx);
            }
            if (txn != "")
            {
                try
                {
                    string json = "{\"otp\":\"" + decryOTP + "\",\"transactionid\":\"" + decryTXN + "\"}";
                    string auacode = _configuration["AadharServiceDetails:ValidateAadhaarOTP_Esign"].ToString();
                    ss = WebRequestinJson(auacode, json, "application/json");
                    JObject root = (JObject)JObject.Parse(ss);
                    foreach (var item in root)
                    {
                        if (item.Key.ToLower() == "status")
                            status = item.Value.ToString().Replace("\"", "");
                        if (item.Key.ToLower() == "transactionid")
                            TransactionId = item.Value.ToString().Replace("\"", "");
                    }
                    if (status == "1")
                    {
                        message = "Success";
                        listx.Add(new string[] { "success", message });
                    }
                    else
                    {
                        message = "Invalid OTP!";
                        listx.Add(new string[] { "Failed", message });
                    }
                    dtb = ConvertListToDataTable(listx);
                }
                catch (Exception ex)
                {
                    listx.Add(new string[] { "Failed", ex.ToString() });
                    dtb = ConvertListToDataTable(listx);
                }

            }

            return dtb;
        }

        public static string GetEncryptedPIDXmlNew(string pidXml, string certPath, string ts, ref string certExpiryDate, ref string encSessionKey, ref string encHmac)
        {
            ENCRYPTER enc = new ENCRYPTER(certPath);
            byte[] pidXmlBytes = Encoding.UTF8.GetBytes(pidXml);
            byte[] session_key = enc.generateSessionKey();
            byte[] encrypted_skey = enc.encryptUsingPublicKey(session_key);
            byte[] encPidXmlBytes = enc.encryptUsingSessionKeyNew(session_key, pidXmlBytes, ts, false);
            byte[] hmac = enc.generateSha256Hash(pidXmlBytes);
            byte[] encHmacBytes = enc.encryptUsingSessionKeyNew(session_key, hmac, ts, true);

            encSessionKey = Convert.ToBase64String(encrypted_skey);
            encHmac = Convert.ToBase64String(encHmacBytes);
            certExpiryDate = enc.getCertificateIdentifier();
            return Convert.ToBase64String(encPidXmlBytes);
        }
        public static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();
            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }
            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }
            return table;
        }
        public static string Encrypt(string Text)
        {
            string Key = "681D392DB4FD7B8C6562712DFEEF1";
            string initVector = "tu89geji340t89u2";
            int keysize = 256;

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Encrypted = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(Encrypted);
        }

        public string GetIpAddress()  // Get IP Address
        {
            string ip = "";
            IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
            IPAddress[] addr = ipEntry.AddressList;
            ip = addr[1].ToString();
            return ip;
        }
        public static string GetCompCode()  // Get Computer Name
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            return strHostName;
        }
        #endregion

        #region "GetAadharByVID"
        public string GetAadharByVID(string _UUID, IConfiguration _configuration)
        {

            string _AadhaarNo = string.Empty;
            string subaua = _configuration["AadharServiceDetails:subaua"].ToString();
            // string subaua = "PNSCL22866";
            try
            {
                if (!string.IsNullOrEmpty(_UUID) && _UUID.Length == 15)
                {
                    string ip = GetIpAddress();
                    //string url = "https://api.sewadwaar.rajasthan.gov.in/app/live/Aadhaar/Prod/detokenizeV2/doitAadhaar/encDec/demo/hsm/auth?client_id=f6de7747-60d3-4cf0-a0ae-71488abd6e95";
                    string url = _configuration["AadharServiceDetails:GetAadhaarNoByVIDURL"].ToString();

                    string ModifiedData = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><AuthRequest UUID=\"" + _UUID + "\" subaua=\"" + subaua + "\" flagType=\"" + "A" + "\" ver=\"2.5\"></AuthRequest>";

                    System.Net.WebRequest req = null;
                    WebResponse rsp = null;
                    try
                    {
                        req = WebRequest.Create(url);
                        req.Method = "POST";
                        req.ContentType = "application/xml";
                        req.Headers["appname"] = "CO-Operative";
                        StreamWriter writer = new StreamWriter(req.GetRequestStream());
                        writer.Write(ModifiedData);
                        writer.Close();
                        rsp = req.GetResponse();
                        StreamReader sr = new StreamReader(rsp.GetResponseStream());
                        string results = sr.ReadToEnd();
                        sr.Close();
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(results);
                        XmlNodeList xnList = xml.SelectNodes("/DSMTokanize");
                        string sa = "";
                        foreach (XmlNode xn in xnList)
                        {
                            sa = xn["status"].InnerText;
                            if (sa.ToUpper() == "Y")
                                _AadhaarNo = xn["AadhaarNo"].InnerText;
                            else
                                _AadhaarNo = "NO";
                        }
                        if (sa.ToUpper() == "N")
                        {

                            _AadhaarNo = "NO";
                        }
                    }
                    catch (Exception ex)
                    {
                        _AadhaarNo = "NO#" + ex.Message;
                    }
                }
                else
                {
                    _AadhaarNo = "NO" + "#" + "ReferenceId Not Found.";
                }
            }
            catch (Exception ex)
            {
                _AadhaarNo = "NO" + "#" + "ReferenceId Not Found";
                CommonDataAccessHelper.Insert_ErrorLog("GetAadharByVID", ex.ToString());
            }
            return _AadhaarNo;
        }
        #endregion

        public string eSignPDF(string PDFFileName, string OTPTransactionID, int DepartmentID, int ParamID, IConfiguration _configuration)
        {
            string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF") + "/" + PDFFileName;
            var str = GenerateEsign_PDF(pdfPath, OTPTransactionID, DepartmentID, ParamID, "MSKY", _configuration);
            return str;
        }

        public string GenerateEsign_PDF(string pdfPath, string txn, int DepartmentID, int ParamID, string formType, IConfiguration _configuration)
        {
            string final_status = "";
            string final_document = "";
            string succmsg = string.Empty;
            try
            {

                byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfPath);
                string pdfBase64 = Convert.ToBase64String(pdfBytes);
                string url = _configuration["AadharServiceDetails:eSignMultipleSignAgri"].ToString();
                string json2 = "";

                if (DepartmentID == 5)
                {
                    json2 = "{\"inputJson\":{\"File\":\"" + pdfBase64 + "\"},\"transactionid\":\"" + txn + "\",\"docname\":\"" + Path.GetFileName(pdfPath) + "\",\"designation\": \"\",\"status\":\"SelfAttested\",\"llx\":\"370\",\"lly\":\"230\",\"positionX\":\"420\",\"positionY\":\"170\",\"mode\":\"1\"}";
                }
                else
                {
                    json2 = "{\"inputJson\":{\"File\":\"" + pdfBase64 + "\"},\"transactionid\":\"" + txn + "\",\"docname\":\"" + Path.GetFileName(pdfPath) + "\",\"designation\": \"\",\"status\":\"SelfAttested\",\"llx\":\"350\",\"lly\":\"100\",\"positionX\":\"50\",\"positionY\":\"100\",\"mode\":\"1\"}";
                }
                string ss2 = WebRequestinJson(url, json2, "application/json");
                CommonDataAccessHelper.Insert_ErrorLog("AadharService.GenerateEsign_PDF", ss2);
                // string ss2 = WebRequestinJson(url, json2, "multipart/form-data");
                JObject root2 = (JObject)JObject.Parse(ss2);
                foreach (var item in root2)
                {
                    if (item.Key.ToLower() == "status")
                    {
                        final_status = item.Value.ToString();
                    }
                    else if (item.Key.ToLower() == "errormessage")
                    {
                        if (item.Value.ToString() == "The signature already exists")
                        {
                            succmsg = "Success";
                        }

                    }
                    else if (item.Key.ToLower() == "document")
                    {
                        final_document = item.Value.ToString().Replace("\"", "");
                        byte[] sPDFDecoded = Convert.FromBase64String(final_document);
                        string filepath = string.Empty;
                        filepath = "SystemGeneratedPDF/" + Path.GetFileName(pdfPath);

                        filepath = Path.Combine(Directory.GetCurrentDirectory(), filepath); //System.Web.Hosting.HostingEnvironment.MapPath("~/" + filepath);
                        FileStream stream = new FileStream(filepath, FileMode.Create);
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(sPDFDecoded, 0, sPDFDecoded.Length);
                        writer.Close();
                        FileInfo fi = new FileInfo(filepath);
                        succmsg = "Success";
                    }
                    else
                    {
                        //CommonDataAccessHelper.Insert_ErrorLog("AadharService.GenerateEsign_PDF", ss2);
                    }
                }

            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AadharService.GenerateEsign_PDF", ex.ToString());
                succmsg = ex.Message.ToString();
                throw;
            }
            return succmsg;
        }

        public string WebRequestinJson(string url, string postData, string contenttype)
        {
            string ret = string.Empty;
            try
            {
                StreamWriter requestWriter;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 40000;

                    webRequest.ContentType = contenttype;
                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }
                }

                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                Stream resStream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                ret = reader.ReadToEnd();

            }
            catch (WebException wex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("AadharService.WebRequestinJson", wex.ToString());
            }
            return ret;
        }

    }

}
