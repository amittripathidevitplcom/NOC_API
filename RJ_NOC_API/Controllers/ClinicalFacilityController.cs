using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ClinicalFacility")]
    [ApiController]
    public class ClinicalFacilityController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ClinicalFacilityController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetAllClinicalFacilityList/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllClinicalFacilityList(int UserID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllClinicalFacilityList", 0, "ClinicalFacility");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClinicalFacility.GetCourseClinicalFacilityList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ClinicalFacility.GetCourseClinicalFacilityList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(ClinicalFacilityModel clinicalFacility)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClinicalFacility.SaveData(clinicalFacility));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (clinicalFacility.FacilityList.Select(a => a.CollegeFacilityID).FirstOrDefault() == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(clinicalFacility.UserId, "Save", 0, "ClinicalFacility");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(clinicalFacility.UserId, "Update", clinicalFacility.CollegeID, "ClinicalFacility");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (clinicalFacility.FacilityList.Select(a=>a.CollegeFacilityID).FirstOrDefault() == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ClinicalFacilityController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetCollegeClinicalFacilityList/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetCollegeClinicalFacilityList(int UserID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetCollegeClinicalFacilityList", 0, "ClinicalFacility");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClinicalFacility.GetCollegeClinicalFacilityList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ClinicalFacility.GetCollegeClinicalFacilityList", ex.ToString());
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
