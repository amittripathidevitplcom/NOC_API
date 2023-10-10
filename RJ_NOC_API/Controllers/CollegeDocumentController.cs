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
using Microsoft.AspNetCore.Http.HttpResults;

namespace RJ_NOC_API.Controllers
{
    //[Authorize]
    // [CustomeAuthorize]
    [Route("api/CollegeDocument")]
    [ApiController]
    public class CollegeDocumentController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public CollegeDocumentController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{DepartmentID}/{CollegeID}/{Type}/{ApplyNOCID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetAllData(int DepartmentID, int CollegeID, string Type, int ApplyNOCID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(CollegeID, "GetAllData", 0, "CollegeDocument");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeDocumentUtility.GetAllData(DepartmentID, CollegeID, Type, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeDocumentController.GetAllCourse", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpPost]
        public async Task<OperationResult<bool>> SaveData(CollegeDocumentDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeDocumentUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(request.CollegeID, "Save", 0, "CollegeDocument");
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
                CommonDataAccessHelper.Insert_ErrorLog("CollegeDocumentController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("Delete/{AID}")]
        public async Task<OperationResult<bool>> Delete(int AID)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CollegeDocumentUtility.Delete(AID));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    CommonDataAccessHelper.Insert_TrnUserLog(AID, "Delete", 0, "CollegeDocument");
                    result.SuccessMessage = "Saved successfully .!";

                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error deleting data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CollegeDocumentController.Delete", e.ToString());
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

