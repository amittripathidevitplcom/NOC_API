using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/FarmLandDetails")]
    [ApiController]
    public class FarmLandDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public FarmLandDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(FarmLandDetailsModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FarmLandDetailsUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.FarmLandDetailID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.FarmLandDetailID, "Save", 0, "FarmLandDetails");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.FarmLandDetailID, "Update", request.FarmLandDetailID, "FarmLandDetails");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.FarmLandDetailID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("FarmLandDetailsController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllFarmLandDetalsListByCollegeID/{CollegeID}/{ApplyNOCID}")]
        public async Task<OperationResult<List<FarmLandDetailsListModel>>> GetAllFarmLandDetalsListByCollegeID(int CollegeID,int ApplyNOCID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(CollegeID, "GetAllData", 0, " FarmLandDetails");
            var result = new OperationResult<List<FarmLandDetailsListModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FarmLandDetailsUtility.GetFarmLandDetailsList(CollegeID, ApplyNOCID));
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
                CommonDataAccessHelper.Insert_ErrorLog("FarmLandDetailsController.GetAllFarmLandDetalsListByCollegeID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetFarmLandDetalsByID/{FarmLandDetailsID}")]
        public async Task<OperationResult<FarmLandDetailsModel>> GetFarmLandDetalsByID(int FarmLandDetailsID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", FarmLandDetailsID, " FarmLandDetails");
            var result = new OperationResult<FarmLandDetailsModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FarmLandDetailsUtility.ViewFarmLandDetailsListByID(FarmLandDetailsID));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("FarmLandDetailsController.GetFarmLandDetalsByID", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{FarmLandDetailsID}")]
        public async Task<OperationResult<bool>> DeleteData(int FarmLandDetailsID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.FarmLandDetailsUtility.DeleteData(FarmLandDetailsID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", FarmLandDetailsID, "FarmLandDetails");
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
                CommonDataAccessHelper.Insert_ErrorLog("FarmLandDetailsController.DeleteData", e.ToString());
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
