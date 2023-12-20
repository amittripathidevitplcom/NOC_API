using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections;
using static System.Diagnostics.Activity;
using System.Security.Cryptography;
using System.Net;
using RJ_NOC_Model;
using Newtonsoft.Json.Linq;
using static Azure.Core.HttpHeader;
using Org.BouncyCastle.Ocsp;
using iTextSharp.text.pdf.qrcode;
using static System.Runtime.InteropServices.JavaScript.JSType;
using QRCoder;
using Microsoft.Extensions.Primitives;

namespace RJ_NOC_DataAccess.Common
{
    public class CommonHelper
    {
        //private IConfiguration _configuration { get; }
        private static IConfiguration _configuration;
        string sqlConnectionStaring = "";
        static string sqlConnectionStaringSys = "";
        public CommonHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            //sqlConnectionStaring = _configuration.GetConnectionString("DefaultConnection");
            sqlConnectionStaring = AppSetting.ConnectionString;
            sqlConnectionStaringSys = AppSetting.ConnectionString;
            //sqlConnectionStaringSys = _configuration.GetConnectionString("DefaultConnection");
        }
        public static string ConvertDataTable(DataTable dt)
        {
            //List<T> data = new List<T>();

            var json = JsonConvert.SerializeObject(dt);
            return json;


            //List<T> data = new List<T>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    T item = GetItem<T>(row);
            //    data.Add(item);
            //}
            //return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static string GetVisitorIPAddress(bool GetLan = false)
        {
            //   GetLan = false;
            var visitorIPAddress = "0.0.0.0";//HttpContext.Connection.RemoteIpAddress.ToString();
            //var visitorIPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return visitorIPAddress;
        }

        public static string GetDetailsTableQry(object request, string HashTableName)
        {
            var result = ((IEnumerable)request).Cast<object>().ToList();

            string CandidateInfo_Str = " select * INTO ##" + HashTableName + " from ( select  ";
            int countRows = 1;
            foreach (object item in result)
            {
                if (item == null) continue;
                foreach (PropertyInfo property in item.GetType().GetProperties())
                {
                    var Key = property.Name;
                    var Value = property.GetValue(item, null);
                    CandidateInfo_Str += "''" + AvoidSQLInjection_Char(Value?.ToString()) + "'' as ''" + Key + "'',";
                }
                if (CandidateInfo_Str != "")
                {
                    CandidateInfo_Str = CandidateInfo_Str.Remove(CandidateInfo_Str.Length - 1, 1);
                }

                if (countRows < result.Count)
                {
                    CandidateInfo_Str += " union all select ";
                }
                countRows++;
            }
            CandidateInfo_Str += " ) table1";

            return CandidateInfo_Str;
        }

        public static string AvoidSQLInjection_Char(string str)
        {
            str = str?.Trim();
            str = str?.Replace("'", "");
            str = str?.Replace("==", "=");
            return str;
        }

        private static string _privateKey= "DevITNOT";
        private static string _publicKey= "DevITNOT";
        private static UnicodeEncoding _encoder = new UnicodeEncoding();
        public static string Encrypt(string textToEncrypt, string EncryptionPassword = "DevITNOT")
        {
            var sb = new StringBuilder();
            var bytes = Encoding.Unicode.GetBytes(textToEncrypt);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"

            //string Text = "";
            //byte[] data = UTF8Encoding.UTF8.GetBytes(textToEncrypt);
            //using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            //{
            //    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(EncryptionPassword));
            //    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            //    {
            //        ICryptoTransform transform = tripDes.CreateEncryptor();
            //        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            //        Text = Convert.ToBase64String(results, 0, results.Length);
            //    }
            //}
            //return Text;
            //MemoryStream memStream = null;
            //try
            //{
            //    byte[] key = { };
            //    byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
            //    key = Encoding.UTF8.GetBytes(EncryptionPassword);
            //    byte[] byteInput = Encoding.UTF8.GetBytes(textToEncrypt);
            //    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            //    memStream = new MemoryStream();
            //    ICryptoTransform transform = provider.CreateEncryptor(key, IV);
            //    CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
            //    cryptoStream.Write(byteInput, 0, byteInput.Length);
            //    cryptoStream.FlushFinalBlock();
            //}
            //catch (Exception ex)
            //{
            //    //Response.Write(ex.Message);
            //}
            //return Convert.ToBase64String(memStream.ToArray());
        }
        public static string Decrypt(string textToDecrypt, string EncryptionPassword = "DevITNOT")
        {
            var bytes = new byte[textToDecrypt.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(textToDecrypt.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
            //MemoryStream memStream = null;
            //try
            //{
            //    byte[] key = { };
            //    byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
            //    key = Encoding.UTF8.GetBytes(EncryptionPassword);
            //    byte[] byteInput = new byte[textToDecrypt.Length];
            //    byteInput = Convert.FromBase64String(textToDecrypt);
            //    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            //    memStream = new MemoryStream();
            //    ICryptoTransform transform = provider.CreateDecryptor(key, IV);
            //    CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
            //    cryptoStream.Write(byteInput, 0, byteInput.Length);
            //    cryptoStream.FlushFinalBlock();
            //}
            //catch (Exception ex)
            //{
            //    //Response.Write(ex.Message);
            //}

            //Encoding encoding1 = Encoding.UTF8;
            //return encoding1.GetString(memStream.ToArray());
        }

        public static string SendSMS(SMSConfigurationSetting sMSConfigurationSetting, string MobileNo, string Message, string TemplateID, string language = "ENG")
        {
            string RetrunValue = "";
            try
            {
                var Model = new UNOCSmsModel
                {
                    Language = language,
                    Message = Message,
                    MobileNo = new List<string> { MobileNo },
                    ServiceName = sMSConfigurationSetting.ServiceName,
                    UniqueID = sMSConfigurationSetting.UniqueID
                };

                var response = string.Empty;
                WebRequest request = (HttpWebRequest)WebRequest.Create(sMSConfigurationSetting.SMSUrl + "?client_id=" + sMSConfigurationSetting.SmsClientID);
                request.ContentType = "application/json";
                request.Method = "POST";
                request.Headers.Add("username", sMSConfigurationSetting.SMSUserName);
                request.Headers.Add("password", sMSConfigurationSetting.SMSPassWord);
                var inputJsonSer = System.Text.Json.JsonSerializer.Serialize(Model);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(inputJsonSer);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                var outputJsonDser = System.Text.Json.JsonSerializer.Deserialize<SmsResponseModel>(response);
                outputJsonDser.TrustType = "Final Save";
                outputJsonDser.responseID = MobileNo;
                RetrunValue = outputJsonDser.responseMessage.ToString();
            }
            catch (WebException ex)
            {
                //SmsResponseModel res = new SmsResponseModel();
                //res.responseCode = 200;
                //res.responseID = "1234556789";
                RetrunValue = "Request send Successfully";
                //var outputJsonDser = res;
                //return outputJsonDser;
                throw ex;
            }

            return RetrunValue;

        }

        public static T ConvertDataTable<T>(DataTable dt)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dt);
                if (typeof(T).Name != "List`1")
                {
                    json = json.TrimStart('[').TrimEnd(']');
                }
                var obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static byte[] GenerateQrCode(string qrmsg)
        {
            string code = qrmsg;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);

            using (System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    return byteImage;
                }
            }
        }

        #region "User Define Function"
        public static string GenerateTransactionNumber()
        {
            // Generate a new GUID.
            Guid guid = Guid.NewGuid();

            // Convert the first 6 bytes of the GUID to a byte array.
            byte[] bytes = guid.ToByteArray();

            // Take the first 6 bytes and convert them to a hexadecimal string.
            string hexString = BitConverter.ToString(bytes, 0, 6).Replace("-", "");

            Random rnd = new Random();
            //Create a 12-character transaction number from the hexadecimal string.
            string transactionNumber = rnd.Next(10000, 99999) + hexString;
            return transactionNumber;
        }
        #endregion

    }

}
