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
    [Route("api/DTEStatistics_OfficersDetails")]
    [ApiController]

    public class DTEStatistics_OfficersDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DTEStatistics_OfficersDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{RoleID}/{UserID}")]
        public async Task<OperationResult<DTEStatistics_OfficersDetailsDataModel>> GetByID(int RoleID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", RoleID, "DTEStatistics_OfficersDetails");
            var result = new OperationResult<DTEStatistics_OfficersDetailsDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_OfficersDetailsUtility.GetByID(RoleID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_OfficersDetails.GetByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(DTEStatistics_OfficersDetailsDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_OfficersDetailsUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;

                    CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", request.EntryID, "DTEStatistics_OfficersDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_OfficersDetails.SaveData", e.ToString());
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


