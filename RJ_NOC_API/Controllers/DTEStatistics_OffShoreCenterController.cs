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
    [Route("api/DTEStatistics_OffShoreCenter")]
    [ApiController]

    public class DTEStatistics_OffShoreCenterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DTEStatistics_OffShoreCenterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{RoleID}/{UserID}")]
        public async Task<OperationResult<DTEStatistics_OffShoreCenterDataModel>> GetByID(int RoleID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", RoleID, "DTEStatistics_OffShoreCenter");
            var result = new OperationResult<DTEStatistics_OffShoreCenterDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_OffShoreCenterUtility.GetByID(RoleID));
                if (result != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_OffShoreCenter.GetByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(DTEStatistics_OffShoreCenterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_OffShoreCenterUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;

                    CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", request.EntryID, "DTEStatistics_OffShoreCenter");
                    result.SuccessMessage = "Saved successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_OffShoreCenter.SaveData", e.ToString());
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


