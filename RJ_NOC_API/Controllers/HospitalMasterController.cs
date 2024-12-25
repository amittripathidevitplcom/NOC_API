using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Azure.Core;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/HospitalMaster")]
    [ApiController]
    public class HospitalMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public HospitalMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetHospitalAreaValidation")]
        public async Task<OperationResult<List<HospitalAreaValidation>>> GetHospitalAreaValidation()
        {
            var result = new OperationResult<List<HospitalAreaValidation>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.GetHospitalAreaValidation());
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
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.GetHospitalAreaValidation", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("GetDataList/{collegeId}")]
        public async Task<OperationResult<List<HospitalMasterDataModel>>> GetDataList(int collegeId)
        {
            var result = new OperationResult<List<HospitalMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.GetDataList(collegeId));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.GetDataList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetData/{hospitalId}")]
        public async Task<OperationResult<HospitalMasterDataModel>> GetData(int hospitalId)
        {
            var result = new OperationResult<HospitalMasterDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.GetData(hospitalId));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.GetData", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData([FromBody] HospitalMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.HospitalID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", 0, "HospitalMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Update", 0, "HospitalMaster");
                        result.SuccessMessage = "Updateed successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.HospitalID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpPost("DeleteData/{hospitalId}/{modifiedBy}")]
        public async Task<OperationResult<bool>> DeleteData(int hospitalId, int modifiedBy)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.DeleteData(hospitalId, modifiedBy));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "Delete", 0, "HospitalMaster");
                }
                else
                {
                    result.State = OperationState.Error;
                    result.SuccessMessage = "There was an error deleting data.!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "Delete", 0, "HospitalMaster");
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("IsSuperSpecialtyHospital/{collegeId}")]
        public async Task<OperationResult<bool>> IsSuperSpecialtyHospital(int collegeId)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.IsSuperSpecialtyHospital(collegeId));
                result.State = OperationState.Success;
                if (result.Data)
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
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.GetData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetHospitalDataListforPDF/{CollegeID}")]
        public async Task<OperationResult<List<HospitalMasterDataModel>>> GetHospitalDataListforPDF(int CollegeID)
        {
            var result = new OperationResult<List<HospitalMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.GetHospitalDataListforPDF(CollegeID));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.GetHospitalDataListforPDF", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpPost("SaveMGThreeHospitalData")]
        public async Task<OperationResult<bool>> SaveMGThreeHospitalData([FromBody] MGThreeHospitalDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HospitalMasterUtility.SaveMGThreeHospitalData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.HospitalID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.CollegeID, "Save", 0, "HospitalMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.CollegeID, "Update", 0, "HospitalMaster");
                        result.SuccessMessage = "Updateed successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.HospitalID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HospitalMasterController.SaveMGThreeHospitalData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }
    }
}

