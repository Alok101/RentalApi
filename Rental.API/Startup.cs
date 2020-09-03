using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Rental.API.Business.Interface;
using Rental.API.Business.Model;
using Rental.API.Extensions;
using Rental.API.Infrastructures;
using System;
using System.Linq;
using System.Text;
namespace Rental.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            });
            // services.AddControllers().AddNewtonsoftJson();
            services.AddCustomDbContext(Configuration);
            // services.AddTokenAuthentication(Configuration);

        }

        private IInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                              .AddLogging()
                              .AddMvc()
                              .AddNewtonsoftJson()
                              .Services.BuildServiceProvider();

            return builder
                              .GetRequiredService<IOptions<MvcOptions>>()
                              .Value
                              .InputFormatters
                              .OfType<NewtonsoftJsonPatchInputFormatter>()
                              .First();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Api Response MiddleWare
            app.UseApiResponseAndExceptionWrapper();
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<RentalDbContext>
            (
            options => options.UseSqlServer(configuration.GetConnectionString("RentalDBConnection"))
            );
            return services;
        }
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("Token").GetSection("Issuer").Value,
                    ValidAudience = configuration.GetSection("Token").GetSection("Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Token").GetSection("SecretKey").Value))
                };
            });
            return services;
        }



    }


}
