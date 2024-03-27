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
using RJ_NOC_API.AuthModels;

namespace RJ_NOC_API.Controllers
{
    [Route("api/DTEStatistics_Staff")]
    [ApiController]
    public class DTEStatistics_StaffController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public DTEStatistics_StaffController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("TeachingStaff/{CollegeID}/{EntryType}")]
        public async Task<OperationResult<List<DTEStatistics_StaffDataModels>>> TeachingStaff(int CollegeID, string EntryType)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(CollegeID, "GetAllData", 0, "TeachingStaff");
            var result = new OperationResult<List<DTEStatistics_StaffDataModels>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_StaffUtility.TeachingStaff(CollegeID, EntryType));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_StaffController.TeachingStaff", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("NonTeaching/{CollegID}/{UserID}/{EntryType}")]
        public async Task<OperationResult<DTEStatistics_NonTeachingDataModel>> NonTeaching_GetByID(int CollegID, int UserID, string EntryType)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", CollegID, "DTEStatistics_ExaminationResults");
            var result = new OperationResult<DTEStatistics_NonTeachingDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_StaffUtility.NonTeaching_GetByID(CollegID, UserID, EntryType));
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_Staff.GetByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("NonTeaching")]
        public async Task<OperationResult<bool>> SaveData(DTEStatistics_NonTeachingDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DTEStatistics_StaffUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;

                    CommonDataAccessHelper.Insert_TrnUserLog(request.ModifyBy, "Save", request.EntryID, "DTEStatistics_ExaminationResults");
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
                CommonDataAccessHelper.Insert_ErrorLog("DTEStatistics_Staff.SaveData", e.ToString());
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
