using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_Model;

namespace RJ_NOC_API.Controllers
{
    [Route("api/ClassWiseStudentDetails")]
    [ApiController]
    public class ClassWiseStudentDetailsController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public ClassWiseStudentDetailsController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("GetCollegeWiseStudenetDetails/{collegeId}/{ApplyNOCID}")]
        public async Task<OperationResult<List<ClassWiseStudentDetailsDataModel>>> GetCollegeWiseStudenetDetails(int collegeId,int ApplyNOCID)
        {
            var result = new OperationResult<List<ClassWiseStudentDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClassWiseStudentDetailsUtility.GetCollegeWiseStudenetDetails(collegeId, ApplyNOCID));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("ClassWiseStudentDetailsController.GetCollegeWiseStudenetDetails", ex.ToString());
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
        public async Task<OperationResult<bool>> SaveData(PostClassWiseStudentDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClassWiseStudentDetailsUtility.SaveData(request));
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





        [HttpGet("GetSubjectWiseStudenetDetails/{collegeId}/{ApplyNOCID}")]
        public async Task<OperationResult<List<SubjectWiseStatisticsDetailsDataModel>>> GetSubjectWiseStudenetDetails(int collegeId,int ApplyNOCID)
        {
            var result = new OperationResult<List<SubjectWiseStatisticsDetailsDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClassWiseStudentDetailsUtility.GetSubjectWiseStudenetDetails(collegeId, ApplyNOCID));
                result.State = OperationState.Success;
                if (result.Data != null)
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
                CommonDataAccessHelper.Insert_ErrorLog("ClassWiseStudentDetailsController.GetCollegeWiseStudenetDetails", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("SaveDataSubjectWise")]
        public async Task<OperationResult<bool>> SaveDataSubjectWise(PostSubjectWiseStatisticsDetailsDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ClassWiseStudentDetailsUtility.SaveDataSubjectWise(request));
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
                CommonDataAccessHelper.Insert_ErrorLog("ClassWiseStudentDetailsController.SaveDataSubjectWise", e.ToString());
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
