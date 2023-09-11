using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;

namespace RJ_NOC_API.Controllers
{
    [Route("api/LegalEntity")]
    [ApiController]
    public class LegalEntityController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public LegalEntityController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(LegalEntityModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LegalEntity.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.LegalEntityID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.LegalEntityID, "Save", 0, "LegalEntity");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.LegalEntityID, "Update", request.LegalEntityID, "LegalEntity");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.LegalEntityID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LegalEntityController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("CheckDuplicate")]
        public async Task<OperationResult<bool>> CheckDuplicate(LegalEntityDuplicateCheckDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = await Task.Run(() => UtilityHelper.LegalEntity.IfExists(request.LegalEntityID, request.RegistrationNo,request.AadhaarNo));
                if (IfExits == false)
                {
                    result.State = OperationState.Success;
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.RegistrationNo +" or "+request.AadhaarNo+ " is Already Exist, It Can't Not Be Duplicate.!";
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LegalEntityController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetLegalEntityList/{UserID}/{SSOID}")]
        public async Task<OperationResult<List<LegalEntityListModel>>> GetLegalEntityList(int UserID,string SSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "LegalEntity");
            var result = new OperationResult<List<LegalEntityListModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LegalEntity.GetLegalEntityList(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LegalEntityController.GetLegalEntityList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("ViewlegalEntityDataByID/{LegalEntityID}/{UserID}/{SSOID}")]
        public async Task<OperationResult<List<LegalEntityListModel>>> ViewlegalEntityDataByID(int LegalEntityID,int UserID,string SSOID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", LegalEntityID, "LegalEntity");
            var result = new OperationResult<List<LegalEntityListModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LegalEntity.ViewlegalEntityDataByID(LegalEntityID, SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LegalEntityController.ViewlegalEntityDataByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetLegalEntityBySSOID/{SSOID}/{UserID}")]
        public async Task<OperationResult<List<LegalEntityListModel>>> GetLegalEntityBySSOID(string SSOID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "LegalEntity");
            var result = new OperationResult<List<LegalEntityListModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LegalEntity.GetLegalEntityBySSOID(SSOID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LegalEntityController.GetLegalEntityBySSOID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("CheckExistsLegalEntity")]
        public async Task<OperationResult<bool>> CheckExistsLegalEntity(LegalEntitySSODuplicateCheckDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = await Task.Run(() => UtilityHelper.LegalEntity.CheckExistsLegalEntity(request.SSOID, request.RoleID));
                if (IfExits == false)
                {
                    result.State = OperationState.Success;
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.SSOID + " is Already Exist, It Can't Not Be Duplicate.!";
                }

            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LegalEntityController.CheckExistsLegalEntity", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
    }
}
