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

namespace RJ_NOC_API.Controllers
{
    [Route("api/DocumentMaster")]
    [ApiController]
    public class DocumentMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DocumentMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<OperationResult<bool>> SaveData(DocumentMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.DocumentMasterUtility.IfExists(request.DocumentMasterID, request.DocumentName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DocumentMasterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.DocumentMasterID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.DocumentMasterID, "DocumentMaster");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.DocumentMasterID, "DocumentMaster");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.DocumentMasterID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.DocumentName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DocumentMaster.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllDocument/{UserID}/{DepartmentID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllDocument(int UserID,int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "DocumentMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DocumentMasterUtility.GetAllDocument(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DocumentMasterController.GetAllDocument", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{DocumentMasterID}/{UserID}")]
        public async Task<OperationResult<List<DocumentMasterDataModel>>> GetDocumentMasterIDWise(int DocumentMasterID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", DocumentMasterID, "DocumentMaster");
            var result = new OperationResult<List<DocumentMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DocumentMasterUtility.GetDocumentMasterIDWise(DocumentMasterID));
                if (result.Data.Count > 0)
                {

                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DocumentMasterController.GetDocumentMasterIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{DocumentMasterID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int DocumentMasterID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DocumentMasterUtility.DeleteData(DocumentMasterID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", DocumentMasterID, "DocumentMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("DocumentMasterController.DeleteData", e.ToString());
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
