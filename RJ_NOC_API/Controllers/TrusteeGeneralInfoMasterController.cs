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
    [Route("api/TrusteeGeneralInfoMaster")]
    [ApiController]
    public class TrusteeGeneralInfoMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public TrusteeGeneralInfoMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetDataOfLegalEntity/{ssoId}")]
        public async Task<OperationResult<LegalEntityDataModel>> GetDataOfLegalEntity(string ssoId)
        {
            var result = new OperationResult<LegalEntityDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.TrusteeGeneralInfoMasterUtility.GetDataOfLegalEntity(ssoId));
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
                CommonDataAccessHelper.Insert_ErrorLog("TrusteeGeneralInfoMasterController.GetDataOfLegalEntity", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDataList/{legalEntityID}")]
        public async Task<OperationResult<List<TrusteeGeneralInfoMasterDataModel>>> GetDataList(int legalEntityID)
        {
            var result = new OperationResult<List<TrusteeGeneralInfoMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.TrusteeGeneralInfoMasterUtility.GetDataList(legalEntityID));
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
                CommonDataAccessHelper.Insert_ErrorLog("TrusteeGeneralInfoMasterController.GetDataList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetData/{TrusteeGeneralInfoId}")]
        public async Task<OperationResult<TrusteeGeneralInfoMasterDataModel>> GetData(int TrusteeGeneralInfoId)
        {
            var result = new OperationResult<TrusteeGeneralInfoMasterDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.TrusteeGeneralInfoMasterUtility.GetData(TrusteeGeneralInfoId));
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
                CommonDataAccessHelper.Insert_ErrorLog("TrusteeGeneralInfoMasterController.GetData", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData([FromBody] TrusteeGeneralInfoMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.TrusteeGeneralInfoMasterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.TrusteeGeneralInfoID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", 0, "TrusteeGeneralInfoMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Update", 0, "TrusteeGeneralInfoMaster");
                        result.SuccessMessage = "Updateed successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.TrusteeGeneralInfoID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("TrusteeGeneralInfoMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpPost("DeleteData/{TrusteeGeneralInfoId}/{modifiedBy}")]
        public async Task<OperationResult<bool>> DeleteData(int TrusteeGeneralInfoId, int modifiedBy)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.TrusteeGeneralInfoMasterUtility.DeleteData(TrusteeGeneralInfoId, modifiedBy));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "Delete", 0, "TrusteeGeneralInfoMaster");
                }
                else
                {
                    result.State = OperationState.Error;
                    result.SuccessMessage = "There was an error deleting data.!";
                    CommonDataAccessHelper.Insert_TrnUserLog(modifiedBy, "Delete", 0, "TrusteeGeneralInfoMaster");
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("TrusteeGeneralInfoMasterController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

    }
}

