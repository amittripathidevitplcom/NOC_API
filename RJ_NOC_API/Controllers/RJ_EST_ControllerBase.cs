using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Utility;
using RJ_NOC_API.AuthModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using RJ_NOC_Model;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RJ_NOC_API.Controllers
{
    public class RJ_NOC_ControllerBase : ControllerBase
    {
        protected IUtilityHelper UtilityHelper;
        private IConfiguration _configuration;
        public RJ_NOC_ControllerBase(IConfiguration configuration)
        {
            _configuration = configuration;
            UtilityHelper = new UtilityHelper(configuration);
        }

        public CustomPrincipal CustomPrincipal => new CustomPrincipal(HttpContext.User);

        protected async Task<string> CreateAuthentication(UserMasterDataModel model)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid,Convert.ToString(model.UserID)),
                    new Claim(ClaimTypes.GivenName,model.UserName)
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                , new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties());

            return GenrateJwtToken(claims);
        }

        protected async Task RemoveAuthentication()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        protected string GenrateJwtToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SiteKeys.JWTSecret));

            var token = new JwtSecurityToken(
                issuer: SiteKeys.JWTIssuer,
                audience: SiteKeys.JWTAudience,
                expires: DateTime.Now.AddMinutes(SiteKeys.SessionTime),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //protected async Task<string> CreateGeoTaggingAuthentication(GeoTaggingDataModels model)
        //{
        //    var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.PrimarySid,Convert.ToString(model.UserID)),
        //            new Claim(ClaimTypes.GivenName,model.UserName)
        //        };

        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
        //        , new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties());

        //    return GenrateJwtToken(claims);
        //}
    }
}
