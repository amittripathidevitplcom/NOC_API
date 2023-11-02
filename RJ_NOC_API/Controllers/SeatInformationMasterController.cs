using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace RJ_NOC_API.Controllers
{
    [Route("api/SeatInformationMaster")]
    [ApiController]
    public class SeatInformationMasterController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public SeatInformationMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("{UserID}")]
        public async Task<OperationResult<List<CommonDataModel_DataTable>>> GetSeatInformationList(int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetSeatInformationList", 0, "SeatInformationMaster");
            var result = new OperationResult<List<CommonDataModel_DataTable>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SeatInformationMasterUtility.GetSeatInformationList());
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
                CommonDataAccessHelper.Insert_ErrorLog("SeatInformationMasterController.GetSeatInformationList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("{ID}/{UserID}")]
        public async Task<OperationResult<List<SeatInformationMasterDataModel>>> GetSeatByID(int ID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetSeatByID", ID, "SeatInformationMaster");
            var result = new OperationResult<List<SeatInformationMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SeatInformationMasterUtility.GetSeatByID(ID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SeatInformationMasterController.GetSeatByID", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(SeatInformationMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExits = false;
                IfExits = UtilityHelper.SeatInformationMasterUtility.IfExists(request.ID, request.DepartmentID,request.CourseID);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.SeatInformationMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.ID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Save", request.ID, "SeatInformationMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.UserID, "Update", request.ID, "SeatInformationMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.ID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "Given Seat is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("SeatInformationMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{ID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int ID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SeatInformationMasterUtility.DeleteData(ID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", ID, "SeatInformationMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("SeatInformationMasterController.DeleteData", e.ToString());
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
