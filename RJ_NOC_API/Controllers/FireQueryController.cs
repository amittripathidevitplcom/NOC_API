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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using RJ_NOC_DataAccess.Common;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
using SSOService;


namespace RJ_NOC_API.Controllers
{
    [Route("api/FireQuery")]
    [ApiController]
    public class FireQueryController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public FireQueryController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("DataFill")]
        public async Task<OperationResult<List<DataSet>>> DataFill(FireQueryDataModel fireQueryDataModel)
        {
            var result = new OperationResult<List<DataSet>>();
            try
            {
                if (fireQueryDataModel.UserID == "Unoc" && fireQueryDataModel.Password == "Unoc@1230")
                {
                    if (fireQueryDataModel.SqlQuery != "")
                    {

                        result.Data = await Task.Run(() => UtilityHelper.FireQueryUtility.DataFill(fireQueryDataModel));
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
                    else
                    {
                        result.State = OperationState.Warning;
                        result.SuccessMessage = "Sql Query field is required .!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "Please enter valid username or password.!";
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


        [HttpPost("DataExecuteNonQuery")]
        [HttpPost]
        public async Task<OperationResult<bool>> DataExecuteNonQuery(FireQueryDataModel fireQueryDataModel)
        {
            var result = new OperationResult<bool>();
            try
            {
                if (fireQueryDataModel.UserID == "Unoc" && fireQueryDataModel.Password == "Unoc@1230")
                {
                    if (fireQueryDataModel.SqlQuery != "")
                    {
                        result.Data = await Task.Run(() => UtilityHelper.FireQueryUtility.DataExecuteNonQuery(fireQueryDataModel));
                        if (result.Data)
                        {
                            result.State = OperationState.Success;
                            result.SuccessMessage = "Commands completed successfully .!";
                        }
                        else
                        {
                            result.State = OperationState.Error;
                            result.ErrorMessage = "There was an error updating data.!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Warning;
                        result.SuccessMessage = "Sql Query field is required .!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "Please enter valid username or password.!";
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

