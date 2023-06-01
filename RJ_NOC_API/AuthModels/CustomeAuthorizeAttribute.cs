using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RJ_NOC_Model;
using System;

namespace RJ_NOC_API.AuthModels
{
    public class CustomeAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public CustomeAuthorizeAttribute()
        {

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionToken = $"Bearer {Convert.ToString(context.HttpContext.Session.GetString("jwttoken")) ?? ""}";
            var requestToken = Convert.ToString(context.HttpContext.Request.Headers["Authorization"]) ?? "";

            if (context.HttpContext.User == null || context.HttpContext.User.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new JsonResult(new RJ_NOC_Model.OperationResult<object>
                {
                    State = OperationState.Error,
                    ErrorMessage = "Invalid user credentials.!"
                });

            }
            else if (sessionToken != requestToken)
            {
                context.Result =
                    new JsonResult(new RJ_NOC_Model.OperationResult<object>
                    {
                        State = OperationState.Error,
                        ErrorMessage = "Token is not valid.!"
                    });

            }
        }
    }

}