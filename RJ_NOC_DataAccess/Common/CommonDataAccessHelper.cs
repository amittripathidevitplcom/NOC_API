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
using RJ_NOC_Model;
using Org.BouncyCastle.Asn1.Ocsp;


namespace RJ_NOC_DataAccess.Common
{
    public class CommonDataAccessHelper
    {
        //private IConfiguration _configuration { get; }
        private static IConfiguration _configuration;
        // string sqlConnectionStaring1 = "";
        string sqlConnectionStaring = "";
        static string sqlConnectionStaringSys = "";
        public CommonDataAccessHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionStaring = _configuration.GetConnectionString("DefaultConnection");
            sqlConnectionStaringSys = _configuration.GetConnectionString("DefaultConnection");

            //sqlConnectionStaring = AppSetting.ConnectionString;
            //sqlConnectionStaringSys = AppSetting.ConnectionString;
        }


        public void GetConnectionstr(ref string ConnectionString1, ref string ConnectionString2, ref string ConnectionString3)
        {
            ConnectionString1 = AppSetting.GetConnectionString();
            ConnectionString2 = sqlConnectionStaring;
            //ConnectionString3 = sqlConnectionStaring1; 
            ConnectionString3 = ""; ;
        }


        public DataTable Fill_DataTable(string SqlQuery, string FuncationName = "")
        {
            //string Connectionstr = AppSetting.GetConnectionString();
            using (SqlConnection con = new SqlConnection(sqlConnectionStaring))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        sda.SelectCommand.CommandTimeout = 600;
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog(FuncationName, ex.ToString());
                    throw new Exception(ex.ToString());

                    //throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public DataSet Fill_DataSet(string SqlQuery, string FuncationName = "")
        {
            using (SqlConnection con = new SqlConnection(sqlConnectionStaring))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        sda.SelectCommand.CommandTimeout = 600;
                        using (DataSet dataSet = new DataSet())
                        {
                            sda.Fill(dataSet);
                            return dataSet;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog(FuncationName, ex.ToString());
                    return null;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public int NonQuerry(string SqlQuery, string FuncationName = "")
        {
            int Rows = 0;
            DataTable dt = new DataTable();
            SqlTransaction transaction = null;
            using (var conn = new SqlConnection(sqlConnectionStaring))
            {
                try
                {
                    conn.Open();
                    //string Qry = "BEGIN TRY BEGIN TRANSACTION " + SqlQuery + " COMMIT TRANSACTION END TRY BEGIN CATCH IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION END CATCH";
                    string Qry = SqlQuery;
                    transaction = conn.BeginTransaction("createOrder");
                    using (var cmd = new SqlCommand(Qry, conn))
                    {
                        cmd.Transaction = transaction;
                        Rows += cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    CommonDataAccessHelper.Insert_ErrorLog(FuncationName, ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            return Rows;

        }

        public int ExecuteScalar(string SqlQuery, string FuncationName = "")
        {
            object Rows = 0;
            DataTable dt = new DataTable();
            SqlTransaction transaction = null;
            using (var conn = new SqlConnection(sqlConnectionStaring))
            {
                try
                {
                    conn.Open();
                    //string Qry = "BEGIN TRY BEGIN TRANSACTION " + SqlQuery + " COMMIT TRANSACTION END TRY BEGIN CATCH IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION END CATCH";
                    string Qry = SqlQuery;
                    transaction = conn.BeginTransaction("createOrder");
                    using (var cmd = new SqlCommand(Qry, conn))
                    {
                        cmd.Transaction = transaction;
                        Rows = cmd.ExecuteScalar();
                        if (Rows != null)
                        {
                            Rows = Convert.ToInt32(Rows);
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    CommonDataAccessHelper.Insert_ErrorLog(FuncationName, ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            return Convert.ToInt32(Rows);

        }


        public static int NonQuerrySys(string SqlQuery)
        {
            int Rows = 0;
            DataTable dt = new DataTable();
            //SqlTransaction transaction = null;
            using (var conn = new SqlConnection(sqlConnectionStaringSys))
            {
                try
                {
                    conn.Open();
                    string Qry = "BEGIN TRY BEGIN TRANSACTION " + SqlQuery + " COMMIT TRANSACTION END TRY BEGIN CATCH IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION END CATCH";
                    // transaction = conn.BeginTransaction("createOrder");
                    using (var cmd = new SqlCommand(Qry, conn))
                    {
                        //cmd.Transaction = transaction;
                        Rows += cmd.ExecuteNonQuery();
                        // transaction.Commit();
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Rows = 0;
                    //    transaction.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            return Rows;

        }


        #region Sys Log and Track funcaiton
        public static void Insert_TrnUserLog(int? UserID, string Action, int? PrimaryKey_ID, string CurrentPageName)
        {
            try
            {
                if (UserID == 0)
                {
                    UserID = 1;
                }
                string IPAddress = "0.0.0.0";
                string SqlQry = "   insert into TrnUserLog ";
                SqlQry += " (UserID, LoginUserID, PageName, Action, PrimaryKey_ID,IPAddress) ";
                SqlQry += " Values('" + UserID + "', (select top 1 UserLoginID from M_UserMaster where UId='" + UserID + "'), '" + CurrentPageName.ToString() + "', '" + Action.ToString() + "', '" + PrimaryKey_ID.ToString() + "','" + IPAddress.ToString() + "')";
                int Rows = NonQuerrySys(SqlQry);
            }
            catch (Exception ex)
            {
            }
        }
        public static void Insert_TrnTrackLog(string LogType, string LogMessage)
        {
            try
            {
                string SqlQry = "   insert into trn_TrackLog ";
                SqlQry += "  (LogType, LogMessage) ";
                SqlQry += "  Values('" + LogType + "', '" + LogMessage + "')  ";
                int Rows = NonQuerrySys(SqlQry);
            }
            catch (Exception ex)
            {
            }
        }
        public static void Insert_ErrorLog(string FunctionName, string ErrorMessage)
        {
            try
            {
                string SqlQry = "   insert into trn_ErrorLog ";
                SqlQry += "  (FunctionName, ErrorMessage) ";
                SqlQry += "  Values('" + FunctionName + "', '" + ErrorMessage.Replace("'", "") + "')  ";
                int Rows = NonQuerrySys(SqlQry);
            }
            catch (Exception ex)
            {
            }
        }

        public static int EGrassPaymentDetails_Req_Res(EGrassPaymentDetails_Req_Res req_Res)
        {
            int Rows = 0;
            try
            {
                string SqlQry = " exec USP_EGrassPaymentDetails_Req_Res_Save ";
                SqlQry += " @ApplyNocApplicationID='" + req_Res.ApplyNocApplicationID + "', ";
                SqlQry += " @DepartmentID='" + req_Res.DepartmentID + "',";
                SqlQry += " @Head_Name='" + req_Res.Head_Name + "',@Request_AUIN='" + req_Res.Request_AUIN + "', ";
                SqlQry += " @Request_CollegeName='" + req_Res.Request_CollegeName + "',";
                SqlQry += " @Request_SSOID='" + req_Res.Request_SSOID + "',";
                SqlQry += " @Request_AMOUNT='" + req_Res.Request_AMOUNT + "',";
                SqlQry += " @Request_MerchantCode='" + req_Res.Request_MerchantCode + "', ";
                SqlQry += " @Request_REGTINNO='" + req_Res.Request_REGTINNO + "',";
                SqlQry += " @Request_OfficeCode='" + req_Res.Request_OfficeCode + "',";
                SqlQry += " @Request_DepartmentCode='" + req_Res.Request_DepartmentCode + "',";
                SqlQry += " @Request_Checksum='" + req_Res.Request_Checksum + "', ";
                SqlQry += " @Request_ENCAUIN='" + req_Res.Request_ENCAUIN + "',";
                SqlQry += " @Request_Json='" + req_Res.Request_Json + "',";
                SqlQry += " @Request_JsonENC='" + req_Res.Request_JsonENC + "',";
                SqlQry += " @Response_CIN='" + req_Res.Response_CIN + "',";
                SqlQry += " @Response_BankReferenceNo='" + req_Res.Response_BankReferenceNo + "', ";
                SqlQry += " @Response_BANK_CODE='" + req_Res.Response_BANK_CODE + "',";
                SqlQry += " @Response_BankDate='" + req_Res.Response_BankDate + "',";
                SqlQry += " @Response_GRN='" + req_Res.Response_GRN + "',";
                SqlQry += " @Response_Amount='" + req_Res.Response_Amount + "',";
                SqlQry += " @Response_Status='" + req_Res.Response_Status + "', ";
                SqlQry += " @Response_checkSum='" + req_Res.Response_checkSum + "',@Response_Json='" + req_Res.Response_Json + "', ";
                SqlQry += " @Response_JsonENC='" + req_Res.Response_JsonENC + "' ";
                Rows = NonQuerrySys(SqlQry);
            }
            catch (Exception ex)
            {
                Insert_ErrorLog("PaymentController.EGrassPaymentDetails_Req_Res", ex.ToString());
                Rows = 0;
            }
            return Rows;
        }

        public static int GRAS_GetPaymentStatus_Req_Res(EGrassPaymentDetails_Req_Res req_Res)
        {
            int Rows = 0;
            try
            {
                string SqlQry = "  ";
                SqlQry += " exec USP_GRAS_PaymentStatusLog_Save  ";
                SqlQry += " @RequestData = '" + req_Res.Request_Json + "', ";
                SqlQry += " @ResponseDataEnc = '" + req_Res.Request_JsonENC + "', ";
                SqlQry += " @ResponseData = '" + req_Res.Response_Json + "', ";
                SqlQry += " @AUIN = '" + req_Res.Request_AUIN + "', ";
                SqlQry += " @CIN = '" + req_Res.Response_CIN + "', ";
                SqlQry += " @BankReferenceNo = '" + req_Res.Response_BankReferenceNo + "', ";
                SqlQry += " @BANK_CODE = '" + req_Res.Response_BANK_CODE + "', ";
                SqlQry += " @BankDate = '" + req_Res.Response_BankDate + "', ";
                SqlQry += " @GRN = '" + req_Res.Response_GRN + "', ";
                SqlQry += " @Amount = '" + req_Res.Response_Amount + "', ";
                SqlQry += " @Status = '" + req_Res.Response_Status + "', ";
                SqlQry += " @checkSum = '" + req_Res.Response_checkSum + "' ";
                Rows = NonQuerrySys(SqlQry);
            }
            catch (Exception ex)
            {
                Insert_ErrorLog("PaymentController.GRAS_GetPaymentStatus_Req_Res", ex.ToString());
                Rows = 0;
            }
            return Rows;
        }

        #endregion

        #region "Common convert file to base64 Function"
        public string ConvertTobase64(string FileName)
        {
            string base64Data = "";
            string path = "";
            string FullPath = "";

            try
            {
                path = "ImageFile/" + FileName;
                FullPath = Path.Combine(Directory.GetCurrentDirectory(), path);

                if (System.IO.File.Exists(FullPath))
                {
                    var bytes = File.ReadAllBytes(FullPath);
                    base64Data = "data:image/png;charset=utf-8;base64," + Convert.ToBase64String(bytes);
                }
                else
                {
                    path = "ImageFile/Noimage.png";
                    FullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
                    var bytes = File.ReadAllBytes(FullPath);
                    base64Data = "data:image/png;charset=utf-8;base64," + Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                base64Data = "";
            }
            return base64Data;
        }
        #endregion


        //Get
        public static DataTable GetEgrassDetails_DepartmentWise(int DepartmentID, string PaymentType)
        {
            string SqlQuery = "select * from M_EGrassDetails Where DepartmentID=" + DepartmentID + " and PaymentType='" + PaymentType + "' and ActiveStatus=1 and DeleteStatus=0 order by aid desc";
            using (SqlConnection con = new SqlConnection(sqlConnectionStaringSys))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog("GetEgrassDetails_DepartmentWise", ex.ToString());
                    throw new Exception(ex.ToString());

                    //throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public static DataTable GetEGrass_AUIN_Verify_Data(int EGrassPaymentAID)
        {
            string SqlQuery = "exec USP_EGrass_AUIN_Verify_Data @AID='" + EGrassPaymentAID + "'";
            using (SqlConnection con = new SqlConnection(sqlConnectionStaringSys))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog("GetEGrass_AUIN_Verify_Data", ex.ToString());
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static bool CAeSign_Req_Res(CAGetSignedXmlApiRequest req_Res)
        {
            int Rows = 0;
            try
            {
                string SqlQry = "exec USP_CAeSign_Req_Res_Req_Res_Save";
                SqlQry += " @ApplyNocApplicationID='" + req_Res.ApplyNocApplicationID + "', ";
                SqlQry += " @DepartmentID='" + req_Res.DepartmentID + "',";
                SqlQry += " @TransactionID='" + req_Res.TransactionID + "',";
                SqlQry += " @pdfFile1='" + req_Res.pdfFile1 + "',";
                SqlQry += " @PDFFileName='" + req_Res.PDFFileName + "',";
                SqlQry += " @SSOdisplayName='" + req_Res.SSOdisplayName + "',";
                SqlQry += " @Designation='" + req_Res.designation + "', ";
                SqlQry += " @esignResponseUrl='" + req_Res.esignResponseUrl + "',";
                SqlQry += " @eSignType='" + req_Res.eSignType + "',";
                SqlQry += " @ResponseJson='" + req_Res.ResponseJson + "',";
                SqlQry += " @RSDRequestUrl='" + req_Res.RSDRequestUrl + "', ";
                SqlQry += " @RedirectJson='" + req_Res.RedirectJson + "',";
                SqlQry += " @esignData='" + req_Res.esignData + "',";
                SqlQry += " @ESPRequestURL='" + req_Res.ESPRequestURL + "',";
                SqlQry += " @IPAddress='" + req_Res.IPAddress + "',";
                SqlQry += " @CreatedBy='" + req_Res.CreatedBy + "',";
                SqlQry += " @successFailureurl='" + req_Res.successFailureurl + "',";
                SqlQry += " @ResponseCode='" + req_Res.ResponseCode + "',";
                SqlQry += " @ResponseMessage='" + req_Res.ResponseMessage + "',";
                SqlQry += " @RequestType='" + req_Res.RequestType + "' ";


                Rows = NonQuerrySys(SqlQry);
                if (Rows > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Insert_ErrorLog("esignController.CAeSign_Req_Res", ex.ToString());
                return false;
            }

        }


        public static DataTable GetCAeSign_Req_Res(string TransactionID)
        {
            string SqlQuery = "exec USP_CAeSign_Req_Res_Req_Res_Save @TransactionID='" + TransactionID + "',@RequestType ='GetesignRSDURL'";
            using (SqlConnection con = new SqlConnection(sqlConnectionStaringSys))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog("GetCAeSign_Req_Res", ex.ToString());
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static DataTable GetCAeSignCredentials()
        {
            string SqlQuery = "exec USP_CAeSign_Req_Res_Req_Res_Save @RequestType ='GeteSignCredentials'";
            using (SqlConnection con = new SqlConnection(sqlConnectionStaringSys))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog("GetCAeSignCredentials", ex.ToString());
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public static DataTable GetCAeSignTransactionDetails(string TransactionID)
        {
            string SqlQuery = "exec USP_CAeSign_Req_Res_Req_Res_Save @TransactionID='" + TransactionID + "',@RequestType ='GetCAeSignTransactionDetails'";
            using (SqlConnection con = new SqlConnection(sqlConnectionStaringSys))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(SqlQuery, con))
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonDataAccessHelper.Insert_ErrorLog("GetCAeSignTransactionDetails", ex.ToString());
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

    }
}
