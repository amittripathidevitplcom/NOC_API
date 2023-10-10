using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using RJ_NOC_API.AuthModels;
using RJ_NOC_DataAccess;
using System.Net;
using System.Text;



namespace RJ_NOC_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            var configuration = builder.Configuration;

            configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables();

            //session time out
            var sessionTimeOut = TimeSpan.FromMinutes(Convert.ToInt32(configuration["SiteKeys:Session-Time"] ?? "420"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddSession(x =>
            {
                x.IdleTimeout = sessionTimeOut;
            });



            /*validate*/
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebAPI",
                    Description = "Product WebAPI"
                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List <string> ()
                    }
                });
            });



            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    //x.LoginPath = "/user/userlogin";
                    x.ExpireTimeSpan = sessionTimeOut;
                }).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuer = configuration["SiteKeys:Jwt-Issuer"],
                        ValidAudience = configuration["SiteKeys:Jwt-Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SiteKeys:Jwt-Secret"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true
                    };
                });
            builder.Services.AddAuthorization();




            //builder.Services.AddCors(option => option.AddPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("http://172.22.33.75:80", "http://172.22.33.75:81", "http://172.22.33.75").AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            builder.Services.AddDirectoryBrowser();
            builder.Services.AddMvc();
            builder.Services.AddSystemWebAdapters();



            SiteKeys.Configure(configuration.GetSection("SiteKeys"));
            AppSetting.Configure(configuration.GetConnectionString("DefaultConnection"), configuration.GetSection("SiteKeys"));




            // ----------------------------pipeline
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                                Path.Combine(Directory.GetCurrentDirectory(), "ImageFile")),
                RequestPath = "/ImageFile"
            });
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //                    Path.Combine(Directory.GetCurrentDirectory(), "ExcelFile")),
            //    RequestPath = "/ExcelFile"
            //});
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                                Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF")),
                RequestPath = "/SystemGeneratedPDF"
            });
            //Enable directory browsing
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), "ImageFile")),
                RequestPath = "/ImageFile"
            }); 
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), "SystemGeneratedPDF")),
                RequestPath = "/SystemGeneratedPDF"
            });
            app.UseSession();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseCors("corsapp");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseSystemWebAdapters();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); //originally "./swagger/v1/swagger.json"
            });
            app.Run();
        }
    }
}