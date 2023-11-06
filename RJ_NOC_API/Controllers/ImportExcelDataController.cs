using ikvm.@internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using System.Data;
using System.Text.RegularExpressions;
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

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(ImportExcelDataDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                var PartyJson = request.Data;
                bool isSave = true;
                if (PartyJson == null || PartyJson.Count == 0)
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "Invalid excel file.!";
                    return result;
                }

                int cont = 0;
                foreach (var data in PartyJson)
                {
                    cont++;
                    if (request.FinancialYearName == "2022-2023" && string.IsNullOrWhiteSpace(data.ApplicationID))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Application ID is required at row : {cont}.!";
                        return result;
                    }
                    if (request.FinancialYearName == "2022-2023" && !Regex.IsMatch(data.ApplicationID ?? "", @"^\d{8}$"))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid Application ID at row : {cont}.! It should be 8 digit.";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.District))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"District is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.CollegeName))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"College Name is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.AISHECode))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"AISHE Code is required at row : {cont}.!";
                        return result;
                    }
                    if (!Regex.IsMatch(data.AISHECode ?? "", @"^\d{5}$"))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid AISHE Code at row : {cont}.! It should be 5 digit.";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.StudentName))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Student Name is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.FatherName))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Father's Name is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.Gender))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Gender is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.Course))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Course is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.Subject))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Subject is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.Class))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Class is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.Cast))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Category is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.PH))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"PH is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.Minorty))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Minorty is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.HasScholarship))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Scholarship is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.DOB))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Date of Birth is required at row : {cont}.!";
                        return result;
                    }
                    if (!Regex.IsMatch(data.DOB, @"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$"))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid Date of Birth at row : {cont}!. Like Expmaple Valid is (dd.mm.yyyy or dd/mm/yyyy)!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.StudentMobileNo))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Student Mobile No. is required at row : {cont}.!";
                        return result;
                    }
                    if (!Regex.IsMatch(data.StudentMobileNo, @"^\d{10}$"))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid Student Mobile No. at row : {cont}.! It should be 10 digit.";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.StudentEmailId))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Student Email is required at row : {cont}.!";
                        return result;
                    }
                    if (!Regex.IsMatch(data.StudentEmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid Student Email at row : {cont}!. Like Expmaple Valid is (test@gmail.com)!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.PrincipalName))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Principal Name is required at row : {cont}.!";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.PrincipalMobileNo))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Principal Mobile No. is required at row : {cont}.!";
                        return result;
                    }
                    if (!Regex.IsMatch(data.PrincipalMobileNo, @"^\d{10}$"))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid Principal Mobile No. at row : {cont}.! It should be 10 digit.";
                        return result;
                    }
                    if (string.IsNullOrWhiteSpace(data.CollegeEmailId))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"College Email is required at row : {cont}.!";
                        return result;
                    }
                    if (!Regex.IsMatch(data.CollegeEmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid College Email at row : {cont}!. Like Expmaple Valid is (test@gmail.com)!";
                        return result;
                    }

                    //    
                    string[] CheckGender = { "M", "F", "T" };
                    if (!CheckGender.Contains(data.Gender))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"InValid Gender at row : {cont}. Like Expmaple Valid is (M,F,T)!";
                        return result;
                    }

                    string[] Category = { "OBC", "GEN", "ST", "SC", "SBC", "EWS" };
                    if (!Category.Contains(data.Cast))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"InValid  Category at row : {cont} !. Like Expmaple Valid is (OBC, GEN, ST, SC,SBC,EWS)!";
                        return result;
                    }

                    string[] YesNo = { "YES", "NO" };
                    if (!YesNo.Contains(data.PH))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"InValid PH at row : {cont} !. Like Expmaple Valid is (YES, NO)!";
                        return result;
                    }
                    if (!YesNo.Contains(data.Minorty))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"InValid Minorty at row : {cont} !. Like Expmaple Valid is (YES, NO)!";
                        return result;
                    }
                    if (!YesNo.Contains(data.HasScholarship))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Invalid Scholarship at row : {cont} !. Like Expmaple Valid is (YES, NO)!";
                        return result;
                    }
                    if (data.HasScholarship == "YES" && string.IsNullOrWhiteSpace(data.ScholarshipName))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = $"Scholarship Name is required at row : {cont}.!";
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

        [HttpPost("UpdateSingleRow")]
        public async Task<OperationResult<bool>> UpdateSingleRow(MemberDataModel data)
        {
            var result = new OperationResult<bool>();

            try
            {
                var request = data;
                bool isSave = true;

                int cont = 1;
                if (string.IsNullOrWhiteSpace(data.District))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"District is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.CollegeName))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"College Name is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.AISHECode))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"AISHE Code is required at row : {cont}.!";
                    return result;
                }
                if (!Regex.IsMatch(data.AISHECode ?? "", @"^\d{5}$"))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid AISHE Code at row : {cont}.! It should be 5 digit.";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.StudentName))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Student Name is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.FatherName))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Father's Name is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.Gender))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Gender is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.Course))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Course is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.Subject))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Subject is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.Class))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Class is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.Cast))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Category is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.PH))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"PH is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.Minorty))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Minorty is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.HasScholarship))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Scholarship is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.DOB))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Date of Birth is required at row : {cont}.!";
                    return result;
                }
                if (!Regex.IsMatch(data.DOB, @"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$"))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid Date of Birth at row : {cont}!. Like Expmaple Valid is (dd.mm.yyyy or dd/mm/yyyy)!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.StudentMobileNo))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Student Mobile No. is required at row : {cont}.!";
                    return result;
                }
                if (!Regex.IsMatch(data.StudentMobileNo, @"^\d{10}$"))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid Student Mobile No. at row : {cont}.! It should be 10 digit.";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.StudentEmailId))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Student Email is required at row : {cont}.!";
                    return result;
                }
                if (!Regex.IsMatch(data.StudentEmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid Student Email at row : {cont}!. Like Expmaple Valid is (test@gmail.com)!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.PrincipalName))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Principal Name is required at row : {cont}.!";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.PrincipalMobileNo))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Principal Mobile No. is required at row : {cont}.!";
                    return result;
                }
                if (!Regex.IsMatch(data.PrincipalMobileNo, @"^\d{10}$"))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid Principal Mobile No. at row : {cont}.! It should be 10 digit.";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(data.CollegeEmailId))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"College Email is required at row : {cont}.!";
                    return result;
                }
                if (!Regex.IsMatch(data.CollegeEmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid College Email at row : {cont}!. Like Expmaple Valid is (test@gmail.com)!";
                    return result;
                }

                //    
                string[] CheckGender = { "M", "F", "T" };
                if (!CheckGender.Contains(data.Gender))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"InValid Gender at row : {cont}. Like Expmaple Valid is (M,F,T)!";
                    return result;
                }

                string[] Category = { "OBC", "GEN", "ST", "SC", "SBC", "EWS" };
                if (!Category.Contains(data.Cast))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"InValid  Category at row : {cont} !. Like Expmaple Valid is (OBC, GEN, ST, SC,SBC,EWS)!";
                    return result;
                }

                string[] YesNo = { "YES", "NO" };
                if (!YesNo.Contains(data.PH))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"InValid PH at row : {cont} !. Like Expmaple Valid is (YES, NO)!";
                    return result;
                }
                if (!YesNo.Contains(data.Minorty))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"InValid Minorty at row : {cont} !. Like Expmaple Valid is (YES, NO)!";
                    return result;
                }
                if (!YesNo.Contains(data.HasScholarship))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Invalid Scholarship at row : {cont} !. Like Expmaple Valid is (YES, NO)!";
                    return result;
                }
                if (data.HasScholarship == "YES" && string.IsNullOrWhiteSpace(data.ScholarshipName))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = $"Scholarship Name is required at row : {cont}.!";
                    return result;
                }

                if (isSave == true)
                {
                    result.Data = await Task.Run(() => UtilityHelper.CommonFuncationUtility.UpdateSingleRow(data, 0, 0, ""));

                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (data.ID > 0)
                            result.SuccessMessage = "Update successfully .!";
                        else
                            result.SuccessMessage = "Added successfully .!";

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
