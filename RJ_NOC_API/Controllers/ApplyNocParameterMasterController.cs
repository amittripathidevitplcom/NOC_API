using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/ApplyNocParameterMaster")]
    [ApiController]
    public class ApplyNocParameterMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ApplyNocParameterMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetApplyNocParameterMaster/{CollegeID}")]
        public async Task<OperationResult<List<ApplyNocParameterMaster_ddl>>> GetApplyNocParameterMaster(int CollegeID)
        {
            var result = new OperationResult<List<ApplyNocParameterMaster_ddl>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.GetApplyNocParameterMaster(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNocParameterMasterController.GetApplyNocParameterMaster", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveApplyNocApplication")]
        public async Task<OperationResult<bool>> SaveApplyNocApplication([FromBody] ApplyNocParameterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.SaveApplyNocApplication(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.ApplyNocApplicationID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", 0, "ApplyNocParameterMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Update", 0, "ApplyNocParameterMaster");
                        result.SuccessMessage = "Updateed successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.ApplyNocApplicationID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNocParameterMasterController.SaveApplyNocApplication", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

        [HttpGet("GetApplyNocFor_TNOCExtension/{CollegeID}/{ApplyNocFor}")]
        public async Task<OperationResult<ApplyNocParameterMaster_TNOCExtensionDataModel>> GetApplyNocFor_TNOCExtension(int CollegeID, string ApplyNocFor)
        {
            var result = new OperationResult<ApplyNocParameterMaster_TNOCExtensionDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.GetApplyNocFor_TNOCExtension(CollegeID, ApplyNocFor));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNocParameterMasterController.GetApplyNocFor_TNOCExtension", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetApplyNocFor_AdditionOfNewSeats60/{CollegeID}/{ApplyNocFor}")]
        public async Task<OperationResult<ApplyNocParameterMaster_AdditionOfNewSeats60DataModel>> GetApplyNocFor_AdditionOfNewSeats60(int CollegeID, string ApplyNocFor)
        {
            var result = new OperationResult<ApplyNocParameterMaster_AdditionOfNewSeats60DataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.GetApplyNocFor_AdditionOfNewSeats60(CollegeID, ApplyNocFor));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNocParameterMasterController.GetApplyNocFor_TNOCExtension", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetApplyNoc_FDRMasterByCollegeID/{CollegeID}")]
        public async Task<OperationResult<List<ApplyNocFDRDetailsDataModel>>> GetCommitteeMasterList(int CollegeID)
        {
            var result = new OperationResult<List<ApplyNocFDRDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.GetApplyNoc_FDRMasterByCollegeID(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommitteeMasterController.GetCommitteeMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveApplyNoc_FDRMasterDetail")]
        public async Task<OperationResult<bool>> SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {

                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.SaveApplyNoc_FDRMasterDetail(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.ApplyNocFDRID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "CommitteeMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.ApplyNocFDRID, "CommitteeMaster");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.ApplyNocFDRID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNocParameterMasterController.SaveApplyNoc_FDRMasterDetail", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetApplyNocFDRDetails/{ApplyNocFDRID}/{ApplyNocID}")]
        public async Task<OperationResult<List<ApplyNocFDRDetailsDataModel>>> GetApplyNocFDRDetails(int ApplyNocFDRID,int ApplyNocID)
        {
            var result = new OperationResult<List<ApplyNocFDRDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNocParameterMasterUtility.GetApplyNocFDRDetails(ApplyNocFDRID, ApplyNocID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CommitteeMasterController.GetCommitteeMasterList", ex.ToString());
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

