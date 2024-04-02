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
    [Route("api/DTEStatistics_FinancialDetails")]
    [ApiController]

    public class DTEStatistics_FinancialDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DTEStatistics_FinancialDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{RoleID}/{UserID}/{EntryType}")]
        public async Task<OperationResult<DTEStatistics_FinancialDetailsDataModel>> GetByID(int RoleID, int UserID, string EntryType)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", RoleID, "DTEStatistics_FinancialDetails");
            var result = new OperationResult<DTEStatistics_FinancialDetailsDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_FinancialDetailsUtility.GetByID(RoleID, EntryType));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_FinancialDetails.GetByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(DTEStatistics_FinancialDetailsDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_FinancialDetailsUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;

                    CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", request.EntryID, "DTEStatistics_FinancialDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_FinancialDetails.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpGet("FinancialDetailsItem/{CollegeID}")]
        public async Task<OperationResult<DTEStatistics_FinancialDetailsDataModel>> FinancialDetailsItem(int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(CollegeID, "FetchData_IDWise", CollegeID, "FinancialDetailsItem");
            var result = new OperationResult<DTEStatistics_FinancialDetailsDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_FinancialDetailsUtility.FinancialDetailsItem(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_FinancialDetails.FinancialDetailsItem", ex.ToString());
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


