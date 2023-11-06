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
                string ErrorMsg;
                foreach (var data in PartyJson)
                {
                    cont++;                    

                    // validate
                    if (!IsValidExcelData(request.FinancialYearName, cont, data, out ErrorMsg))
                    {
                        isSave = false;
                        result.State = OperationState.Warning;
                        result.ErrorMessage = ErrorMsg;
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

        [HttpPost("UpdateSingleRow/{FinancialYearName}")]
        public async Task<OperationResult<bool>> UpdateSingleRow(string FinancialYearName, MemberDataModel data)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool isSave = true;
                string ErrorMsg;

                // validate
                if (!IsValidExcelData(FinancialYearName, 0, data, out ErrorMsg))
                {
                    isSave = false;
                    result.State = OperationState.Warning;
                    result.ErrorMessage = ErrorMsg;
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

        private bool IsValidExcelData(string FinancialYearName, int cont, MemberDataModel data, out string ErrorMsg)
        {
            string[] CheckGender = { "M", "F", "T" };
            string[] Category = { "OBC", "GEN", "ST", "SC", "SBC", "EWS" };
            string[] YesNo = { "YES", "NO" };

            bool retStatus = true;
            string retMsg = string.Empty;

            if (FinancialYearName == "2022-2023" && string.IsNullOrWhiteSpace(data.ApplicationID))
            {
                retStatus = false;
                retMsg = $"Application ID is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (FinancialYearName == "2022-2023" && !Regex.IsMatch(data.ApplicationID ?? "", @"^\d{8}$"))
            {
                retStatus = false;
                retMsg = $"Invalid Application ID{(cont == 0 ? $" at row {cont}" : string.Empty)}. It should be 8 digit.";
            }
            else if (string.IsNullOrWhiteSpace(data.District))
            {
                retStatus = false;
                retMsg = $"District is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.CollegeName))
            {
                retStatus = false;
                retMsg = $"College Name is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.AISHECode))
            {
                retStatus = false;
                retMsg = $"AISHE Code is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (!Regex.IsMatch(data.AISHECode ?? "", @"^\d{5}$"))
            {
                retStatus = false;
                retMsg = $"Invalid AISHE Code{(cont == 0 ? $" at row {cont}" : string.Empty)}. It should be 5 digit.";
            }
            else if (string.IsNullOrWhiteSpace(data.StudentName))
            {
                retStatus = false;
                retMsg = $"Student Name is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.FatherName))
            {
                retStatus = false;
                retMsg = $"Father's Name is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.Gender))
            {
                retStatus = false;
                retMsg = $"Gender is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.Course))
            {
                retStatus = false;
                retMsg = $"Course is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.Subject))
            {
                retStatus = false;
                retMsg = $"Subject is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.Class))
            {
                retStatus = false;
                retMsg = $"Class is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.Cast))
            {
                retStatus = false;
                retMsg = $"Category is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.PH))
            {
                retStatus = false;
                retMsg = $"PH is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.Minorty))
            {
                retStatus = false;
                retMsg = $"Minorty is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.HasScholarship))
            {
                retStatus = false;
                retMsg = $"Scholarship is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.DOB))
            {
                retStatus = false;
                retMsg = $"Date of Birth is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (!Regex.IsMatch(data.DOB, @"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$"))
            {
                retStatus = false;
                retMsg = $"Invalid Date of Birth{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (dd.mm.yyyy or dd/mm/yyyy)!";
            }
            else if (string.IsNullOrWhiteSpace(data.StudentMobileNo))
            {
                retStatus = false;
                retMsg = $"Student Mobile No. is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (!Regex.IsMatch(data.StudentMobileNo, @"^\d{10}$"))
            {
                retStatus = false;
                retMsg = $"Invalid Student Mobile No.{(cont == 0 ? $" at row {cont}" : string.Empty)}. It should be 10 digit.";
            }
            else if (string.IsNullOrWhiteSpace(data.StudentEmailId))
            {
                retStatus = false;
                retMsg = $"Student Email is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (!Regex.IsMatch(data.StudentEmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                retStatus = false;
                retMsg = $"Invalid Student Email{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (test@gmail.com)!";
            }
            else if (string.IsNullOrWhiteSpace(data.PrincipalName))
            {
                retStatus = false;
                retMsg = $"Principal Name is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (string.IsNullOrWhiteSpace(data.PrincipalMobileNo))
            {
                retStatus = false;
                retMsg = $"Principal Mobile No. is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (!Regex.IsMatch(data.PrincipalMobileNo, @"^\d{10}$"))
            {
                retStatus = false;
                retMsg = $"Invalid Principal Mobile No.{(cont == 0 ? $" at row {cont}" : string.Empty)}. It should be 10 digit.";
            }
            else if (string.IsNullOrWhiteSpace(data.CollegeEmailId))
            {
                retStatus = false;
                retMsg = $"College Email is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else if (!Regex.IsMatch(data.CollegeEmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                retStatus = false;
                retMsg = $"Invalid College Email{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (test@gmail.com)!";
            }
            else if (!CheckGender.Contains(data.Gender))
            {
                retStatus = false;
                retMsg = $"InValid Gender{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (M,F,T)!";
            }
            else if (!Category.Contains(data.Cast))
            {
                retStatus = false;
                retMsg = $"InValid  Category{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (OBC, GEN, ST, SC,SBC,EWS)!";
            }
            else if (!YesNo.Contains(data.PH))
            {
                retStatus = false;
                retMsg = $"InValid PH{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (YES, NO)!";
            }
            else if (!YesNo.Contains(data.Minorty))
            {
                retStatus = false;
                retMsg = $"InValid Minorty{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (YES, NO)!";
            }
            else if (!YesNo.Contains(data.HasScholarship))
            {
                retStatus = false;
                retMsg = $"Invalid Scholarship{(cont == 0 ? $" at row {cont}" : string.Empty)}. Like Expmaple Valid is (YES, NO)!";
            }
            else if (data.HasScholarship == "YES" && string.IsNullOrWhiteSpace(data.ScholarshipName))
            {
                retStatus = false;
                retMsg = $"Scholarship Name is required{(cont == 0 ? $" at row {cont}" : string.Empty)}.";
            }
            else
            {
                retStatus = true;
            }

            return retStatus;
        }
    }
}
