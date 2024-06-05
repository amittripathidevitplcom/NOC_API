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
using Azure.Core;

namespace RJ_NOC_API.Controllers
{
    [Route("api/SMSMail")]
    [ApiController]
    public class SMSMailController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public SMSMailController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("SendMessage/{MobileNo}/{MessageType}/{ID=0}")]
        public async Task<OperationResult<string>> SendMessage(string MobileNo,string MessageType,int ID=0)
        {
            var result = new OperationResult<string>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SMSMailUtility.SendMessage(MobileNo, MessageType,ID));

                result.State = OperationState.Success;
                if (result.Data!=null)
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
                CommonDataAccessHelper.Insert_ErrorLog("SMSMailController.SendOTP", ex.ToString());
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