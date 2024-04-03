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


    }
}
