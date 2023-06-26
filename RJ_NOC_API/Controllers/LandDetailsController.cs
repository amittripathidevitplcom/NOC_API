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
    [Route("api/LandDetails")]
    [ApiController]

    public class LandDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public LandDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("GetAllLandDetails/{SelectedCollageID}/{LandDetailID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetLandDetailsList(int SelectedCollageID,int LandDetailID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetLandDetailsList", 0, "LandDetails");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandDetailsUtility.GetLandDetailsList(SelectedCollageID, LandDetailID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LandDetailsController.GetLandDetailsList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllLandDetailsIDWise/{LandDetailID}/{CollegeID}")]
        public async Task<OperationResult<List<LandDetailsDataModel>>> GetLandDetailsIDWise(int LandDetailID,int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", LandDetailID, "LandDetails");
            var result = new OperationResult<List<LandDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandDetailsUtility.GetLandDetailsIDWise(LandDetailID, CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LandDetailsController.GetLandDetailsIDWise", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(LandDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                //bool IfExits = false;
                //IfExits = UtilityHelper.LandDetailsUtility.IfExists(request.LandDetailID, request.LandAreaID, request.CollegeID);
                //if (IfExits == false)
                //{
                    result.Data = await Task.Run(() => UtilityHelper.LandDetailsUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.LandDetailID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Save", 0, "LandDetails");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(0, "Update", request.LandDetailID, "LandDetails");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.LandDetailID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                //}
                //else
                //{
                //    result.State = OperationState.Warning;
                //     result.ErrorMessage =  "Entry Already Exist, It Can't Not Be Duplicate.!";
                //    // result.ErrorMessage = request.QualificationName + " is Already Exist, It Can't Not Be Duplicate.!";
                //}
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LandDetails.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{LandDetailID}")]
        public async Task<OperationResult<bool>> DeleteData(int LandDetailID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LandDetailsUtility.DeleteData(LandDetailID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", LandDetailID, "LandDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("LandDetailsController.DeleteData", e.ToString());
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




