using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using System.Data;

namespace RJ_NOC_API.Controllers
{

    [Route("api/DCEStaffReports")]
    [ApiController]
    public class DCEStaffReportsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;

        public DCEStaffReportsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("DCEStaffDetailsList")]
        public async Task<OperationResult<List<DCEStaffReportsDataModel_list>>> DCEStaffDetailsList(DCEStaffReportsDataModel request)
        {
            var result = new OperationResult<List<DCEStaffReportsDataModel_list>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DCEStaffReportsUtility.DCEStaffDetailsList(request));
                if (result.Data.Count > 0)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "DCEStaffDetailsList", 0, "DCEStaffReportsController");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error in DCENOCReportData";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DCEStaffReportsController.DCEStaffDetailsList", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetSubjectList")]
        public async Task<OperationResult<List<DCEStaffReports_SubjectList>>> GetSubjectList()
        {
            var result = new OperationResult<List<DCEStaffReports_SubjectList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DCEStaffReportsUtility.GetSubjectList());
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
                CommonDataAccessHelper.Insert_ErrorLog("DCEStaffReportsController.GetSubjectList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        [HttpGet("GetStaffDuplicateAdharList/{DepartmentID}")]
        public async Task<OperationResult<List<DCEStaffReports_SubjectList>>> GetStaffDuplicateAdharList(int DepartmentID)
        {
            var result = new OperationResult<List<DCEStaffReports_SubjectList>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DCEStaffReportsUtility.GetStaffDuplicateAdharList(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DCEStaffReportsController.GetStaffDuplicateAdharList", ex.ToString());
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


