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

namespace RJ_NOC_Utility.CustomerDomain
{
    public class AadharService : UtilityBase, IAadharService
    {
        public AadharService(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public CommonDataModel_DataTable SendOtpByAadharNo(CommonDataModel_AadharDataModel modal, IConfiguration _configuration)
        {
            return SendOtpByAadharNo(modal.AadharNo, "NOC", _configuration);

        }

        //public CommonDataModel_AadharDataModel VerifyAadhaarOTP(CommonDataModel_AadharDataModel modal)
        //{
        //    throw new NotImplementedException();
        //}



        #region "User Define Functiotion"

        public CommonDataModel_DataTable SendOtpByAadharNo(string _AadharNo, string modulename, IConfiguration _configuration)
        {

            CommonDataModel_DataTable obj = new CommonDataModel_DataTable();

            obj.data = new DataTable();
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
            obj.data = dt;
            return obj;
        }

        public  string GetIpAddress()  // Get IP Address
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



    }






}
