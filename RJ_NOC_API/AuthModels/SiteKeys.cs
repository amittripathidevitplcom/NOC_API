namespace RJ_NOC_API.AuthModels
{
    public static class SiteKeys
    {
        private static IConfigurationSection _configurationSection;
        public static void Configure(IConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
        }

        public static string JWTIssuer => _configurationSection["Jwt-Issuer"];
        public static string JWTAudience => _configurationSection["Jwt-Audience"];
        public static string JWTSecret => _configurationSection["Jwt-Secret"];
        public static int SessionTime => Convert.ToInt32(_configurationSection["Session-Time"] ?? "30");
    }
}
