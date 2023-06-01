using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace RJ_NOC_API.AuthModels
{
    public class CustomPrincipal : IPrincipal
    {
        [JsonIgnore]
        public IIdentity? Identity { get; private set; }

        public bool IsInRole(string roleName)
        {
            return RoleNames == roleName;
        }

        public bool IsAuthenticated { get; private set; }
        public int UserID { get; set; }
        public string UserName { get; private set; }
        public string Email { get; set; }
        public string RoleIDs { get; set; }
        public string RoleNames { get; set; }

        private readonly ClaimsPrincipal _claimsPrincipal;

        public CustomPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;

            SetCustomPrincipal(_claimsPrincipal);
        }

        private void SetCustomPrincipal(ClaimsPrincipal customPrincipal)
        {
            if (_claimsPrincipal.Identity != null)
            {
                IsAuthenticated = _claimsPrincipal.Identity.IsAuthenticated;

                if (IsAuthenticated)
                {
                    UserID = Convert.ToInt32(_claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value);

                    Identity = new GenericIdentity(_claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value);
                    UserName = _claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;

                }
            }
        }
    }
}
