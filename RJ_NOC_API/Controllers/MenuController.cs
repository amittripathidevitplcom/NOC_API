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
using Microsoft.AspNetCore.Authorization;
using RJ_NOC_API.AuthModels;

namespace RJ_NOC_API.Controllers
{
    [Route("api/Menu")]
    [ApiController]
    public class MenuController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public MenuController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<OperationResult<List<MenuDataModel_List>>> GetAllMenu()
        {
            var result = new OperationResult<List<MenuDataModel_List>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MenuUtility.GetAllMenu());
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
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

        // GET: api/Menu/5
        [HttpGet("{AccountID}")]
        public async Task<OperationResult<List<MenuDataModel>>> GetMenuIDWise(int AccountID)
        {
            var result = new OperationResult<List<MenuDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MenuUtility.GetMenuIDWise(AccountID));
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
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }



        // GET: api/Menu/5
        [HttpGet("GetUserWiseMenu/{UserID}")]
        public async Task<OperationResult<List<MenuDataModel_List>>> GetUserWiseMenu(int UserID)
        {
            var result = new OperationResult<List<MenuDataModel_List>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MenuUtility.GetUserWiseMenu(UserID));
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
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        // Post: api/Menu
        [HttpPost]
        public async Task<OperationResult<bool>> SaveData(MenuDataModel request)
        {
            var result = new OperationResult<bool>();

            //try
            //{
            //    bool IfExits = false;
            //    IfExits = UtilityHelper.MenuUtility.IfExists(request.MenuId, request.GroupName);
            //    if (IfExits == false)
            //    {
            //        if (request.MenuId == 0)
            //        {
            //            result.Data = await Task.Run(() => UtilityHelper.MenuUtility.SaveData(request));
            //        }
            //        else
            //        {
            //            result.Data = await Task.Run(() => UtilityHelper.MenuUtility.UpdateData(request));

            //        }
            //        if (result.Data)
            //        {
            //            result.State = OperationState.Success;
            //            if (request.MenuId == 0)
            //                result.SuccessMessage = "Saved successfully .!";
            //            else
            //                result.SuccessMessage = "Updated successfully .!";
            //        }
            //        else
            //        {
            //            result.State = OperationState.Error;
            //            if (request.MenuId == 0)
            //                result.ErrorMessage = "There was an error adding data.!";
            //            else
            //                result.ErrorMessage = "There was an error updating data.!";
            //        }
            //    }
            //    else
            //    {
            //        result.State = OperationState.Warning;
            //        result.ErrorMessage = request.GroupName + " is Already Exist, It Can't Not Be Duplicate.!";
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.State = OperationState.Error;
            //    result.ErrorMessage = e.Message.ToString();
            //}
            //finally
            //{
            //    //UnitOfWork.Dispose();
            //}
            return result;
        }


        // Put: api/Menu
        [HttpPut]
        public async Task<OperationResult<bool>> UpdateData(MenuDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MenuUtility.UpdateData(request));
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Updated successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "There was an error updating data.!";
                }
            }
            catch (Exception e)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }


        // Post: api/Menu/Delete/5
        [HttpPost("Delete/{AccountID}")]
        public async Task<OperationResult<bool>> DeleteData(int AccountID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.MenuUtility.DeleteData(AccountID));
                if (result.Data)
                {
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

