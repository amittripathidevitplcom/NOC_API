using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Cors;
using RJ_NOC_DataAccess;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Authorization;
using RJ_NOC_API.AuthModels;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    //[CustomeAuthorize]
    [Route("api/DTECommitteeMaster")]
    [ApiController]
    public class DTECommitteeMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DTECommitteeMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]

        public async Task<OperationResult<bool>> SaveData(DTECommitteeMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.DTECommitteeMasterUtility.IfExists(request.DTECommitteeMasterID, request.CommitteeType, request.CommitteeName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.DTECommitteeMasterID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTECommitteeMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.DTECommitteeMasterID, "DTECommitteeMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.DTECommitteeMasterID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.CommitteeName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetDTECommitteeMasterList/{DTECommitteeMasterID}")]
        public async Task<OperationResult<List<DTECommitteeMasterDataModel>>> GetDTECommitteeMasterList(int DTECommitteeMasterID)
        {
            var result = new OperationResult<List<DTECommitteeMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.GetDTECommitteeMasterList(DTECommitteeMasterID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.GetDTECommitteeMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("DeleteCommitteeData/{DTECommitteeMasterID}")]
        public async Task<OperationResult<bool>> DeleteCommitteeData(int DTECommitteeMasterID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.DeleteCommitteeData(DTECommitteeMasterID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "DeleteCommitteeData", DTECommitteeMasterID, "DTECommitteeMaster");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error deleting data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMaster.DeleteCommitteeData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        #region "APPLICATION Committee"

        [HttpPost("SaveApplicationCommitteeData")]
        public async Task<OperationResult<bool>> SaveApplicationCommitteeData(PostApplicationCommitteeMemberdataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.SaveApplicationCommitteeData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTECommitteeMaster");
                    result.SuccessMessage = "Saved successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error adding data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.SaveApplicationCommitteeData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveApplicationCommitteeData_AH")]
        public async Task<OperationResult<bool>> SaveApplicationCommitteeData_AH(PostApplicationCommitteeMemberdataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.SaveApplicationCommitteeData_AH(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTECommitteeMaster");
                    result.SuccessMessage = "Saved successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error adding data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.SaveApplicationCommitteeData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveApplicationCommitteeData_Agri")]
        public async Task<OperationResult<bool>> SaveApplicationCommitteeData_Agri(PostApplicationCommitteeMemberdataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.SaveApplicationCommitteeData_Agri(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "DTECommitteeMaster");
                    result.SuccessMessage = "Saved successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error adding data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.SaveApplicationCommitteeData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("GetApplicationCommitteeList/{ApplyNocApplicationID}")]
        public async Task<OperationResult<List<ApplicationCommitteeMemberdataModel>>> GetApplicationCommitteeList(int ApplyNocApplicationID)
        {
            var result = new OperationResult<List<ApplicationCommitteeMemberdataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.GetApplicationCommitteeList(ApplyNocApplicationID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.GetApplicationDTECommitteeMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetApplicationCommitteeList_AH/{ApplyNocApplicationID}/{ActionType}")]
        public async Task<OperationResult<List<ApplicationCommitteeMemberdataModel>>> GetApplicationCommitteeList_AH(int ApplyNocApplicationID,string ActionType)
        {
            var result = new OperationResult<List<ApplicationCommitteeMemberdataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.GetApplicationCommitteeList_AH(ApplyNocApplicationID, ActionType));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.GetApplicationDTECommitteeMasterList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        #endregion


        [HttpGet("GetApplicationNodelOfficer/{ApplyNocApplicationID}")]
        public async Task<OperationResult<NodelOfficerDetails_DCE>> GetApplicationNodelOfficer(int ApplyNocApplicationID)
        {
            var result = new OperationResult<NodelOfficerDetails_DCE>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTECommitteeMasterUtility.GetApplicationNodelOfficer(ApplyNocApplicationID));
                result.State = OperationState.Success;
                if (result.Data!=null)
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
                CommonDataAccessHelper.Insert_ErrorLog("DTECommitteeMasterController.GetApplicationNodelOfficer", ex.ToString());
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

