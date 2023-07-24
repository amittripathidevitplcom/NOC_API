using Microsoft.AspNetCore.Mvc;
using System.Data;
using RJ_NOC_Model;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess.Common;
using Microsoft.AspNetCore.Http;
using static RJ_NOC_Model.BuildingDetailsDataModel;

namespace RJ_NOC_API.Controllers
{
    [Route("api/VeterinaryHospital")]
    [ApiController]
    public class VeterinaryHospitalController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public VeterinaryHospitalController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetAnimalMasterList")]
        public async Task<OperationResult<List<AnimalDataModel_AnimalList>>> GetAnimalMasterList()
        {
            var result = new OperationResult<List<AnimalDataModel_AnimalList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.VeterinaryHospitalUtility.GetAnimalMasterList());
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
                CommonDataAccessHelper.Insert_ErrorLog("VeterinaryHospitalController.GetAnimalMasterList", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(VeterinaryHospitalDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.VeterinaryHospitalUtility.SaveData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    if (request.VeterinaryHospitalID == 0)
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.VeterinaryHospitalID, "Save", 0, "VeterinaryHospital");
                        result.SuccessMessage = "Saved successfully .!";
                    }
                    else
                    {
                        CommonDataAccessHelper.Insert_TrnUserLog(request.VeterinaryHospitalID, "Update", request.VeterinaryHospitalID, "VeterinaryHospital");
                        result.SuccessMessage = "Updated successfully .!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    if (request.VeterinaryHospitalID == 0)
                        result.ErrorMessage = "There was an error adding data.!";
                    else
                        result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("VeterinaryHospitalController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpGet("GetAllVeterinaryHospitalList/{UserID}/{CollegeID}")]
        public async Task<OperationResult<List<VeterinaryHospitalDataModelList>>> GetAllVeterinaryHospitalList(int UserID, int CollegeID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "GetAllData", 0, "VeterinaryHospital");
            var result = new OperationResult<List<VeterinaryHospitalDataModelList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.VeterinaryHospitalUtility.GetAllVeterinaryHospitalList(CollegeID));
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
                CommonDataAccessHelper.Insert_ErrorLog("VeterinaryHospitalController.GetAllVeterinaryHospitalList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
        [HttpGet("GetVeterinaryHospitalByIDWise/{VeterinaryHospitalID}/{UserID}")]
        public async Task<OperationResult<VeterinaryHospitalDataModel>> GetVeterinaryHospitalByIDWise(int VeterinaryHospitalID, int UserID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(UserID, "FetchData_IDWise", VeterinaryHospitalID, "VeterinaryHospital");
            
            var result = new OperationResult<VeterinaryHospitalDataModel>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.VeterinaryHospitalUtility.GetVeterinaryHospitalByIDWise(VeterinaryHospitalID));
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
                CommonDataAccessHelper.Insert_ErrorLog("VeterinaryHospitalController.GetVeterinaryHospitalByIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("Delete/{VeterinaryHospitalID}/{UserID}")]
        public async Task<OperationResult<bool>> DeleteData(int VeterinaryHospitalID, int UserID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.VeterinaryHospitalUtility.DeleteData(VeterinaryHospitalID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(UserID, "Delete", VeterinaryHospitalID, "VeterinaryHospital");
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
                CommonDataAccessHelper.Insert_ErrorLog("VeterinaryHospitalController.DeleteData", e.ToString());
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
