using ikvm.@internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;
using System.Data;
using System.Net;
using System.Xml;

namespace RJ_NOC_API.Controllers
{
    [Route("api/AadharService")]
    [ApiController]
    public class AadharServiceController : RJ_NOC_ControllerBase
    {

        private IConfiguration _configuration;
        public AadharServiceController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SendAadharOTP")]
        public DataTable SendAadharOTP(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                DataTable dt = UtilityHelper.AadharServiceUtility.SendOtpByAadharNo(Model, _configuration);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString().Contains("Service"))
                    {
                        urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                                dt.Rows[0][0].ToString() });
                    }
                    else
                    {
                        // insert row values
                        if (dt.Rows[0][0].ToString().Contains("DOIT"))
                        {
                            urldt.Rows.Add(new Object[]{
                                "success",0,
                               dt.Rows[0][0].ToString()});
                        }
                        else
                        {
                            urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                               dt.Rows[0][0].ToString()});
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
            }
            return urldt;
        }

          [HttpPost("SendOtpByAadharNo_Esign")]
        public DataTable SendOtpByAadharNo_Esign(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                DataTable dt = UtilityHelper.AadharServiceUtility.SendOtpByAadharNo_Esign(Model, _configuration);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString().Contains("Service"))
                    {
                        urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                                dt.Rows[0][0].ToString() });
                    }
                    else
                    {
                        // insert row values
                        if (dt.Rows[0][0].ToString().Contains("DOIT"))
                        {
                            urldt.Rows.Add(new Object[]{
                                "success",0,
                               dt.Rows[0][0].ToString()});
                        }
                        else
                        {
                            urldt.Rows.Add(new Object[]{
                                dt.Rows[0][0].ToString(),1,
                               dt.Rows[0][0].ToString()});
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
            }
            return urldt;
        }



        [HttpPost("ValidateAadharOTP")]
        public DataTable ValidateAadharOTP(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                //return string.Empty;
                PaymentEncriptionDec.EmitraEncrypt(Model.OTP);
                PaymentEncriptionDec.EmitraEncrypt(Model.TransactionNo);
                PaymentEncriptionDec.EmitraEncrypt(Model.AadharNo);
                DataTable dt = UtilityHelper.AadharServiceUtility.ValidateAadhaarOTP(Model, _configuration);
                //create table
                if (dt.Rows[0][0].ToString().ToLower().Contains("success"))
                {


                    urldt.Rows.Add(new Object[]{
                                "success",0,
                                CommonHelper.ConvertDataTable(dt)
                });
                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Invalid OTP!",1,
                                dt.Rows[0][0].ToString() });

                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
                CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.ValidateAadharOTP", ex.ToString());
            }
            return urldt;
        }

         [HttpPost("ValidateAadharOTP_Esign")]
        public DataTable ValidateAadharOTP_Esign(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                //return string.Empty;
                PaymentEncriptionDec.EmitraEncrypt(Model.OTP);
                PaymentEncriptionDec.EmitraEncrypt(Model.TransactionNo);
                PaymentEncriptionDec.EmitraEncrypt(Model.AadharNo);
                DataTable dt = UtilityHelper.AadharServiceUtility.ValidateAadhaarOTP_Esign(Model, _configuration);
                //create table
                if (dt.Rows[0][0].ToString().ToLower().Contains("success"))
                {


                    urldt.Rows.Add(new Object[]{
                                "success",0,
                                CommonHelper.ConvertDataTable(dt)
                });
                }
                else
                {
                    urldt.Rows.Add(new Object[]{
                                "Invalid OTP!",1,
                                dt.Rows[0][0].ToString() });

                }
            }
            catch (Exception ex)
            {
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                                "Please try again"
                                });
                CommonDataAccessHelper.Insert_ErrorLog("Aadharservice.ValidateAadharOTP", ex.ToString());
            }
            return urldt;
        }



        [HttpPost("GetAadharByVID")]
        public DataTable GetAadharByVID(CommonDataModel_AadharDataModel Model)
        {
            var urldt = new System.Data.DataTable("tableName");
            // create fields
            urldt.Columns.Add("message", typeof(string));
            urldt.Columns.Add("status", typeof(int));
            urldt.Columns.Add("data", typeof(string));
            try
            {
                string strResult = UtilityHelper.AadharServiceUtility.GetAadharByVID(Model, _configuration);
                if (!string.IsNullOrEmpty(strResult))
                {
                    if (strResult.Contains("NO"))
                    {
                        urldt.Rows.Add(new Object[]{
                                "Failed",1,
                                strResult });

                    }
                    else
                    {
                        //create table
                        urldt.Rows.Add(new Object[]{
                                "success",0,
                                strResult });
                    }
                }
                else
                {
                    //create table
                    urldt.Rows.Add(new Object[]{
                                "Failed",1,
                                "something went wrong" });

                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("GetAadharByVID.SaveData", ex.ToString());
                urldt.Rows.Add(new Object[]{
                                "Please try again",1,
                               ex.Message
                                });
            }
            return urldt;
        }


        [HttpGet("eSignPDF/{PDFPath}/{OTPTransactionID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> eSignPDF(string PDFFileName, string OTPTransactionID, IConfiguration _configuration)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.AadharServiceUtility.eSignPDF(PDFFileName, OTPTransactionID, _configuration));
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.eSignPDF", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


    }
}