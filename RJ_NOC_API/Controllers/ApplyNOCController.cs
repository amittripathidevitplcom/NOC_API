using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ApplyNOC")]
    [ApiController]
    public class ApplyNOCController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ApplyNOCController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetApplyNOCApplicationListByRole/{RoleID}")]
        public async Task<OperationResult<List<ApplyNOCDataModel>>> GetApplyNOCApplicationListByRole(int RoleID)
        {
            var result = new OperationResult<List<ApplyNOCDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetApplyNOCApplicationListByRole(RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetApplyNOCApplicationListByRole", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("DocumentScrutiny/{ApplyNOCID}/{RoleID}/{UserID}/{ActionType}/{DepartmentID}")]
        public async Task<OperationResult<bool>> DocumentScrutiny(int ApplyNOCID, int RoleID, int UserID, string ActionType,int DepartmentID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.DocumentScrutiny(ApplyNOCID,RoleID, UserID,ActionType, DepartmentID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "DocumentScrutiny", ApplyNOCID, "ApplyNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = ActionType+" successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.DocumentScrutiny", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost("SaveDocumentScrutiny")]
        public async Task<OperationResult<bool>> SaveDocumentScrutiny(DocumentScrutinyDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.SaveDocumentScrutiny(request));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(request.DocumentScrutinyID, "DocumentScrutiny_Temp", 0, "ApplyNOC");
                    result.State = OperationState.Success;
                    result.SuccessMessage = request.ActionType + " successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error revert application";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.DocumentScrutiny_Temp", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetDocumentScrutinyData_TabNameCollegeWise/{TabName}/{CollegeID}/{RoleID}")]
        public async Task<OperationResult<List<DocumentScrutinyDataModel>>> GetDocumentScrutinyData_TabNameCollegeWise(string TabName,int CollegeID,int RoleID)
        {
            var result = new OperationResult<List<DocumentScrutinyDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ApplyNOCUtility.GetDocumentScrutinyData_TabNameCollegeWise(TabName,CollegeID, RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ApplyNOCController.GetDocumentScrutinyData_TabNameCollegeWise", ex.ToString());
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
