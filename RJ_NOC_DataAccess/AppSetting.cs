using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess
{
    public class AppSetting
    {

        private static IConfigurationSection _configurationSection;
        private static string _connectionString;
        public static void Configure(string connectionString ,IConfigurationSection configurationSection)
        {
            _connectionString = connectionString;
            _configurationSection = configurationSection;
        }
         
        public static string ConnectionString => _connectionString;


        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
           .Build();
            var str = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            Console.WriteLine(str);
            return str;
        }

    }


}
