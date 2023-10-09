using ikvm.@internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using System.Data;
using static com.sun.tools.classfile.Dependency;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ImportExcelData")]
    [ApiController]
    public class ImportExcelDataController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ImportExcelDataController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<OperationResult<bool>> SaveData(ImportExcelDataDataModel request)
        {
            var result = new OperationResult<bool>();
            object dataString = request.Data[0].ToString();

            List<MemberDataModel> PartyJson = null;
            if ((request.Data != null) && (request.Data.ToString() != ""))
            {
                PartyJson = JsonConvert.DeserializeObject<List<MemberDataModel>>(request.Data[0].ToString());
            }

            string Check_MembershipNo = "";
            string Check_CasteCategory = "";
            string check_Gender = "";
            string Check_PHMinorty = "";
            string Check_Section = "";

            try
            {
                bool isSave = true;
                if (PartyJson.Count == 0)
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "Invalid excel file.!";
                    return result;
                }
                foreach (var data in PartyJson)
                {

                    if ((data.Course == null) || (data.Course == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Course is required.!";
                        return result;
                    }
                    if ((data.Subject == null) || (data.Subject == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Subject is required.!";
                        return result;
                    }
                    if ((data.StudentName == null) || (data.StudentName == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Student Name is required.!";
                        return result;
                    }
                    if ((data.FatherName == null) || (data.FatherName == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Father Name is required.!";
                        return result;
                    }
                    if ((data.DOB == null) || (data.DOB == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " DOB is required.!";
                        return result;
                    }
                    if ((data.Gender == null) || (data.Gender == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Gender is required.!";
                        return result;
                    }
                    if ((data.Cast == null) || (data.Cast == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Caste category is required.!";
                        return result;
                    }

                    if ((data.Section == null) || (data.Section == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Section is required.!";
                        return result;
                    }

                    if ((data.RollNo == null) || (data.RollNo == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " RollNo is required.!";
                        return result;
                    }

                    if ((data.Year == null) || (data.Year == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " Year is required.!";
                        return result;
                    }
                    if ((data.PH == null) || (data.PH == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " PH is required.!";
                        return result;
                    }

                    if ((data.Minorty == null) || (data.Minorty == ""))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " PH is required.!";
                        return result;
                    }

                    string[] Category = { "OBC", "GEN", "ST", "SC", "SBC", "EWS" };
                    if ((data.Cast != null) || (data.Cast != ""))
                    {
                        int index = Array.IndexOf(Category, data.Cast);
                        if (index == -1)
                        {
                            Check_CasteCategory += data.Cast + System.Environment.NewLine;
                        }
                    }


                    string[] CheckGender = { "M", "F", "T" };
                    if ((data.Gender != null) && (data.Gender != ""))
                    {
                        int index = Array.IndexOf(CheckGender, data.Gender);
                        if (index == -1)
                        {
                            check_Gender += data.Gender + System.Environment.NewLine;
                        }
                    }

                    string[] PHMinorty = { "YES", "NO" };
                    if ((data.PH != null) && (data.PH != ""))
                    {
                        int index = Array.IndexOf(PHMinorty, data.PH);
                        if (index == -1)
                        {
                            Check_PHMinorty += data.PH + System.Environment.NewLine;
                        }
                    }

                    if ((data.Minorty != null) && (data.Minorty != ""))
                    {
                        int index = Array.IndexOf(PHMinorty, data.Minorty);
                        if (index == -1)
                        {
                            Check_PHMinorty += data.Minorty + System.Environment.NewLine;
                        }
                    }

                    string[] Section = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "W", "X", "Y", "Z" };
                    if ((data.Section != null) && (data.Section != ""))
                    {
                        int index = Array.IndexOf(Section, data.Section);
                        if (index == -1)
                        {
                            Check_Section += data.Section + System.Environment.NewLine;
                        }
                    }

                }
                if (isSave == true)
                {
                    if (Check_CasteCategory != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid  Caste Category : " + Check_CasteCategory + ". Like Expmaple Valid is (OBC, GEN, ST, SC,SBC,EWS)!";
                        return result;

                    }
                    if (check_Gender != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid Gender : " + check_Gender + ".Like Expmaple Valid is (M,F,T) !";
                        return result;

                    }
                    if (Check_PHMinorty != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid PH/Minorty : " + Check_PHMinorty + ".Like Expmaple Valid is (YES, NO) !";
                        return result;

                    }
                    if (Check_Section != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid Section : " + Check_Section + ".Like Expmaple Valid is (A,B,C,D,E,F,G,H,I........) !";
                        return result;

                    }
                }

                if (isSave == true)
                {
                    result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.SaveExcelData(PartyJson, request.StaticsFileID, request.DepartmentID, request.CollegeID, request.CourseID, request.FinancialYear, request.FileName, request.SSOID));

                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "There was an error adding data.!";
                    }
                }

            }
            catch (Exception e)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost]
        public async Task<OperationResult<bool>> UpdateSingleRow(MemberDataModel data)
        {
            var result = new OperationResult<bool>();
            string Check_MembershipNo = "";
            string Check_CasteCategory = "";
            string check_Gender = "";
            string Check_PHMinorty = "";
            string Check_Section = "";

            try
            {
                bool isSave = true;


                if ((data.Course == null) || (data.Course == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Course is required.!";
                    return result;
                }
                if ((data.Subject == null) || (data.Subject == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Subject is required.!";
                    return result;
                }
                if ((data.StudentName == null) || (data.StudentName == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Student Name is required.!";
                    return result;
                }
                if ((data.FatherName == null) || (data.FatherName == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Father Name is required.!";
                    return result;
                }
                if ((data.DOB == null) || (data.DOB == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " DOB is required.!";
                    return result;
                }
                if ((data.Gender == null) || (data.Gender == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Gender is required.!";
                    return result;
                }
                if ((data.Cast == null) || (data.Cast == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Caste category is required.!";
                    return result;
                }

                if ((data.Section == null) || (data.Section == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Section is required.!";
                    return result;
                }

                if ((data.RollNo == null) || (data.RollNo == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " RollNo is required.!";
                    return result;
                }

                if ((data.Year == null) || (data.Year == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " Year is required.!";
                    return result;
                }
                if ((data.PH == null) || (data.PH == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " PH is required.!";
                    return result;
                }

                if ((data.Minorty == null) || (data.Minorty == ""))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = " PH is required.!";
                    return result;
                }

                string[] Category = { "OBC", "GEN", "ST", "SC", "SBC", "EWS" };
                if ((data.Cast != null) || (data.Cast != ""))
                {
                    int index = Array.IndexOf(Category, data.Cast);
                    if (index == -1)
                    {
                        Check_CasteCategory += data.Cast + System.Environment.NewLine;
                    }
                }


                string[] CheckGender = { "M", "F", "T" };
                if ((data.Gender != null) && (data.Gender != ""))
                {
                    int index = Array.IndexOf(CheckGender, data.Gender);
                    if (index == -1)
                    {
                        check_Gender += data.Gender + System.Environment.NewLine;
                    }
                }

                string[] PHMinorty = { "YES", "NO" };
                if ((data.PH != null) && (data.PH != ""))
                {
                    int index = Array.IndexOf(PHMinorty, data.PH);
                    if (index == -1)
                    {
                        Check_PHMinorty += data.PH + System.Environment.NewLine;
                    }
                }

                if ((data.Minorty != null) && (data.Minorty != ""))
                {
                    int index = Array.IndexOf(PHMinorty, data.Minorty);
                    if (index == -1)
                    {
                        Check_PHMinorty += data.Minorty + System.Environment.NewLine;
                    }
                }

                string[] Section = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "W", "X", "Y", "Z" };
                if ((data.Section != null) && (data.Section != ""))
                {
                    int index = Array.IndexOf(Section, data.Section);
                    if (index == -1)
                    {
                        Check_Section += data.Section + System.Environment.NewLine;
                    }
                }


                if (isSave == true)
                {
                    if (Check_CasteCategory != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid  Caste Category : " + Check_CasteCategory + ". Like Expmaple Valid is (OBC, GEN, ST, SC,SBC,EWS)!";
                        return result;

                    }
                    if (check_Gender != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid Gender : " + check_Gender + ".Like Expmaple Valid is (M,F,T) !";
                        return result;

                    }
                    if (Check_PHMinorty != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid PH/Minorty : " + Check_PHMinorty + ".Like Expmaple Valid is (YES, NO) !";
                        return result;

                    }
                    if (Check_Section != "")
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = " InValid Section : " + Check_Section + ".Like Expmaple Valid is (A,B,C,D,E,F,G,H,I........) !";
                        return result;

                    }
                }

                if (isSave == true)
                {
                    result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.UpdateSingleRow(data, 0, 0, ""));

                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        result.SuccessMessage = "Update successfully .!";
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "There was an error adding data.!";
                    }
                }

            }
            catch (Exception e)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetImportExcelData/{SSOID}/{DeptId}/{CollegeID}/{StaticsFileID}/{ActionType}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetImportExcelData(string SSOID, int DeptId, int CollegeID, int StaticsFileID, string ActionType)
        {
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.GetImportExcelData(SSOID, DeptId, CollegeID, StaticsFileID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommonFuncationController.GetImportExcelData", ex.ToString());
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
